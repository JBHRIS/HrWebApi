﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_PAYMENT_ITEM
    {
        public string TAX_PAYMENT_ITEM_CODE { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public string TAX_PAYMENT_ITEM_CNAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
