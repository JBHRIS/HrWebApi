using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_GetCard
    {
        List<CardDto> GetCard(AttendanceEntry attendanceEntry);
    }
}