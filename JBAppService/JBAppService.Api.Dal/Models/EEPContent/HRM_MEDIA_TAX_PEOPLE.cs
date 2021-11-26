using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_PEOPLE
    {
        public string IS_EMPLOYEE { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string NAME_C { get; set; }
        public string RESIDENCE_ADDRESS { get; set; }
        public string TEL { get; set; }
        public string EMAIL { get; set; }
        public string CELL_PHONE { get; set; }
        public string IDNO { get; set; }
        public string TAX_ID_CODE { get; set; }
        public string POSTCODE { get; set; }
        public string GROUP_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
