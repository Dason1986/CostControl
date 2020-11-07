using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.IO;
using System.Linq;

namespace CostControlWebApplication.Services
{
    public class ProjectMasterService : BaseService
    {


        public ProjectMasterService(ProjectRepository repository, ISerialNumberProvider serialNumberProvider, FileStorageServie fileStorageServie, IBoundedContext bounded, IStaffeUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.serialNumberProvider = serialNumberProvider;
            this.fileStorageServie = fileStorageServie;
        }
        private readonly ProjectRepository repository;
        private readonly ISerialNumberProvider serialNumberProvider;
        private readonly FileStorageServie fileStorageServie;

        public IPagingList<VIProjectMaster> GetProjects(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectMaster> specification = EntityHelper.GetSpecification<VIProjectMaster>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }
        public void Add(ProjectMasterDto dto )
        {
            if (dto.CreateFileId <= 0) throw new LogicException("立项目文件为空");
            if (dto.CompanyId <= 0) throw new LogicException("公司爲空");
            Supplier supplier = repository.GetSupplier(dto.CompanyId);
            if (supplier == null) throw new LogicException("選擇的公司無效");
            if (!supplier.IsCompany || string.IsNullOrEmpty(supplier.Code)) throw new LogicException("選擇的公司無效");
            if (string.IsNullOrEmpty(dto.Name)) throw new LogicException("項目名稱不能爲空");
            if (string.IsNullOrEmpty(dto.Address)) throw new LogicException("項目地址不能爲空");
            if (dto.ContractAmount <= 0) throw new LogicException("合同金額不能小於等於0");
            if (dto.ContractorsId <= 0) throw new LogicException("承建商爲空");
            if (dto.ProjectMainId <= 0) throw new LogicException("項目主體爲空");
            if (dto.ManagerId <= 0) throw new LogicException("項目經理爲空");
            ProjectMaster entity = dto.ProjectedAs<ProjectMaster>();
            if (entity.BeginDate.HasValue && entity.EndDate.HasValue && entity.EndDate < entity.BeginDate) throw new LogicException("實際開始日期不能大於實際結束日期");


            if (entity.EstimatedBeginDate.HasValue && entity.EstimatedEndDate.HasValue && entity.EstimatedEndDate < entity.EstimatedBeginDate) throw new LogicException("評估開始日期不能大於評估結束日期");

            ProjectAboutFile savefile = repository.GetFile(dto.CreateFileId);
            if(savefile==null)throw new LogicException("立项目文件不存在");
            entity.Code = serialNumberProvider.Dequeue(supplier);
            if (string.IsNullOrEmpty(entity.Code)) throw new LogicException("生成項目編號失敗");

       

            var path = Path.Combine("project", entity.Code, savefile.FileType.GetHashCode().ToString(), Bounded.Generator.New()+ savefile.FileName);
          
            fileStorageServie.Move(savefile.StoragePath, path);
            savefile.StoragePath = path;
            savefile.ProjectId = entity.ID;
            savefile.FileType = ProjectFileType.Create;
            entity.State = CommonState.Enabled;
            entity.Created(this);

    

            var standingbook = new ProjectStandingbook();
            standingbook.ProjectId = entity.ID;
            standingbook.Created(this);

            var targetCost = new ProjectTargetCost();
            targetCost.ProjectId = entity.ID;
            targetCost.Created(this);


            var calculation = new ProjectCalculation();
            calculation.ProjectId = entity.ID;
            calculation.Created(this);

            repository.AddMaster(entity);
            repository.AddCalculation(calculation);
            repository.AddStandingbook(standingbook);
            repository.AddTargetCost(targetCost);
            repository.Update(savefile);

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
