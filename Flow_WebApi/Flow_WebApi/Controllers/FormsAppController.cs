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
    public class FormsAppController : ControllerBase
    {

        private IFormsAppInterface _IGetFormsAppInterface;

        public FormsAppController(IFormsAppInterface getFormsAppInterface)
        {
            this._IGetFormsAppInterface = getFormsAppInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetFormsAppList")]
        [HttpGet]
        public ApiResult<List<FormsAppDto>> GetFormsAppList()
        {

            ApiResult<List<FormsAppDto>> mapiResult = new ApiResult<List<FormsAppDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsAppInterface.GetFormsAppList();
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
        public ApiResult<List<FormsAppDto>> GetFormsListByCode(IdList Id)
        {

            ApiResult<List<FormsAppDto>> mapiResult = new ApiResult<List<FormsAppDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetFormsAppInterface.GetFormsAppListById(Id.Id);
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
