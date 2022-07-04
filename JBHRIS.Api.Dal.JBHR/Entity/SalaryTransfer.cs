using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SalaryTransfer
    {
        public int Auto { get; set; }
        public string Bankcode { get; set; }
        public string Classify { get; set; }
        public int No { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Location { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public string Filled { get; set; }
        public string Yeartype { get; set; }
        public string Dateformat { get; set; }
        public string Fixedcontent { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
