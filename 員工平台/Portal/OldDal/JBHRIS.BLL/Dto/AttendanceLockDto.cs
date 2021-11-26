using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttendanceLockDto
    {
        public DateTime AttendanceDate { get; set; }
        public List<string> LockedDatagroupList { get; set; }
    }
}
