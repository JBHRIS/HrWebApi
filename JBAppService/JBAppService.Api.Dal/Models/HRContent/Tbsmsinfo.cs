using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Tbsmsinfo
    {
        public int Reference { get; set; }
        public string Smsid { get; set; }
        public int Smsindex { get; set; }
        public int? Smstype { get; set; }
        public string Smscontent { get; set; }
        public string Smsstarttm { get; set; }
        public int? Smstmleng { get; set; }
        public string Gentm { get; set; }
    }
}
