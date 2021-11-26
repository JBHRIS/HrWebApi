﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrOt
    {
        public string SNobr { get; set; }
        public DateTime DDateB { get; set; }
        public string STimeB { get; set; }
        public string STimeE { get; set; }
        public decimal ITotHours { get; set; }
        public decimal IOtHrs { get; set; }
        public decimal IRestHrs { get; set; }
        public string SNote { get; set; }
        public string SYymm { get; set; }
        public string SSerNo { get; set; }
        public string IOtCar { get; set; }
        public string SOtDept { get; set; }
        public string SOtrcd { get; set; }
        public string SOtRote { get; set; }
    }
}
