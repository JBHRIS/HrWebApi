using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendDto
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
        public decimal? Specamt { get; set; }
        public string Specsalcd { get; set; }
        public decimal? Stationamt { get; set; }
        public int? EarlyMins { get; set; }
        public int? DelayMins { get; set; }
        public decimal? RelHrs { get; set; }
        public string RoteH { get; set; }
    }
}
