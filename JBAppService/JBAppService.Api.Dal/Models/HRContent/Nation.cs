using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Nation
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int Sort { get; set; }
    }
}
