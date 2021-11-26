using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppShiftLong
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
        public string sRotetCode { get; set; }
        public string sRotetName { get; set; }
        public string sHoliCode { get; set; }
        public string sHoliName { get; set; }
        public string sOtRateCode { get; set; }
        public string sOtRateName { get; set; }
        public DateTime? dDate { get; set; }
        public string sRotetCodeA { get; set; }
        public string sRotetNameA { get; set; }
        public string sHoliCodeA { get; set; }
        public string sHoliNameA { get; set; }
        public string sOtRateCodeA { get; set; }
        public string sOtRateNameA { get; set; }
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
