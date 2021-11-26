using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CodeFilter
    {
        public string Source { get; set; }
        public string Code { get; set; }
        public string Codegroup { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
