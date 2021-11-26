using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppOt
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public string sDept { get; set; }
        public string sDeptName { get; set; }
        public string sJob { get; set; }
        public string sJobName { get; set; }
        public string sJobl { get; set; }
        public string sJoblName { get; set; }
        public string sEmpcd { get; set; }
        public string sEmpcdName { get; set; }
        public string sRole { get; set; }
        public string sDI { get; set; }
        public string sRote { get; set; }
        public DateTime dDateTimeB1 { get; set; }
        public DateTime dDateTimeE1 { get; set; }
        public DateTime dDateB1 { get; set; }
        public DateTime dDateE1 { get; set; }
        public string sTimeB1 { get; set; }
        public string sTimeE1 { get; set; }
        public DateTime dDateTimeB { get; set; }
        public DateTime dDateTimeE { get; set; }
        public DateTime dDateB { get; set; }
        public DateTime dDateE { get; set; }
        public string sTimeB { get; set; }
        public string sTimeE { get; set; }
        public string sOtcatCode { get; set; }
        public string sOtcatName { get; set; }
        public string sOtrcdCode { get; set; }
        public string sOtrcdName { get; set; }
        public string sRoteCode { get; set; }
        public string sRoteName { get; set; }
        public string sOtDeptCode { get; set; }
        public string sOtDeptName { get; set; }
        public decimal iTotalHour1 { get; set; }
        public decimal iTotalHour { get; set; }
        public bool bExceptionHour { get; set; }
        public decimal iExceptionHour { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public string sSalYYMM { get; set; }
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
