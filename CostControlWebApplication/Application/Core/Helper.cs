using BingoX;
using BingoX.AspNetCore;
using BingoX.DataAccessor;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CostControlWebApplication
{
    public class BasicsCode
    {
        public const string TrageCastProjectType = "006"; 
        public const string Currency = "003";
        public const string ProjectMain = "004";
        public const string SettlementMethod = "001";
        public const string ContractType = "002";
        public const string ProjectType = "008";
        public const string Undertaking = "009";
    }
    public static class Helper
    {
        public static bool IsAdmin(this ICurrentUser stafferRequest)
        {
            if (stafferRequest == null) throw new LogicException("未登录");

            return string.Equals(stafferRequest.Role, "Admin", System.StringComparison.CurrentCultureIgnoreCase);
        }

        public static void SetPage<T>(this ISpecification<T> specification, QueryRequest queryRequest)
        {
            specification.PageSize = queryRequest.PageSize;
            specification.PageIndex = queryRequest.PageIndex;
            if (specification.PageSize == 0) specification.PageSize = 10;
            if (queryRequest.PageNo > 0) specification.PageIndex = queryRequest.PageNo - 1; ;
        }
       
        public static IHtmlContent GetBasics(this IHtmlHelper helper, string groupcode)
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetBasics(groupcode));
        }
        public static IHtmlContent GetLastHome(this IHtmlHelper helper )
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetLastHome());
        }
        public static IHtmlContent GetUserOptions(this IHtmlHelper helper )
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetUser());
        } 
        public static SidebarMenu[] GetMenus(this IHtmlHelper helper)
        {


            var request = helper.ViewContext.HttpContext.RequestServices.GetService<ICurrentUser>();
            IList<SidebarMenu> Menus = new List<SidebarMenu>() {
              new SidebarMenu { Name = "Dashboard", Url = "/Dashboard", Icon = "fa fa-pie-chart"

                },
                new SidebarMenu { Name = "工程管理", Url = "#", Icon = "fa fa-files-o" ,
                    Childs=  new []
                    {
                        new SidebarMenu{Name = "目标成本", Url = "/TargetCost" , Icon = "fa fa-cubes" },
                        new SidebarMenu{Name = "项目台帐", Url = "/Project" , Icon = "fa fa-cubes" },
                        new SidebarMenu{Name = "项目收入", Url = "/ProjectIncome", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "项目成本", Url = "/ProjectCost", Icon = "fa fa-cube"  },

                    }}
            };
            if (request.IsAdmin())
            {
                Menus.Add(new SidebarMenu
                {
                    Name = "系统管理",
                    Url = "#",
                    Icon = "fa fa-cogs",
                    Childs = new[]
                    {
                        new SidebarMenu{Name = "系統設置", Url = "/Platform/Setting", Icon = "fa fa-cog"  },
                        new SidebarMenu{Name = "基礎資料", Url = "/Platform/BasicData", Icon = "fa fa-cog"  },
                        new SidebarMenu{Name = "員工管理", Url = "/Platform/Staffer", Icon = "fa fa-user"  },
                        new SidebarMenu{Name = "供應商管理", Url = "/Platform/Supplier", Icon = "fa fa-truck"  }
                    }
                });

            }
            return Menus.ToArray();



        }
    }
}
