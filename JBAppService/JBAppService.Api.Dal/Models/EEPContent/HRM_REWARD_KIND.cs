using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_REWARD_KIND
    {
        public int REWARD_KIND_ID { get; set; }
        public string REWARD_KIND_CODE { get; set; }
        public string REWARD_KIND_CNAME { get; set; }
        public string REWARD_KIND_ENAME { get; set; }
        public string REWARD_TYPE { get; set; }
        public int? REWARD_KIND_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
