using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Accsal
    {
        public string DNo { get; set; }
        public string Acccd { get; set; }
        public string CodeD { get; set; }
        public string CodeC { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool? DispCostname { get; set; }
    }
}
