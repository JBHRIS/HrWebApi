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
    public class QuestionMainController : ControllerBase
    {

        private QuestionMainInterFace _QuestionMainInterface;

        public QuestionMainController(QuestionMainInterFace QuestionMain)
        {
            this._QuestionMainInterface = QuestionMain;
        }

        /// <summary>
        /// 查詢所有提問單
        /// </summary>
        /// <param name="User"></param>
        /// <param name="CompanyId"></param>
        /// <param name="sNobr"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionMain")]
        public ApiResult<List<QuestionMainVdb>> GetQuestionMain()
        {
            ApiResult<List<QuestionMainVdb>> mapiResult = new ApiResult<List<QuestionMainVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionMainInterface.GetQuestionMain();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }



        /// <summary>
        /// 取得該工號所有提問單
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="sNobr"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionMainByEmpID")]
        public ApiResult<List<QuestionMainVdb>> GetQuestionMainByEmpID(string sNobr, string CompanyId = "")
        {
            ApiResult<List<QuestionMainVdb>> mapiResult = new ApiResult<List<QuestionMainVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionMainInterface.GetQuestionMainByEmpID(CompanyId, sNobr);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }





        /// <summary>
        /// 根據Code查詢提問單
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionMainByCode")]
        public ApiResult<List<QuestionMainVdb>> GetQuestionMainByCode(string Code)
        {
            ApiResult<List<QuestionMainVdb>> mapiResult = new ApiResult<List<QuestionMainVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionMainInterface.GetQuestionMainByCode(Code);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }


        /// <summary>
        /// 取得該公司所有提問單
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionMainByCompany")]
        public ApiResult<List<QuestionMainVdb>> GetQuestionMainByCompany(string CompanyId="")
        {
            ApiResult<List<QuestionMainVdb>> mapiResult = new ApiResult<List<QuestionMainVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionMainInterface.GetQuestionMainByCompany(CompanyId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }








        /// <summary>
        /// 新增提問單
        /// </summary>
        /// <param name="vdb"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertQuestionMain")]
        public ApiResult<bool> InsertQuestionMain(QuestionMainVdb vdb)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;
            
            try
            {
                if (this._QuestionMainInterface.InsertQuestionMain(vdb))
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
        /// 更新提問單
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="vdb"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateQuestionMain")]
        public ApiResult<bool> UpdateQuestionMain(string Code, QuestionMainVdb vdb)
        {
            ApiResult<bool> mapiResult = new ApiResult<bool>();

            mapiResult.State = false;

            try
            {
                if (this._QuestionMainInterface.UpdateQuestionMain(Code,vdb))
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



        ///// <summary>
        ///// 刪除回報單預設訊息
        ///// </summary>
        ///// <param name="Code"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("DeleteQuestionMain")]
        //public ApiResult<bool> DeleteQuestionMain(string Code)
        //{
        //    ApiResult<bool> mapiResult = new ApiResult<bool>();

        //    mapiResult.State = false;

        //    try
        //    {
        //        if (this._QuestionMainInterface.DeleteQuestionMain(Code))
        //        {
        //            mapiResult.Result = true;
        //            mapiResult.State = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        mapiResult.Message = ex.Message;
        //    }

        //    return mapiResult;
        //}





    }
}
