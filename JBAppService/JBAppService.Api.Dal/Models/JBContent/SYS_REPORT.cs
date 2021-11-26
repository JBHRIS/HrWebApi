using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_REPORT
    {
        public string REPORTID { get; set; }
        public string FILENAME { get; set; }
        public string REPORTNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string FILEPATH { get; set; }
        public string OUTPUTMODE { get; set; }
        public string HEADERREPEAT { get; set; }
        public byte[] HEADERFONT { get; set; }
        public byte[] HEADERITEMS { get; set; }
        public byte[] FOOTERFONT { get; set; }
        public byte[] FOOTERITEMS { get; set; }
        public byte[] FIELDFONT { get; set; }
        public byte[] FIELDITEMS { get; set; }
        public byte[] SETTING { get; set; }
        public byte[] FORMAT { get; set; }
        public byte[] PARAMETERS { get; set; }
        public byte[] IMAGES { get; set; }
        public byte[] MAILSETTING { get; set; }
        public string DATASOURCE_PROVIDER { get; set; }
        public byte[] DATASOURCES { get; set; }
        public byte[] CLIENT_QUERY { get; set; }
        public string REPORT_TYPE { get; set; }
        public string TEMPLATE_DESC { get; set; }
    }
}
