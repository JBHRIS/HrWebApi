using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAb
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
        public string sRole { get; set; }
        public string sRote { get; set; }
        public DateTime dDateTimeB { get; set; }
        public DateTime dDateTimeE { get; set; }
        public DateTime dDateB { get; set; }
        public DateTime dDateE { get; set; }
        public string sTimeB { get; set; }
        public string sTimeE { get; set; }
        public string sHcode { get; set; }
        public string sHname { get; set; }
        public decimal iDay { get; set; }
        public decimal iHour { get; set; }
        public decimal iMinute { get; set; }
        public decimal iTotalDay { get; set; }
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
        public string sAgentNobr { get; set; }
        public string sAgentName { get; set; }
        public string sAgentNote { get; set; }
        public bool bAuth { get; set; }
        public string sNote { get; set; }
        public DateTime? dKeyDate { get; set; }
        public string sGuid { get; set; }
        public decimal iUse { get; set; }
        public decimal iBalance { get; set; }
        public string sUnit { get; set; }
        public string sUnitName { get; set; }
        public string sKeyName { get; set; }
        public DateTime? dEventDate { get; set; }
        public string sEmpCode { get; set; }
        public bool bToday { get; set; }
        public bool bCirculate { get; set; }
        public bool bAppointment { get; set; }
        public decimal BaseHour { get; set; }
        public decimal UseD { get; set; }
        public decimal UseH { get; set; }
        public decimal UseM { get; set; }
        public string sPlace { get; set; }
    }
}
