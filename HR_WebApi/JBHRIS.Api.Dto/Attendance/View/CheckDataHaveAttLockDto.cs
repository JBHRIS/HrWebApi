using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class CheckDataHaveAttLockDto
    {
        public bool haveLockData { get; set; }
        public string ErrorMessage { get; set; }
    }
}
