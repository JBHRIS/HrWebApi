using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormSignM
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sFormName { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sKey1 { get; set; }
        public string sKey2 { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public string sDept { get; set; }
        public string sDeptName { get; set; }
        public string sJob { get; set; }
        public string sJobName { get; set; }
        public string sRole { get; set; }
        public string sNote { get; set; }
        public string sNodeCode { get; set; }
        public string sNodeName { get; set; }
        public bool bSign { get; set; }
        public string sSign { get; set; }
        public string ChiefCode { get; set; }
        public DateTime? dKeyDate { get; set; }
        public string sNobrTo { get; set; }
        public string sNameTo { get; set; }
        public string sDeptTo { get; set; }
        public string sDeptNameTo { get; set; }
        public string sJobTo { get; set; }
        public string sJobNameTo { get; set; }
        public string sRoleTo { get; set; }
    }
}
