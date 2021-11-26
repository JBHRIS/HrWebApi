using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Health
    {
        public int AuthKey { get; set; }
        public string Nobr { get; set; }
        public DateTime? Adate { get; set; }
        public bool? Sp { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public string Note5 { get; set; }
    }
}
