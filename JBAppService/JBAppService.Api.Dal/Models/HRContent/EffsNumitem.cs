using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsNumitem
    {
        public int AutoKey { get; set; }
        public string NumId { get; set; }
        public string NumName { get; set; }
        public decimal MinNum { get; set; }
        public decimal MaxNum { get; set; }
        public decimal? MinRate { get; set; }
        public decimal? MaxRate { get; set; }
    }
}
