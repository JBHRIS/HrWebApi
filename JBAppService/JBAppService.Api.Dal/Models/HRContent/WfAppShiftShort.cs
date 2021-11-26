using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class WfAppShiftShort
    {
        public int IAutoKey { get; set; }
        public string SFormCode { get; set; }
        public string SProcessId { get; set; }
        public int IdProcess { get; set; }
        public string SNobr { get; set; }
        public string SNobrA { get; set; }
        public string SNameA { get; set; }
        public string SDeptA { get; set; }
        public string SDeptNameA { get; set; }
        public string SJobA { get; set; }
        public string SJobNameA { get; set; }
        public string SJoblA { get; set; }
        public string SJoblNameA { get; set; }
        public string SEmpcdA { get; set; }
        public string SEmpcdNameA { get; set; }
        public string SRoleA { get; set; }
        public string SDia { get; set; }
        public string SRoteA { get; set; }
        public string SRoteNameA { get; set; }
        public DateTime DDateA { get; set; }
        public string SNobrB { get; set; }
        public string SNameB { get; set; }
        public string SDeptB { get; set; }
        public string SDeptNameB { get; set; }
        public string SJobB { get; set; }
        public string SJobNameB { get; set; }
        public string SJoblB { get; set; }
        public string SJoblNameB { get; set; }
        public string SEmpcdB { get; set; }
        public string SEmpcdNameB { get; set; }
        public string SRoleB { get; set; }
        public string SDib { get; set; }
        public string SRoteB { get; set; }
        public string SRoteNameB { get; set; }
        public DateTime DDateB { get; set; }
        public string SReserve1 { get; set; }
        public string SReserve2 { get; set; }
        public string SReserve3 { get; set; }
        public string SReserve4 { get; set; }
        public bool BSign { get; set; }
        public string SState { get; set; }
        public bool BAuth { get; set; }
        public string SNote { get; set; }
        public DateTime? DKeyDate { get; set; }
        public string SManage { get; set; }
        public string SGuid { get; set; }
    }
}
