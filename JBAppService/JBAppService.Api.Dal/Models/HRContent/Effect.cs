using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Effect
    {
        public string Apcd { get; set; }
        public string Apcdname { get; set; }
        public decimal Effb { get; set; }
        public decimal Effe { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
