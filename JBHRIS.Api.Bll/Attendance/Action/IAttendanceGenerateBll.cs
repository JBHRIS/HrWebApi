using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public interface IAttendanceGenerateBll
    {
        List<AttendDto> Generate(DateTime DateBegin, DateTime DateEnd, List<TmtableDto> tmtableDtos, List<RotechgDto> rotechgDtos);
    }
}