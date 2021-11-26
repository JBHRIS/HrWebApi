using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppAbsDay
    {
        public int AutoKey { get; set; }
        public string AbsCode { get; set; }
        public string ProcessId { get; set; }
        public string idProcess { get; set; }
        public DateTime DateTimeB { get; set; }
        public DateTime DateTimeE { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public decimal Use { get; set; }
        public string RoteCode { get; set; }
        public string RotehCode { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
