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
    public class FormsController : ControllerBase
    {

        private IFormsInterface _IGetFormsInterface;

        public FormsController(IFormsInterface getFormsInterface)
        {
            this._IGetFormsInterface = getFormsInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetFormsList")]
        [HttpGet]
        public ApiResult<List<FormsDto>> GetFormsList()
        {

            ApiResult<List<FormsDto>> mapiResult = new ApiResult<List<FormsDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsInterface.GetFormsList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetFormsListByCode")]
        [HttpPost]
        public ApiResult<List<FormsDto>> GetFormsListByCode(CodeList CodeId)
        {

            ApiResult<List<FormsDto>> mapiResult = new ApiResult<List<FormsDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsInterface.GetFormsListByCode(CodeId.CodeId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }
        [Route("GetProcessID")]
        [HttpGet]
        public ApiResult<int> GetPorcessID()
        {

            ApiResult<int> mapiResult = new ApiResult<int>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsInterface.GetProcessID();
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
