using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class TargetCostMappingResolver : IMappingResolver<ProjectTargetCost, ProjectTargetCostDto> 
    {
        public void Map(IMappingExpression<ProjectTargetCost, ProjectTargetCostDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
        }


      


    } 
}
