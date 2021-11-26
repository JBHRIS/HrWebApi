using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_SCALE
    {
        public int SCALE_ID { get; set; }
        public string SCALE_NAME { get; set; }
        public string SCALE_EXPLAIN { get; set; }
        public int? DATUM { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
