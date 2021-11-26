using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppAbsc_View : ISystem_FormsAppAbsc_View
    {
        private ezFlowContext _context;

        public System_FormsAppAbsc_View(ezFlowContext context)
        {
            this._context = context;
        }

        public AbsFlowAppRow GetFormsAppAbsByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            List<AbsFlowAppsRow> VdbSql = new List<AbsFlowAppsRow>();

            AbsCalculate oAbsCalculate = new AbsCalculate();

            SignState = SignState ?? "";
            Status = Status ?? "";

            VdbSql = (from a in _context.FormsAppAbscs
                      join m in _context.FormsApps on a.idProcess equals m.idProcess
                      where a.idProcess == ProcessFlowID 
                      && ( a.SignState == SignState || SignState=="")
                      && ( a.Status == Status  || Status =="")
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
                          Balance = 0,
                          UnitCode = a.UnitCode ,
                          IsExceptionUse = false,
                          ExceptionUse = 0,
                          IsCirculate = false,
                          ProcessID = a.idProcess,
                          AgentEmpId = "",
                          AgentEmpName = "",
                          AgentNote = "",
                          Note = a.Note,
                          Status = a.Status,
                          Sign = a.Sign,
                          SignState = a.SignState,
                          DeptName = a.DeptName,
                          DeptCode = a.DeptCode,
                          JobName = a.JobName,
                          JobCode = a.JobCode,
                          BaseHours = 8,
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        public async Task<string> GetFormsAppAbsc(string Nobr, DateTime BDate, DateTime EDate, string ApiURL)
        {

            //List<HcodeTypesRow>    hcode = new List<HcodeTypesRow>();

            //HttpClientHandler handler = new HttpClientHandler();
            //using (HttpClient client = new HttpClient(handler))
            //{
            //    try
            //    {
            //      string aa   = await client.GetFromJsonAsync<WeatherForecast[]>(
            //    "WeatherForecast");
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}




            return "";


        }







        public class StandardDataBaseRow
        { 
        
            
        }

        public class StandardDataRow
        { 
        
        }

        public class HcodeTypesRow
        { 
        
        }


        /// <summary>
        /// 資料共用條件
        /// </summary>
        public class DataConditions
        {
            /// <summary>
            /// Key
            /// </summary>
            public string Key { set; get; }
            /// <summary>
            /// AutoKey
            /// </summary>
            public int AutoKey { set; get; }
            /// <summary>
            /// 代碼
            /// </summary>
            public string Code { set; get; }
            /// <summary>
            /// 資料狀態
            /// </summary>
            public List<string> ListStatus { set; get; }
            /// <summary>
            /// 關鍵字
            /// </summary>
            public string Keyword { set; get; }
            /// <summary>
            /// 顯示筆數
            /// </summary>
            public int Take { set; get; }
            /// <summary>
            /// 重叫次數
            /// </summary>
            public int ReCallFrequencyMax { set; get; }
            /// <summary>
            /// 重叫間隔時間(秒)
            /// </summary>
            public int ReCallIntervalSec { set; get; }
            /// <summary>
            /// AccessToken
            /// </summary>
            public string AccessToken { set; get; }
            /// <summary>
            /// RefreshToken
            /// </summary>
            public string RefreshToken { set; get; }
            /// <summary>
            /// 忽略驗証日期
            /// </summary>
            public bool IgnoreValidDate { set; get; }
            /// <summary>
            /// 系統代碼
            /// </summary>
            public string SystemCode { set; get; }
            /// <summary>
            /// 
            /// </summary>
            public DataConditions()
            {
                Key = "";
                AutoKey = 0;
                Code = "";
                ListStatus = new List<string>();
                ListStatus.Add("1");
                Keyword = "";
                Take = 2000;
                ReCallFrequencyMax = 999999;
                ReCallIntervalSec = 1;
                AccessToken = "";
                RefreshToken = "";
                IgnoreValidDate = true;
                SystemCode = "";
            }
        }

        public class AbsenceTakenViewConditions : DataConditions
        {
            public List<string> employeeList { get; set; }
            public List<string> leaveCodeList { get; set; }
            public DateTime dateBegin { get; set; }
            public DateTime dateEnd { get; set; }
        }

    }
}
