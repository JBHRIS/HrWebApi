using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IDiversionShiftService
    {
        ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry);
        ApiResult<string> InsertDiversionShift(DiversionShiftDto diversionShiftDto);
        ApiResult<string> UpdateDiversionShift(DiversionShiftDto diversionShiftDto);
        ApiResult<string> DeleteDiversionShift(DiversionShiftDto diversionShiftDto);
    }
}
