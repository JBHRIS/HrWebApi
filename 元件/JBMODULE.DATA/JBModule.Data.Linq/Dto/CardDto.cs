using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class CardDto
    {
        public string NOBR { get; set; }
        public DateTime ADATE { get; set; }
        public string ONTIME { get; set; }
        public string REASON { get; set; }
        public string MENO { get; set; }
        public bool LOS { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
