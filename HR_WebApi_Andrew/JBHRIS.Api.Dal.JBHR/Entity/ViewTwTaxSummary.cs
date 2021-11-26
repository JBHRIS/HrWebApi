using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ViewTwTaxSummary
    {
        public int 編號 { get; set; }
        public string 員工編號 { get; set; }
        public decimal 給付總額 { get; set; }
        public decimal 扣繳稅額 { get; set; }
        public string 所得格式 { get; set; }
        public string 備註 { get; set; }
        public string 登錄者 { get; set; }
        public DateTime 登錄日期 { get; set; }
        public string 稅籍編號 { get; set; }
        public string 公司別代碼 { get; set; }
        public bool 匯入 { get; set; }
        public decimal 勞退自提 { get; set; }
        public bool 已申報 { get; set; }
        public string 郵遞區號 { get; set; }
        public string 戶籍地址 { get; set; }
        public string 員工姓名 { get; set; }
        public string 身分證號 { get; set; }
        public string 流水號 { get; set; }
        public string 證號別 { get; set; }
        public string 公司統編 { get; set; }
        public string 機關別 { get; set; }
        public string 媒體代號 { get; set; }
        public string 錯誤註記 { get; set; }
        public string 公司名稱 { get; set; }
        public string 所得註記 { get; set; }
        public int Pid { get; set; }
    }
}
