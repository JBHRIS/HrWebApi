using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
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
    public class ProcessIdController : ControllerBase
    {


        private IProcessIdInterface _IProcessIdInterface;

        public ProcessIdController(IProcessIdInterface processIdInterface)
        {
            this._IProcessIdInterface = processIdInterface;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetProcessId")]
        public ApiResult<int> GetProcessId()
        {
            ApiResult<int> result = new ApiResult<int>();
            try
            {
                result.Result = this._IProcessIdInterface.GetProcessId();
                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }
    }
}
