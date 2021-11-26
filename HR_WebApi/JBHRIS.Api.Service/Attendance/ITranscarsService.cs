using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface ITranscardService
    {
        ApiResult<string> Run(TranscardEntry transecardEntry);
    }
}
