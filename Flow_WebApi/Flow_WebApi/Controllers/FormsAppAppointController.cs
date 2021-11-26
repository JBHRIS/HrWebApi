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
    public class FormsAppAppointController : ControllerBase
    {

        private IFormsAppAppointInterface _IFormsAppAppointInterface;

        public FormsAppAppointController(IFormsAppAppointInterface formsAppAppointInterface)
        {
            this._IFormsAppAppointInterface = formsAppAppointInterface;
        }

        /// <summary>
        /// 取得任用單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppAppointByProcessId")]
        public ApiResult<List<AppointVdb>> GetFormsAppAppointByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<List<AppointVdb>> mapiResult = new ApiResult<List<AppointVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppAppointInterface.GetFormsAppAppointByProcessId(ProcessFlowID, Sign, SignState, Status);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }
        /// <summary>
        /// HR取得任用單明細
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppAppointForHR")]
        public ApiResult<List<AppointVdb>> GetFormsAppAppointForHR()
        {
            ApiResult<List<AppointVdb>> mapiResult = new ApiResult<List<AppointVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppAppointInterface.GetFormsAppAppointForHR();
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
