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
    public class TargetCostMappingResolver : IMappingResolver<ProjectTargetCost, ProjectTargetCostDto> 
    {
        public void Map(IMappingExpression<ProjectTargetCost, ProjectTargetCostDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
        }


      


    }
    public class TargetCostListItmeMappingResolver :  IMappingResolver<ProjectTargetCost, ProjectTargetCostListItmeDto>
    {
        


        public void Map(IMappingExpression<ProjectTargetCost, ProjectTargetCostListItmeDto> mapping)
        {
            mapping.IncludeBase<IEstimatedDate, IDateDto>();
            //       mapping.ForMember(n => n.State, opt => opt.MapFrom(ProjectResolver.StateDisplay));


        }


    }
}
