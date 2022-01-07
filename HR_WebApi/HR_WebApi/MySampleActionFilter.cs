using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HR_WebApi
{
    public class MySampleActionFilter : IActionFilter
    {
        private ILogger _logger;
        public MySampleActionFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Info("呼叫方法了");
            //var Bearer = context.HttpContext.Request.Headers.Select(P => P.Key ="HeaderAuthorization");
            var Path = context.HttpContext.Request.Path;
            var QueryString = context.HttpContext.Request.QueryString;
            //var token = context.HttpContext.Request.Headers["Authorization"];
            //var Method = context.HttpContext.Request.Method;
            //var requestVal = "";
            //foreach(var a in context.ActionArguments)
            //{
            //    requestVal += $"\"{a.Key}\":\"{a.Value}\"";  
            //}
            _logger.Info("Request Path："+context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Info("呼叫方法完成了");
            //_logger.Info((IFormatProvider)MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }
    }
}
