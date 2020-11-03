﻿using AutoMapper;
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
    public class ProjectMappingListItmeResolver : IMappingResolver<VIProjectStandingbook, ProjectStandingbookListItmeDto>
    {
        public void Map(IMappingExpression<VIProjectStandingbook, ProjectStandingbookListItmeDto> mapping)
        {
            mapping.ForMember(n => n.StateDisplay, opt => opt.MapFrom<ProjectResolver>());
            mapping.IncludeBase<IDate, IDateDto>();
        }






    }
    public class ProjectMappingResolver : IMappingResolver<VIProjectStandingbook, ProjectStandingbookDto>
    {



        public void Map(IMappingExpression<VIProjectStandingbook, ProjectStandingbookDto> mapping)
        {

            mapping.ForMember(n => n.StateDisplay, opt => opt.MapFrom<ProjectResolver>());
            mapping.IncludeBase<IDate, IDateDto>();
        }


    }
    public class ProjectResolver : IValueResolver<VIProjectStandingbook, ProjectStandingbookListItmeDto, string>, IValueResolver<VIProjectStandingbook, ProjectStandingbookDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CacheConfigService cacheConfigService;

        public ProjectResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            cacheConfigService = _httpContextAccessor.HttpContext.RequestServices.GetService<CacheConfigService>();
        }

        public string Resolve(VIProjectStandingbook source, ProjectStandingbookListItmeDto destination, string destMember, ResolutionContext context)
        {


            Amount(source, destination);


            return string.Format("{0:n2}%", source.CompletionRatio);

        }

        public string Resolve(VIProjectStandingbook source, ProjectStandingbookDto destination, string destMember, ResolutionContext context)
        {


            Amount(source, destination);


            return string.Format("{0:n2}%", source.CompletionRatio);

        }
        void Amount(VIProjectStandingbook source, ProjectStandingbookListItmeDto destination)
        {
            if (source.ContractAmount > 0)
            {
                destination.ContractAmount = string.Format("{0:n2}", source.ContractAmount);
            }
            else
            {
                destination.ContractAmount = string.Empty;
            }
            if (source.CostAmount > 0)
            {
                destination.CostAmount = string.Format("{0:n2}", source.CostAmount);
            }
            else
            {
                destination.CostAmount = string.Empty;
            }
            if (source.AdditionalAmount > 0)
            {
                destination.AdditionalAmount = string.Format("{0:n2}", source.AdditionalAmount);
            }
            else
            {
                destination.AdditionalAmount = string.Empty;
            }
            if (source.BalanceAmount > 0)
            {
                destination.BalanceAmount = string.Format("{0:n2}", source.BalanceAmount);
            }
            else
            {
                destination.BalanceAmount = string.Empty;
            }
            if (source.CashInProjectAmount + source.CashInSecuringAmount > 0)
            {
                destination.CashInAmount = string.Format("{0:n2}", source.CashInProjectAmount + source.CashInSecuringAmount);
            }
            else
            {
                destination.CashInAmount = string.Empty;
            }
            if (source.CashOutAmount > 0)
            {
                destination.CashOutAmount = string.Format("{0:n2}", source.CashOutAmount);
            }
            else
            {
                destination.CashOutAmount = string.Empty;
            }
            if (source.PayableAmount > 0)
            {
                destination.PayableAmount = string.Format("{0:n2}", source.PayableAmount);
            }
            else
            {
                destination.PayableAmount = string.Empty;
            }
            if (source.ReceivableAmount > 0)
            {
                destination.ReceivableAmount = string.Format("{0:n2}", source.ReceivableAmount);
            }
            else
            {
                destination.ReceivableAmount = string.Empty;
            }
        }



    }
}
