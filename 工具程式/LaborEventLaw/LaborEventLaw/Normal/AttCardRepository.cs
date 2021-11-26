using JBHRIS.BLL.Att.LaborEventLaw;
using JBHRIS.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using JBTools.Extend;

namespace LaborEventLaw.Normal
{
    public class AttCardRepository : IAttCardRepository
    {
        private JBHRModelDataContext dcHR;

        public AttCardRepository()
        {
            dcHR = new JBHRModelDataContext();
        }

        public AttCardRepository(JBHRModelDataContext dc)
        {
            dcHR = dc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public List<AttcardDto> GetDataByEmployeeDate(List<string> employeeList, DateTime dateBegin, DateTime dateEnd)
        {
            List<AttcardDto> Result = new List<AttcardDto>();
            foreach (var item in employeeList.Split(1000))
            {
                var AttCardDataList = (from att in dcHR.ATTCARD
                                       where item.Contains(att.NOBR)
                                       && dateBegin <= att.ADATE
                                       && att.ADATE <= dateEnd
                                       select new
                                       {
                                           AttendanceDate = att.ADATE,
                                           CantModify = att.NOMODY,
                                           EmployeeID = att.NOBR,
                                           CreateMan = att.KEY_MAN,
                                           OnTimeForget = att.LOST1,
                                           OffTimeForget = att.LOST2,
                                           OnTime = att.T1,
                                           OffTime = att.T2,
                                       }).ToList();
                var Result_Temp = (from c in AttCardDataList
                               select new AttcardDto
                               {
                                   AttendanceDate = c.AttendanceDate,
                                   CantModify = c.CantModify,
                                   EmployeeID = c.EmployeeID,
                                   CreateMan = c.CreateMan,
                                   OnTimeForget = c.OnTimeForget,
                                   OffTimeForget = c.OffTimeForget,
                                   BeginTime = ConvertDateTime(c.AttendanceDate, c.OnTime),
                                   EndTime = ConvertDateTime(c.AttendanceDate, c.OffTime),
                               }).ToList();
                Result.AddRange(Result_Temp);
            }
            return Result;
        }

        private DateTime? ConvertDateTime(DateTime date, string HHmm)
        {
            if (HHmm == null)
                return null;
            if (HHmm.Length != 4)
                return null;
            try
            {
                int HH = Convert.ToInt32(HHmm.Substring(0, 2));
                int mm = Convert.ToInt32(HHmm.Substring(2, 2));

                return date.AddHours(HH).AddMinutes(mm);
            }
            catch
            {
                return null;
            }
        }
    }
}