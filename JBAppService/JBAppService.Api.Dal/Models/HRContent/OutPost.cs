using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class OutPost
    {
        public string Code { get; set; }
        public string OutPostName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string CodeDisp { get; set; }
    }
}
