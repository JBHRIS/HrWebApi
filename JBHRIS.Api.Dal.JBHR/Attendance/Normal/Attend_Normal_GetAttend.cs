using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Attend_Normal_GetAttend : IAttend_Normal_GetAttend
    {
        private IUnitOfWork _unitOfWork;

        public Attend_Normal_GetAttend(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AttendDto> GetAttend(List<string> EmployeeList, DateTime StartDate, DateTime EndDate)
        {
            List<AttendDto> attendDtos = new List<AttendDto>();
            foreach (var item in EmployeeList.Split(2100))
            {
                var attends = (from att in _unitOfWork.Repository<Attend>().Reads()
                               where item.Contains(att.Nobr)
                               && att.Adate >= StartDate && att.Adate <= EndDate
                               select new AttendDto
                               {
                                   Nobr = att.Nobr,
                                   Adate = att.Adate,
                                   Rote = att.Rote,
                                   KeyMan = att.KeyMan,
                                   KeyDate = att.KeyDate,
                                   LateMins = att.LateMins,
                                   EMins = att.EMins,
                                   Abs = att.Abs,
                                   AdjCode = att.AdjCode,
                                   CantAdj = att.CantAdj,
                                   Ser = att.Ser,
                                   NightHrs = att.NightHrs,
                                   Foodamt = att.Foodamt,
                                   Foodsalcd = att.Foodsalcd,
                                   Forget = att.Forget,
                                   AttHrs = att.AttHrs,
                                   Nigamt = att.Nigamt,
                                   Specamt = att.Specamt,
                                   Specsalcd = att.Specsalcd,
                                   Stationamt = att.Stationamt,
                                   EarlyMins = att.EarlyMins,
                                   DelayMins = att.DelayMins,
                                   RelHrs = att.RelHrs,
                                   RoteH = att.RoteH,
                               }
                              ).ToList();

                attendDtos.AddRange(attends);
            }

            return attendDtos;
        }
    }
}
