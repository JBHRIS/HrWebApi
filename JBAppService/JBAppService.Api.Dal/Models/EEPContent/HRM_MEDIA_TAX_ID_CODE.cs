﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_ID_CODE
    {
        public string TAX_ID_CODE { get; set; }
        public string TAX_ID_CODE_DESCRIPTION { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
