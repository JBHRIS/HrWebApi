using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormsAppEmployByProcessIdVdb
    {
    }
    public class EmployChangeLog
    {
        public int AutoKey { get; set; }
        public string EmployCode { get; set; }
        public string DeptCodeChange { get; set; }
        public string DeptNameChange { get; set; }
        public string DeptmCodeChange { get; set; }
        public string DeptmNameChange { get; set; }
        public string JobCodeChange { get; set; }
        public string JobNameChange { get; set; }
        public string JoblCodeChange { get; set; }
        public string JoblNameChange { get; set; }
        public string ResultAreaCode { get; set; }
        public string ResultAreaName { get; set; }
        public int ExtendMonth { get; set; }
        public DateTime DateAppoint { get; set; }
        public string Performance01 { get; set; }
        public string Performance02 { get; set; }
        public string Performance03 { get; set; }
        public string Performance04 { get; set; }
        public string Performance05 { get; set; }
        public string SalaryContent { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    
    public class FormsAppEmployByProcessIdConditions : DataConditions
    {
        public string ProcessFlowID { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Status { get; set; }
    }
    public class FormsAppEmployByProcessIdApiRow : StandardDataBaseApiRow
    {
        public class FlowEmployData
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string ProcessId { get; set; }
            public int IdProcess { get; set; }
            public string EmpId { get; set; }
            public string EmpName { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string DeptmCode { get; set; }
            public string DeptmName { get; set; }
            public string JobCode { get; set; }
            public string JobName { get; set; }
            public string JoblCode { get; set; }
            public string JoblName { get; set; }
            public string RoleId { get; set; }
            public DateTime Birthday { get; set; }
            public string Sex { get; set; }
            public DateTime DateIn { get; set; }
            public DateTime DateA { get; set; }
            public DateTime DateD { get; set; }
            public string SchoolCode { get; set; }
            public string SchoolName { get; set; }
            public string WorkExperience { get; set; }
            public string AttendContent { get; set; }
            public string DeptCodeChange { get; set; }
            public string DeptNameChange { get; set; }
            public string DeptmCodeChange { get; set; }
            public string DeptmNameChange { get; set; }
            public string JobCodeChange { get; set; }
            public string JobNameChange { get; set; }
            public string JoblCodeChange { get; set; }
            public string JoblNameChange { get; set; }
            public string ResultAreaCode { get; set; }
            public string ResultAreaName { get; set; }
            public int ExtendMonth { get; set; }
            public DateTime DateAppoint { get; set; }
            public bool AllowSign { get; set; }
            public bool AllowSalary { get; set; }
            public string Note { get; set; }
            public bool Sign { get; set; }
            public string SignState { get; set; }
            public string Status { get; set; }
            public string InsertMan { get; set; }
            public DateTime InsertDate { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
            public List<EmployChangeLog> EmployChangeLog { get; set; }
        }
        public List<FlowEmployData> Result { get; set; }
    }
    public class FormsAppEmployByProcessIdRow
    {
        
        public string EmpID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptmCode { get; set; }
        public string DeptmName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string JoblCode { get; set; }
        public string JoblName { get; set; }
        public string RoleId { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public string WorkExperience { get; set; }
        public string AttendContent { get; set; }
        public string DeptCodeChange { get; set; }
        public string DeptNameChange { get; set; }
        public string DeptmCodeChange { get; set; }
        public string DeptmNameChange { get; set; }
        public string JobCodeChange { get; set; }
        public string JobNameChange { get; set; }
        public string JoblCodeChange { get; set; }
        public string JoblNameChange { get; set; }
        public string ResultAreaCode { get; set; }
        public string ResultAreaName { get; set; }
        public int ExtendMonth { get; set; }
        public DateTime DateAppoint { get; set; }
        public bool AllowSign { get; set; }
        public bool AllowSalary { get; set; }
        public List<EmployChangeLog> ChangeLogs { get; set; }
    }
}
