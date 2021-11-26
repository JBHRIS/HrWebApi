using JBHRIS.BLL.Att.LaborEventLaw;
using JBHRIS.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBTools.Extend;
namespace JBModule.Data.Repo
{
    public class AttendRepository : IAttendRepository
    {
        private JBModule.Data.Linq.HrDBDataContext dcHR;

        public AttendRepository()
        {
            dcHR = new JBModule.Data.Linq.HrDBDataContext();
        }

        public AttendRepository(JBModule.Data.Linq.HrDBDataContext dc)
        {
            dcHR = dc;
        }

        public List<AttendDto> GetDataByEmployeeDate(List<string> employeeList, DateTime dateBegin, DateTime dateEnd)
        {
            List<AttendDto> Result = new List<AttendDto>();
            foreach (var item in employeeList.Split(1000))
            {
                var Result1 = (from a in dcHR.ATTEND
                               join r in dcHR.ROTE on a.ROTE equals r.ROTE1
                               where item.Contains(a.NOBR)
                                       && dateBegin <= a.ADATE
                                       && a.ADATE <= dateEnd
                               select new AttendDto
                               {
                                   Absenteeism = a.ABS,
                                   AttendanceDate = a.ADATE,
                                   CheckError = true,
                                   CreateMan = a.KEY_MAN,
                                   EarilyMinutes = Convert.ToInt32(a.E_MINS),
                                   EmployeeID = a.NOBR,
                                   FirstCardTime = new DateTime(),
                                   LastCardTime = new DateTime(),
                                   FlexibleMins = Convert.ToInt32(r.ALLLATES1),
                                   LateMinutes = Convert.ToInt32(a.LATE_MINS),
                                   RoteCode = r.ROTE1,
                                   RoteCodeCheck = r.ROTE_DISP,
                                   Remark = "",
                                   WorkTimes = new List<Tuple<DateTime, DateTime>>(),
                                   OtRestTimes = new List<Tuple<DateTime, DateTime>>(),
                                   RestTimes = new List<Tuple<DateTime, DateTime>>(),
                               }).ToList();
                Result.AddRange(Result1);
            }

            var RoteList = (from c in dcHR.ROTE select c).ToList();

            foreach (var item in Result)
            {
                var rote = RoteList.Where(x => x.ROTE1 == item.RoteCode).FirstOrDefault();
                if (rote != null && !string.IsNullOrWhiteSpace(rote.ON_TIME) && !string.IsNullOrWhiteSpace(rote.OFF_TIME))
                {
                    int ON_TIME_HH = Convert.ToInt32(rote.ON_TIME.Substring(0, 2));
                    int ON_TIME_MM = Convert.ToInt32(rote.ON_TIME.Substring(2, 2));

                    DateTime dOnTime = item.AttendanceDate.AddHours(ON_TIME_HH).AddMinutes(ON_TIME_MM);

                    int OFF_TIME_HH = Convert.ToInt32(rote.OFF_TIME.Substring(0, 2));
                    int OFF_TIME_MM = Convert.ToInt32(rote.OFF_TIME.Substring(2, 2));

                    DateTime dOffTime = item.AttendanceDate.AddHours(OFF_TIME_HH).AddMinutes(OFF_TIME_MM);

                    item.WorkTimes = new List<Tuple<DateTime, DateTime>>();

                    item.WorkTimes.Add(new Tuple<DateTime, DateTime>(dOnTime, dOffTime));
                }
            }

            return Result;
        }
    }
}
