using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_FORM_GROUP_EMPLOYEE
    {
        public int FORM_ID { get; set; }
        public int GROUP_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? EVALUATION_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
