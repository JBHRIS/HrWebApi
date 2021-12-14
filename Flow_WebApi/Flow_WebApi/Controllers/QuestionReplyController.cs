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
    public class QuestionReplyController : ControllerBase
    {

        private QuestionReplyInterFace _QuestionReplyInterface;

        public QuestionReplyController(QuestionReplyInterFace QuestionReply)
        {
            this._QuestionReplyInterface = QuestionReply;
        }

        /// <summary>
        /// 根據Code取得所有回覆單
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionReplyByCode")]
        public ApiResult<List<QuestionReplyVdb>> GetQuestionReply(string Code)
        {
            ApiResult<List<QuestionReplyVdb>> mapiResult = new ApiResult<List<QuestionReplyVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionReplyInterface.GetQuestionReplyByCode(Code);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }
        /// <summary>
        /// 新增回覆
        /// </summary>
        /// <param name="vdb"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertQuestionReply")]
        public ApiResult<bool> InsertQuestionReply(QuestionReplyVdb vdb)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;
            
            try
            {
                if (this._QuestionReplyInterface.InsertQuestionReply(vdb))
                {
                    mapiResult.Result = true;
                    mapiResult.State = true;
                }
                
            }
            catch (Exception ex)
            {
                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }

        /// <summary>
        /// 修改主要回覆單Send值
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="QRsend"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateQuestionReplySend")]
        public ApiResult<bool> UpdateQuestionReplySend(string Code, bool QRsend)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;

            try
            {
                if (this._QuestionReplyInterface.UpdateQuestionReplySend(Code,QRsend))
                {
                    mapiResult.Result = true;
                    mapiResult.State = true;
                }

            }
            catch (Exception ex)
            {
                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }



        /// <summary>
        /// 修改主要回覆單內容
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="QRContent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateQuestionReplyContent")]
        public ApiResult<bool> UpdateQuestionReplyContent(string Code, string QRContent)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;

            try
            {
                if (this._QuestionReplyInterface.UpdateQuestionReplyContent(Code,QRContent))
                {
                    mapiResult.Result = true;
                    mapiResult.State = true;
                }

            }
            catch (Exception ex)
            {
                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }





    }
}
