using BingoX.AspNetCore.Extensions;
using BingoX.Helper;
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
            services.AddSingleton<ISerialNumberProvider, SerialNumberProvider>();
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

  static   class SettingHelper
    {
        public static T GetValue<T> (this IList<SystemSetting> systems,string code)
        {
            var item = systems.FirstOrDefault(n => string.Equals(code, n.Code, System.StringComparison.CurrentCultureIgnoreCase));
            if (item != null) return BingoX.Utility.StringUtility.Cast<T>(item.DataValue).Value;
            return default;
        }
    }
}
