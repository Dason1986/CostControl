﻿using BingoX.AspNetCore;
using BingoX.AspNetCore.Extensions;
using BingoX.Helper;
using BingoX.Repository;
using CostControlWebApplication.Application.AD;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CostControlWebApplication
{
    [DIConfigureServicesAttribute(0)]
    public class StandardConfigureServices : DIConfigureServices
    {
        public StandardConfigureServices(IConfiguration configuration, IServiceCollection services) : base(configuration, services)
        {
        }

        protected override void Register()
        {

            services.AddSession();

            var assembly = this.GetType().Assembly;


            var jwtSeetings = new JwtSeetings();
            //绑定jwtSeetings
            configuration.Bind("JWT", jwtSeetings);
            services.AddSingleton<JwtSeetings>(jwtSeetings);
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
          .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
          {
              options.ClaimsIssuer = "Cookie";
              options.SessionStore = new MemoryCacheTicketStore();
          })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSeetings.Issuer,
                    ValidAudience = jwtSeetings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSeetings.Secret))
                };
            });
            services.AddScoped<ISerialNumberProvider, SerialNumberProvider>(n =>
            {
                var repository = n.GetService<IRepository<Supplier>>();
                return new SerialNumberProvider("{Code}{Date:yyyy}{Number:d3}", repository);
            });
            services.AddScoped<IStaffeUser, SocpStaffeUser>(n =>
            {
                var user = n.GetService<ICurrentUser>();
                return new SocpStaffeUser
                {
                    Claims = user.Claims,
                    Name = user.Name,
                    Role = user.Role,
                    UserID = BingoX.Utility.StringUtility.Cast<long>(user.Claims.First(n => n.Type == "UserID")?.Value),
                     NameIdentifier= BingoX.Utility.StringUtility.Cast<long>(user.Claims.First(n => n.Type == ClaimTypes.NameIdentifier)?.Value),
                };
            });
            services.AddScoped<ActiveDirectoryService>(x =>
            {
                var repository = x.GetService<SettingRepository>();
                var LDAP = repository.Where(x => x.GroupCode == "LDAP");
                if (LDAP.IsEmpty()) return null;
                if (!LDAP.GetValue<bool>("Enabled")) return null;
                return new ActiveDirectoryService(new ActiveDirectoryOption { LDAPService = LDAP.GetValue<string>("LDAPService"), Uid = LDAP.GetValue<string>("Uid"), Pwd = LDAP.GetValue<string>("Pwd") });
            });
        }
    }
    static class SettingHelper
    {
        public static T GetValue<T>(this IList<SystemSetting> systems, string code)
        {
            var item = systems.FirstOrDefault(n => string.Equals(code, n.Code, System.StringComparison.CurrentCultureIgnoreCase));
            if (item != null) return BingoX.Utility.StringUtility.Cast<T>(item.DataValue).Value;
            return default;
        }
    }
}
