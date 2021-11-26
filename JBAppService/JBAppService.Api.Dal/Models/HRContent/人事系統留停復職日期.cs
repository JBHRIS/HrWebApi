using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class 人事系統留停復職日期
    {
        public string Ttscode { get; set; }
        public DateTime 生效日 { get; set; }
        public string 狀態 { get; set; }
        public DateTime? 離職或復職日 { get; set; }
        public string Nobr { get; set; }
    }
}
