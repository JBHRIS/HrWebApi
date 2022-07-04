using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.WorkFromHome
{
    public class DiversionAttendTypeDto
    {
        public string DiversionAttendType { get; set; }
        public string DiversionAttendTypeName { get; set; }
        public bool CheckWfhAttend { get; set; }
        public bool CheckWorkLog { get; set; }
        public bool CheckWebCard { get; set; }
        public bool CheckTemperoturyReport { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
        public Guid Guid { get; set; }
    }
}
