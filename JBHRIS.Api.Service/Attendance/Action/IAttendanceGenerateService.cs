using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Action
{
    public interface IAttendanceGenerateService
    {
        ApiResult<List<AttendDto>> Generate(List<string> employeeList, DateTime DateBegin, DateTime DateEnd);
    }
}
