﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_MONTH_FOREIGN
    {
        public string TAX_CITY_OFFICE_CODE { get; set; }
        public string SERIAL_NO { get; set; }
        public string MARK { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public string IDNO { get; set; }
        public string TAX_ID_CODE { get; set; }
        public string TAX_ID { get; set; }
        public decimal? TOTAL_AMOUNT_PAID { get; set; }
        public decimal? NET_WITHHOLDING_TAX { get; set; }
        public decimal? NET_PAYMENT { get; set; }
        public string ERROR_MARK { get; set; }
        public string YEAR_PAYMENT { get; set; }
        public string MONTH_PAYMENT { get; set; }
        public string NAME_C { get; set; }
        public string RESIDENCE_ADDRESS { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_TRANSFER_DATE { get; set; }
        public DateTime? END_TRANSFER_DATE { get; set; }
        public string BEGIN_YYMM { get; set; }
        public string END_YYMM { get; set; }
        public string IS_DECLARE { get; set; }
        public string GROUP_ID { get; set; }
        public string COMPANY_ID { get; set; }
        public decimal? RETIRE_AMT { get; set; }
        public string NOT_MODIFY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
