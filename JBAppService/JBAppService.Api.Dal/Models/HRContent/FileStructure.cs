using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FileStructure
    {
        public string Code { get; set; }
        public string SPath { get; set; }
        public string SFileName { get; set; }
        public string SFileTitle { get; set; }
        public string SDescription { get; set; }
        public string SParentKey { get; set; }
        public int IOrder { get; set; }
        public string SKeyMan { get; set; }
        public DateTime? DKeyDate { get; set; }
        public string SIconPath { get; set; }
        public string SIconName { get; set; }
        public bool OpenNewWin { get; set; }
        public string NoticeContent { get; set; }
        public string NoticeTitle { get; set; }
        public bool? DisplayNotice { get; set; }
    }
}
