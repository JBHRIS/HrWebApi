
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    /// <summary>
    /// 調班
    /// </summary>
    public class LongShiftChangeApplyDto
    {
        public string EmployeeId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string AfterShiftGroupCode { get; set; }

        public LongShiftChangeApplyDto()
        {

        }
    }
}
