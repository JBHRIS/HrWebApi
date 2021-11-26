using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EmployeeParameter
    {
        public int EmployeeParameterId { get; set; }
        public string EmployeeId { get; set; }
        public string IsAllowLeave { get; set; }
        public string IsDeformation { get; set; }
        public string IsMail { get; set; }
        public string CreateMan { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string IsRestOver { get; set; }
    }
}
