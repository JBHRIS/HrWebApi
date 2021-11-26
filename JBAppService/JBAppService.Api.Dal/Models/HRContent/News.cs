using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class News
    {
        public string NewsId { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDeadline { get; set; }
        public bool IsOn { get; set; }
        public string Newsfileid { get; set; }
        public string PostMan { get; set; }
        public int? Sort { get; set; }
        public int? AttachmentCount { get; set; }
        public string PublishAllEmp { get; set; }
        public DateTime? LatestSendMailDate { get; set; }
        public int? BrowsingNumber { get; set; }
    }
}
