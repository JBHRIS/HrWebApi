using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class OvertimeService : IOvertimeService
    {
        private IOvertime_Normal_GetOvertime _overtime_Normal_GetOvertime;
        private IOvertime_Normal_GetOvertimeReason _overtime_Normal_GetOvertimeReason;
        private IOvertime_Normal_GetOvertimeType _overtime_Normal_GetOvertimeType;
        private IOvertime_Normal_GetPeopleOvertime _overtime_Normal_GetPeopleOvertime;

        public OvertimeService(IOvertime_Normal_GetOvertime overtime_Normal_GetOvertime, IOvertime_Normal_GetOvertimeReason overtime_Normal_GetOvertimeReason
            , IOvertime_Normal_GetOvertimeType overtime_Normal_GetOvertimeType, IOvertime_Normal_GetPeopleOvertime overtime_Normal_GetPeopleOvertime)
        {
            _overtime_Normal_GetOvertime = overtime_Normal_GetOvertime;
            _overtime_Normal_GetOvertimeReason = overtime_Normal_GetOvertimeReason;
            _overtime_Normal_GetOvertimeType = overtime_Normal_GetOvertimeType;
            _overtime_Normal_GetPeopleOvertime = overtime_Normal_GetPeopleOvertime;
        }
        public List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry)
        {
            return _overtime_Normal_GetOvertime.GetOvertime(attendanceEntry);
        }

        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            return _overtime_Normal_GetOvertimeReason.GetOvertimeReason();
        }

        public List<OvertimeTypeDto> GetOvertimeType()
        {
            return _overtime_Normal_GetOvertimeType.GetOvertimeType();
        }

        public List<string> GetPeopleOvertime(AttendanceEntry attendanceEntry)
        {
            return _overtime_Normal_GetPeopleOvertime.GetPeopleOvertime(attendanceEntry);
        }
    }
}
