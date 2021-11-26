using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_BANK_TRANSFER_CLIENT
    {
        public int TRANSFER_CLIENT_ID { get; set; }
        public int BANK_TRANSFER_ID { get; set; }
        public string TRANSFER_GROUP { get; set; }
        public string COMPANY_ID { get; set; }
        public string CLIENT_NO { get; set; }
        public string GIRO_ACCOUNT { get; set; }
        public string PAY_TYPE { get; set; }
        public int? BANK_WEIGHT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
