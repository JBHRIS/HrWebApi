using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class BaseMaTemp
    {
        public string 工號 { get; set; }
        public string 中文姓名 { get; set; }
        public string Name英文姓名 { get; set; }
        public string 護照號碼 { get; set; }
        public DateTime? 護照到期 { get; set; }
        public DateTime? 入境日期 { get; set; }
        public DateTime? 期滿日期 { get; set; }
        public string 工作期限 { get; set; }
        public string 新統一編號 { get; set; }
    }
}
