using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectCostInMappingResolver : IMappingResolver<VIProjectCostIn,  ProjectCostInDto>
    {
        public void Map(IMappingExpression<VIProjectCostIn, ProjectCostInDto> mapping)
        {
            
        }


    }
    public class ProjectCostOutMappingResolver : IMappingResolver<VIProjectCostOut, ProjectCostOutDto>
    {
        public void Map(IMappingExpression<VIProjectCostOut, ProjectCostOutDto> mapping)
        {

        }


    }
    public class TargetCostMappingResolver : IMappingResolver<TargetCost, TargetCostDto> 
    {
        public void Map(IMappingExpression<TargetCost, TargetCostDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
        }


      


    }
    public class TargetCostListItmeMappingResolver :  IMappingResolver<TargetCost, TargetCostListItmeDto>
    {
        


        public void Map(IMappingExpression<TargetCost, TargetCostListItmeDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
            //       mapping.ForMember(n => n.State, opt => opt.MapFrom(ProjectResolver.StateDisplay));


        }


    }
}
