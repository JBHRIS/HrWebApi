using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrOtrcd
    {
        public string SName { get; set; }
        public string SOtrCode { get; set; }
        public string SOtrName { get; set; }
        public bool? BDisplay { get; set; }
        public int ISort { get; set; }
        public bool? BNoCalc { get; set; }
    }
}
