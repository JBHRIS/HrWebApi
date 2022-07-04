using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IWorkFromHome_Normal_DeleteWorkLog
    {
        ApiResult<string> DeleteWorkLog(WorkLogDto workLogDto);
    }
}