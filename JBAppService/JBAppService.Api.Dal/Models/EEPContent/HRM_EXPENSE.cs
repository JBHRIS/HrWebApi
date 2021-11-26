﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EXPENSE
    {
        public int EXPENSE_ID { get; set; }
        public string EXPENSE_CODE { get; set; }
        public string EXPENSE_CNAME { get; set; }
        public string EXPENSE_ENAME { get; set; }
        public int? EXPENSE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
