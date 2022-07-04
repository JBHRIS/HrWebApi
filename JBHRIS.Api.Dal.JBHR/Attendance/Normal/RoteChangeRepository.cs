using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class RoteChangeRepository : IRoteChangeRepository
    {
        private IUnitOfWork _unitOfWork;
        public RoteChangeRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<RoteChangeDto> GetRoteChange(AttendanceEntry attendanceEntry)
        {
            var result = new List<RoteChangeDto>();
            foreach (var item in attendanceEntry.EmployeeList.Split(2100))
            {
                var RoteChangesByEntry = from rchg in _unitOfWork.Repository<Rotechg>().Reads()
                                   join b in _unitOfWork.Repository<Base>().Reads() on rchg.Nobr equals b.Nobr
                                   join r in _unitOfWork.Repository<Rote>().Reads() on rchg.Rote equals r.Rote1
                                   where item.Contains(rchg.Nobr) && attendanceEntry.DateBegin <= rchg.Adate && rchg.Adate <= attendanceEntry.DateEnd
                                   select new RoteChangeDto
                                   {
                                       EmployeeID = rchg.Nobr,
                                       EmployeeName = b.NameC,
                                       RoteChangeDate = rchg.Adate,
                                       Rote = r.RoteDisp,
                                       RoteName = r.Rotename,
                                       AutoKey = rchg.Autokey
                                   };
                result.AddRange(RoteChangesByEntry);
            }
            return result.ToList();
        }
    }
}
