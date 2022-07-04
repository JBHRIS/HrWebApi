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
                var CardsByEntry = from c in _unitOfWork.Repository<Card>().Reads()
                                   join cl in _unitOfWork.Repository<Cardlosd>().Reads() on c.Reason equals cl.Code
                                   into cclgrp
                                   from cclg in cclgrp.DefaultIfEmpty()
                                   where item.Contains(c.Nobr) && attendanceEntry.DateBegin <= c.Adate && c.Adate <= attendanceEntry.DateEnd
                                   select new CardDto
                                   {
                                       EmployeeID = c.Nobr,
                                       PuchInDate = c.Adate,
                                       PuchInTime = c.Ontime,
                                       Source = c.Code,
                                       Forget = c.Los,
                                       ForgetReason = cclg.Descr,
                                       Remarks = c.Meno,
                                       IsAddForgetTime = cclg.Att,
                                       Code = c.Code
                                   };
                result.AddRange(CardsByEntry);
            }
            return result;
        }
    }
}
