using BingoX.AspNetCore;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostControlWebApplication.Services
{
    public interface IResourceAccountService : IService
    {
        AccountUser Login(object account, object password);
    }

    public class ResourceAccountService : IResourceAccountService
    {
        public AccountUser Login(object account, object password)
        {
            return new AccountUser { State = 1, Account = "admin", Name = "管理员", RoleCode = "admin", ID = 1 };
        }
    }
}
