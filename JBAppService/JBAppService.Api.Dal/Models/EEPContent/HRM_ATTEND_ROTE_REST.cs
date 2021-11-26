using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTE_REST
    {
        public int ROTE_ID { get; set; }
        public int REST_SEQ { get; set; }
        public string REST_BEGIN_TIME { get; set; }
        public string REST_END_TIME { get; set; }
        public string IS_NORMAL_ABSENT { get; set; }
        public string IS_NORMAL_OVERTIME { get; set; }
        public string IS_HOLIDAY_ABSENT { get; set; }
        public string IS_HOLIDAY_OVERTIME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
