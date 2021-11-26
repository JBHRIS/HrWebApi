using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_TEMPORARY_WORKER_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string NAME_C { get; set; }
        public string NAME_E { get; set; }
        public string COMPANY_MAIL { get; set; }
        public string PHOTO { get; set; }
        public string IDNO { get; set; }
        public string SEX { get; set; }
        public DateTime? BIRTHDAY { get; set; }
        public string MARRIAGE { get; set; }
        public string BLOOD { get; set; }
        public string CELL_PHONE { get; set; }
        public string TEL { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public int? RELATION_ID { get; set; }
        public string EMPLOYEE_CONTACT_NAME { get; set; }
        public string EMPLOYEE_CONTACT_CELLPHONE { get; set; }
        public int? COUNTRY_ID { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public string RESIDENT_CERTIFICATE { get; set; }
        public int? COMPANY_ID { get; set; }
        public int? DEPT_ID { get; set; }
        public int? DEPTC_ID { get; set; }
        public int? IDENTITY_ID { get; set; }
        public int? BANK_ID { get; set; }
        public string ACCOUNT_NO { get; set; }
        public decimal? HOURLY_AMT { get; set; }
        public int? INSURANCE_COMPANY_ID { get; set; }
        public string LABOR_ALLOWANCE_CODE { get; set; }
        public string INSURANCE_TYPE { get; set; }
        public decimal? LABOR_AMT { get; set; }
        public decimal? RETIRE_AMT { get; set; }
        public decimal? HEALTH_AMT { get; set; }
        public decimal? RETIRE_SELF_RATE { get; set; }
        public string HIRE_TYPE { get; set; }
        public string SALARY_PAY_TYPE { get; set; }
        public string ALIEN_RESIDENT_TYPE { get; set; }
        public DateTime? GROUP_EFFECT_DATE { get; set; }
        public DateTime? ARRIVE_DATE { get; set; }
        public string GROUP_ID { get; set; }
        public string ATTEND_GROUP_ID { get; set; }
        public string EMPLOYEE_GROUP_ID { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
