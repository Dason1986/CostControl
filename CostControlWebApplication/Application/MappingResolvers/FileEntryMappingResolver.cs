using AutoMapper;
using BingoX.Utility;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class FileEntryMappingResolver : IMappingResolver<FileEntry, FileEntryDto>
    {
        public void Map(IMappingExpression<FileEntry, FileEntryDto> mapping)
        {
            mapping.ForMember(n => n.FileSize, opt => opt.MapFrom((x,y)=>FileUtility.GetFileSizeDisplay(x.FileSize)));
        }


    }
}
