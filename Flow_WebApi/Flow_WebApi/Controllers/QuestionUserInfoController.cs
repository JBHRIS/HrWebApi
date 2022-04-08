using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionUserInfoController : ControllerBase
    {

        private QuestionUserInfoInterFace _QuestionUserInfoInterface;

        public QuestionUserInfoController(QuestionUserInfoInterFace QuestionUserInfo)
        {
            this._QuestionUserInfoInterface = QuestionUserInfo;
        }

        /// <summary>
        /// 根據Code取得使用者資料
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionUserInfoByCode")]
        public ApiResult<List<QuestionUserInfoVdb>> GetQuestionUserInfoByQuestionMainCode(string Code)
        {
            ApiResult<List<QuestionUserInfoVdb>> mapiResult = new ApiResult<List<QuestionUserInfoVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionUserInfoInterface.GetQuestionUserInfoByCode(Code);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }








    }
}
