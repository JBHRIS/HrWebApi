using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class MENUCHECKLOG
    {
        public int LOGID { get; set; }
        public string ITEMTYPE { get; set; }
        public string PACKAGE { get; set; }
        public DateTime? PACKAGEDATE { get; set; }
        public string FILETYPE { get; set; }
        public string FILENAME { get; set; }
        public DateTime? FILEDATE { get; set; }
        public byte[] FILECONTENT { get; set; }
    }
}
