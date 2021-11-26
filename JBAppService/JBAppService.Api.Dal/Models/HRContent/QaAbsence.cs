using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class QaAbsence
    {
        public string Nobr { get; set; }
        public DateTime AbsDate { get; set; }
        public string AbsBtime { get; set; }
        public string AbsEtime { get; set; }
        public decimal AbsHrs { get; set; }
        public string Unit { get; set; }
        public string HName { get; set; }
        public string HEname { get; set; }
        public string Htypename { get; set; }
        public string Htype { get; set; }
        public string HCode { get; set; }
    }
}
