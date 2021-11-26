using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_DATA_FLOW
    {
        public int CARD_DATA_ID { get; set; }
        public string CARD_TYPE { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string SOURCE_CODE { get; set; }
        public string CARD_NO { get; set; }
        public DateTime? CARD_DATE { get; set; }
        public string CARD_TIME { get; set; }
        public DateTime? CARD_DATE_TIME { get; set; }
        public string NOT_TRAN { get; set; }
        public string IS_FORGET_CARD { get; set; }
        public string FORGET_CARD_CAUSE_ID { get; set; }
        public string IP_ADDRESS { get; set; }
        public string MEMO { get; set; }
        public string SERIAL_NO { get; set; }
        public string CARD_DATA_NO { get; set; }
        public string FLOW_CONTENT { get; set; }
        public string APPLICATE_ROLE { get; set; }
        public string APPLICATE_USER { get; set; }
        public string FLOWFLAG { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
