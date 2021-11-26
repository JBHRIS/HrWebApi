using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class IdType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string CheckType { get; set; }
        public string KeyMan { get; set; }
        public string KeyDate { get; set; }
    }
}
