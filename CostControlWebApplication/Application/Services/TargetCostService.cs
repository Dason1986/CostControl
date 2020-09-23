using BingoX.AspNetCore;
using BingoX.ComponentModel.Data;
using BingoX.DataAccessor;
using BingoX.Repository;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Services
{
    public class TargetCostService :  BaseService
    {
        private readonly IRepository<TargetCost> repository;

        public TargetCostService(IRepository<TargetCost> repository,IBoundedContext bounded, ICurrentUser user) : base(bounded, user)
        {
            this.repository = repository;
        }
     

        public IPagingList<TargetCostListItmeDto> GetProjects(ProjectQueryRequest queryRequest)
        {
            ISpecification<TargetCost> specification = new Specification<TargetCost>();
            specification.SetPage(queryRequest);
               int total = 0;
            return repository.PageList(specification,ref total).ProjectedAsPagingList<TargetCostListItmeDto>(total,queryRequest);
            
        }

        public void Add(TargetCostDto dto)
        {
            TargetCost entity = dto.ProjectedAs<TargetCost>();
            
            entity.Created(this);
            repository.Add(entity);
            repository.UnitOfWork.Commit();
        }
    }


}
