﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WELFARE_ACCOUNT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_ACCOUNT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? BANK_ID { get; set; }
        public string ACCOUNT_NO { get; set; }
        public int? CURRENCY_ID { get; set; }
        public decimal? ACCOUNT_PERCENT { get; set; }
        public decimal? ACCOUNT_QUOTA { get; set; }
        public int? ACCOUNT_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
