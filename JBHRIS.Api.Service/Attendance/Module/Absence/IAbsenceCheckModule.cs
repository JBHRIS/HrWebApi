using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Absence
{
    public interface IAbsenceCheckModule
    {
        ApiResult<List<string>> Check(List<CalAbsHoursDto> calAbsHoursDtos,HcodeDto hcodeDto);
    }
}
