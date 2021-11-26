using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Rote
    {
        public Rote()
        {
            Attend = new HashSet<Attend>();
            RoteBonus = new HashSet<RoteBonus>();
        }

        public string Rote1 { get; set; }
        public string Rotename { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string ResBTime { get; set; }
        public string ResETime { get; set; }
        public decimal WkHrs { get; set; }
        public decimal DkHrs { get; set; }
        public decimal MoHrs { get; set; }
        public string Offtime2 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Overday { get; set; }
        public bool Night { get; set; }
        public decimal HoliMins { get; set; }
        public decimal WrHrsa { get; set; }
        public decimal WrHrsb { get; set; }
        public decimal Fcolor { get; set; }
        public decimal Bcolor { get; set; }
        public bool Ot { get; set; }
        public string ResB1Time { get; set; }
        public string ResE1Time { get; set; }
        public string ResB2Time { get; set; }
        public string ResE2Time { get; set; }
        public string ResB3Time { get; set; }
        public string ResE3Time { get; set; }
        public string ResB4Time { get; set; }
        public string ResE4Time { get; set; }
        public decimal YrrestHrs { get; set; }
        public bool Rate2 { get; set; }
        public bool Earaward { get; set; }
        public string Foodsalcd { get; set; }
        public decimal Foodamt { get; set; }
        public string Nightsalcd { get; set; }
        public decimal Nightamt { get; set; }
        public decimal Nightamt1 { get; set; }
        public bool Notfood { get; set; }
        public decimal Foodamt1 { get; set; }
        public decimal WkHrsa { get; set; }
        public decimal WkHrsb { get; set; }
        public decimal Alllates { get; set; }
        public string OtBegin { get; set; }
        public string Dd { get; set; }
        public string Calot { get; set; }
        public decimal Foodamto { get; set; }
        public string OverTime { get; set; }
        public string StrTime { get; set; }
        public string Specsalcd { get; set; }
        public decimal Specamt { get; set; }
        public decimal Specamt1 { get; set; }
        public decimal Specamt2 { get; set; }
        public decimal Alllates1 { get; set; }
        public string AttEnd { get; set; }
        public bool Helf { get; set; }
        public decimal BefNightamt { get; set; }
        public decimal AftNightamt { get; set; }
        public string Foodrule { get; set; }
        public string Nightrule { get; set; }
        public string Specrule { get; set; }
        public int? Sort { get; set; }
        public string RoteDisp { get; set; }
        public int? HolidayAddmin { get; set; }

        public virtual ICollection<Attend> Attend { get; set; }
        public virtual ICollection<RoteBonus> RoteBonus { get; set; }
    }
}
