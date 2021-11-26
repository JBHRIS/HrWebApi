using JBHRIS.Api.Dto;
using JBHRIS.Api.Service.Interface;
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
    public class TestController : ControllerBase
    {

        private ITestInterface _ITestInterface;

        public TestController(ITestInterface testInterface)
        {
            this._ITestInterface = testInterface;
        }


        /// <summary>
        /// 測試案例
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetDeptList")]
        [HttpGet]
        public ApiResult<List<ItemKeyValue>> GetDeptList()
        {

            ApiResult<List<ItemKeyValue>> mapiResult = new ApiResult<List<ItemKeyValue>>();


            mapiResult.State = false;
            try
            {

                mapiResult.Result = this._ITestInterface.GetDeptList();
                mapiResult.State = true;
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;


        }


        [Route("GetTestList")]
        [HttpGet]
        public string GetTestList([FromQuery] List<string> rdlist)
        {
            return String.Join(", ", rdlist.ToArray());
        }



        [Route("GetTestClass")]
        [HttpGet]
        public string GetTestClass([FromQuery] TestClass DataList)
        {
            return string.Format("Nobr : {0} ,Dept : {1}", String.Join(",", DataList.NobrList.ToArray()), String.Join(",", DataList.DeptList.ToArray()));

                  
        }

        [Route("PostTestList")]
        [HttpPost]
        public string PostTestList( List<string> rdlist)
        {
            return String.Join(", ", rdlist.ToArray());
        }



        [Route("PostTestClass")]
        [HttpPost]
        public string PostTestClass( TestClass DataList)
        {
            return string.Format("Nobr : {0} ,Dept : {1}", String.Join(",", DataList.NobrList.ToArray()), String.Join(",", DataList.DeptList.ToArray()));


        }


        public class TestClass
        {
            public List<string> NobrList { get; set; }

            public List<string> DeptList { get; set; }
        }


    }
}
