using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Transcard
{
    public class TranslateCardToAttcard_TranscardModule : ITranscardModule
    {
        public ApiResult<string> Run(TranscardEntry transcardEntry)
        {
            string msg = "轉換刷卡";
            Console.WriteLine(msg);
            var result = new ApiResult<string>();
            result.Result = msg;
            return result;
        }
    }
}
