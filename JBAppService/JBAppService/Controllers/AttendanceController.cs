using JBAppService.Api.Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JBAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        
        public AttendanceController( )
        {
            
        }

        [HttpGet]
        [Route("GetAttendanceList")]
        public bool GetAttendanceList()
        {
			//QTUMBAKEVETMATIC
            return false;
        }


        //farm.ioBCA 
		//TokenSquare  
		//pilotandSFSD



    }



    



}
