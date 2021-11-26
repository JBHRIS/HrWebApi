using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class WorkadrSalary
    {
        public string WorkCode { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public string Currency { get; set; }
        public decimal MonthSalary { get; set; }
        public decimal DailySalary { get; set; }
        public decimal HourSalary { get; set; }
        public string Memo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
