using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.View
{
    public interface IAttend_View_GetAbsenceTakenView
    {
        ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry);

        ApiResult<string> UpdateAbsenceBalanceLeavehoursView(string guid,decimal useHours);
        ApiResult<string> InsertAbsenceTakenView(AbsDto absDto);
        ApiResult<string> InsertAbsenceOffsetView(AbsdDto absdDto);
    }
}
