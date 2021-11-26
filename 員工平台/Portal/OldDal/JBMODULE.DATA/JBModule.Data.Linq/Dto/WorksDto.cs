using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class WorksDto
    {
        public string NOBR { get; set; }
        public string COMPANY { get; set; }
        public string TITLE { get; set; }
        public DateTime BDATE { get; set; }
        public DateTime EDATE { get; set; }
        public string JOB { get; set; }
        public string NOTE { get; set; }
        //public string TRADE_CODE { get; set; }
        //public bool IN_MARK { get; set; }
        //public bool IN_CABINET { get; set; }
        //public Decimal VOLUME { get; set; }
        //public string DIR_TITLE { get; set; }
        //public string SEC_TITLE { get; set; }
        //public Decimal PEOPLE { get; set; }
        //public string TEL_NO { get; set; }
        //public string ADDR { get; set; }
        //public int work_id { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
