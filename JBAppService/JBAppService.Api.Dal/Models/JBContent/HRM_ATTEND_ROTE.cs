using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class HRM_ATTEND_ROTE
    {
        public int ROTE_ID { get; set; }
        public string ROTE_CODE { get; set; }
        public string ROTE_CNAME { get; set; }
        public string ROTE_ENAME { get; set; }
        public string ON_TIME { get; set; }
        public string OFF_TIME { get; set; }
        public decimal? WORK_HRS { get; set; }
        public decimal? D_WORK_HRS { get; set; }
        public int? OFF_TIME_LATEST { get; set; }
        public int? ON_TIME_EARLIEST { get; set; }
        public string OT_BEGIN_TIME { get; set; }
        public decimal? YEAR_REST_HRS { get; set; }
        public string LEAVE_OFF_TIME { get; set; }
        public string IS_FIX_OVERTIME { get; set; }
        public decimal? FIX_OVERTIME_HRS { get; set; }
        public string IS_ROTE_ALLOWANCE { get; set; }
        public string ROTE_ALLOWANCE_SALCODE { get; set; }
        public decimal? ROTE_ALLOWANCE_AMT { get; set; }
        public decimal? LATE_MINUTE { get; set; }
        public decimal? FLEXIBLE_MINUTE { get; set; }
        public string IS_CARD { get; set; }
        public int? SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
