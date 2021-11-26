using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsBase
    {
        public string EffbaseId { get; set; }
        public string Yy { get; set; }
        public string Seq { get; set; }
        public string TempletId { get; set; }
        public string Nobr { get; set; }
        public string Dept { get; set; }
        public string Depta { get; set; }
        public string Depts { get; set; }
        public string Job { get; set; }
        public string Jobl { get; set; }
        public DateTime? Stddate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Firstdate { get; set; }
        public string Deptorder { get; set; }
        public string Jobplan { get; set; }
        public bool? Mangfinish { get; set; }
        public bool? Isdeff { get; set; }
        public string Effsfinally { get; set; }
        public string EffsgroupId { get; set; }
    }
}
