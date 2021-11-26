using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class DocItem
    {
        public int Auto { get; set; }
        public string CateGory { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Memo { get; set; }
        public bool IsNecessary { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public int? FinalDays { get; set; }
    }
}
