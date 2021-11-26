using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormsAppAbscByProcessIdVdb
    {
    }
    public class FormsAppAbscByProcessIdConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormsAppAbscByProcessIdApiRow : StandardDataBaseApiRow
    {
        public class UseDayHourMinute
        {
            public Decimal Day { get; set; }
            public Decimal Hour { get; set; }
            public Decimal Minute { get; set; }
        }

        public class RoteRest
        {
            public string RoteID { get; set; }
            public Decimal Seq { get; set; }
            public string TimeB { get; set; }
            public string TimeE { get; set; }
            public Decimal Minute { get; set; }
            public bool IsNormalAbs { get; set; }
            public bool IsNormalOt { get; set; }
            public bool IsHoliDayAbs { get; set; }
            public bool IsHoliDayOt { get; set; }
        }

        public class RoteMapping
        {
            public string RoteMappingCode { get; set; }
            public string RoteMappingName { get; set; }
            public string RoteID { get; set; }
        }

        public class Rote
        {
            public string RoteID { get; set; }
            public string RoteCode { get; set; }
            public string RoteNameC { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public DateTime OnDateTime { get; set; }
            public DateTime OffDateTime { get; set; }
            public string OnTime { get; set; }
            public string OffTime { get; set; }
            public Decimal WorkHours { get; set; }
            public Decimal DWorkHours { get; set; }
            public Decimal OnTimeEarliest { get; set; }
            public Decimal OffTimeLatest { get; set; }
            public string OtBeginTime { get; set; }
            public Decimal YearRestHours { get; set; }
            public string LeaveOffTime { get; set; }
            public Decimal FlexibleMinute { get; set; }
            public Decimal FlexibleMinuteForward { get; set; }
            public Decimal FlexibleMinuteBehind { get; set; }
            public Decimal LateMinute { get; set; }
            public Decimal WorkInterval { get; set; }
            public bool IsCard { get; set; }
            public bool IsShift { get; set; }
            public bool IsDifferShift { get; set; }
            public bool Ride { get; set; }
            public Decimal Seq { get; set; }
            public bool Holiday { get; set; }
            public List<RoteRest> RoteRest { get; set; }
            public RoteMapping RoteMapping { get; set; }
        }

        public class AbsFlowAppsTran
        {
            public string AbsPlusKey { get; set; }
            public DateTime AbsPlusDateB { get; set; }
            public DateTime AbsPlusDateE { get; set; }
            public string AbsPlusTimeB { get; set; }
            public string AbsPlusTimeE { get; set; }
            public string AbsPlusHcode { get; set; }
            public DateTime EventDate { get; set; }
            public string KeyName { get; set; }
            public Decimal AbsPlusMax { get; set; }
            public Decimal AbsPlusUse { get; set; }
            public Decimal AbsPlusBalance { get; set; }
            public DateTime DateTimeB { get; set; }
            public DateTime DateTimeE { get; set; }
            public DateTime DateB { get; set; }
            public string TimeB { get; set; }
            public string TimeE { get; set; }
            public string HoliDayID { get; set; }
            public Decimal Use { get; set; }
            public Decimal Balance { get; set; }
        }

        public class RoteRestList
        {
            public string RoteID { get; set; }
            public Decimal Seq { get; set; }
            public string TimeB { get; set; }
            public string TimeE { get; set; }
            public Decimal Minute { get; set; }
            public bool IsNormalAbs { get; set; }
            public bool IsNormalOt { get; set; }
            public bool IsHoliDayAbs { get; set; }
            public bool IsHoliDayOt { get; set; }
        }

        public class AbsFlowAppsDetail
        {
            public string EmpID { get; set; }
            public DateTime DateB { get; set; }
            public string TimeB { get; set; }
            public string TimeE { get; set; }
            public DateTime DateTimeB { get; set; }
            public DateTime DateTimeE { get; set; }
            public string HoliDayID { get; set; }
            public Decimal Use { get; set; }
            public string RoteID { get; set; }
            public Rote Rote { get; set; }
            public UseDayHourMinute UseDayHourMinute { get; set; }
            public List<AbsFlowAppsTran> AbsFlowAppsTrans { get; set; }
            public List<RoteRestList> RoteRestList { get; set; }
            public Decimal AbsentMinusDetailId { get; set; }
            public string State { get; set; }
            public bool IsDelete { get; set; }
            public string Key { get; set; }
            public Decimal ProcessID { get; set; }
        }

        public class UploadFile
        {
            public Decimal UploadID { get; set; }
            public string UploadName { get; set; }
            public string ServerName { get; set; }
            public string Description { get; set; }
            public string Blob { get; set; }
            public string Type { get; set; }
            public Decimal Size { get; set; }
        }

        public class TusinessTrip
        {
            public string JobLevel { get; set; }
            public string JobLevelCode { get; set; }
            public string DeptPath { get; set; }
            public string Station { get; set; }
            public string DriveNum { get; set; }
            public string DriveNo { get; set; }
            public string Drive { get; set; }
            public string DriveEtc { get; set; }
        }

        public class FlowApp
        {
            public string AppEmpCode { get; set; }
            public string AppEmpName { get; set; }
            public string EmpID { get; set; }
            public string EmpCode { get; set; }
            public string EmpName { get; set; }
            public string RoteID { get; set; }
            public DateTime DateB { get; set; }
            public DateTime DateE { get; set; }
            public string TimeB { get; set; }
            public string TimeE { get; set; }
            public DateTime DateTimeB { get; set; }
            public DateTime DateTimeE { get; set; }
            public string HolidayCode { get; set; }
            public string HolidayName { get; set; }
            public Decimal Use { get; set; }
            public UseDayHourMinute UseDayHourMinute { get; set; }
            public Decimal Day { get; set; }
            public Decimal Balance { get; set; }
            public string UnitCode { get; set; }
            public bool IsExceptionUse { get; set; }
            public Decimal ExceptionUse { get; set; }
            public string AgentEmpId { get; set; }
            public string AgentEmpName { get; set; }
            public string AgentNote { get; set; }
            public string Note { get; set; }
            public string Info { get; set; }
            public string KeyName { get; set; }
            public string EventDate { get; set; }
            public List<AbsFlowAppsDetail> AbsFlowAppsDetail { get; set; }
            public List<UploadFile> UploadFile { get; set; }
            public string MailBody { get; set; }
            public string Status { get; set; }
            public bool Sign { get; set; }
            public string SignState { get; set; }
            public bool Today { get; set; }
            public bool IsCirculate { get; set; }
            public bool Appointment { get; set; }
            public Decimal ProcessID { get; set; }
            public string Serno { get; set; }
            public string DeptName { get; set; }
            public string DeptCode { get; set; }
            public string JobName { get; set; }
            public string JobCode { get; set; }
            public bool HoliDayIsNotRefRote { get; set; }
            public Decimal BaseHours { get; set; }
            public string sGuid { get; set; }
            public Decimal AutoKey { get; set; }
            public string Key { get; set; }
            public TusinessTrip TusinessTrip { get; set; }
        }

        public class result
        {
            public string EmpID { get; set; }
            public string EmpCode { get; set; }
            public string EmpNameC { get; set; }
            public string State { get; set; }
            public string Cond1 { get; set; }
            public string Cond2 { get; set; }
            public string Cond3 { get; set; }
            public string Cond4 { get; set; }
            public string Cond5 { get; set; }
            public string Cond6 { get; set; }
            public Decimal Day { get; set; }
            public Decimal HoliDayID { get; set; }
            public List<FlowApp> FlowApps { get; set; }
            public UseDayHourMinute UseDayHourMinute { get; set; }
        }

        public result Result { get; set; }
    }
    public class FormsAppAbscByProcessIdRow
    {
        
        public string EmpID { get; set; }
        public string EmpCode { get; set; }
        public string EmpNameC { get; set; }
        public string State { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public string Cond4 { get; set; }
        public string Cond5 { get; set; }
        public string Cond6 { get; set; }
        public Decimal Day { get; set; }
        public Decimal HoliDayID { get; set; }
        public List<FlowAbscData> FlowApps { get; set; }
    }
    public class FlowAbscData
    {
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime AbscDateB { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime AbscDateE { get; set; }
        public string AutoKey { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string RoteID { get; set; }
        public string Code { get; set; }
        public Decimal Use { get; set; }
        public Decimal ExceptionUse { get; set; }
        public string UnitCode { get; set; }
        public bool IsExceptionUse { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// 起始時間
        /// </summary>
        public string AbscTimeB { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string AbscTimeE { get; set; }
        /// <summary>
        /// 共計
        /// </summary>
        public Decimal AbscTotalTime { get; set; }
        /// <summary>
        /// 請假單號
        /// </summary>
        public string ProcessId { get; set; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HolidayName { get; set; }
        /// <summary>
        /// 假別代碼
        /// </summary>
        public string HolidayCode { get; set; }
    }
}
