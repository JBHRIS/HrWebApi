using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDQUEUEPAGE
    {
        public int ID { get; set; }
        public byte[] DOCUMENT { get; set; }
        public byte[] PHOTO { get; set; }
        public string PAGENAME { get; set; }
    }
}
