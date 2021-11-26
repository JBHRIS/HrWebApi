using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_REWARD
    {
        public int REWARD_ID { get; set; }
        public string REWARD_CODE { get; set; }
        public string REWARD_CNAME { get; set; }
        public string REWARD_ENAME { get; set; }
        public string REWARD_TYPE { get; set; }
        public int? REWARD_SEQ { get; set; }
        public decimal? PERFORMANCE_SCORE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
