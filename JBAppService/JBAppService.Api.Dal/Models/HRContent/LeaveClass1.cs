using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class LeaveClass1
    {
        public int LeaveId { get; set; }
        public string LeaveName { get; set; }
        public double MinUnit { get; set; }
        public short Unit { get; set; }
        public short RemaindProc { get; set; }
        public short RemaindCount { get; set; }
        public string ReportSymbol { get; set; }
        public double Deduct { get; set; }
        public short LeaveType { get; set; }
        public int Color { get; set; }
        public short Classify { get; set; }
        public string Calc { get; set; }
    }
}
