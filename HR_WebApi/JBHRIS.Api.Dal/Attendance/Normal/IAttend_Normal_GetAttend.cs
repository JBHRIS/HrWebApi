using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAttend_Normal_GetAttend
    {
        public List<AttendDto> GetAttend(List<string> EmployeeList, DateTime StartDate, DateTime EndDate);
    }
}
