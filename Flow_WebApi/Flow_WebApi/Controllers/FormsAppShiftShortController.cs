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
    public class FormsAppShiftShortController : ControllerBase
    {

        private IFormsAppShiftShortInterface _IFormsAppShiftShortInterface;

        public FormsAppShiftShortController(IFormsAppShiftShortInterface formsAppShiftShortInterface)
        {
            this._IFormsAppShiftShortInterface = formsAppShiftShortInterface;
        }

        /// <summary>
        /// 取得換班單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppShiftShortByProcessId")]
        public ApiResult<List<ShiftShortVdb>> GetFormsAppShiftShortByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<List<ShiftShortVdb>> mapiResult = new ApiResult<List<ShiftShortVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppShiftShortInterface.GetFormsAppShiftShortByProcessId(ProcessFlowID, Sign, SignState, Status);
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
