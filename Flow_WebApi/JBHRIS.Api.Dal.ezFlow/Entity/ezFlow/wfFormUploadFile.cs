using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormUploadFile
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sFormName { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sKey { get; set; }
        public string sKey2 { get; set; }
        public string sUpName { get; set; }
        public string sServerName { get; set; }
        public string sDescription { get; set; }
        public string sType { get; set; }
        public int iSize { get; set; }
        public DateTime? dKeyDate { get; set; }
        public byte[] oBlob { get; set; }
    }
}
