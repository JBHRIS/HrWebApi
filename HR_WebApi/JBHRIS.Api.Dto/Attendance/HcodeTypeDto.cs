using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class HcodeTypeDto
    {
        public string Htype { get; set; }
        public string TypeName { get; set; }
        public string GetCode { get; set; }
        public int Sort { get; set; }
        public string YearMax { get; set; }
        public bool AutoCreateHours { get; set; }
        public bool MergeDisplay { get; set; }
        public string Unit { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string ExtendCode { get; set; }
        public string ExpireCode { get; set; }
    }
}
