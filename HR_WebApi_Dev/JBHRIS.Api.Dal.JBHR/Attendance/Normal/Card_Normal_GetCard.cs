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
    public class Card_Normal_GetCard : ICard_Normal_GetCard
    {
        private IUnitOfWork _unitOfWork;

        public Card_Normal_GetCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            var cardRepo = _unitOfWork.Repository<Card>();
            List<CardDto> result = new List<CardDto>();
            foreach (var emp in attendanceEntry.employeeList.Split(1000))
            {
                result.AddRange(cardRepo.Reads(p => emp.Contains(p.Nobr)
                && p.Adate >= attendanceEntry.DateBegin && p.Adate <= attendanceEntry.DateEnd)
                    .Select(p => new CardDto
                    {
                        AttendanceDate = p.Adate,
                        CardNumber = p.Cardno,
                        Source = p.Code,
                        IpAddress = p.Ipadd,
                        CreateTime = p.KeyDate,
                        CreateMan = p.KeyMan,
                        IsForget = p.Los,
                        Remark = p.Meno,
                        EmployeeId = p.Nobr,
                        IsLock = p.NotTran,
                        CheckTime = p.Ontime,
                        Reason = p.Reason,
                        SerialNumber = p.Serno,
                    }
                ).ToList());
            }
            return result;
        }
    }
}
