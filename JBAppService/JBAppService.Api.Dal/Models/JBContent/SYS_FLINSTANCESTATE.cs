using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_FLINSTANCESTATE
    {
        public string FLINSTANCEID { get; set; }
        public byte[] STATE { get; set; }
        public int? STATUS { get; set; }
        public string INFO { get; set; }
    }
}
