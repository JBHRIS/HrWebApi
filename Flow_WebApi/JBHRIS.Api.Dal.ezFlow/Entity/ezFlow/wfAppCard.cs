﻿using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppCard
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
        public DateTime? dDateTimeB { get; set; }
        public DateTime? dDateB { get; set; }
        public string sTimeB { get; set; }
        public string sReasonCode1 { get; set; }
        public string sReasonName1 { get; set; }
        public DateTime? dDateTimeE { get; set; }
        public DateTime? dDateE { get; set; }
        public string sTimeE { get; set; }
        public string sReasonCode2 { get; set; }
        public string sReasonName2 { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public bool bAuth { get; set; }
        public string sCode1 { get; set; }
        public string sName1 { get; set; }
        public string sCode2 { get; set; }
        public string sName2 { get; set; }
        public string sCode3 { get; set; }
        public string sName3 { get; set; }
        public string sNote { get; set; }
        public DateTime? dKeyDate { get; set; }
        public string sGuid { get; set; }
        public string sEmpCode { get; set; }
        public DateTime? dDate { get; set; }
        public DateTime? dRoteDateTimeB { get; set; }
        public DateTime? dRoteDateTimeE { get; set; }
        public DateTime? dCardDateTimeB { get; set; }
        public DateTime? dCardDateTimeE { get; set; }
    }
}
