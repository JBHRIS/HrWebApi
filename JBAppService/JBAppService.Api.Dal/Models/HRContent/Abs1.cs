using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Abs1
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public DateTime Bdate2 { get; set; }
        public DateTime Edate2 { get; set; }
        public string Btime2 { get; set; }
        public string Etime2 { get; set; }
        public string Btime3 { get; set; }
        public string Etime3 { get; set; }
        public string GoType { get; set; }
        public bool Abord { get; set; }
        public string CfmMan { get; set; }
        public string Dept { get; set; }
        public string Target { get; set; }
        public string Reason { get; set; }
        public string Cust { get; set; }
        public bool NotDisp { get; set; }
        public bool Onetomany { get; set; }
        public string Note { get; set; }
        public string Seq { get; set; }
        public string Yymm { get; set; }
        public string Serno { get; set; }
    }
}
