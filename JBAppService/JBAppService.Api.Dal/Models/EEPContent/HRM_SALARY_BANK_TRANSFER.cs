using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_BANK_TRANSFER
    {
        public int BANK_TRANSFER_ID { get; set; }
        public string BANK_TRANSFER_NAME { get; set; }
        public string SPLIT_TYPE { get; set; }
        public string FILE_EXTENSION { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string FILE_NAME { get; set; }
        public string IS_SHOW { get; set; }
        public string MEMO { get; set; }
    }
}
