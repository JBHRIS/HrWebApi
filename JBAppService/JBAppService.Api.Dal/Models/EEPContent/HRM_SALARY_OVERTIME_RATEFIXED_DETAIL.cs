using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_RATEFIXED_DETAIL
    {
        public int OVERTIME_RATEFIXED_DETAIL_ID { get; set; }
        public int OVERTIME_RATEFIXED_MASTER_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
