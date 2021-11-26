using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Transcard
{
    public class CheckAttendError_TranscardModule : ITranscardModule
    {
        public ApiResult<string> Run(TranscardEntry transcardEntry)
        {
            string msg = "判斷異常";
            Console.WriteLine(msg);
            var result = new ApiResult<string>();
            result.Result = msg;
            return result;
        }
    }
}
