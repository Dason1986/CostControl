using BingoX;
using BingoX.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace CostControlWebApplication
{
 
    public static class Helper
    {
        public static bool IsAdmin(this ICurrentUser stafferRequest)
        {
            if (stafferRequest == null) throw new LogicException("未登录");

            return string.Equals(stafferRequest.Role, "Admin", System.StringComparison.CurrentCultureIgnoreCase);
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
                        new SidebarMenu{Name = "工程查询", Url = "/Project" , Icon = "fa fa-cubes" },
                        new SidebarMenu{Name = "完结工程", Url = "/Batch/Approval", Icon = "fa fa-cube"  },
                        
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
                        new SidebarMenu{Name = "系统设置", Url = "/Platform/Setting", Icon = "fa fa-cog"  },
                        new SidebarMenu{Name = "员工管理", Url = "/Platform/Employee", Icon = "fa fa-user"  },
                        new SidebarMenu{Name = "供应商管理", Url = "/Platform/Supplier", Icon = "fa fa-truck"  }
                    }
                });

            }
            return Menus.ToArray();



        }
    }
}
