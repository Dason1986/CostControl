using System.Security.Claims;

namespace CostControlWebApplication.Domain
{
    public class AccountUser : BingoX.Domain.ISnowflakeEntity<AccountUser>
    {
        public long ID { get; set; }
        public int State { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string RoleCode { get; set; }
    }
}
