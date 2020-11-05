using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Linq;

namespace CostControlWebApplication.Services
{
    public class ProjectMasterService : BaseService
    {


        public ProjectMasterService(ProjectRepository repository, ISerialNumberProvider serialNumberProvider, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.serialNumberProvider = serialNumberProvider;

        }
        private readonly ProjectRepository repository;
        private readonly ISerialNumberProvider serialNumberProvider;
        public IPagingList<VIProjectMaster> GetProjects(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectMaster> specification = EntityHelper.GetSpecification<VIProjectMaster>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }
        public void Add(ProjectMasterDto dto, BingoX.ComponentModel.Compress.CompressEntry fileentry)
        {
            ProjectMaster entity = dto.ProjectedAs<ProjectMaster>();
            if (entity.CompanyId <= 0) throw new LogicException("公司爲空");
            Supplier supplier = repository.GetSupplier(entity.CompanyId);
            if (supplier == null) throw new LogicException("選擇的公司無效");
            if (!supplier.IsCompany || string.IsNullOrEmpty(supplier.Code)) throw new LogicException("選擇的公司無效");
            if (string.IsNullOrEmpty(entity.Name)) throw new LogicException("項目名稱不能爲空");
            if (string.IsNullOrEmpty(entity.Address)) throw new LogicException("項目地址不能爲空");
            if (entity.ContractAmount <= 0) throw new LogicException("合同金額不能小於等於0");
            if (entity.ContractorsId <= 0) throw new LogicException("承建商爲空");
            if (entity.ProjectMainId <= 0) throw new LogicException("項目主體爲空");
            if (entity.ManagerId <= 0) throw new LogicException("項目經理爲空");
            if (entity.BeginDate.HasValue && entity.EndDate.HasValue && entity.EndDate < entity.BeginDate) throw new LogicException("實際開始日期不能大於實際結束日期");


            if (entity.EstimatedBeginDate.HasValue && entity.EstimatedEndDate.HasValue && entity.EstimatedEndDate < entity.EstimatedBeginDate) throw new LogicException("評估開始日期不能大於評估結束日期");

            entity.Code = serialNumberProvider.Dequeue(supplier);
            if (  string.IsNullOrEmpty(entity.Code)) throw new LogicException("生成項目編號失敗");

            entity.State = CommonState.Enabled;


            entity.Created(this);
            var standingbook = new ProjectStandingbook();
            standingbook.ProjectId = entity.ID;
            standingbook.Created(this);

            var targetCost = new ProjectTargetCost();
            targetCost.ProjectId = entity.ID;
            targetCost.Created(this);

            repository.Add(entity);
            repository.Add(standingbook);
            repository.Add(targetCost);
            repository.UnitOfWork.Commit();
        }
        public ProjectMasterDto GetProject(long id)
        {
            var entity = repository.GetProjectMaster(id);
            var dto = entity.ProjectedAs<ProjectMasterDto>();
            if (dto == null) return dto;
            dto.Procurements = repository.GetProcurements(id).ProjectedAsCollection<ProjectProcurementDto>();
            dto.Files = repository.GetFiles(id).ProjectedAsCollection<ProjectAboutFileDto>();
            dto.Costin = repository.GetCostins(id).ProjectedAsCollection<ProjectCostInDto>();
            dto.Costout = repository.GetCostouts(id).ProjectedAsCollection<ProjectCostOutDto>();
            return dto;
        }

        public OptionEntry[] SearchProject(string code)
        {
            Specification<VIProjectMaster> specification = EntityHelper.GetSpecification<VIProjectMaster>();
            specification.And(n => n.Code.Contains(code) || n.Name.Contains(code));
            var list = repository.PagingList(specification).Items;
            return list.Select(n => new OptionEntry { Id = n.ID.ToString(), Label = n.Name, Value = n.Code }).ToArray();
        }



        public string GetProjectCode(long projectId)
        {
            var entity = repository.GetProjectMaster(projectId);
            return entity?.Code;
        }



        public ProjectAboutFile AddAboutFile(long projectId, long foreignID, ProjectFileType fileType, FileEntry filedto)
        {
            ProjectAboutFile entity = new ProjectAboutFile
            {
                ProjectId = projectId,
                ForeignID = foreignID,
                FileName = filedto.FileName,
                FileSize = filedto.FileSize,
                StoragePath = filedto.StoragePath,
                FileType = fileType
            };
            entity.Created(this);
            repository.AddAboutFile(entity);
            repository.UnitOfWork.Commit();
            return entity;
        }


    }


}
