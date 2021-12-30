using JBHRIS.Api.Dal.Interface;
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
    public class SystemUserController : ControllerBase
    {

        private SystemUserInterFace _SystemUserInterface;

        public SystemUserController(SystemUserInterFace SystemUser)
        {
            this._SystemUserInterface = SystemUser;
        }

        /// <summary>
        /// 查詢所有系統商人員
        /// </summary>   
        /// <returns></returns>
        [HttpGet]
        [Route("GetSystemUser")]
        public ApiResult<List<SystemUserVdb>> GetSystemUser()
        {
            ApiResult<List<SystemUserVdb>> mapiResult = new ApiResult<List<SystemUserVdb>>();

            mapiResult.State = false;
            try
            {
                mapiResult.Result = this._SystemUserInterface.GetSystemUser();
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
