using HR_WebApi.Controllers.Attendance;
using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkFromHomeService
    {
        ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry);
        ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry);
        ApiResult<List<DiversionShiftAttendReportDto>> GetDiversionShiftAttendReport(GetDiversionShiftAttendReportEntry getDiversionShiftAttendReportEntry);
    }
}
