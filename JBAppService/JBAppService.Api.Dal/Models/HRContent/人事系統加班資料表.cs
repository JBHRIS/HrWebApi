using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class 人事系統加班資料表
    {
        public string 狀態 { get; set; }
        public string 工號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 英文姓名 { get; set; }
        public string 性別 { get; set; }
        public string 身份別 { get; set; }
        public string 直間接 { get; set; }
        public DateTime? 到職日期 { get; set; }
        public decimal? 年資 { get; set; }
        public DateTime? 離職日期 { get; set; }
        public string 部門代碼 { get; set; }
        public string 部門名稱 { get; set; }
        public string 成本部門代碼 { get; set; }
        public string 成本部門名稱 { get; set; }
        public string 職稱代碼 { get; set; }
        public string 職稱 { get; set; }
        public string 職等代碼 { get; set; }
        public string 職等名稱 { get; set; }
        public string 班別 { get; set; }
        public string 職類代碼 { get; set; }
        public string 職類名稱 { get; set; }
        public string 員別代碼 { get; set; }
        public string 員別員稱 { get; set; }
        public DateTime 加班日期 { get; set; }
        public string 加班起時間 { get; set; }
        public string 加班迄時間 { get; set; }
        public decimal 加班總時數 { get; set; }
        public decimal 加班時數 { get; set; }
        public decimal 補休時數 { get; set; }
        public string 成本代碼 { get; set; }
        public string 成本中心 { get; set; }
        public string 備註 { get; set; }
        public string 計薪年月 { get; set; }
        public decimal? 基本薪資 { get; set; }
        public string 加班班別 { get; set; }
        public string 加班班別名稱 { get; set; }
        public string 出勤班別 { get; set; }
        public string 出勤班別名稱 { get; set; }
        public string 上班卡 { get; set; }
        public string 下班卡 { get; set; }
        public decimal? 加班費 { get; set; }
        public string 加班原因 { get; set; }
    }
}
