using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectListItmeResolver : IValueResolver<VIProjectInfo, ProjectInfoListItmeDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CacheConfigService cacheConfigService;

        public ProjectListItmeResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            cacheConfigService = _httpContextAccessor.HttpContext.RequestServices.GetService<CacheConfigService>();
        }
        
        public string Resolve(VIProjectInfo source, ProjectInfoListItmeDto destination, string destMember, ResolutionContext context)
        {
         
            ProjectResolver.Date(source, destination);
            ProjectResolver.Amount(source,destination);


            return string.Format("{0:n2}%", source.CompletionRatio);

        }

    }
}
