using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Services
{
    public class StandingbookService : BaseService
    {
        public StandingbookService(ProjectRepository repository, IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
        }
        private readonly ProjectRepository repository;
        public void Add(ProjectStandingbookDto dto)
        {
            ProjectStandingbook entity = dto.ProjectedAs<ProjectStandingbook>();

            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
        public IPagingList<VIProjectStandingbook> GetProjects(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectStandingbook> specification = new Specification<VIProjectStandingbook>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }

        public ProjectStandingbookDto GetProject(long id)
        {
            var entity = repository.GetStandingbook(id);
            var dto = entity.ProjectedAs<ProjectStandingbookDto>();
            if (dto == null) return dto;
            dto.CostOut = repository.ProjectCostOutList(id).ProjectedAsCollection<ProjectCostOutDto>();
            dto.CostIn = repository.ProjectCostInList(id).ProjectedAsCollection<ProjectCostInDto>();
            dto.AboutFiles = repository.AboutFilesList(id).ProjectedAsCollection<ProjectAboutFileDto>();

            return dto;
        }
    }


}
