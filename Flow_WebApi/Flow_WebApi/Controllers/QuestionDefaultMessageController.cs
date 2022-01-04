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
    public class QuestionDefaultMessageController : ControllerBase
    {

        private QuestionDefaultMessageInterFace _QuestionDefaultMessageInterface;

        public QuestionDefaultMessageController(QuestionDefaultMessageInterFace questionDefaultMessage)
        {
            this._QuestionDefaultMessageInterface = questionDefaultMessage;
        }

        /// <summary>
        /// 取得回報單預設訊息
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionDefaultMessage")]
        public ApiResult<List<QuestionDefaultMessageVdb>> GetQuestionDefaultMessage(string Code)
        {
            ApiResult<List<QuestionDefaultMessageVdb>> mapiResult = new ApiResult<List<QuestionDefaultMessageVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionDefaultMessageInterface.GetQuestionDefaultMessage(Code);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }

        /// <summary>
        /// 根據CompanyId取得回傳內容
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionDefaultMessageByCompanyId")]
        public ApiResult<List<QuestionDefaultMessageVdb>> GetQuestionDefaultMessageByRoleKey(string CompanyId)
        {
            ApiResult<List<QuestionDefaultMessageVdb>> mapiResult = new ApiResult<List<QuestionDefaultMessageVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionDefaultMessageInterface.GetQuestionDefaultMessageByCompanyId(CompanyId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }


        /// <summary>
        /// 新增回報單預設訊息
        /// </summary>
        /// <param name="vdb"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertQuetionDefaultMessage")]
        public ApiResult<bool> InsertQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;
            
            try
            {
                if (this._QuestionDefaultMessageInterface.InsertQuestionDefaultMessage(vdb))
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
        /// 更新回報單預設訊息
        /// </summary>
        /// <param name="vdb"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateQuestionDefaultMessage")]
        public ApiResult<bool> UpdateQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;

            try
            {
                if (this._QuestionDefaultMessageInterface.UpdateQuestionDefaultMessage(vdb))
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
        /// 刪除回報單預設訊息
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteQuestionDefaultMessage")]
        public ApiResult<bool> DeleteQuestionDefaultMessage(string Code)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;

            try
            {
                if (this._QuestionDefaultMessageInterface.DeleteQuestionDefaultMessage(Code))
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
