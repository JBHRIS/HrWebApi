using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormsAppAbnByProcessIdVdb
    {
    }
    public class FormsAppAbnByProcessIdConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormsAppAbnByProcessIdApiRow : StandardDataBaseApiRow
    {
       
        public List<FlowAbnData> Result { get; set; }
    }
    public class FormsAppAbnByProcessIdRow
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
        public List<FlowAbnData> FlowApps { get; set; }
    }
    public class FlowAbnData
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string ProcessId { get; set; }
        public int idProcess { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string RoleId { get; set; }
        public DateTime DateB { get; set; }
        public bool IsEarlyWork { get; set; }
        public int EarlyWorkMin { get; set; }
        public bool IsLateOut { get; set; }
        public int LateOutMin { get; set; }
        public string AbnCode { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
