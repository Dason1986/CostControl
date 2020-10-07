using AutoMapper;
using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.MappingResolvers
{
    public class AccountUserMappingResolver : IMappingResolver<AccountUser, AccountUserDto>
    {
        public void Map(IMappingExpression<AccountUser, AccountUserDto> mapping)
        {
            mapping.ForMember(n => n.RoleType, opt => opt.MapFrom((x,y)=>x.RoleType.ToString()));
        }


    }
  
}
