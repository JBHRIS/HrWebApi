using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UserFoodCardNumber
    {
        public string Nobr { get; set; }
        public string Cardno { get; set; }
        public DateTime Bdate { get; set; }
        public string NameC { get; set; }
        public DateTime? Edate { get; set; }
    }
}
