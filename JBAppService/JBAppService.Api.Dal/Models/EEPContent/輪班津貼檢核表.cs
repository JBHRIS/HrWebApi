using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class 輪班津貼檢核表
    {
        public string 員工編號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 公司代碼 { get; set; }
        public string 公司名稱 { get; set; }
        public string 部門代碼 { get; set; }
        public string 部門名稱 { get; set; }
        public DateTime? 出勤日期 { get; set; }
        public string 班別代碼 { get; set; }
        public string 班別名稱 { get; set; }
        public string 薪資代碼 { get; set; }
        public string 薪資名稱 { get; set; }
        public decimal? 設定金額 { get; set; }
        public decimal? 請假時數 { get; set; }
        public decimal? 工作時數 { get; set; }
        public decimal? 應發金額 { get; set; }
        public decimal 實發金額 { get; set; }
        public decimal? 差額 { get; set; }
    }
}
