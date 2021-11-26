using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class ShareMessage
    {
        public int AutoKey { get; set; }
        public string SystemCode { get; set; }
        public string Code { get; set; }
        public string MessageTypeCode { get; set; }
        public string Contents { get; set; }
        public string SystemContents { get; set; }
        public string AppName { get; set; }
        public string Note { get; set; }
        public string HandleStatusCode { get; set; }
        public string IpAddress { get; set; }
        public int Sort { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
