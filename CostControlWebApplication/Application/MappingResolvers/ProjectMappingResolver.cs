using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectMasterResolver : IMappingResolver<VIProjectMaster, ProjectMasterDto>
    {
        public void Map(IMappingExpression<VIProjectMaster, ProjectMasterDto> mapping)
        {

            mapping.IncludeBase<IDate, IDateDto>();
        }






    }
  
    public class ProjectMappingResolver : IMappingResolver<VIProjectStandingbook, ProjectStandingbookDto>
    {



        public void Map(IMappingExpression<VIProjectStandingbook, ProjectStandingbookDto> mapping)
        {

            mapping.ForMember(n => n.StateDisplay, opt => opt.MapFrom<ProjectResolver>());
         
        }


    }
    public class ProjectResolver :   IValueResolver<VIProjectStandingbook, ProjectStandingbookDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CacheConfigService cacheConfigService;

        public ProjectResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            cacheConfigService = _httpContextAccessor.HttpContext.RequestServices.GetService<CacheConfigService>();
        }

      

        public string Resolve(VIProjectStandingbook source, ProjectStandingbookDto destination, string destMember, ResolutionContext context)
        {


     //       Amount(source, destination);


            return string.Format("{0:n2}%", source.CompletionRatio);

        } 


    }
}
