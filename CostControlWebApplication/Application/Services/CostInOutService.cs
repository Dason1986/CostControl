using BingoX;
using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Services
{
    public class CostInOutService : BaseService
    {
        public CostInOutService(ProjectRepository repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;

        }
        private readonly ProjectRepository repository;
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
            var project = repository.GetStandingbook(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            decimal projectExpendAmount = repository.GetProjectExpendAmount(dto.ProjectId);
            if (project.CostAmount < (projectExpendAmount + dto.ExpendAmount)) throw new BingoX.LogicException("貸方金額 不能超出成本金額");
            ProjectCostOut entity = dto.ProjectedAs<ProjectCostOut>();

            entity.Created(this);
            repository.AddCostout(entity);
            repository.UnitOfWork.Commit();
        }
        public void EditCostout(long id, ProjectCostOutDto dto)
        {
            ProjectCostOut entity = repository.GetCostout(id);
            if (entity == null) throw new LogicException("支出项目为空");
            if (dto.ProjectId == 0) throw new LogicException("項目 爲空");
            if (string.IsNullOrEmpty(dto.Title)) throw new LogicException("摘要 爲空");
            if (string.IsNullOrEmpty(dto.CostoutDate)) throw new LogicException("日期 爲空");
            var project = repository.GetStandingbook(dto.ProjectId);
            if (project == null) throw new BingoX.LogicException("項目 不存在");
            decimal projectExpendAmount = repository.GetProjectExpendAmount(dto.ProjectId);
            projectExpendAmount = projectExpendAmount - entity.ExpendAmount;
            if (project.CostAmount < (projectExpendAmount + dto.ExpendAmount)) throw new BingoX.LogicException("貸方金額 不能超出成本金額");
            entity.CopyFromGroup(dto.ProjectedAs<ProjectCostOut>(), "Info");
            repository.UpdateCostout(entity);
            repository.UnitOfWork.Commit();
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

            var project = repository.GetStandingbook(dto.ProjectId);
            if (project == null) throw new LogicException("項目 不存在");
            ProjectCostIn entity = dto.ProjectedAs<ProjectCostIn>();

            entity.Created(this);
            repository.AddCostin(entity);
            repository.UnitOfWork.Commit();
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
    }


}
