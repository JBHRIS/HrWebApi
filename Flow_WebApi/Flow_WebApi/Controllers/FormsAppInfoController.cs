using JBHRIS.Api.Dto;
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
    public class FormsAppInfoController : ControllerBase
    {

        private IFormsAppInfoInterface _IGetFormsAppInfoInterface;

        public FormsAppInfoController(IFormsAppInfoInterface getFormsAppInfoInterface)
        {
            this._IGetFormsAppInfoInterface = getFormsAppInfoInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetFormsAppInfoList")]
        [HttpGet]
        public ApiResult<List<FormsAppInfoDto>> GetFormsAppInfoList()
        {

            ApiResult<List<FormsAppInfoDto>> mapiResult = new ApiResult<List<FormsAppInfoDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsAppInfoInterface.GetFormsAppInfoList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetFormsAppInfoListByProcessId")]
        [HttpPost]
        public ApiResult<List<FormsAppInfoDto>> GetFormsAppInfoListByProcessId(ProcessList ProcessId)
        {

            ApiResult<List<FormsAppInfoDto>> mapiResult = new ApiResult<List<FormsAppInfoDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsAppInfoInterface.GetFormsAppInfoListByProcessId(ProcessId.ProcessId);
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
