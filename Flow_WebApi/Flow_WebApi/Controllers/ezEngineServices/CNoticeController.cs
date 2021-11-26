using JBHRIS.Api.Dto.Vdb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.ezEngineServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CNoticeController : ControllerBase
    {
        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="dDate">預設帶入今天所有生效的資料</param>
        /// <returns>List NoticeRow</returns>
        [HttpGet]
        [Route("GetNoticeData")]
        public List<NoticeRow> GetNoticeData(DateTime dDate )
        {


            return new List<NoticeRow>();
        }

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        [HttpGet]
        [Route("GetNoticeRow")]
        public List<NoticeRow> GetNoticeRow(string Guid)
        {
            return new List<NoticeRow>();
        }



        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>bool</returns>
        [HttpGet]
        [Route("DeleteCNotice")]
        public bool DeleteCNotice(string Guid)
        {
            return false;
        }


        /// <summary>
        /// 存入公告
        /// </summary>
        /// <param name="Row">NoticeRow資料列</param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("SaveCNotice")]
        public bool SaveCNotice(NoticeRow Row)
        {
            return false;
        }


    }
}
