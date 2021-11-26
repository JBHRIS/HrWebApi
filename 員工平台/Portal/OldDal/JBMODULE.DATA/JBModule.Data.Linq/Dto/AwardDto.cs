using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class AwardDto
    {
        public string NOBR { get; set; }
        public DateTime ADATE { get; set; }
        public string AWARD_CODE { get; set; }
        public Decimal AWARD1 { get; set; }
        public Decimal AWARD2 { get; set; }
        public Decimal AWARD3 { get; set; }
        public Decimal AWARD4 { get; set; }
        //public bool AWARD5 { get; set; }
        //public Decimal AWARD6 { get; set; }
        public Decimal FAULT1 { get; set; }
        public Decimal FAULT2 { get; set; }
        public Decimal FAULT3 { get; set; }
        public Decimal FAULT4 { get; set; }
        //public Decimal FAULT5 { get; set; }
        public string YYMM { get; set; }
        public string NOTE { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
