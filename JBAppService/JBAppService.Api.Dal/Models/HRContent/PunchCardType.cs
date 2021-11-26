using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class PunchCardType
    {
        public int AutoKey { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public int? ItemOrder { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
