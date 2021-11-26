using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class ExamineDto
    {
        public string EFFLVL { get; set; }
        public decimal EFFSCORE { get; set; }
        public string EFFTYPE { get; set; }
        public string NOBR { get; set; }
        public string YYMM { get; set; }
        public bool IMPORT { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
