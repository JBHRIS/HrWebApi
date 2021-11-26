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

namespace Flow_WebApi.Controllers.Emp
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {

        private IGetEmpInterface _IGetEmpInterface;

        public EmpController(IGetEmpInterface  getEmpInterface)
        {
            this._IGetEmpInterface = getEmpInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetEmpList")]
        [HttpGet]
        public ApiResult<List<EmpDto>> GetEmpList()
        {

            ApiResult<List<EmpDto>> mapiResult = new ApiResult<List<EmpDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetEmpInterface.GetEmpList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetEmpListByEmpId")]
        [HttpPost]
        public ApiResult<List<EmpDto>> GetEmpListByEmpId(EmpList EmpIdList)
        {

            ApiResult<List<EmpDto>> mapiResult = new ApiResult<List<EmpDto>>();

            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IGetEmpInterface.GetEmpListByEmpId(EmpIdList.EmpId);
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
