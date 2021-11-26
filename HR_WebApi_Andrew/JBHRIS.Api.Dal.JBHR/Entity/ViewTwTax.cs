using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ViewTwTax
    {
        public int 編號 { get; set; }
        public string 標題 { get; set; }
        public string 年月 { get; set; }
        public DateTime 起始日期 { get; set; }
        public DateTime 結束日期 { get; set; }
        public string 備註 { get; set; }
        public DateTime 登錄日期 { get; set; }
        public string 登錄者 { get; set; }
        public bool 鎖檔 { get; set; }
        public DateTime? 啟用查詢日期 { get; set; }
    }
}
