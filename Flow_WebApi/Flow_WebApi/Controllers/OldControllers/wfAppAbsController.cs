using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.OldControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class wfAppAbsController : ControllerBase
    {
        public wfAppAbsController()
        {

        }


        [HttpGet]
        [Route("getabs")]
        public string getabs()
        {
            return "";
        }
    }
}
