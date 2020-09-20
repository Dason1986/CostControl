using BingoX.AspNetCore;
using CostControlWebApplication.Application.Services.Dtos;
using System;

namespace CostControlWebApplication.Services
{
    public class SettingService : BaseService
    {
        public SettingService(IBoundedContext bounded, ICurrentUser user):base(bounded, user)
        {
        
        
        }
      
        public SettingDto GetSetting()
        {
            throw new NotImplementedException();
        }
    }
}
