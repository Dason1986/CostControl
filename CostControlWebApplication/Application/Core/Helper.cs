﻿using BingoX;
using BingoX.AspNetCore;
using BingoX.DataAccessor;
using BingoX.Domain;
using BingoX.Helper;
using CostControlWebApplication.Domain;
using CostControlWebApplication.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace CostControlWebApplication
{
   
    public static class Helper
    {
        public static void CopyFromGroup<T>(this T entry, object obj, string groupName) where T : IDomainEntry
        {
            var propertis = typeof(T).GetProperties().Where(n => n.GetAttribute<System.ComponentModel.CategoryAttribute>()?.Category == groupName).ToArray();
            var fromType = obj.GetType();
            foreach (var item in propertis)
            {
                var propertyInfo = fromType.GetProperty(item.Name);
                if (propertyInfo == null) continue;
                var value = propertyInfo.FastGetValue(obj);

                BingoX.Helper.FastReflectionExtensions.FastSetValue(item, entry, value);
            }
        }
        public static bool IsManager(this IHtmlHelper helper)
        {
            var stafferRequest = helper.ViewContext.HttpContext.RequestServices.GetService<IStaffeUser>();
            if (stafferRequest == null) return false;
            if( string.Equals(stafferRequest.Role, "Manager", System.StringComparison.CurrentCultureIgnoreCase))return true;
            if (string.Equals(stafferRequest.Role, "Admin", System.StringComparison.CurrentCultureIgnoreCase))return true;
            return false;
        }
        public static bool IsManager(this IStaffeUser stafferRequest)
        {
            if (stafferRequest == null) throw new LogicException("未登錄");

            return string.Equals(stafferRequest.Role, "Manager", System.StringComparison.CurrentCultureIgnoreCase);
        }
        public static bool IsStaffer(this IStaffeUser stafferRequest)
        {
            if (stafferRequest == null) throw new LogicException("未登錄");

            return string.Equals(stafferRequest.Role, "Staffer", System.StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsAdmin(this IStaffeUser stafferRequest)
        {
            if (stafferRequest == null) throw new LogicException("未登錄");

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
        public static IHtmlContent GetSupplier(this IHtmlHelper helper)
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetSupplier());
        }
        public static IHtmlContent GetCompany(this IHtmlHelper helper)
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetCompany());
        }
        public static IHtmlContent GetUserOptions(this IHtmlHelper helper)
        {
            var service = helper.ViewContext.HttpContext.RequestServices.GetService<ResourceService>();
            return helper.RawEntity(service.GetUser());
        }
        public static IHtmlContent GetTableColumn(this IHtmlHelper helper, Type tableType)
        {
             
            StringBuilder builder = new StringBuilder();
            foreach (var item in tableType.GetProperties())
            {
                var att = item.GetAttribute<DisplayNameAttribute>();
                if (att == null) continue;
                builder.AppendFormat("<el-table-column label=\"{0}\" width=\"120\" prop=\"{1}{2}\"> </el-table-column>", att.DisplayName, item.Name[0].ToString().ToLower(), item.Name.Substring(1));
            }
            return helper.Raw(builder.ToString()); ;
        }
        public static SidebarMenu[] GetMenus(this IHtmlHelper helper)
        {


            var request = helper.ViewContext.HttpContext.RequestServices.GetService<IStaffeUser>();
            IList<SidebarMenu> Menus = new List<SidebarMenu>() {
              new SidebarMenu { Name = "Dashboard", Url = "/Dashboard", Icon = "fa fa-pie-chart"

                },
                new SidebarMenu { Name = "工程管理", Url = "#", Icon = "fa fa-files-o" ,
                    Childs=  new []
                    {
                        new SidebarMenu{Name = "项目立项", Url = "/ProjectMaster", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "采购审批", Url = "/Procurement", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "目標測算", Url = "/Calculation" , Icon = "fa fa-cubes" },
                        new SidebarMenu{Name = "項目收入", Url = "/ProjectIncome", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "項目成本", Url = "/ProjectCost", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "项目核算", Url = "/ProjectCost", Icon = "fa fa-cube"  },
                        new SidebarMenu{Name = "項目臺帳", Url = "/Standingbook" , Icon = "fa fa-cubes" },

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
            if (request.IsManager())
            {
                Menus.Add(new SidebarMenu
                {
                    Name = "系统管理",
                    Url = "#",
                    Icon = "fa fa-cogs",
                    Childs = new[]
                    {
                      
                        new SidebarMenu{Name = "供應商管理", Url = "/Platform/Supplier", Icon = "fa fa-truck"  }
                    }
                });

            }
            return Menus.ToArray();



        }
    }
}
