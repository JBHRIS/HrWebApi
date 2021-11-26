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
    public class FormsAppOTController : ControllerBase
    {


        private IFormAppOTInterface _IFormAppOTInterface;

        public FormsAppOTController(IFormAppOTInterface IFormAppOTInterface)
        {
            this._IFormAppOTInterface = IFormAppOTInterface;
        }

        /// <summary>
        /// 取得加班單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppOTByProcessId")]
        public ApiResult<OTFlowAppRow> GetFormsAppOTByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<OTFlowAppRow> mapiResult = new ApiResult<OTFlowAppRow>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormAppOTInterface.GetFormsAppOTByProcessId(ProcessFlowID, Sign, SignState, Status);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }
        /// <summary>
        /// 取得加班單明細
        /// </summary>
        /// <param name="AutoKey"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppOTByAutoKey")]
        public ApiResult<OTFlowAppsRow> GetFormsAppOTByAutoKey(int AutoKey, string SignState, string Status)
        {
            ApiResult<OTFlowAppsRow> mapiResult = new ApiResult<OTFlowAppsRow>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormAppOTInterface.GetFormsAppOTByAutoKey(AutoKey, SignState, Status);
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
