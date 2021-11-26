using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_OVERTIME_RATE
    {
        public int OVERTIME_RATE_ID { get; set; }
        public string OVERTIME_RATE_CODE { get; set; }
        public string OVERTIME_RATE_CNAME { get; set; }
        public string OVERTIME_RATE_ENAME { get; set; }
        public string OVERTIME_RATE_WTYPE { get; set; }
        public decimal? MIN_MINUTE { get; set; }
        public string FIX_RATE { get; set; }
        public int? OT_INTERVAL_MINUTE { get; set; }
        public decimal? OT133WTIME_B { get; set; }
        public decimal? OT133WTIME_E { get; set; }
        public decimal? OT133WRATE { get; set; }
        public decimal? OT133WAMT { get; set; }
        public decimal? OT167WTIME_B { get; set; }
        public decimal? OT167WTIME_E { get; set; }
        public decimal? OT167WRATE { get; set; }
        public decimal? OT167WAMT { get; set; }
        public decimal? OT200WTIME_B { get; set; }
        public decimal? OT200WTIME_E { get; set; }
        public decimal? OT200WRATE { get; set; }
        public decimal? OT200WAMT { get; set; }
        public string OVERTIME_RATE_HTYPE { get; set; }
        public decimal? OT133HTIME_B { get; set; }
        public decimal? OT133HTIME_E { get; set; }
        public decimal? OT133HRATE { get; set; }
        public decimal? OT133HAMT { get; set; }
        public decimal? OT167HTIME_B { get; set; }
        public decimal? OT167HTIME_E { get; set; }
        public decimal? OT167HRATE { get; set; }
        public decimal? OT167HAMT { get; set; }
        public decimal? OT200HTIME_B { get; set; }
        public decimal? OT200HTIME_E { get; set; }
        public decimal? OT200HRATE { get; set; }
        public decimal? OT200HAMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
