using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{
    public class ShiftLongVdb
    {

        public int AutoKey { get; set; }
        public string Code {get;set;}
        public string ProcessId { get;set;}
        public int idProcess { get;set;}
        public string EmpId { get;set;}
        public string EmpName { get;set;}
        public string DeptCode { get;set;}
        public string DeptName { get;set;}
        public string JobCode { get;set;}
        public string JobName { get;set;}
        public string RoleId { get;set;}
        public DateTime Date { get;set;}
        public string RotetCode { get; set; }
        public string RotetName { get; set; }
        public string RotetCodeOrigin { get; set; }
        public string RotetNameOrigin { get; set; }
        public bool Sign { get;set;}
        public string SignState { get;set;}
        public string Note { get;set;}
        public string Status { get;set;}
        public string InsertMan { get;set;}
        public DateTime InsertDate { get;set;}
        public string UpdateMan { get;set;}
        public DateTime UpdateDate { get;set;}
    }
}
