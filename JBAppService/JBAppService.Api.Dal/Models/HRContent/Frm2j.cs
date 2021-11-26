using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Frm2j
    {
        public string DName { get; set; }
        public string NameC { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal SugHrs { get; set; }
        public decimal OtHrs { get; set; }
        public decimal Ot1Hrs { get; set; }
        public decimal Ot2Hrs { get; set; }
        public bool Trans { get; set; }
        public string OtDept { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Yymm { get; set; }
        public string OtRote { get; set; }
        public bool Tranp { get; set; }
        public decimal RestHrs { get; set; }
        public bool SysOt { get; set; }
        public string Otrcd { get; set; }
        public string Note { get; set; }
    }
}
