using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ViewSalarycorrection
    {
        public string 主鍵 { get; set; }
        public string 員工編號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 異動狀態 { get; set; }
        public string 計薪年月 { get; set; }
        public string 期別 { get; set; }
        public decimal? 應發薪資 { get; set; }
        public decimal? 應付薪資 { get; set; }
        public decimal? 實付薪資 { get; set; }
        public DateTime 計薪日期起 { get; set; }
        public DateTime 計薪日期迄 { get; set; }
        public DateTime? 出勤日期起 { get; set; }
        public DateTime? 出勤日期迄 { get; set; }
        public string Saladr { get; set; }
        public string 公司編號 { get; set; }
        public DateTime? 到職日 { get; set; }
        public DateTime? 離職日 { get; set; }
        public string 自願性離職 { get; set; }
        public string 性別 { get; set; }
    }
}
