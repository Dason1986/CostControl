using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
 
using BingoX.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication.Cookies;
using BingoX.Helper;
using CostControlWebApplication.Services;
using CostControlWebApplication;
using BingoX.AspNetCore;
using CostControlWebApplication.Models;

namespace GreeSaas.WebApplication.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="jwtSeetings"></param>
        /// <param name="dateTimeService"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromServices] AccountService service, [FromServices] JwtSeetings jwtSeetings, [FromServices] IDateTimeService dateTimeService, [FromForm] LoginInputModel userLogin)
        {

            if (string.IsNullOrEmpty(userLogin.Account)) throw new BingoX.LogicException();
            if (string.IsNullOrEmpty(userLogin.Password)) throw new BingoX.LogicException();
            var user = service.Login(userLogin.Account, userLogin.Password);
            if (user == null) throw new  UnauthorizedException("登录失败，帐号或密码错误");
            if (user.State !=   CostControlWebApplication.Domain.CommonState.Enabled) throw new UnauthorizedException("登录失败，帐号已经注销");
            var now = dateTimeService.GetNow();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSeetings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var claims = new Claim[]
                      {
                            new Claim("Account",user.Account),
                            new Claim(ClaimTypes.Name,user.Name),
                            new Claim(ClaimTypes.Role,user.RoleType.ToString()), 
                            new Claim("UserID",user.ID.ToString()), 

                      };


            var token = new JwtSecurityToken(
                jwtSeetings.Issuer,
                jwtSeetings.Audience,
                claims,
                now,
               now.AddDays(30),
                creds
                );
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            Response.Headers.Add("Authorization", "Bearer " + tokenstring);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
            if (Url.IsLocalUrl(userLogin.ReturnUrl))
            {
                return Redirect(userLogin.ReturnUrl);
            }
            else
            {
                return Redirect("/Project");
            }


        }

        public IActionResult AccessDenied(string returnUrl = null)
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
