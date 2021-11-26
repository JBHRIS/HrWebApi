using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppAbs_View : ISystem_FormsAppAbs_View
    {

        private ezFlowContext _context;

        public System_FormsAppAbs_View(ezFlowContext ezFlowContext)
        {

            this._context = ezFlowContext;
        }

        public AbsFlowAppRow GetFormsAppAbsByProcessId( int ProcessFlowID ,bool Sign , string SignState ,string Status)
        {
            List<AbsFlowAppsRow> VdbSql = new List<AbsFlowAppsRow>();

            AbsCalculate oAbsCalculate = new AbsCalculate();

            SignState = SignState ?? "";
            Status = Status ?? "";

            VdbSql = (from a in _context.FormsAppAbs
                          join m in _context.FormsApps on a.idProcess equals m.idProcess
                          where a.idProcess == ProcessFlowID 
                          && ( a.SignState == SignState || SignState=="")
                          && ( a.Status == Status || Status=="")
                      select new AbsFlowAppsRow
                          {
                              AutoKey = a.AutoKey,
                              AppEmpCode = m.EmpId,
                              AppEmpName = m.EmpName,
                              EmpID = a.EmpId,
                              EmpCode = a.EmpId,
                              EmpName = a.EmpName,
                              RoteID = a.RoleId,
                              DateB = a.DateB,
                              DateE = a.DateE,
                              TimeB = a.TimeB,
                              TimeE = a.TimeE,
                              DateTimeB = a.DateTimeB,
                              DateTimeE = a.DateTimeE,
                              HolidayCode = a.HolidayCode,
                              HolidayName = a.HolidayName,
                              Use = a.Use,
                              Balance = a.Balance,
                              UnitCode = a.UnitCode,
                              IsExceptionUse = a.IsExceptionUse,
                              ExceptionUse = a.ExceptionUse,
                              IsCirculate = a.IsCirculate,
                              ProcessID = a.idProcess,
                              AgentEmpId = a.AgentEmpId,
                              AgentEmpName = a.AgentEmpName,
                              AgentNote = a.AgentNote,
                              Note = a.Note,
                              Status = a.Status,
                              Sign = a.Sign,
                              SignState = a.SignState,                              
                              DeptName = a.DeptName,
                              DeptCode = a.DeptCode,
                              JobName = a.JobName,
                              JobCode =a.JobCode,
                              BaseHours = 8,
                              Code = a.Code
                          }).ToList();

            decimal TotalDay = 0, TotalHour = 0, TotalMinute = 0;
            foreach (var rVdb in VdbSql)
            {
                //var rHoliDay = rsHoliDay.FirstOrDefault(p => p.HoliDayID == rVdb.HoliDayID);

                //var HoursInDay = rVdb.BaseHours;

                //if (oMultiHandler.HoliDayCodeForBaseHour24.Contains(rHoliDay.HoliDayCode))
                //{
                //    HoursInDay = 24m;
                //}


                double HoliDayUnit = 1;
                var DayWorkHours = 8;
                var DayWorkMinutes = Convert.ToInt32(DayWorkHours * 60);



                rVdb.UseDayHourMinute = oAbsCalculate.ConvertTimeUse(rVdb.Use, Convert.ToInt32(HoliDayUnit), DayWorkHours, DayWorkMinutes);

                TotalDay += rVdb.UseDayHourMinute.Day;
                TotalHour += rVdb.UseDayHourMinute.Hour;
                TotalMinute += rVdb.UseDayHourMinute.Minute;

                //rVdb.AbsFlowAppsDetail = GetAbsFlowAppsDetail(rVdb.Key, rVdb.EmpID, rVdb.HoliDayID, ListHoliDayRoteID, rVdb.DateB, rVdb.DateE, rVdb.State);
                //rVdb.UploadFile = oMultiFlowHandler.GetUploadFile(rVdb.Key, Miniature);
                //foreach (var AbsFlowAppsDetailRow in rVdb.AbsFlowAppsDetail)
                //{
                //    AbsFlowAppsDetailRow.UseDayHourMinute = oAbsCalculate.ConvertTimeUse(AbsFlowAppsDetailRow.Use, Convert.ToInt32(HoliDayUnit), DayWorkHours, DayWorkMinutes);
                //}
            }
            AbsFlowAppRow result = new AbsFlowAppRow();
            result.UseDayHourMinute = new DayHourMinuteRow();
            result.UseDayHourMinute.Day = TotalDay;
            result.UseDayHourMinute.Hour = TotalHour;
            result.UseDayHourMinute.Minute = TotalMinute;

            result.FlowApps = new List<AbsFlowAppsRow>();
            result.FlowApps.AddRange(VdbSql);

            return result;
        }

        public AbsFlowAppRow GetFormsAppAbsByProcessId()
        {
            throw new NotImplementedException();
        }

        public List<FormsAppAbsUseDto> GetFormsAppAbsUseListByProcessId(List<string> ProcessId)
        {
            var result = (from d in _context.FormsAppAbs
                          where ProcessId.Contains(d.ProcessID)
                          select new FormsAppAbsUseDto
                          {
                              ProcessId = d.ProcessID,
                              EmpId = d.EmpId,
                              HCode = d.HolidayCode,
                              HName = d.HolidayName,
                              Unit = d.UnitCode,
                              Use = d.Use
                          }).ToList();
            return result;
        }



       
    }
}
