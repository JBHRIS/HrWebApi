using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class HRM_ATTEND_ATTEND_CARD
    {
        public int ATTEND_CARD_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? CARD_DATE { get; set; }
        public string ON_TIME { get; set; }
        public DateTime? CARD_DATE_TIME_ON { get; set; }
        public string OFF_TIME { get; set; }
        public DateTime? CARD_DATE_TIME_OFF { get; set; }
        public string ON_TIME_FORGET { get; set; }
        public string OFF_TIME_FORGET { get; set; }
        public string ON_TIME_TRAN { get; set; }
        public DateTime? CARD_DATE_TIME_ON_TRAN { get; set; }
        public string OFF_TIME_TRAN { get; set; }
        public DateTime? CARD_DATE_TIME_OFF_TRAN { get; set; }
        public string NOT_MODIFY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
