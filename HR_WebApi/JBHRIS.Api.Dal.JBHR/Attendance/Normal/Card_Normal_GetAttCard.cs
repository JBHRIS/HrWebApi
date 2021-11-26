using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.JBHR.Repository;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_GetAttCard : ICard_Normal_GetAttCard
    {
        private IUnitOfWork _unitOfWork;
        public Card_Normal_GetAttCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AttendCardDto> GetAttendCard(AttendanceEntry attendanceEntry)
        {
            var attendCards = from card in _unitOfWork.Repository<Attcard>().Reads()
                              where attendanceEntry.EmployeeList.Contains(card.Nobr)
                              && attendanceEntry.DateBegin <= card.Adate
                              && card.Adate <= attendanceEntry.DateEnd
                              select new AttendCardDto()
                              {
                                  EmployeeID = card.Nobr,
                                  PuchInDate = card.Adate,
                                  PuchInOnTime = card.T1,
                                  PuchInOffTime = card.T2,
                                  Code = card.Code,
                                  Ser = card.Ser,
                                  KeyMan = card.KeyMan,
                                  KeyDate = card.KeyDate,
                                  Dd1 = card.Dd1,
                                  Dd2 = card.Dd2,
                                  Lost1 = card.Lost1,
                                  Lost2 = card.Lost2,
                                  Tt1 = card.Tt1,
                                  Tt2 = card.Tt2,
                                  Nomody = card.Nomody
                              };

            List<AttendCardDto> attendCardDtos = new List<AttendCardDto>();
            attendCardDtos = attendCards.ToList();

            return attendCardDtos;
        }
    }
}
