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
    public class OverTimeRepository : IOverTimeRepository
    {
        private IUnitOfWork _unitOfWork;
        public OverTimeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry)
        {
            var result = new List<OvertimeDto>();
            foreach (var item in attendanceEntry.EmployeeList.Split(2100))
            {
                var OverTimesByEntry = from ot in _unitOfWork.Repository<Ot>().Reads()
                                       join b in _unitOfWork.Repository<Base>().Reads() on ot.Nobr equals b.Nobr
                                       join r in _unitOfWork.Repository<Rote>().Reads() on ot.OtRote equals r.Rote1
                                       join otr in _unitOfWork.Repository<Otrcd>().Reads() on ot.Otrcd equals otr.Otrcd1
                                       where item.Contains(ot.Nobr) && attendanceEntry.DateBegin <= ot.Bdate && ot.Bdate <= attendanceEntry.DateEnd
                                       select new OvertimeDto
                                       {
                                           EmployeeID = ot.Nobr,
                                           EmployeeName = b.NameC,
                                           OverTimeDate = ot.Bdate,
                                           BeginTime = ot.Btime,
                                           EndTime = ot.Etime,
                                           OverTimeReason = otr.Otrname,
                                           OverTimeRote = r.RoteDisp,
                                           OverTimeRoteName = r.Rotename,
                                           OverTimeHours =ot.OtHrs,
                                           RestTimeHours = ot.RestHrs,
                                           SerialNumber = ot.Serno
                                       };
                result.AddRange(OverTimesByEntry);
            }
            return result.ToList();
        }
    }
}
