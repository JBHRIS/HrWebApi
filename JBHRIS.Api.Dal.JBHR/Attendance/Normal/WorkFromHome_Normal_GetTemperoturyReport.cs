using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dal.JBHR.Repository;
using HR_WebApi.Dto.Attendance;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class WorkFromHome_Normal_GetTemperoturyReport : IWorkFromHome_Normal_GetTemperoturyReport
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_GetTemperoturyReport(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 取得體溫回報報表
        /// </summary>
        /// <param name="getTemperoturyReportEntry"></param>
        /// <returns></returns>
        public ApiResult<List<TemperoturyReportDto>> GetTemperoturyReport(GetTemperoturyReportEntry getTemperoturyReportEntry)
        {
            ApiResult<List<TemperoturyReportDto>> apiResult = new ApiResult<List<TemperoturyReportDto>>();
            apiResult.State = false;
            try
            {
                var GetTemperoturyReports = from a in _unitOfWork.Repository<TemperoturyReport>().Reads()
                                            join b in _unitOfWork.Repository<Base>().Reads() on a.EmployeeId equals b.Nobr
                                            where getTemperoturyReportEntry.EmployeeList.Contains(a.EmployeeId)
                                               && getTemperoturyReportEntry.DateBegin <= a.AttendDate
                                               && getTemperoturyReportEntry.DateEnd >= a.AttendDate
                                            select new TemperoturyReportDto
                                            {
                                                EmployeeId = a.EmployeeId,
                                                EmployeeName = b.NameC,
                                                AttendDate = a.AttendDate,
                                                ReportType = a.ReportType,
                                                Temperotury = a.Temperotury,
                                                Description = a.Description,
                                                AutoKey = a.AutoKey,
                                                Guid = a.Guid
                                            };

                apiResult.Result = GetTemperoturyReports.ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }
    }
}
