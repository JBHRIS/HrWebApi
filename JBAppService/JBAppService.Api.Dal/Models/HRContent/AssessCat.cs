using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AssessCat
    {
        public int IAutoKey { get; set; }
        public string STemplateCode { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public int IOrder { get; set; }
        public string SKeyMan { get; set; }
        public DateTime? DKeyDate { get; set; }
    }
}
