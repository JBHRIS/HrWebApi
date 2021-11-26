using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Frm27
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Rote { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal LateMins { get; set; }
        public decimal EMins { get; set; }
        public bool Abs { get; set; }
        public string AdjCode { get; set; }
        public bool CantAdj { get; set; }
        public decimal Ser { get; set; }
        public decimal NightHrs { get; set; }
        public decimal Foodamt { get; set; }
        public string Foodsalcd { get; set; }
        public decimal Forget { get; set; }
        public decimal AttHrs { get; set; }
        public decimal Nigamt { get; set; }
        public string NameC { get; set; }
        public string Dept { get; set; }
        public string Rotename { get; set; }
        public string RoteH { get; set; }
    }
}
