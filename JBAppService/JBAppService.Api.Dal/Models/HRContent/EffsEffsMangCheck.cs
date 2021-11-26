using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsEffsMangCheck
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Mm { get; set; }
        public string Nobr { get; set; }
        public string Mangnobr { get; set; }
        public string Mangname { get; set; }
        public string Mangtitle { get; set; }
        public DateTime? AppDate { get; set; }
        public string Note { get; set; }
        public bool? IsApproved { get; set; }
        public bool? Approved { get; set; }
        public int? EffsCount { get; set; }
    }
}
