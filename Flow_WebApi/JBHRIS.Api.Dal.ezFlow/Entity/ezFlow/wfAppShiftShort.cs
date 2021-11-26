using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppShiftShort
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sNobrA { get; set; }
        public string sNameA { get; set; }
        public string sDeptA { get; set; }
        public string sDeptNameA { get; set; }
        public string sJobA { get; set; }
        public string sJobNameA { get; set; }
        public string sJoblA { get; set; }
        public string sJoblNameA { get; set; }
        public string sEmpcdA { get; set; }
        public string sEmpcdNameA { get; set; }
        public string sRoleA { get; set; }
        public string sDIA { get; set; }
        public string sRoteA { get; set; }
        public string sRoteNameA { get; set; }
        public DateTime dDateA { get; set; }
        public string sNobrB { get; set; }
        public string sNameB { get; set; }
        public string sDeptB { get; set; }
        public string sDeptNameB { get; set; }
        public string sJobB { get; set; }
        public string sJobNameB { get; set; }
        public string sJoblB { get; set; }
        public string sJoblNameB { get; set; }
        public string sEmpcdB { get; set; }
        public string sEmpcdNameB { get; set; }
        public string sRoleB { get; set; }
        public string sDIB { get; set; }
        public string sRoteB { get; set; }
        public string sRoteNameB { get; set; }
        public DateTime dDateB { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public bool bAuth { get; set; }
        public string sNote { get; set; }
        public DateTime? dKeyDate { get; set; }
        public string sGuid { get; set; }
        public string sInfo { get; set; }
        public string sMailBody { get; set; }
    }
}
