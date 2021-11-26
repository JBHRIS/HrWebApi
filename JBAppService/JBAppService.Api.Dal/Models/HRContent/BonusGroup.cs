using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class BonusGroup
    {
        public string Code { get; set; }
        public string GroupName { get; set; }
        public int Sort { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Temp1 { get; set; }
        public string Temp2 { get; set; }
        public string Temp3 { get; set; }
    }
}
