using BingoX.AspNetCore;
using System;
using System.Security.Claims;

namespace CostControlWebApplication
{
    public interface IStaffeUser : ICurrentUser
    {
          long UserID { get; }
    }
    public class SocpStaffeUser : IStaffeUser, ICurrentUser
    {
        public long UserID { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public Claim[] Claims { get; set; }

        public object NameIdentifier { get; set; }
    }
}
