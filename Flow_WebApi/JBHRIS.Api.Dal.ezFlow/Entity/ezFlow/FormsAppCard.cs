using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppCard
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
        public DateTime DateTimeB { get; set; }
        public DateTime DateB { get; set; }
        public string TimeB { get; set; }
        public DateTime DateTimeE { get; set; }
        public DateTime DateE { get; set; }
        public string TimeE { get; set; }
        public string CardLostCode { get; set; }
        public string CardLostName { get; set; }
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
