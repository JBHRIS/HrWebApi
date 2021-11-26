using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EatitemSp
    {
        public int Autokey { get; set; }
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public DateTime? Adate { get; set; }
        public string Eattype { get; set; }
        public int? Eatnum { get; set; }
        public decimal? Eatamt { get; set; }
        public string Note { get; set; }
        public string Depts { get; set; }
        public string Deptsname { get; set; }
        public string Workcd { get; set; }
    }
}
