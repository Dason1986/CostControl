using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Helper;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using SqlSugar;
using System;
using System.IO;
using System.Linq;

namespace CostControlWebApplication.Services
{
    public class ProjectProcurementService : BaseService
    {
        private readonly ProjectRepository repository;
        private readonly FileStorageServie fileStorageServie;

        public ProjectProcurementService(ProjectRepository repository, FileStorageServie fileStorageServie, IBoundedContext bounded, IStaffeUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.fileStorageServie = fileStorageServie;
        }
        public IPagingList<VIProjectProcurement> GetProcurements(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectProcurement> specification = this.GetSpecification<VIProjectProcurement>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }

        public void Submit(long procurementID)
        {
            var entity = repository.GetProcurement(procurementID);
            if (entity == null) throw new LogicException("提交編號不存在");

            if (entity.State != ProcurementState.Save) throw new LogicException("当前状态不能提交！");

            var files = repository.GetProcurementFiles(procurementID);
            if (files.IsEmpty()) throw new LogicException("審批文件爲空");
            var items = repository.GetProcurementBQItems(procurementID);
            if (items.IsEmpty() && entity.ProcurementType != ProcurementType.Paid) throw new LogicException("BQ明細爲空");
            var calculation = repository.GetCalculation(entity.ProjectId);
            entity.State = ProcurementState.Submit;
            repository.UpdateProcurement(entity);

            switch (entity.ProcurementType)
            {

                case ProcurementType.Materials:
                    {
                        calculation.MaterialCost += entity.ThisProcurementAmount;
                        break;
                    }
                case ProcurementType.Outsourcing:
                    {
                        var calculationItem = new ProjectCalculationDetail()
                        {
                            ProcurementId = procurementID,
                            ProjectId = entity.ProjectId,
                            ContractAmount = entity.ItemAmount,
                            ProcurementAmount = entity.ProcurementAmount,
                            EstimateCost = entity.OtherAmount,
                            Remark = entity.Remark,
                            GrossMargin = entity.ProfitsRate
                        };
                        calculationItem.Created(this);

                        repository.AddCalculationDetail(calculationItem);
                        //   if (entity.TotalPurchaseAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");
                        break;
                    }
                case ProcurementType.Other:
                    {
                        calculation.MangerCost += entity.ThisProcurementAmount;
                        break;
                    }

                case ProcurementType.Paid:
                    {

                        calculation.MangerCost += entity.PaidAmount;
                        //  if (entity.TotalPurchaseAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");
                        break;
                    }
                default:
                    break;
            }
            repository.UnitOfWork.Commit();
        }
        public void AddOrEdit(ProjectProcurementDto dto)
        {
            ProjectProcurement entity = null;
            if (dto.ID == 0)
            {
                entity = new ProjectProcurement();
                dto.ProjectedAs(entity);
                entity.Created(this);
                repository.AddProcurement(entity);
            }
            else
            {
                entity = repository.GetProcurement(dto.ID);
                if (entity == null) throw new BingoX.LogicException("編號不存在");
                dto.ProjectedAs(entity);
                repository.UpdateProcurement(entity);
            }
            var project = repository.GetProjectMaster(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("项目不存在");
            var ProcurementAmount = dto.Items.Sum(n => n.ProcurementAmount);//採購金額
            var BidAmount = dto.Items.Sum(n => n.BidAmount);//中標總計
            var ProcurementEndAmount = dto.Items.Sum(n => n.ProcurementEndAmount);//已採購金額
            var ProcurementEndTotalAmount = dto.Items.Sum(n => n.ProcurementEndTotalAmount);//總採購金額
            var OtherTotal = dto.Items.Sum(n => n.Total);//其他暫估 總計
            entity.OtherAmount = OtherTotal;
            entity.ItemAmount = BidAmount;
            entity.ProfitsRate = 1 - (ProcurementAmount + OtherTotal) / BidAmount;
            entity.ThisProcurementAmount = ProcurementAmount;
            switch (entity.ProcurementType)
            {

                case ProcurementType.Materials:
                    {
                        if (string.IsNullOrEmpty(entity.MaterialUsage)) throw new BingoX.LogicException("材料用途 为空");
                        // if (entity.AllProcurementAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");

                        entity.BeenProcurementAmount = ProcurementEndAmount;
                        entity.AllProcurementAmount = ProcurementAmount + ProcurementEndAmount;
                        break;
                    }
                case ProcurementType.Outsourcing:
                    {

                        //   if (entity.TotalPurchaseAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");
                        break;
                    }
                case ProcurementType.Other:
                    {

                        // if (entity.TotalPurchaseAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");
                        break;
                    }
                case ProcurementType.Paid:
                    {
                        //  if (entity.TotalPurchaseAmount <= 0) throw new BingoX.LogicException("總採購金額 不爲正數");
                        break;
                    }
                default:
                    break;
            }
            if (dto.AddFiles.HasAny())
            {
                var files = repository.GetFiles(dto.AddFiles);

                foreach (var item in files)
                {
                    item.FileType = ProjectFileType.Procurement;
                    item.ProjectId = dto.ProjectId;
                    item.ForeignID = entity.ID;
                    var path = Path.Combine("project", project.Code, item.FileType.GetHashCode().ToString(), Bounded.Generator.New() + item.FileName);

                    fileStorageServie.Move(item.StoragePath, path);
                    repository.Update(item);
                }
            }

            entity.State = ProcurementState.Save;
            var items = dto.Items.Where(n => n.Id == 0).Select(n =>
              {
                  var en = n.ProjectedAs<ProcurementBQItem>();
                  en.ProcurementId = entity.ID;
                  en.ProjectId = entity.ProjectId;
                  en.ProcurementType = entity.ProcurementType;
                  en.Created(this);
                  return en;
              }).ToList();


            repository.AddBQItems(items);

            repository.UnitOfWork.Commit();
        }



        public ProjectProcurementDto GetProcurement(long id)
        {
            var entity = repository.GetProcurement(id);
            if (entity == null) return null;
            var dto = entity.ProjectedAs<ProjectProcurementDto>();
            if (dto == null) return dto;
            dto.Files = repository.GetProcurementFiles(id).ProjectedAsCollection<ProjectAboutFileDto>();
            dto.Items = repository.GetProcurementBQItems(id).ProjectedAsCollection<ProcurementBQItemDto>();
            return dto;
        }
    }


}
