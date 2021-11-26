﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_ACCOUNT_DETAIL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ACCOUNT_ID { get; set; }
        public int EXPENSE_ID { get; set; }
        public string ACCOUNT_DEBIT { get; set; }
        public string ACCOUNT_CREDIT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
