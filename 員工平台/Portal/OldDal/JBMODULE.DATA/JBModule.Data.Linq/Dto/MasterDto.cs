using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class MasterDto
    {
        public string NOBR { get; set; }
        public string MASTER { get; set; }
        public string RELISH_CODE { get; set; }
        public string RELISH { get; set; }
        public string CORPORATION { get; set; }
        public string LANGUAGE { get; set; }
        public string MEMO { get; set; }
        //public int master_id { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
