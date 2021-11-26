using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBAppService.Api.Dto;
using JBAppService.Api.Service.Interface;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBAppService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttHandlerController : ControllerBase
    {

        private readonly JwtHelpers _jwt;
        private IAttHandlerService _IAttHandlerService;

        public AttHandlerController(IAttHandlerService attHandlerService , JwtHelpers jwt)
        {
            this._IAttHandlerService = attHandlerService;
            this._jwt = jwt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr">工號</param>
        /// <param name="BDate">開始日期</param>
        /// <param name="EDate">結束日期</param>
        /// <param name="PageRow">頁面顯示比數</param>
        /// <param name="PageNumber">頁面</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAttEndDetail")]
        public List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow =20, int PageNumber=1)
        {
            return  this._IAttHandlerService.GetAttEndDetail(Nobr ,BDate ,EDate,PageRow ,PageNumber);
        }
		//checkpythonscriptswithblack
    }





}
