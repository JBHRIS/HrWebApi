using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {

        private IDeptInterface _IDeptInterface;

        public DeptController(IDeptInterface deptInterface)
        {
            this._IDeptInterface = deptInterface;
        }


        /// <summary>
        /// 取得編制部門
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeptEmp")]
        public bool GetDeptEmp()
        {
            return false;
        }

        /// <summary>
        /// 取得編制部門(全部)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeptAll")]
        public bool GetDeptAll()
        {
            return false;
        }


        /// <summary>
        /// 取得簽核部門員工清單(指定階級)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeptaByTree")]
        public bool GetDeptaByTree()
        {
            return false;
        }


        /// <summary>
        /// 取得簽核部門員工清單(工號)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeptaByNobr")]
        public bool GetDeptaByNobr()
        {
            return false;
        }

    }
}
