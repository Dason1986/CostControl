using BingoX.Repository;
using CostControlWebApplication.Domain;
using System;

namespace CostControlWebApplication.Application.Data
{
    public class SettingRepository : Repository<SystemSetting>
    {
        public SettingRepository(RepositoryContextOptions options) : base(options)
        {
            
        }

     
    } 
}
