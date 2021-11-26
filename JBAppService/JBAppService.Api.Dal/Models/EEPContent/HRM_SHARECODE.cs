using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SHARECODE
    {
        public string FIELDNAME { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public int SORT { get; set; }
        public bool DISPLAY { get; set; }
    }
}
