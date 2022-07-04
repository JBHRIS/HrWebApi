using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class RangeSet
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string RangeBegin { get; set; }
        public string RangeEnd { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public string Note5 { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Memo { get; set; }
    }
}
