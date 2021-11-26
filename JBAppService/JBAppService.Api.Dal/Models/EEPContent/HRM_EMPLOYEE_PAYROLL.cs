using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_PAYROLL
    {
        public int EMPLOYEE_PAYROLL_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string PASSWORD { get; set; }
        public string MANAGER_EMPLOYEE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
