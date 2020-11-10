using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectMasterResolver : IMappingResolver<VIProjectMaster, ProjectMasterDto>
    {
        public void Map(IMappingExpression<VIProjectMaster, ProjectMasterDto> mapping)
        {

          //  mapping.IncludeBase<IDate, IDateDto>();
        }






    }
}
