using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class FencePoints
    {
        public int AutoKey { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double? Distance { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public bool? Status { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string PointsGroup { get; set; }
    }
}
