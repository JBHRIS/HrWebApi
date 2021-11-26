using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_CONTACT
    {
        public int EMPLOYEE_CONTACT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? RELATION_ID { get; set; }
        public string EMPLOYEE_CONTACT_NAME { get; set; }
        public string EMPLOYEE_CONTACT_CELLPHONE { get; set; }
        public string EMPLOYEE_CONTACT_PHONE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
