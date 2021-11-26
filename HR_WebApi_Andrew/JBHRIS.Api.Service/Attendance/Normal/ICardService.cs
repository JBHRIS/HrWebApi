using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface ICardService
    {
        List<CardDto> GetCard(AttendanceEntry attendanceEntry);
        List<CardReasonDto> GetCardReason();
    }
}