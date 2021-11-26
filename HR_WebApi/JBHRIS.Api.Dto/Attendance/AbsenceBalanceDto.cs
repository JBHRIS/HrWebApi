using System;
using System.Collections.Generic;

namespace HR_WebApi.Api.Dto
{
    public class AbsenceBalanceDto
    {
        public string EmployeeId { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string Hcode { get; set; }
        public string Htype { get; set; }
        public string Unit { get; set; }
        public string Flag { get; set; }
        public decimal? Tolhours { get; set; }
        public decimal? Balance { get; set; }
        public decimal? LeaveHours { get; set; }
        public string Yymm { get; set; }
        public string Guid { get; set; }
    }
}