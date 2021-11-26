using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfMultiFlow
    {
        public int iAutoKey { get; set; }
        public string sKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sSubProcessID { get; set; }
        public int idSubProcess { get; set; }
        public string sFlowTreeId { get; set; }
        public string sRoleId { get; set; }
        public string sEmpId { get; set; }
        public string sSubRoleId { get; set; }
        public string sSubEmpId { get; set; }
        public string sSubName { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
