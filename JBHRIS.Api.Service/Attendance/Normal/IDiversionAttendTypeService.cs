using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IDiversionAttendTypeService
    {
        ApiResult<List<DiversionAttendTypeDto>> GetDiversionAttendTypes(List<string> DiversionAttendTypes);
        ApiResult<string> InsertDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto);
        ApiResult<string> UpdateDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto);
        ApiResult<string> DeleteDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto);
    }
}
