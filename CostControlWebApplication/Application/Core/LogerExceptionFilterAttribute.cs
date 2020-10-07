using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace CostControlWebApplication
{
    public class LogerExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {

        //string[] ips = { "::1", "127.0.0.1" };scope.row.projectMain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            var _logger = NLog.LogManager.GetLogger(context.ActionDescriptor.DisplayName);
            _logger.Info(ex);
            System.Console.WriteLine($"{context.ActionDescriptor.DisplayName}:{ex.Message}");
        }

    }
}
