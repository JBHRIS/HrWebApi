using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppOt
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string ProcessID { get; set; }
        public int idProcess { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string RoleId { get; set; }
        public DateTime DateTimeB1 { get; set; }
        public DateTime DateTimeE1 { get; set; }
        public DateTime DateB1 { get; set; }
        public DateTime DateE1 { get; set; }
        public string TimeB1 { get; set; }
        public string TimeE1 { get; set; }
        public DateTime DateTimeB { get; set; }
        public DateTime DateTimeE { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string RoteName { get; set; }
        public string RoteCode { get; set; }
        public string RotehName { get; set; }
        public string RotehCode { get; set; }
        public string OtCateCode { get; set; }
        public string OtCateName { get; set; }
        public string OtrcdCode { get; set; }
        public string OtrcdName { get; set; }
        public string DeptsCode { get; set; }
        public string DeptsName { get; set; }
        public decimal Use { get; set; }
        public string UnitCode { get; set; }
        public bool IsExceptionUse { get; set; }
        public decimal ExceptionUse { get; set; }
        public bool Sign { get; set; }
        public string SignState { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
