using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class OvertimeService : IOvertimeService
    {
        private IOverTimeRepository _overTimeRepository;
        private ILogger _logger;
        private IOvertime_Normal_GetOvertime _overtime_Normal_GetOvertime;
        private IOvertime_Normal_GetOvertimeReason _overtime_Normal_GetOvertimeReason;
        private IOvertime_Normal_GetOvertimeType _overtime_Normal_GetOvertimeType;
        private IOvertime_Normal_GetPeopleOvertime _overtime_Normal_GetPeopleOvertime;

        public OvertimeService(IOverTimeRepository overTimeRepository,ILogger logger)
        {
            _overTimeRepository = overTimeRepository;
            _logger = logger;
        }
        public OvertimeService(IOvertime_Normal_GetOvertime overtime_Normal_GetOvertime, IOvertime_Normal_GetOvertimeReason overtime_Normal_GetOvertimeReason
            , IOvertime_Normal_GetOvertimeType overtime_Normal_GetOvertimeType, IOvertime_Normal_GetPeopleOvertime overtime_Normal_GetPeopleOvertime)
        {
            _overtime_Normal_GetOvertime = overtime_Normal_GetOvertime;
            _overtime_Normal_GetOvertimeReason = overtime_Normal_GetOvertimeReason;
            _overtime_Normal_GetOvertimeType = overtime_Normal_GetOvertimeType;
            _overtime_Normal_GetPeopleOvertime = overtime_Normal_GetPeopleOvertime;
        }
        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        public List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry)
        {
            _logger.Info("開始呼叫OverTimeRepository.GetOvertime");
            return _overTimeRepository.GetOvertime(attendanceEntry);
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
