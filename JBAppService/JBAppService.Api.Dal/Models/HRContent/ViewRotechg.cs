using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ViewRotechg
    {
        public string 員工編號 { get; set; }
        public DateTime 調班日期 { get; set; }
        public string 登錄者 { get; set; }
        public DateTime 登錄日期 { get; set; }
        public int 編號 { get; set; }
        public string Code { get; set; }
        public string 員工姓名 { get; set; }
        public string 班別名稱 { get; set; }
        public string 班別代碼 { get; set; }
    }
}
