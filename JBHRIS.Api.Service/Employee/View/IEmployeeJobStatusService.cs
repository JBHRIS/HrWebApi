using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Employee.View
{
    public interface IEmployeeJobStatusService
    {
        ApiResult<string> AddChange(BasettsDto basettsDto);
        ApiResult<string> UpdateChange(BasettsDto basettsDto);
        ApiResult<BasettsDto> GetCurrentJobStatus(string Nobr, DateTime Adate);
        ApiResult<string> CheckEmployeeJobStatusChange(BasettsDto basettsDto);
        ApiResult<DateTime?> GetEmployeeStartWorkDate(string EmployeeID);
    }
}
