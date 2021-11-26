using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class ContractDto
    {
        public string NOBR { get; set; }
        public string ContractType { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public string WorkAdr { get; set; }
        //public string NotifyMessageGuid { get; set; }
        public int AlertDay { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
