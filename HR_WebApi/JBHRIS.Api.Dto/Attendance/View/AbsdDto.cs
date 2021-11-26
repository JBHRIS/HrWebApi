using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class AbsdDto
    {
        public int Ak { get; set; }
        public string Absadd { get; set; }
        public string Abssubtract { get; set; }
        public decimal Usehour { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
