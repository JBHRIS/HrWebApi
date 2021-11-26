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
    public class WorkFromHome_Normal_InsertTemperoturyReport : IWorkFromHome_Normal_InsertTemperoturyReport
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_InsertTemperoturyReport(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 匯入體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> InsertTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TemperoturyReport>();

                TemperoturyReport TemperoturyReportInsert = new TemperoturyReport
                {
                    EmployeeId = temperoturyReportDto.EmployeeId.Trim(),
                    AttendDate = temperoturyReportDto.AttendDate.Date,
                    ReportType = temperoturyReportDto.ReportType.Trim(),
                    Temperotury = temperoturyReportDto.Temperotury,
                    Description = temperoturyReportDto.Description.Trim(),
                    KeyDate = DateTime.Now,
                    KeyMan = temperoturyReportDto.KeyMan.Trim(),
                    Guid = Guid.NewGuid()
                };

                Repo.Create(TemperoturyReportInsert);

                Repo.SaveChanges();

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
