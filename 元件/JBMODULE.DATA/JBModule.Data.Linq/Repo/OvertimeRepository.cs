﻿using JBHRIS.BLL.Att.LaborEventLaw;
using JBHRIS.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBTools.Extend;
namespace JBModule.Data.Repo
{
    public class OvertimeRepository : IOvertimeRepository
    {
        private JBModule.Data.Linq.HrDBDataContext dcHR;

        public OvertimeRepository()
        {
            dcHR = new JBModule.Data.Linq.HrDBDataContext();
        }

        public OvertimeRepository(JBModule.Data.Linq.HrDBDataContext dc)
        {
            dcHR = dc;
        }

        public List<OtDto> GetDataByEmployeeDate(List<string> employeeList, DateTime dateBegin, DateTime dateEnd)
        {
            List<OtDto> Result = new List<OtDto>();
            foreach (var item in employeeList.Split(1000))
            {
                var Result1 = (from o in dcHR.OT
                               join otr in dcHR.OTRCD on o.OTRCD equals otr.OTRCD1 into p
                               from otr in p.DefaultIfEmpty()
                               where item.Contains(o.NOBR)
                                       && dateBegin <= o.BDATE
                                       && o.BDATE <= dateEnd
                               select new OtDto
                               {
                                   AttendanceDate = o.BDATE,
                                   BeginTime = ConvertDateTime(o.BDATE, o.BTIME),
                                   EndTime = ConvertDateTime(o.BDATE, o.ETIME),
                                   EmployeeID = o.NOBR,
                                   OtHours = o.OT_HRS,
                                   RestHours = o.REST_HRS,
                                   TotalHours = o.TOT_HOURS,
                                   ReasonCode = otr.OTRCD1,
                                   ReasonDescription = otr.OTRNAME,
                                   Remark = o.NOTE,
                               }).ToList();
                Result.AddRange(Result1);
            }
            return Result;
        }

        private DateTime ConvertDateTime(DateTime date, string HHmm)
        {
            if (HHmm == null)
                return new DateTime();
            if (HHmm.Length != 4)
                return new DateTime();
            try
            {
                int HH = Convert.ToInt32(HHmm.Substring(0, 2));
                int mm = Convert.ToInt32(HHmm.Substring(2, 2));

                return date.AddHours(HH).AddMinutes(mm);

            }
            catch
            {
                return new DateTime();
            }
        }
    }
}
