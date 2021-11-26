using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Overtime_Normal_GetPeopleOvertime : IOvertime_Normal_GetPeopleOvertime
    {
        private IUnitOfWork _unitOfWork;

        public Overtime_Normal_GetPeopleOvertime(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<string> GetPeopleOvertime(AttendanceEntry attendanceEntry)
        {
            List<string> result = new List<string>();
            var otRepo = _unitOfWork.Repository<Ot>();
            foreach (var emp in attendanceEntry.employeeList.Split(1000))
            {
                result.AddRange(otRepo.Reads(p => emp.Contains(p.Nobr) && p.Bdate >= attendanceEntry.DateBegin && p.Bdate <= attendanceEntry.DateEnd).Select(p => p.Nobr).Distinct().ToList());
            }
            return result.Distinct().ToList();
        }
    }
}
