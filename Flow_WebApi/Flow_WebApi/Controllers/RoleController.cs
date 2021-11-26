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
    public class RoleController : ControllerBase
    {


        private IRoleInterface _IRoleInterface;

        public RoleController(IRoleInterface roleInterface)
        {
            this._IRoleInterface = roleInterface;
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetRoleList")]
        public ApiResult<List<RoleDto>> GetRoleList()
        {
            ApiResult<List<RoleDto>> result = new ApiResult<List<RoleDto>>();
            try
            {
                result.Result = this._IRoleInterface.GetRoleList();
                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmpIdByDeptId")]
        public ApiResult<List<string>> GetEmpIdByDeptId(DeptList DeptId)
        {
            ApiResult<List<string>> result = new ApiResult<List<string>>();
            try
            {
                result.Result = this._IRoleInterface.GetEmpIdByDeptId(DeptId.DeptId);
                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRoleListByEmpId")]
        public ApiResult<List<RoleDto>> GetRoleListByEmpId(EmpList EmpId)
        {
            ApiResult<List<RoleDto>> result = new ApiResult<List<RoleDto>>();
            try
            {
                result.Result = this._IRoleInterface.GetRoleListByEmpId(EmpId.EmpId);
                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEmp"></param>
        /// <param name="idRole"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRoleData")]
        public ApiResult<List<RoleRow>> GetRoleData(string idEmp,string idRole)
        {
            ApiResult<List<RoleRow>> result = new ApiResult<List<RoleRow>>();
            try
            {
                result.Result = this._IRoleInterface.GetRoleData(idEmp,idRole);
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
