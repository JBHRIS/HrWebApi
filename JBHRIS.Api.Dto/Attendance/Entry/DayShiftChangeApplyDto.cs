
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    /// <summary>
    /// 換班
    /// </summary>
    public class DayShiftChangeApplyDto
    {

        public string EmployeeId { get; set; }
        public DateTime ShiftDate { get; set; }
        public string AfterShiftCode { get; set; }
        public string Code { get; set; }
        public string KeyMan { get; set; }

        public DayShiftChangeApplyDto()
        {
            Code = "";
        }
    }
}
