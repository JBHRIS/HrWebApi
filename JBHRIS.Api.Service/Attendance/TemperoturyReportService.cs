using HR_WebApi.Controllers.Attendance;
using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.Attendance.Normal;
using NLog;

namespace JBHRIS.Api.Service.Attendance
{
    public class TemperoturyReportService : ITemperoturyReportService
    {
        private IWorkFromHome_Normal_GetTemperoturyReport _workFromHome_Normal_GetTemperoturyReport;
        private IWorkFromHome_Normal_InsertTemperoturyReport _workFromHome_Normal_InsertTemperoturyReport;
        private IWorkFromHome_Normal_UpdateTemperoturyReport _workFromHome_Normal_UpdateTemperoturyReport;
        private IWorkFromHome_Normal_DeleteTemperoturyReport _workFromHome_Normal_DeleteTemperoturyReport;
        private ILogger _logger;

        public TemperoturyReportService(IWorkFromHome_Normal_GetTemperoturyReport workFromHome_Normal_GetTemperoturyReport
            , IWorkFromHome_Normal_InsertTemperoturyReport workFromHome_Normal_InsertTemperoturyReport
            , IWorkFromHome_Normal_UpdateTemperoturyReport workFromHome_Normal_UpdateTemperoturyReport
            , IWorkFromHome_Normal_DeleteTemperoturyReport workFromHome_Normal_DeleteTemperoturyReport
            , ILogger logger)
        {
            _workFromHome_Normal_GetTemperoturyReport = workFromHome_Normal_GetTemperoturyReport;
            _workFromHome_Normal_InsertTemperoturyReport = workFromHome_Normal_InsertTemperoturyReport;
            _workFromHome_Normal_UpdateTemperoturyReport = workFromHome_Normal_UpdateTemperoturyReport;
            _workFromHome_Normal_DeleteTemperoturyReport = workFromHome_Normal_DeleteTemperoturyReport;
            _logger = logger;
        }

        /// <summary>
        /// 取得體溫回報資料
        /// </summary>
        /// <param name="getTemperoturyReportEntry"></param>
        /// <returns></returns>
        public ApiResult<List<TemperoturyReportDto>> GetTemperoturyReport(GetTemperoturyReportEntry getTemperoturyReportEntry)
        {
            return _workFromHome_Normal_GetTemperoturyReport.GetTemperoturyReport(getTemperoturyReportEntry);
        }

        /// <summary>
        /// 匯入體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> InsertTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            return _workFromHome_Normal_InsertTemperoturyReport.InsertTemperoturyReport(temperoturyReportDto);
        }

        /// <summary>
        /// 更新體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> UpdateTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            return _workFromHome_Normal_UpdateTemperoturyReport.UpdateTemperoturyReport(temperoturyReportDto);
        }

        /// <summary>
        /// 刪除體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> DeleteTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            return _workFromHome_Normal_DeleteTemperoturyReport.DeleteTemperoturyReport(temperoturyReportDto);
        }
    }
}