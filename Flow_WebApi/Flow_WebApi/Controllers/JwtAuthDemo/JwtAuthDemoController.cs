using HR_WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.JwtAuthDemo
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthDemoController : ControllerBase
    {


        private readonly JwtHelpers _jwt;
        public JwtAuthDemoController(JwtHelpers jwt)
        {
            this._jwt = jwt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetClaims")]
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetUserName")]
        [HttpGet]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetUniqueId")]
        [HttpGet]
        public IActionResult GetUniqueId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
            return Ok(jti.Value);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetUsersId")]
        [HttpGet]
        public IActionResult GetUsersId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "Users");
            return Ok(jti.Value);
        }






    }
}
