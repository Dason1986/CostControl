using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{
    public class CalculationService : BaseService
    {
        private readonly ProjectRepository repository;

        public CalculationService(ProjectRepository repository, IBoundedContext bounded, IStaffeUser user) : base(bounded, user)
        {
            this.repository = repository;
        }

        public IPagingList<ProjectCalculationDto> GetCalculations(ProjectQueryRequest queryRequest)
        {
            Specification<VIProjectCalculation> specification = this.GetSpecification<VIProjectCalculation>();
            specification.SetPage(queryRequest);

            return repository.PagingList(specification).ProjectedAsPagingList<ProjectCalculationDto>();
        }

        public ProjectCalculationDto Get(long id)
        {
            var dto = repository.GetVICalculation(id).ProjectedAs<ProjectCalculationDto>();
            if (dto != null)
            {

            }
            return dto;
        }
    }


}
