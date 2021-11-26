using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class SCHLDto
    {
        public string NOBR { get; set; }
        public string EDUCCODE { get; set; }
        public string SCHL { get; set; }
        public string SUBJ { get; set; }
        public DateTime ADATE { get; set; }
        public string DATE_B { get; set; }
        public string DATE_E { get; set; }
        //public string SUBJCODE { get; set; }
        //public int schl_id { get; set; }
        public string DayOrNight { get; set; }
        public string SUBJ_DETAIL { get; set; }
        public Boolean OK { get; set; }
        public Boolean Graduated { get; set; }
        public string MEMO { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
