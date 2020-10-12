using BingoX.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
        }
    }
}
