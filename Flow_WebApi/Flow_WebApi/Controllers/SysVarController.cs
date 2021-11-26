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
    public class SysVarController : ControllerBase
    {
        private ISysVarInterface _ISysVarInterface;

        public SysVarController(ISysVarInterface SysVarInterface)
        {
            this._ISysVarInterface = SysVarInterface;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetSysVarList")]
        public ApiResult<List<SysVarDto>> GetSysVarList()
        {
            ApiResult<List<SysVarDto>> result = new ApiResult<List<SysVarDto>>();
            try
            {
                result.Result = this._ISysVarInterface.GetSysVarList();
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
