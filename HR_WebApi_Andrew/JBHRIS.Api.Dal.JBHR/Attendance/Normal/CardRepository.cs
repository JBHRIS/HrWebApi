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
    public class CardRepository : ICardRepository
    {
        private IUnitOfWork _unitOfWork;
        public CardRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            var result = new List<CardDto>();
            foreach (var item in attendanceEntry.EmployeeList.Split(2100))
            {
                var CardsByEntry = from a in _unitOfWork.Repository<Card>().Reads()
                                   join b in _unitOfWork.Repository<Cardlosd>().Reads() on a.Reason equals b.Code
                                   where item.Contains(a.Nobr) && attendanceEntry.DateBegin <= a.Adate && a.Adate <= attendanceEntry.DateEnd
                                   select new CardDto
                                   {
                                       EmployeeID = a.Nobr,
                                       PuchInDate = a.Adate,
                                       PuchInTime = a.Ontime,
                                       Source = a.Code,
                                       Forget = a.Los,
                                       ForgetReason = b.Descr,
                                       Remarks = a.Meno
                                   };
                result.AddRange(CardsByEntry);
            }
            return result;
        }
    }
}
