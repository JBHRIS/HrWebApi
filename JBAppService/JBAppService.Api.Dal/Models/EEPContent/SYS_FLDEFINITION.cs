using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_FLDEFINITION
    {
        public string FLTYPEID { get; set; }
        public string FLTYPENAME { get; set; }
        public string FLDEFINITION { get; set; }
        public int? VERSION { get; set; }
    }
}
