using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class RoteDto
    {
        public string Rote { get; set; }
        public string RoteName { get; set; }
        public List<Tuple<DateTime, DateTime>> WorkTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> RestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> OtRestTimes { get; set; }
        public decimal WorkHours { get; set; }
        public int LateBufferMins { get; set; }
        public int FlexibleMins { get; set; }
        public DateTime LastCardTime { get; set; }
    }
}
