using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_SHARECODE
    {
        public string FIELDNAME { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public int? SORT { get; set; }
        public string IS_ACTIVE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
