using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{

    public class ProjectService : BaseService
    {
        private readonly ProjectRepository repository;

        public ProjectService(ProjectRepository repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
        }
        public void Add(ProjectInfoDto dto)
        {
            ProjectInfo entity = dto.ProjectedAs<ProjectInfo>();

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

        public void AddCostout(ProjectCostOutDto dto)
        {
            if (dto.ProjectId == 0) throw new BingoX.LogicException("項目 爲空");
            if (string.IsNullOrEmpty(dto.Title)) throw new BingoX.LogicException("摘要 爲空");
            if (string.IsNullOrEmpty(dto.CostoutDate)) throw new BingoX.LogicException("日期 爲空");
            var project = repository.GetProject(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            decimal projectExpendAmount = repository.GetProjectExpendAmount(dto.ProjectId);
            if (projectExpendAmount < dto.ExpendAmount) throw new BingoX.LogicException("貸方金額 不能超出成本金額");
            ProjectCostOut entity = dto.ProjectedAs<ProjectCostOut>();

            entity.Created(this);
            repository.AddCostout(entity);
            repository.UnitOfWork.Commit();
        }

        public string GetProjectCode(long projectId)
        {
            var entity = repository.GetProject(projectId);
            return entity?.Code;
        }

        public void AddAboutFile(long projectId,long filetype, FileEntry filedto)
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

        public void AddCostin(ProjectCostInDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new BingoX.LogicException("摘要 爲空");
            if (dto.ProjectId == 0) throw new BingoX.LogicException("項目 爲空");

            var project = repository.GetProject(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            ProjectCostIn entity = dto.ProjectedAs<ProjectCostIn>();

            entity.Created(this);
            repository.AddCostin(entity);
            repository.UnitOfWork.Commit();
        }
    }


}
