using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class NumRun
    {
        public int NumRunid { get; set; }
        public int? Oldid { get; set; }
        public string Name { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public short? Cyle { get; set; }
        public short? Units { get; set; }
    }
}
