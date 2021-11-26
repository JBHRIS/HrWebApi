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
    public class HcodeController : ControllerBase
    {
        private IHcodeInterface _IHcodeInterface;

        public HcodeController(IHcodeInterface hcodeInterface)
        {
            this._IHcodeInterface = hcodeInterface;
        }

        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHcodeList")]
        public bool GetHcodeList()
        {
            return false;
        }

    }
}
