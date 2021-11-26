using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppShiftRote
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sShiftRoteType { get; set; }
        public string sShiftRoteName { get; set; }
        public string sEmpID1 { get; set; }
        public string sEmpCode1 { get; set; }
        public string sName1 { get; set; }
        public string sDept1 { get; set; }
        public string sDeptName1 { get; set; }
        public string sJob1 { get; set; }
        public string sJobName1 { get; set; }
        public string sRole1 { get; set; }
        public string sEmpID2 { get; set; }
        public string sEmpCode2 { get; set; }
        public string sName2 { get; set; }
        public string sDept2 { get; set; }
        public string sDeptName2 { get; set; }
        public string sJob2 { get; set; }
        public string sJobName2 { get; set; }
        public string sRole2 { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public bool bAuth { get; set; }
        public string sCode1 { get; set; }
        public string sName11 { get; set; }
        public string sCode2 { get; set; }
        public string sName21 { get; set; }
        public string sCode3 { get; set; }
        public string sName3 { get; set; }
        public string sNote { get; set; }
        public DateTime? dKeyDate { get; set; }
        public string sGuid { get; set; }
        public string sShiftDate { get; set; }
        public bool? bDifferShift { get; set; }
    }
}
