using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAbn
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
        public bool? bEarlyWork { get; set; }
        public int? iEarlyWorkMin { get; set; }
        public bool? bLateOut { get; set; }
        public int? iLateOutMin { get; set; }
        public bool? bLate { get; set; }
        public int? iLateMin { get; set; }
        public bool? bEarly { get; set; }
        public int? iEarlyMin { get; set; }
        public int? iAbnCode { get; set; }
        public DateTime dAbnDate { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public string sSalYYMM { get; set; }
        public string sInfo { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public bool bAuth { get; set; }
        public string sNote { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
