using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.View
{
    public interface IAttend_View_GetOvertimeSearch
    {
        ApiResult<List<OverTimeSearchViewDto>> GetOverTimeSearchView(OverTimeSearchViewEntry overTimeSearchViewEntry);
        List<OvertimeReasonDto> GetOvertimeReason();
        ApiResult<string> CheckOverTimeNoRepeat(OvertimeDto overtimeDto);
        ApiResult<string> SaveOvertime(List<OvertimeDto> overtimeDtos, string KeyMan);
    }
}
