using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using JBHRIS.Api.Service.Attendance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_WebApi.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscardController : Controller
    {
        private ITranscardService _transcardService;

        public TranscardController(ITranscardService transcardService)
        {
            _transcardService = transcardService;
        }
        [Route("")]
        [HttpPost]
        public ApiResult<string> Index()
        {
            return _transcardService.Run(new TranscardEntry { });
        }
    }
}
