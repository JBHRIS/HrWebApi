using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CREATE_CARD_DATA
    {
        public int CREATE_CARD_DATA_ID { get; set; }
        public string EMPLOYEE_TEXT { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string DEPT_TEXT { get; set; }
        public string DEPT_ID { get; set; }
        public string ROTE_TEXT { get; set; }
        public string ROTE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
