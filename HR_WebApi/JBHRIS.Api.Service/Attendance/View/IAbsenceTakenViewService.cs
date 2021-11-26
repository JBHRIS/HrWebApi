using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public interface IAbsenceTakenViewService
    {
        ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry);
    }
}
