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
    public class QuestionCategoryController : ControllerBase
    {

        private QuestionCategoryInterFace _QuestionCategoryInterface;

        public QuestionCategoryController(QuestionCategoryInterFace QuestionCategory)
        {
            this._QuestionCategoryInterface = QuestionCategory;
        }

        /// <summary>
        /// 取得回報類型資料
        /// </summary>
        
        /// <returns></returns>
        [HttpGet]
        [Route("GetQuestionCategory")]
        public ApiResult<List<QuestionCategoryVdb>> GetQuestionCategory()
        {
            ApiResult<List<QuestionCategoryVdb>> mapiResult = new ApiResult<List<QuestionCategoryVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._QuestionCategoryInterface.GetQuestionCategory();
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
