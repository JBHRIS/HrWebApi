using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class LICANDto
    {
        public string NOBR { get; set; }
        public string DESCS { get; set; }
        public string COMP { get; set; }
        public DateTime MDATE { get; set; }
        public DateTime EDATE { get; set; }
        public string LIC_NO { get; set; }
        public string LIC_NOTE { get; set; }
        //public int lican_id { get; set; }
        public Boolean OWNER { get; set; }
        public Boolean LIC_PASS { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
