using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Orgtree
    {
        public int Autokey { get; set; }
        public DateTime Adate { get; set; }
        public string Org { get; set; }
        public string OrgName { get; set; }
        public string OrgParent { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
