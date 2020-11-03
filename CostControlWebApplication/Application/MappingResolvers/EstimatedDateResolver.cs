using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class EstimatedDateMappingResolver : IMappingResolver<IEstimatedDate, IDateDto>
    {
        public void Map(IMappingExpression<IEstimatedDate, IDateDto> mapping)
        {
            mapping.ForMember(n => n.BeginDate, opt => opt.MapFrom((x, y, z) =>
            {
                if (!string.IsNullOrEmpty(z)) return z;
                if (x.EstimatedBeginDate.HasValue)
                {
                    return string.Format("{0:yyyy-MM-dd}", x.EstimatedBeginDate);
                }
                else
                {
                    return "暫無";
                }
            }));
            mapping.ForMember(n => n.EndDate, opt => opt.MapFrom((x, y) =>
            {
                if (x.EstimatedEndDate.HasValue)
                {
                    return string.Format("{0:yyyy-MM-dd}", x.EstimatedEndDate);
                }
                else
                {
                    return "暫無";
                }
            }));
        }
    }

}
