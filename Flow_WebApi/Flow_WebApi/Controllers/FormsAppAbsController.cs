using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Service.Interface;
using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.Forms
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsAppAbsController : ControllerBase
    {

        private IFormsAppAbsInterface _IGetFormsAppAbsInterface;

        public FormsAppAbsController(IFormsAppAbsInterface getFormsAppAbsInterface)
        {
            this._IGetFormsAppAbsInterface = getFormsAppAbsInterface;        
        }

        [Route("GetFormsAppAbsUseListByProcessId")]
        [HttpPost]
        public ApiResult<List<FormsAppAbsUseDto>> GetFormsAppAbsUseListByProcessId(ProcessList ProcessId)
        {

            ApiResult<List<FormsAppAbsUseDto>> mapiResult = new ApiResult<List<FormsAppAbsUseDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsAppAbsInterface.GetFormsAppAbsUseListByProcessId(ProcessId.ProcessId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }


        /// <summary>
        /// 取得請假單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppAbsByProcessId")]
        public ApiResult<AbsFlowAppRow> GetFormsAppAbsByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<AbsFlowAppRow> mapiResult = new ApiResult<AbsFlowAppRow>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IGetFormsAppAbsInterface.GetFormsAppAbsByProcessId( ProcessFlowID,  Sign,  SignState,  Status);
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
