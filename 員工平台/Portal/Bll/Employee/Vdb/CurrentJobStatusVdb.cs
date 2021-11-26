using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Employee.Vdb
{
    public class CurrentJobStatusVdb
    {
    }

    public class CurrentJobStatusConditions : DataConditions
    {
        public string nobr { get; set; }
        public DateTime Adate { get; set; }
    }


    //public class EmployeeInfoApiRow : StandardDataBaseApiRow
    //{
    //    public ResultApiRow result { get; set; }
    //    public class ResultApiRow
    //    {

    //    }
    //}

    public class JobStatus
    {
        public string Nobr { get; set; }
        public DateTime? Adate { get; set; }
        public string Ttscode { get; set; }
        public DateTime? Ddate { get; set; }
        public DateTime? Indt { get; set; }
        public DateTime? Cindt { get; set; }
        public object Oudt { get; set; }
        public object Stdt { get; set; }
        public object Stindt { get; set; }
        public object Stoudt { get; set; }
        public string Comp { get; set; }
        public string Dept { get; set; }
        public string Depts { get; set; }
        public string Job { get; set; }
        public string Jobl { get; set; }
        public string Card { get; set; }
        public string Rotet { get; set; }
        public string Di { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Mang { get; set; }
        public Decimal YrDays { get; set; }
        public Decimal WkYrs { get; set; }
        public string Saltp { get; set; }
        public string Jobs { get; set; }
        public string Workcd { get; set; }
        public string Carcd { get; set; }
        public string Empcd { get; set; }
        public string Outcd { get; set; }
        public bool Calabs { get; set; }
        public string Calot { get; set; }
        public bool Fulatt { get; set; }
        public bool Noter { get; set; }
        public bool Nowel { get; set; }
        public bool Noret { get; set; }
        public bool Notlate { get; set; }
        public string HoliCode { get; set; }
        public bool Noot { get; set; }
        public bool Nospec { get; set; }
        public bool Nocard { get; set; }
        public bool Noeat { get; set; }
        public string Apgrpcd { get; set; }
        public string Deptm { get; set; }
        public string Ttscd { get; set; }
        public string Meno { get; set; }
        public string Saladr { get; set; }
        public bool Nowage { get; set; }
        public bool Mange { get; set; }
        public Decimal Retrate { get; set; }
        public DateTime? Retdate { get; set; }
        public string Retchoo { get; set; }
        public DateTime? Retdate1 { get; set; }
        public bool Onlyontime { get; set; }
        public string Jobo { get; set; }
        public bool CountPass { get; set; }
        public DateTime? PassDate { get; set; }
        public bool Mang1 { get; set; }
        public DateTime? ApDate { get; set; }
        public Decimal GrpAmt { get; set; }
        public DateTime? TaxDate { get; set; }
        public bool Nospamt { get; set; }
        public bool Fixrate { get; set; }
        public DateTime? TaxEdate { get; set; }
        public bool IsSelfout { get; set; }
        public string InsgType { get; set; }
        public string OldSaladr { get; set; }
        public string Station { get; set; }
        public string CardJobName { get; set; }
        public string CardJobEnName { get; set; }
        public string OilSubsidy { get; set; }
        public string CardId { get; set; }
        public string DoorGuard { get; set; }
        public string OutPost { get; set; }
        public bool Nooldret { get; set; }
        public object ReinstateDate { get; set; }
        public string PassType { get; set; }
        public object AuditDate { get; set; }
        public object AssessManage1 { get; set; }
        public object AssessManage2 { get; set; }
    }
    public class CurrentJobStatusApiRow : StandardDataBaseApiRow
    {
        
        public JobStatus result { get; set; }
    }

    public class CurrentJobStatusRow : StandardDataRow
    {
        public JobStatus Result { get; set; }
    }
}