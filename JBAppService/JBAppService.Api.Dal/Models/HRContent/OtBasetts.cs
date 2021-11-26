using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class OtBasetts
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public decimal RestHrs { get; set; }
        public decimal OtHrs { get; set; }
        public bool CountMa { get; set; }
        public string Di { get; set; }
        public string Dept { get; set; }
        public string OtDept { get; set; }
        public string Depts { get; set; }
        public string NameC { get; set; }
        public string Yymm { get; set; }
        public string Workcd { get; set; }
        public string Empcd { get; set; }
        public string Comp { get; set; }
        public string Job { get; set; }
        public string Saladr { get; set; }
        public string NameE { get; set; }
    }
}
