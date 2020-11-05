using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class ProjectProcurementResolver : IMappingResolver<VIProjectProcurement, ProjectProcurementDto>
    {
        public void Map(IMappingExpression<VIProjectProcurement, ProjectProcurementDto> mapping)
        {
            mapping.ForMember(n => n.ProcurementTypeName, opt => opt.MapFrom((x, y) => BingoX.Utility.EnumUtility.GetDescription(x.ProcurementType)));
            mapping.ForMember(n => n.ProcurementType, opt => opt.MapFrom((x, y) => x.ProcurementType.GetType().ToString()));


        }






    }
}
