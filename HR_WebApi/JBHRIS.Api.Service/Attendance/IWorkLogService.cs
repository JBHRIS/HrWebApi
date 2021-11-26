using HR_WebApi.Controllers.Attendance;
using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkLogService
    {
        ApiResult<List<WorkLogDto>> GetWorkLog(GetWorkLogEntry getWorkLogEntry);
        ApiResult<string> InsertWorkLog(WorkLogDto workLogDto);
        ApiResult<string> UpdateWorkLog(WorkLogDto workLogDto);
        ApiResult<string> DeleteWorkLog(WorkLogDto workLogDto);
    }
}
