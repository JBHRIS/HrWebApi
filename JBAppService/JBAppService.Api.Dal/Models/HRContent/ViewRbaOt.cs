﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ViewRbaOt
    {
        public int Autokey { get; set; }
        public string Dept { get; set; }
        public string DNoDisp { get; set; }
        public string DName { get; set; }
        public decimal OtMax { get; set; }
        public DateTime Adate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
