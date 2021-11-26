using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UserMessage
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public DateTime? Ddate { get; set; }
        public string NameC { get; set; }
        public string DNoDisp { get; set; }
        public string DName { get; set; }
    }
}
