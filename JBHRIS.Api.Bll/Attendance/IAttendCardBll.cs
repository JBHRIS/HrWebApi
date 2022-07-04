using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public interface IAttendCardBll
    {
        List<AttendRangeDto> GetAttendCardRange(List<AttendRangeEntryDto> attenndRangeEntryDtos);
        List<AttendRangeCardDto> GetAttCard(List<AttendRangeDto> attenndRangeDtos, List<CardDto> cardDtos);
        decimal CalLateMin(DateTime roteOnTime, DateTime roteOffTime, List<Tuple<DateTime, DateTime>> roteRestList, DateTime? cardOnTime);
        decimal CalEarMin(DateTime roteOnTime, DateTime roteOffTime, List<Tuple<DateTime, DateTime>> roteRestList, DateTime? cardOffTime);
        bool IsAbsenteeism(DateTime? cardOnTime, DateTime? cardOffTime);
    }
}
