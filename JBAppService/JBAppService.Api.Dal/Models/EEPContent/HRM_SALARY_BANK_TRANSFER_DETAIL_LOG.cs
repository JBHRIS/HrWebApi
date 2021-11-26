using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_BANK_TRANSFER_DETAIL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int BANK_TRANSFER_DETAIL_ID { get; set; }
        public int BANK_TRANSFER_ID { get; set; }
        public string CLASSIFY { get; set; }
        public string TRANSFER_CODE { get; set; }
        public string NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string USER_DEFINED { get; set; }
        public int BANK_TRANSFER_LENGTH { get; set; }
        public string PAD_TYPE { get; set; }
        public string PAD_CHAR { get; set; }
        public string YEAR_TYPE { get; set; }
        public string DATE_FORMAT { get; set; }
        public int BANK_TRANSFER_SORT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
