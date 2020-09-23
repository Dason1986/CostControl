using BingoX.AspNetCore;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Application.Services.Dtos;
using System;

namespace CostControlWebApplication.Services
{
    public class SettingService : BaseService
    {
        private readonly SettingRepository repository;

        public SettingService(SettingRepository repository, IBoundedContext bounded, ICurrentUser user):base(bounded, user)
        {
            this.repository = repository;
        }
      
        public SettingDto GetSetting()
        {
            var setting= repository.QueryAll();
            return new SettingDto { };
        }
    }
}
