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
    public class OtrcdController : ControllerBase
    {
        private IOtrcdInterface _IOtrcdInterface;
        public OtrcdController(IOtrcdInterface otrcdInterface)
        {
            this._IOtrcdInterface = otrcdInterface;
        }


        /// <summary>
        /// 取得加班原因
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOtrcdList")]
        public bool GetOtrcdList()
        {
            return false;
        }

    }
}
