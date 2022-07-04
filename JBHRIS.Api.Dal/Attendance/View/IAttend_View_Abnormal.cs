using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.View
{
    public interface IAttend_View_Abnormal
    {
        List<AbnormalViewDto> GetAbnormalViewDtos(AttendanceEntry attendanceEntry);
        ApiResult<string> SaveAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos,string KeyMan);
    }
}
