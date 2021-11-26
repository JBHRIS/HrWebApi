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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JBAppService.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardHandlerController : ControllerBase
    {
          

        private readonly JwtHelpers _jwt;
        private ICardHandlerService _ICardHandlerService;
        private IConfiguration _configuration;
        private readonly ILogger<string> _logger;


        public CardHandlerController(ICardHandlerService cardHandlerService , IConfiguration configuration , JwtHelpers jwt, ILogger<string> logger)
        {
            this._ICardHandlerService = cardHandlerService;
            this._configuration = configuration;
            this._jwt = jwt;
            this._logger = logger;
        }




        /// <summary>
        /// 取得打卡資料
        /// </summary>
        /// <param name="Nobr">查詢工號</param>
        /// <param name="BDate">查詢開始日期</param>
        /// <param name="EDate">查詢結束日期</param>
        /// <param name="PageRow">一頁顯示比數</param>
        /// <param name="PageNumber">第幾頁</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCardDetail")]
        public List<CardRowDataDto> GetCardDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1)
        {
            List<CardRowDataDto> rdlist = new List<CardRowDataDto>();
            string imageUrl = this._configuration.GetValue<string>("RedirectSettings:AppApiURL");
            _logger.LogInformation(string.Format("工號 : ", Nobr));
            rdlist =this._ICardHandlerService.GetCardDetail(imageUrl ,Nobr, BDate, EDate, PageRow,PageNumber);
            return rdlist;
        }
		//etherscan.io
		//
		
		
    }
}
