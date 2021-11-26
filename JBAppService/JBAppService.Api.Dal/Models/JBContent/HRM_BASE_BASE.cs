using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class HRM_BASE_BASE
    {
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
        public int? COUNTRY_ID { get; set; }
        public string BIRTHPLACE { get; set; }
        public decimal? HEIGHT { get; set; }
        public decimal? WEIGHT { get; set; }
        public string ARMY { get; set; }
        public string ARMY_TYPE { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public string PASSPORT_NAME { get; set; }
        public string RESIDENT_CERTIFICATE { get; set; }
        public string ALIEN_RESIDENT_TYPE { get; set; }
        public DateTime? GROUP_EFFECT_DATE { get; set; }
        public DateTime? ADMIT_DATE { get; set; }
        public decimal? EXTERNAL_SENIORITY { get; set; }
        public int? EMPLOYEE_IDENTITY_ID { get; set; }
        public string INTRODUCER_ID { get; set; }
        public string INTRODUCER_CODE { get; set; }
        public string INTRODUCER_NAME { get; set; }
        public string INTRODUCE_COMPANY_ID { get; set; }
        public string REGISTER_COUNTY { get; set; }
        public string CONTACT_COUNTY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
