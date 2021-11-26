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
    public class FormsAppEmployController : ControllerBase
    {

        private IFormsAppEmployInterface _IFormsAppEmployInterface;

        public FormsAppEmployController(IFormsAppEmployInterface formsAppEmployInterface)
        {
            this._IFormsAppEmployInterface = formsAppEmployInterface;
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
        [Route("GetFormsAppEmployByProcessId")]
        public ApiResult<List<EmployVdb>> GetFormsAppEmployByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<List<EmployVdb>> mapiResult = new ApiResult<List<EmployVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppEmployInterface.GetFormsAppEmployByProcessId(ProcessFlowID, Sign, SignState, Status);
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
