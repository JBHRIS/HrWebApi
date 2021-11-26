using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ReportEntitleExtend
    {
        public string 員工編號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 假別種類 { get; set; }
        public string 假別代碼 { get; set; }
        public string 假別名稱 { get; set; }
        public DateTime 生效日期 { get; set; }
        public DateTime 失效日期 { get; set; }
        public decimal 得假 { get; set; }
        public decimal? 已請 { get; set; }
        public decimal? 剩餘 { get; set; }
        public string 單位 { get; set; }
        public string 備註 { get; set; }
        public DateTime 登錄日期 { get; set; }
        public string 登錄者 { get; set; }
        public string 編號 { get; set; }
    }
}
