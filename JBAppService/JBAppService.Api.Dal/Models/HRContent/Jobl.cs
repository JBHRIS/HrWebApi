﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Jobl
    {
        public string Jobl1 { get; set; }
        public string JobName { get; set; }
        public decimal BSal { get; set; }
        public decimal ESal { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string OldJobl { get; set; }
        public decimal BSal1 { get; set; }
        public decimal BSal2 { get; set; }
        public decimal ESal1 { get; set; }
        public decimal ESal2 { get; set; }
        public string JoblGrup { get; set; }
        public decimal SalSecret { get; set; }
        public decimal Entitle { get; set; }
        public decimal Tickets { get; set; }
        public string JoblDisp { get; set; }
    }
}
