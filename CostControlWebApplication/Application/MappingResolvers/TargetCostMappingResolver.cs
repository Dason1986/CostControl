using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class TargetCostMappingResolver : IMappingResolver<TargetCost, TargetCostDto>,IMappingResolver<TargetCost, TargetCostListItmeDto>
    {
        public void Map(IMappingExpression<TargetCost, TargetCostDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
        }


        public void Map(IMappingExpression<TargetCost, TargetCostListItmeDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
            //       mapping.ForMember(n => n.State, opt => opt.MapFrom(ProjectResolver.StateDisplay));


        }


    }
}
