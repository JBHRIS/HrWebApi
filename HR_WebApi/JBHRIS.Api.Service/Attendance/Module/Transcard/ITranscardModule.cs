using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Transcard
{
    public interface ITranscardModule
    {
        ApiResult<string> Run(TranscardEntry transcardEntry);
    }
}
