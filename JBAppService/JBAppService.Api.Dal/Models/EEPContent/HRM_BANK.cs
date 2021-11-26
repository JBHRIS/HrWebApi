﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_BANK
    {
        public int BANK_ID { get; set; }
        public string BANK_CODE { get; set; }
        public string BANK_CNAME { get; set; }
        public string BANK_ENAME { get; set; }
        public int? BANK_SEQ { get; set; }
        public int? BANK_TRANSFER_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
