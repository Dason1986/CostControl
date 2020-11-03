using AutoMapper;
using BingoX.Utility;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class FileEntryMappingResolver : IMappingResolver<ProjectAboutFile,  ProjectAboutFileDto>
    {
        public void Map(IMappingExpression<ProjectAboutFile, ProjectAboutFileDto> mapping)
        {
           
            mapping.ForMember(n => n.FileSize, opt => opt.MapFrom((x,y)=>FileUtility.GetFileSizeDisplay(x.FileSize)));
            mapping.ForMember(n => n.FileType, opt => opt.MapFrom((x,y)=>EnumUtility.GetDescription(x.FileType)));
        }


    }
}
