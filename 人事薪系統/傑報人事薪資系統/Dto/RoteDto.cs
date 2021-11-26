using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Dto
{
    public class RoteDto
    {
        public string Rote { get; set; }
        public string RoteDisp { get; set; }
        public string RoteName { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public decimal WorkHours { get; set; }
        public Dictionary<string,string> RestTimes { get; set; }
        public int FlexMinutes { get; internal set; }
    }
}
