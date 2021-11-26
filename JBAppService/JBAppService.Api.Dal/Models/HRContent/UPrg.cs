using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UPrg
    {
        public string Prog { get; set; }
        public string ProgName { get; set; }
        public string System { get; set; }
        public bool Root { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string FullFormName { get; set; }
    }
}
