using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AbsBasetts
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public string HName { get; set; }
        public decimal TolHours { get; set; }
        public bool Mang { get; set; }
        public string Unit { get; set; }
        public string Comp { get; set; }
        public string Dept { get; set; }
        public string Depts { get; set; }
        public string Job { get; set; }
        public string Di { get; set; }
        public bool CountMa { get; set; }
        public string NameC { get; set; }
        public bool NotSum { get; set; }
        public string Rotet { get; set; }
        public string YearRest { get; set; }
        public string Saladr { get; set; }
        public string NameE { get; set; }
    }
}
