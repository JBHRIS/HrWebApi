using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class AppointVdb
    {

        public int AutoKey { get; set; }
        public string Code {get;set;}
        public string ProcessId { get;set;}
        public string ProcessApParm { get; set; }
        public int idProcess { get;set;}
        public string EmpId { get;set;}
        public string EmpName { get;set;}
        public string DeptCode { get;set;}
        public string DeptName { get;set;}
        public string DeptmCode { get;set;}
        public string DeptmName { get;set;}
        public string JobCode { get;set;}
        public string JobName { get;set;}
        public string JoblCode { get;set;}
        public string JoblName { get;set;}
        public string RoleId { get;set;}
        public DateTime Birthday { get;set;}
        public string Sex { get;set;}
        public DateTime DateIn { get;set;}
        public DateTime DateA { get;set;}
        public string SchoolCode { get;set;}
        public string SchoolName { get;set;}
        public string Performance1 { get;set;}
        public string Performance2 { get;set;}
        public string Performance3 { get;set;}
        public string DeptCodeChange { get; set; }
        public string DeptNameChange { get; set; }
        public string DeptmCodeChange { get; set; }
        public string DeptmNameChange { get; set; }
        public string JobCodeChange { get; set; }
        public string JobNameChange { get; set; }
        public string JoblCodeChange { get; set; }
        public string JoblNameChange { get; set; }
        public string ChangeItemCode { get; set; }
        public string ChangeItemName { get; set; }
        public DateTime DateAppoint { get; set; }
        public string ReasonChange { get; set; }
        public string Evaluation { get; set; }
        public string Qualified { get; set; }
        public bool AllowSign { get; set; }
        public bool AllowSalary { get; set; }
        public string Note { get;set;}
        public bool Sign { get; set; }
        public string SignState { get;set;}
        public string Status { get;set; }
        public string InsertMan { get;set;}
        public DateTime InsertDate { get;set;}
        public string UpdateMan { get;set;}
        public DateTime UpdateDate { get;set;}
        public List<AppointChangeLog> AppointChangeLog { get; set; }
    }
    public class AppointChangeLog
    {
        public int AutoKey { get; set; }
        public string AppointCode { get; set; }
        public string DeptCodeChange { get; set; }
        public string DeptNameChange { get; set; }
        public string DeptmCodeChange { get; set; }
        public string DeptmNameChange { get; set; }
        public string JobCodeChange { get; set; }
        public string JobNameChange { get; set; }
        public string JoblCodeChange { get; set; }
        public string JoblNameChange { get; set; }
        public string Performance1 { get; set; }
        public string Performance2 { get; set; }
        public DateTime DateAppoint { get; set; }
        public string SalaryContent { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
