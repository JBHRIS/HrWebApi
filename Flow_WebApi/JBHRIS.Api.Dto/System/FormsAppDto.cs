using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class FormsAppDto
    {
        public int AutoKey { get; set; }
        public string FormsCode { get; set; }
        public string ProcessID { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string RoleId { get; set; }
        public int DeptTreeB { get; set; }
        public int DeptTreeE { get; set; }
        public DateTime DateTimeA { get; set; }
        public DateTime DateTimeD { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Cond01 { get; set; }
        public string Cond02 { get; set; }
        public string Cond03 { get; set; }
        public string Cond04 { get; set; }
        public string Cond05 { get; set; }
        public string Cond06 { get; set; }
        public string Cond07 { get; set; }
        public string Cond08 { get; set; }
        public string Cond09 { get; set; }
        public string Cond10 { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
