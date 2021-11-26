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
    public class DeptController : ControllerBase
    {

        private IDeptInterface _IDeptInterface;

        public DeptController(IDeptInterface FlowInterface)
        {
            this._IDeptInterface = FlowInterface;        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetDeptList")]
        [HttpGet]
        public ApiResult<List<DeptDto>> GetDeptList()
        {

            ApiResult<List<DeptDto>> mapiResult = new ApiResult<List<DeptDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IDeptInterface.GetDeptList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetDeptListById")]
        [HttpPost]
        public ApiResult<List<DeptDto>> GetDeptListById(DeptList DeptId)
        {

            ApiResult<List<DeptDto>> mapiResult = new ApiResult<List<DeptDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IDeptInterface.GetDeptListById(DeptId.DeptId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }
        [Route("GetDeptListAllByDeptId")]
        [HttpPost]
        public ApiResult<List<DeptDto>> GetDeptListAllByDeptId(DeptList DeptId)
        {

            ApiResult<List<DeptDto>> mapiResult = new ApiResult<List<DeptDto>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IDeptInterface.GetDeptListAllByDeptId(DeptId.DeptId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }

        [Route("GetDeptListAllByEmpId")]
        [HttpPost]
        public ApiResult<List<string>> GetDeptListAllByEmpId(EmpList EmpId)
        {

            ApiResult<List<string>> mapiResult = new ApiResult<List<string>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IDeptInterface.GetDeptListAllByEmpId(EmpId.EmpId);
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }

        [Route("GetDeptListByEmpId")]
        [HttpPost]
        public ApiResult<List<string>> GetDeptListByEmpId(EmpList EmpId)
        {

            ApiResult<List<string>> mapiResult = new ApiResult<List<string>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._IDeptInterface.GetDeptListByEmpId(EmpId.EmpId);
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
