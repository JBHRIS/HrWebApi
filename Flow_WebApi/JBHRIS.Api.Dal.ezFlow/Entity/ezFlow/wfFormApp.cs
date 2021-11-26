using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormApp
    {
        public int iAutoKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sFormCode { get; set; }
        public string sFormName { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public string sDept { get; set; }
        public string sDeptName { get; set; }
        public string sJob { get; set; }
        public string sJobName { get; set; }
        public string sJobl { get; set; }
        public string sJoblName { get; set; }
        public string sRole { get; set; }
        public string sDI { get; set; }
        public int iCateOrder { get; set; }
        public bool bDelay { get; set; }
        public string sNote { get; set; }
        public string sReserve1 { get; set; }
        public string sReserve2 { get; set; }
        public string sReserve3 { get; set; }
        public string sReserve4 { get; set; }
        public DateTime? dDateTimeA { get; set; }
        public DateTime? dDateTimeD { get; set; }
        public string sLevel { get; set; }
        public string sLimitTime { get; set; }
        public string sYear { get; set; }
        public string sDecode { get; set; }
        public bool bAuth { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public string sConditions1 { get; set; }
        public string sConditions2 { get; set; }
        public string sConditions3 { get; set; }
        public string sConditions4 { get; set; }
        public string sConditions5 { get; set; }
        public string sConditions6 { get; set; }
        public string sInfo { get; set; }
        public string sMailSubject { get; set; }
        public string sMailBdoy { get; set; }
        public string sMailSign { get; set; }
        public string sJsonInfo { get; set; }
        public string sEmpCode { get; set; }
    }
}
