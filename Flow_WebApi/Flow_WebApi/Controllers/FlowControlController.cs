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
    public class FlowControlController : ControllerBase
    {

        private IFlowControlInterface _IGetFlowControlInterface;

        public FlowControlController(IFlowControlInterface getFlowControlInterface)
        {
            this._IGetFlowControlInterface = getFlowControlInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetFlowControlCodeList")]
        [HttpGet]
        public ApiResult<List<FlowControlCodeDto>> GetFlowControlCodeList()
        {

            ApiResult<List<FlowControlCodeDto>> mapiResult = new ApiResult<List<FlowControlCodeDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFlowControlInterface.GetFlowControlCodeList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetFormsAppListById")]
        [HttpPost]
        public ApiResult<List<FlowControlDto>> GetFormsListByCode(FlowControlCondition Cond)
        {

            ApiResult<List<FlowControlDto>> mapiResult = new ApiResult<List<FlowControlDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFlowControlInterface.GetFlowControlListByCode(Cond);
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
