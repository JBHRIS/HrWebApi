using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ViewAbswriteoff
    {
        public string 屬性 { get; set; }
        public string 員工編號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 計薪年月 { get; set; }
        public string 班別 { get; set; }
        public string 班別名稱 { get; set; }
        public string 假別代碼 { get; set; }
        public string 假別 { get; set; }
        public string 假別名稱 { get; set; }
        public DateTime 請假日期 { get; set; }
        public string 請假起 { get; set; }
        public string 請假迄 { get; set; }
        public decimal 請假時數 { get; set; }
        public string 單位 { get; set; }
        public string 編號 { get; set; }
        public string 登錄者 { get; set; }
        public DateTime 登錄日 { get; set; }
        public string 扣款金額 { get; set; }
    }
}
