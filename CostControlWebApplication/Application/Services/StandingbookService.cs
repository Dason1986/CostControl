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
        public StandingbookService(ProjectRepository repository, IBoundedContext bounded, IStaffeUser user) : base(bounded, user)
        {
            this.repository = repository;
        }
        private readonly ProjectRepository repository;
      
        public IPagingList<VIProjectStandingbook> GetProjects(ProjectQueryRequest queryRequest)
        {

            Specification<VIProjectStandingbook> specification = EntityHelper.GetSpecification<VIProjectStandingbook>();
            specification.SetPage(queryRequest);
            return repository.PagingList(specification);

        }

        public ProjectStandingbookDto GetProject(long id)
        {
            var entity = repository.GetStandingbook(id);
            var dto = entity.ProjectedAs<ProjectStandingbookDto>();
            if (dto == null) return dto;
            dto.CostOut = repository.GetCostouts(id).ProjectedAsCollection<ProjectCostOutDto>();
            dto.CostIn = repository.GetCostins(id).ProjectedAsCollection<ProjectCostInDto>();
            dto.AboutFiles = repository.AboutFiless(id).ProjectedAsCollection<ProjectAboutFileDto>();

            return dto;
        }
    }


}
