using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_LICENCE_FILE
    {
        public int EMPLOYEE_LICENCE_FILE_ID { get; set; }
        public int EMPLOYEE_LICENCE_ID { get; set; }
        public string EMPLOYEE_LICENCE_FILE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
