using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectMappingResolver : IMappingResolver<VIProjectInfo, ProjectInfoListItmeDto>
    {
        public void Map(IMappingExpression<VIProjectInfo, ProjectInfoListItmeDto> mapping)
        {
            mapping.ForMember(n => n.StateDisplay, opt => opt.MapFrom(ProjectResolver.StateDisplay));
        }


    }
    public class TargetCostMappingResolver : IMappingResolver<TargetCost, TargetCostDto>
    {
        public void Map(IMappingExpression<TargetCost, TargetCostDto> mapping)
        {
            mapping.ForMember(n => n.State, opt => opt.MapFrom(ProjectResolver.Date));
        }


    }
    public class TargetCostListItmeMappingResolver : IMappingResolver<TargetCost, TargetCostListItmeDto>
    {
        public void Map(IMappingExpression<TargetCost, TargetCostListItmeDto> mapping)
        {
            mapping.ForMember(n => n.State, opt => opt.MapFrom(ProjectResolver.Date));
        }


    }
}
