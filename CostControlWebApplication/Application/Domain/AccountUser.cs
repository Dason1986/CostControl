using BingoX.Domain;
using System;
using System.Security.Claims;

namespace CostControlWebApplication.Domain
{
    public class AccountUser : ISnowflakeEntity<AccountUser>, IDomainEntry
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long ID { get; set; }
        public CommonState State { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleType RoleType { get; set; }
        public string Pwd { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
