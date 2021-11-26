using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FoodItem
    {
        public string Foodcode { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Ontime { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool NotTran { get; set; }
        public string Memo { get; set; }
    }
}
