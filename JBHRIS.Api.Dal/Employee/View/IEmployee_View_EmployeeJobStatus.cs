using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Employee.View
{
    public interface IEmployee_View_EmployeeJobStatus
    {
        ApiResult<string> AddChange(BasettsDto basettsDto);
        ApiResult<string> UpdateChange(BasettsDto basettsDto);
        ApiResult<string> ValidateTtscode(string CurrentTtscode, string NewTtscode);
        ApiResult<string> CheckChange(BasettsDto basettsDto);
        BasettsDto GetCurrentJobStatus(string EmployeeId, DateTime CheckDate);
        List<BasettsDto> GetEmployeeJobStatus(string EmployeeId);
    }
}
