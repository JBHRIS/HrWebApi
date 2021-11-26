using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Attend
    {
        public Attend()
        {
            AbsNavigation = new HashSet<Abs>();
            Abspre = new HashSet<Abspre>();
            Attcard = new HashSet<Attcard>();
            Card = new HashSet<Card>();
            Ot = new HashSet<Ot>();
            Rotechg = new HashSet<Rotechg>();
        }

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
        public int? EarlyMins { get; set; }
        public int? DelayMins { get; set; }
        public string RoteH { get; set; }

        public virtual Base NobrNavigation { get; set; }
        public virtual Rote RoteNavigation { get; set; }
        public virtual ICollection<Abs> AbsNavigation { get; set; }
        public virtual ICollection<Abspre> Abspre { get; set; }
        public virtual ICollection<Attcard> Attcard { get; set; }
        public virtual ICollection<Card> Card { get; set; }
        public virtual ICollection<Ot> Ot { get; set; }
        public virtual ICollection<Rotechg> Rotechg { get; set; }
    }
}
