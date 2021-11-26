using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppAppointChangeLog
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
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
