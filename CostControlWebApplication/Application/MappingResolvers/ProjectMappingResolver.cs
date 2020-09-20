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
}
