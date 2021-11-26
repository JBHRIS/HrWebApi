using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Transcard
{
    public class ShiftGenerate_TranscardModule : ITranscardModule
    {

        public ShiftGenerate_TranscardModule()
        {
           
        }
        public ApiResult<string> Run(TranscardEntry transcardEntry)
        {
            string msg = "產生班表";
            Console.WriteLine(msg);
            var result = new ApiResult<string>();
            result.Result = msg;
            return result;
        }
    }
}
