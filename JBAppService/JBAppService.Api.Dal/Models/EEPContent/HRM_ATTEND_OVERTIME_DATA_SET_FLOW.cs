using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_OVERTIME_DATA_SET_FLOW
    {
        public int OVERTIME_SET_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? OVERTIME_DEPT_ID { get; set; }
        public string IS_ATTENDCARD { get; set; }
        public string FLOW_CONTENT { get; set; }
        public string APPLICATE_ROLE { get; set; }
        public string APPLICATE_USER { get; set; }
        public string FLOWFLAG { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
