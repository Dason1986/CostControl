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

    public class ProjectService : BaseService
    {
        private readonly ProjectRepository repository;
        private readonly ISerialNumberProvider serialNumberProvider;

        public ProjectService(ProjectRepository repository, ISerialNumberProvider serialNumberProvider, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
            this.serialNumberProvider = serialNumberProvider;
        }
        public void Add(ProjectInfoDto dto)
        {
            ProjectInfo entity = dto.ProjectedAs<ProjectInfo>();
            if (string.IsNullOrEmpty(entity.Code)) entity.Code = serialNumberProvider.Dequeue(SerialNumberCode.ProjectCode);
            else if (repository.ExistCode(entity.Code)) throw new LogicException("编号已经存在");
            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
        public IPagingList<VIProjectInfo> GetProjects(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectInfo> specification = new Specification<VIProjectInfo>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }
        public IPagingList<ProjectCostOutDto> GetProjectCostOut(ProjectQueryRequest queryRequest)
        {

            var specification = new Specification<VIProjectCostOut>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification).ProjectedAsPagingList<ProjectCostOutDto>();

        }
        public void AddCostout(ProjectCostOutDto dto)
        {
            if (dto.ProjectId == 0) throw new BingoX.LogicException("項目 爲空");
            if (string.IsNullOrEmpty(dto.Title)) throw new BingoX.LogicException("摘要 爲空");
            if (string.IsNullOrEmpty(dto.CostoutDate)) throw new BingoX.LogicException("日期 爲空");
            var project = repository.GetProject(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            decimal projectExpendAmount = repository.GetProjectExpendAmount(dto.ProjectId);
            if (project.CostAmount<( projectExpendAmount + dto.ExpendAmount)) throw new BingoX.LogicException("貸方金額 不能超出成本金額");
            ProjectCostOut entity = dto.ProjectedAs<ProjectCostOut>();

            entity.Created(this);
            repository.AddCostout(entity);
            repository.UnitOfWork.Commit();
        }

        public OptionEntry[] SearchProject(string code)
        {
            Specification<VIProjectInfo> specification = new Specification<VIProjectInfo>();
            specification.And(n => n.Code.Contains(code) || n.Name.Contains(code));
            var list = repository.PagingList(specification).Items;
            return list.Select(n => new OptionEntry { Id = n.ID.ToString(), Label = n.Name, Value = n.Code }).ToArray();
        }

        public void EditCostout(long id, ProjectCostOutDto dto)
        {
            ProjectCostOut entity = repository.GetCostout(id);
            if (entity == null) throw new LogicException("支出项目为空");
            if (dto.ProjectId == 0) throw new LogicException("項目 爲空");
            if (string.IsNullOrEmpty(dto.Title)) throw new LogicException("摘要 爲空");
            if (string.IsNullOrEmpty(dto.CostoutDate)) throw new LogicException("日期 爲空");
            var project = repository.GetProject(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            decimal projectExpendAmount = repository.GetProjectExpendAmount(dto.ProjectId);
            projectExpendAmount = projectExpendAmount - entity.ExpendAmount;
            if (project.CostAmount < (projectExpendAmount + dto.ExpendAmount)) throw new BingoX.LogicException("貸方金額 不能超出成本金額");
            entity.CopyFromGroup(dto.ProjectedAs<ProjectCostOut>(), "Info");
            repository.UpdateCostout(entity);
            repository.UnitOfWork.Commit();
        }

        public string GetProjectCode(long projectId)
        {
            var entity = repository.GetProject(projectId);
            return entity?.Code;
        }

        public void EditCostin(long id, ProjectCostInDto dto)
        {
            if (dto.ProjectId == 0) throw new LogicException("項目 爲空");
            if (string.IsNullOrEmpty(dto.Title)) throw new LogicException("摘要 爲空");
         
            ProjectCostIn entity = repository.GetCostIn(id);
            entity.CopyFromGroup(dto.ProjectedAs<ProjectCostIn>(), "Info");
            repository.UpdateCostIn(entity);
            repository.UnitOfWork.Commit();
        }

        public void AddAboutFile(long projectId, long filetype, FileEntry filedto)
        {
            ProjectAboutFile entity = filedto.ProjectedAs<ProjectAboutFile>();
            entity.ProjectId = projectId;
            entity.FileTypeId = filetype;
            entity.Created(this);
            repository.AddAboutFile(entity);
            repository.UnitOfWork.Commit();
        }

        public ProjectInfoDto GetProject(long id)
        {
            var entity = repository.GetProject(id);
            var dto = entity.ProjectedAs<ProjectInfoDto>();
            if (dto == null) return dto;
            dto.CostOut = repository.ProjectCostOutList(id).ProjectedAsCollection<ProjectCostOutDto>();
            dto.CostIn = repository.ProjectCostInList(id).ProjectedAsCollection<ProjectCostInDto>();
            dto.AboutFiles = repository.AboutFilesList(id).ProjectedAsCollection<ProjectAboutFileDto>();

            return dto;
        }
        public IPagingList<ProjectCostInDto> GetProjectCostin(ProjectQueryRequest queryRequest)
        {

            var specification = new Specification<VIProjectCostIn>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification).ProjectedAsPagingList<ProjectCostInDto>();

        }
        public void AddCostin(ProjectCostInDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new LogicException("摘要 爲空");
            if (dto.ProjectId == 0) throw new LogicException("項目 爲空");

            var project = repository.GetProject(dto.ProjectId);
            if (project == null) throw new LogicException("項目 不存在");
            ProjectCostIn entity = dto.ProjectedAs<ProjectCostIn>();

            entity.Created(this);
            repository.AddCostin(entity);
            repository.UnitOfWork.Commit();
        }
    }


}
