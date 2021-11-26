using HR_WebApi.Controllers.Attendance;
using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface ITemperoturyReportService
    {
        ApiResult<List<TemperoturyReportDto>> GetTemperoturyReport(GetTemperoturyReportEntry getTemperoturyReportEntry);
        ApiResult<string> InsertTemperoturyReport(TemperoturyReportDto temperoturyReportDto);
        ApiResult<string> UpdateTemperoturyReport(TemperoturyReportDto temperoturyReportDto);
        ApiResult<string> DeleteTemperoturyReport(TemperoturyReportDto temperoturyReportDto);
    }
}
