using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbnormalService : IAbnormalService
    {
        private IAttend_View_Abnormal _attend_View_Abnormal;
        public AbnormalService(IAttend_View_Abnormal attend_View_Abnormal)
        {
            _attend_View_Abnormal = attend_View_Abnormal;
        }
        public List<AbnormalViewDto> GetAbnormalViewDtos(AttendanceEntry attendanceEntry)
        {
            return _attend_View_Abnormal.GetAbnormalViewDtos(attendanceEntry);
        }

        public List<AbnormalViewDto> GetAbnormalViewDtosByCheckFalse(AttendanceEntry attendanceEntry)
        {
            List<AbnormalViewDto> reData = null;
            attendanceEntry.DateBegin = attendanceEntry.DateBegin.Date;
            attendanceEntry.DateEnd = attendanceEntry.DateEnd.Date;
            var data = _attend_View_Abnormal.GetAbnormalViewDtos(attendanceEntry);
            if(data != null && data.Count > 0)
            {
                reData = new List<AbnormalViewDto>();
                foreach(var d in data)
                {
                    if (!d.IsCheck)
                    {
                        reData.Add(d);
                    }
                }
            }
            return reData;
        }

        public ApiResult<string> SaveAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos,string KeyMan)
        {
            return _attend_View_Abnormal.SaveAbnormalAttendanceComment(abnormalViewDtos, KeyMan);
        }
    }
}
