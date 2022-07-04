using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendanceTypeDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public bool Display { get; set; }
    }
}
