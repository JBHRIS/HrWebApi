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
    public class FormsAppAbnController : ControllerBase
    {

        private IFormsAppAbnInterface _IFormsAppAbnInterface;

        public FormsAppAbnController(IFormsAppAbnInterface formsAppAbnInterface)
        {
            this._IFormsAppAbnInterface = formsAppAbnInterface;
        }

        /// <summary>
        /// 取得註記單明細
        /// </summary>
        /// <param name="ProcessFlowID"></param>
        /// <param name="Sign"></param>
        /// <param name="SignState"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFormsAppAbnByProcessId")]
        public ApiResult<List<AbnVdb>> GetFormsAppAbnByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            ApiResult<List<AbnVdb>> mapiResult = new ApiResult<List<AbnVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._IFormsAppAbnInterface.GetFormsAppAbnByProcessId(ProcessFlowID, Sign, SignState, Status);
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
