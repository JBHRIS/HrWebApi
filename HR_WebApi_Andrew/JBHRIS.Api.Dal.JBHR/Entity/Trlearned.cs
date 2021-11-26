using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trlearned
    {
        public int IAutoKey { get; set; }
        public string SProcessId { get; set; }
        public int IdProcess { get; set; }
        public string SNobr { get; set; }
        public string SName { get; set; }
        public string SDept { get; set; }
        public string SJob { get; set; }
        public string SJobName { get; set; }
        public string SJobl { get; set; }
        public string SJoblName { get; set; }
        public string SDeptName { get; set; }
        public string SApplyNo { get; set; }
        public string SCourseName { get; set; }
        public DateTime DDateB { get; set; }
        public DateTime DDateE { get; set; }
        public string STimeB { get; set; }
        public string STimeE { get; set; }
        public string SAddress { get; set; }
        public string STcrName1 { get; set; }
        public string STcrName2 { get; set; }
        public string STcrName3 { get; set; }
        public string STcrName4 { get; set; }
        public string STcrName5 { get; set; }
        public string SContent { get; set; }
        public string SLearned { get; set; }
        public string SEffor1 { get; set; }
        public string SEffor2 { get; set; }
        public string SEffor3 { get; set; }
        public string SEffor4 { get; set; }
        public string SComment { get; set; }
        public string SReason { get; set; }
        public string SMangAppraise { get; set; }
        public string SNote { get; set; }
        public string SReserve1 { get; set; }
        public string SReserve2 { get; set; }
        public string SReserve3 { get; set; }
        public bool BAuth { get; set; }
        public bool BSign { get; set; }
        public decimal ITotalHour { get; set; }
        public string SState { get; set; }
        public string SConditions1 { get; set; }
        public string SConditions2 { get; set; }
        public string SConditions3 { get; set; }
        public string SConditions4 { get; set; }
        public string SConditions5 { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
