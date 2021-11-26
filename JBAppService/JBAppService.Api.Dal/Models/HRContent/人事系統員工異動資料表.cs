using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class 人事系統員工異動資料表
    {
        public DateTime Adate { get; set; }
        public string 狀態 { get; set; }
        public string 工號 { get; set; }
        public string 員工姓名 { get; set; }
        public string 英文姓名 { get; set; }
        public string 部門代碼 { get; set; }
        public string 原部門 { get; set; }
        public string 異動後部門代碼 { get; set; }
        public string 異動後部門 { get; set; }
        public string 成本部門代碼 { get; set; }
        public string 原成本部門 { get; set; }
        public string 異動後成本部門代碼 { get; set; }
        public string 異動後成本部門 { get; set; }
        public string 原職稱代碼 { get; set; }
        public string 原職稱 { get; set; }
        public string 異動後職稱代碼 { get; set; }
        public string 異動後職稱 { get; set; }
        public string 原職等 { get; set; }
        public string 異動後職等 { get; set; }
        public string 原直間接 { get; set; }
        public string 異動後直間接 { get; set; }
        public string 異動原因代碼 { get; set; }
        public string 異動原因 { get; set; }
    }
}
