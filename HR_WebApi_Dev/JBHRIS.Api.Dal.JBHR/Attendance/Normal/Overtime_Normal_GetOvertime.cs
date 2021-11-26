using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Overtime_Normal_GetOvertime : IOvertime_Normal_GetOvertime
    {
        private IUnitOfWork _unitOfWork;

        public Overtime_Normal_GetOvertime(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry)
        {
            List<OvertimeDto> result = new List<OvertimeDto>();
            var otRepo = _unitOfWork.Repository<Ot>();
            foreach (var emp in attendanceEntry.employeeList.Split(1000))
            {
                result.AddRange(otRepo.Reads(p => emp.Contains(p.Nobr) && p.Bdate >= attendanceEntry.DateBegin && p.Bdate <= attendanceEntry.DateEnd).Select(p => new OvertimeDto
                {
                    EmployeeId = p.Nobr,
                    OvertimeDate = p.Bdate,
                    BeginTime = p.Btime,
                    EndTime = p.Etime,
                    TotalHours = p.TotHours,
                    OvertimeHours = p.OtHrs,
                    RestHours = p.RestHrs,
                    CreateTime = p.KeyDate,
                    CreateMan = p.KeyMan,
                    OvertimeRote = p.OtRote
                }));
            }
            return result;
        }
    }
}
