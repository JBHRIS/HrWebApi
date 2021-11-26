using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_SCALE_ITEM
    {
        public int ITEM_ID { get; set; }
        public int SCALE_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_EXPLAIN { get; set; }
        public int? SCALE_ITEM_SCORE { get; set; }
        public string SCALE_ITEM_COMMENT { get; set; }
        public int? SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
