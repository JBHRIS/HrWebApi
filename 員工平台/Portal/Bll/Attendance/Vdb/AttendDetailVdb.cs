using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Attendance.Vdb
{
    public class AttendDetailVdb
    {
    }

    public class AttendDetailConditions : DataConditions
    {
        public List<string> employeeList { get; set; }
        public List<string> attendTypeList { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class AttendDetailApiRow
    {
        public Result[] result { get; set; }
        public bool state { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
    }

    public class Result
    {
        public string employeeId { get; set; }
        public string employeeName { get; set; }
        public DateTime attendDate { get; set; }
        public string roteCodeDisp { get; set; }
        public string roteCode { get; set; }
        public string roteName { get; set; }
        public string roteDateB { get; set; }
        public string roteTimeB { get; set; }
        public string roteDateE { get; set; }
        public string roteTimeE { get; set; }
        public string cardDateB { get; set; }
        public string cardTimeB { get; set; }
        public string cardDateE { get; set; }
        public string cardTimeE { get; set; }
        public decimal lateMin { get; set; }
        public decimal earlyMin { get; set; }
        public bool isAbs { get; set; }
        public decimal forget { get; set; }
        public Listab[] listAbs { get; set; }
        public Listot[] listOt { get; set; }
        public Listabnormal[] listAbnormal { get; set; }
    }

    public class Listab
    {
        public string employeeID { get; set; }
        public string employeeName { get; set; }
        public string holidayCode { get; set; }
        public string holidayName { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public decimal absenceAmount { get; set; }
        public string absenceUnit { get; set; }
    }

    public class Listot
    {
        public string employeeID { get; set; }
        public string employeeName { get; set; }
        public DateTime overTimeDate { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string overTimeRote { get; set; }
        public string overTimeRoteName { get; set; }
        public string overTimeReason { get; set; }
        public decimal overTotalTimeHours { get; set; }
        public decimal overTimeTotalHours { get; set; }
        public decimal overTimeHours { get; set; }
        public decimal restTimeHours { get; set; }
        public string serialNumber { get; set; }
    }

    public class Listabnormal
    {
        public string type { get; set; }
        public string name { get; set; }
        public int mins { get; set; }
        public bool check { get; set; }
    }

    public class AbsRow
    {
        public string Name { set; get; }
        public string TimeB { set; get; }
        public string TimeE { set; get; }
        public string Time { set; get; }
        public string Hcode { set; get; }
        public string HcodeName { set; get; }
        public string HcodeUnitName { set; get; }
        public decimal Use { set; get; }
    }

    public class OtRow
    {
        public string Name { set; get; }
        public string TimeB { set; get; }
        public string TimeE { set; get; }
        public string Time { set; get; }
        public decimal OtHour { set; get; }
        public decimal RestHour { set; get; }
        public decimal TotalHour { set; get; }
    }

    public class AbnormalRow
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public int Mins { set; get; }
        public bool Check { set; get; }
    }

    public class AttendDetailRow
    {
        public string EmpId { set; get; }
        public string EmpName { set; get; }
        public DateTime DateA { set; get; }
        public string RoteDisplayName { get; set; }
        public string RoteCode { set; get; }
        public string RoteName { set; get; }
        public string RoteTimeB { set; get; }
        public string RoteTimeE { set; get; }
        public string RoteTime { set; get; }
        public string AttcardTimeB { set; get; }
        public string AttcardTimeE { set; get; }
        public string AttcardTime { set; get; }
        public int LateMins { set; get; }
        public int EarlyMins { set; get; }
        public string IsAbs { set; get; }
        public int Forget { set; get; }
        public string AbsData { set; get; }
        public string OtData { set; get; }
        public string AbnormalData { set; get; }
        public List<AbsRow> ListAbs { set; get; }

        public List<OtRow> ListOt { set; get; }

        public List<AbnormalRow> ListAbnormal { set; get; }
    }
}