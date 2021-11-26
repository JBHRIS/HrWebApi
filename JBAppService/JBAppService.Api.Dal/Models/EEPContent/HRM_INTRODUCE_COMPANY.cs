using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_INTRODUCE_COMPANY
    {
        public int INTRODUCE_COMPANY_ID { get; set; }
        public string INTRODUCE_COMPANY_CNAME { get; set; }
        public string INTRODUCE_COMPANY_ENAME { get; set; }
        public string COMPANY_POSTAL { get; set; }
        public string COMPANY_ADDRESS_C { get; set; }
        public string COMPANY_ADDRESS_E { get; set; }
        public string CHAIRMAN_CNAME { get; set; }
        public string CHAIRMAN_ENAME { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string TAX_ID { get; set; }
        public string CONTACT_NAME1 { get; set; }
        public string CONTACT_NAME2 { get; set; }
        public string CONTACT_TEL1 { get; set; }
        public string CONTACT_TEL2 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
