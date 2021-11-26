using JBHRIS.BLL.Att.LaborEventLaw;
using JBHRIS.BLL.Att.LaborEventLaw.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using JBTools.Extend;

namespace LaborEventLaw.LaborEventLaw
{
    public class LaborEventLawAbnormalRepository : ILaborEventLawAbnormalRepository
    {
        private JBHRModelDataContext dcHR;

        public LaborEventLawAbnormalRepository()
        {
            dcHR = new JBHRModelDataContext();
        }

        public LaborEventLawAbnormalRepository(JBHRModelDataContext dc)
        {
            dcHR = dc;
        }

        public void Delete(int id)
        {
            var data = (from c in dcHR.ATTEND_ABNORMAL
                        where c.ID == id
                        select c).ToList();

            dcHR.ATTEND_ABNORMAL.DeleteAllOnSubmit(data);
            dcHR.SubmitChanges();
        }

        public List<LaborEventLawAbnormalDto> GetDataByEmployeeDate(List<string> employeeList, DateTime dateBegin, DateTime dateEnd)
        {
            List<LaborEventLawAbnormalDto> Result = new List<LaborEventLawAbnormalDto>();
            foreach (var item in employeeList.Split(1000))
            {
                var Result_Temp = (from c in dcHR.ATTEND_ABNORMAL
                            where item.Contains(c.NOBR)
                            && dateBegin <= c.ADATE
                            && c.ADATE <= dateEnd
                            select new LaborEventLawAbnormalDto
                            {
                                Id = c.ID,
                                EmpID = c.NOBR,
                                Adate = c.ADATE,
                                Type = c.TYPE,
                                OnTime = c.ON_TIME,
                                OffTime = c.OFF_TIME,
                                OnTimeActual = c.ON_TIME_ACTUAL,
                                OffTimeActual = c.OFF_TIME_ACTUAL,
                                OnTimeBufferMins = c.ON_TIEM_BUFFER_MINS,
                                OffTimeBufferMins = c.OFF_TIME_BUFFER_MINS,
                                ErrorMins = c.ERROR_MINS,
                                IsError = true,
                                RoteCode = c.ROTE_CODE,
                            }).ToList();

                Result.AddRange(Result_Temp);
            }
            return Result;
        }

        public void Save(LaborEventLawAbnormalDto instance)
        {
            var data = (from c in dcHR.ATTEND_ABNORMAL
                        where c.NOBR == instance.EmpID
                        && c.ADATE == instance.Adate
                        && c.TYPE == instance.Type
                        select c).FirstOrDefault();

            if (data == null)
            {
                data = new ATTEND_ABNORMAL();
                data.NOBR = instance.EmpID;
                data.ADATE = instance.Adate;
                data.TYPE = instance.Type;
                data.CREATE_DATE = DateTime.Now;
                data.CREATE_MAN = "System";
                dcHR.ATTEND_ABNORMAL.InsertOnSubmit(data);
            }
            data.ON_TIME = instance.OnTime;
            data.OFF_TIME = instance.OffTime;
            data.ON_TIME_ACTUAL = instance.OnTimeActual;
            data.OFF_TIME_ACTUAL = instance.OffTimeActual;
            data.ON_TIEM_BUFFER_MINS = instance.OnTimeBufferMins;
            data.OFF_TIME_BUFFER_MINS = instance.OffTimeBufferMins;
            data.ROTE_CODE = instance.RoteCode;
            data.UPDATE_DATE = DateTime.Now;
            data.UPDATE_MAN = "System";
            data.ERROR_MINS = instance.ErrorMins;
            data.IS_ERROR = instance.IsError;
            dcHR.SubmitChanges();
        }
    }
}