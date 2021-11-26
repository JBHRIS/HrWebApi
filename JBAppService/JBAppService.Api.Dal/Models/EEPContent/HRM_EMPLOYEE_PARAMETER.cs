using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_PARAMETER
    {
        public int EMPLOYEE_PARAMETER_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string HIRE_TYPE { get; set; }
        public string SALARY_PAY_TYPE { get; set; }
        public string INSURANCE_TYPE { get; set; }
        public string MONTH_MEETING_GROUP { get; set; }
        public string IS_OVERTIME_HOUR { get; set; }
        public string IS_REST_HOUR { get; set; }
        public string IS_REST_OVER { get; set; }
        public string IS_DELAY_MEAL { get; set; }
        public decimal? DELAY_MEAL_AMT { get; set; }
        public decimal? DELAY_MEAL_OVERTIME_INCLUSIVE { get; set; }
        public decimal? DELAY_MEAL_OVERTIME_OVER { get; set; }
        public string IS_HOUSEKEEPING { get; set; }
        public string IS_TEMPORARY_WORKER { get; set; }
        public string IS_NOT_CREATE_YEAR_HOLIDAY { get; set; }
        public string IS_SEND_SHIFT_ALLOWANCE { get; set; }
        public string VD_ACCOUNT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
