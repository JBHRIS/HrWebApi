using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttSalLockDataDto
    {
        public List<CancelLeaveApplyDto> attLockList { get; set; }
        public List<CancelLeaveApplyDto> salLockList { get; set; }
    }
}
