﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Abs
    {
        public Abs()
        {
            Salabs = new HashSet<Salabs>();
        }

        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Yymm { get; set; }
        public bool Notedit { get; set; }
        public string Note { get; set; }
        public bool Syscreate { get; set; }
        public decimal TolDay { get; set; }
        public string AName { get; set; }
        public string Serno { get; set; }
        public bool? Nocalc { get; set; }
        public bool? Syscreate1 { get; set; }
        public string Memo { get; set; }
        public string Guid { get; set; }
        public decimal? Balance { get; set; }
        public decimal? LeaveHours { get; set; }

        public virtual Attend Attend { get; set; }
        public virtual ICollection<Salabs> Salabs { get; set; }
    }
}
