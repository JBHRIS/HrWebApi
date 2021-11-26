using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class GetCardAddForgetTimeDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendDate { get; set; }
        public int ForgetTime { get; set; }
    }
}
