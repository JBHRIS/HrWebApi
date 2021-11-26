using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class FamilyDto
    {
        public string FA_IDNO { get; set; }
        public string FA_NAME { get; set; }
        public string REL_CODE { get; set; }
        public DateTime? FA_BIRDT { get; set; }
        public string NOBR { get; set; }
        public string ADDR { get; set; }
        //public bool IMPORT { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
