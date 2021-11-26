using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JBAppService.Controllers
{
    public class ErrorController : Controller
    {
        private readonly JwtHelpers _jwt;
        private readonly ILogger<string> _logger;
        private readonly RequestDelegate _next;

        public ErrorController(
            JwtHelpers JwtHelpers
            , ILogger<string> logger)
        {
            this._jwt = JwtHelpers;
            this._logger = logger;
        }

        [HttpGet("/error")]
        public string Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                // here is the trick
                this.HttpContext.Response.StatusCode = statusCode.Value;

                var Authorization = HttpContext.Request.Headers["Authorization"];
                var url = HttpContext.Request.Headers["Referer"];
                var PostData = "";
                _logger.LogInformation(string.Format(@"HttpError --- StatusCode:{0},Token:{1},PostData:{2},url:{3}", statusCode, Authorization, PostData, url));
            }

            //return a static file. 
            return "error";

            // or return View 
            // return View(<view name based on statusCode>);
        }
    }

}
