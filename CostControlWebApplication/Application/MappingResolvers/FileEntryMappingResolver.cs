using AutoMapper;
using BingoX.Utility;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class FileEntryMappingResolver : IMappingResolver<FileEntry,  ProjectAboutFile>
    {
        public void Map(IMappingExpression<FileEntry, ProjectAboutFile> mapping)
        {
           
            mapping.ForMember(n => n.FileSize, opt => opt.MapFrom((x,y)=>FileUtility.GetFileSizeDisplay(x.FileSize)));
        }


    }
}
