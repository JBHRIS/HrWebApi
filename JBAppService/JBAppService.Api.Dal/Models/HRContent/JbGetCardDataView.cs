using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbGetCardDataView
    {
        public string Ssn { get; set; }
        public string Name { get; set; }
        public DateTime Checktime { get; set; }
        public string CardNo { get; set; }
        public int? EmpId { get; set; }
        public string Sensorid { get; set; }
    }
}
