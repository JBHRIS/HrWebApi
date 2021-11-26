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
    public class FormsAppShiftLongController : ControllerBase
    {

        private IFormsAppShiftLongInterface _IFormsAppShiftLongInterface;

        public FormsAppShiftLongController(IFormsAppShiftLongInterface formsAppShiftLongInterface)
        {
            this._IFormsAppShiftLongInterface = formsAppShiftLongInterface;
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
        [Route("GetFormsAppShiftLongByProcessId")]
        public ApiResult<List<ShiftLongVdb>> GetFormsAppShiftLongByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<List<ShiftLongVdb>> mapiResult = new ApiResult<List<ShiftLongVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppShiftLongInterface.GetFormsAppShiftLongByProcessId(ProcessFlowID, Sign, SignState, Status);
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
