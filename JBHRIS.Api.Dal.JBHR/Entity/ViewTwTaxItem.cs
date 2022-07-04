using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ViewTwTaxItem
    {
        public int 編號 { get; set; }
        public int Pid { get; set; }
        public string 員工編號 { get; set; }
        public string 所得年月 { get; set; }
        public string 期別 { get; set; }
        public string 來源 { get; set; }
        public decimal 給付總額 { get; set; }
        public decimal 扣繳稅額 { get; set; }
        public string 所得格式 { get; set; }
        public string 備註 { get; set; }
        public string 登錄者 { get; set; }
        public DateTime 登錄日期 { get; set; }
        public string 稅籍編號 { get; set; }
        public bool 匯入 { get; set; }
        public string 公司 { get; set; }
        public string 公司名稱 { get; set; }
        public string 員工姓名 { get; set; }
        public decimal 自提退休金 { get; set; }
        public bool 已申報 { get; set; }
        public string 所得註記 { get; set; }
    }
}
