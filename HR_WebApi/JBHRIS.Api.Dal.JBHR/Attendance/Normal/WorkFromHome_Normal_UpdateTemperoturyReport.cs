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
    public class WorkFromHome_Normal_UpdateTemperoturyReport : IWorkFromHome_Normal_UpdateTemperoturyReport
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_UpdateTemperoturyReport(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 更新體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> UpdateTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TemperoturyReport>();

                var TemperoturyReportUpdate = Repo.Reads().Where(x => x.AutoKey == temperoturyReportDto.AutoKey).FirstOrDefault();

                TemperoturyReportUpdate.EmployeeId = temperoturyReportDto.EmployeeId.Trim();
                TemperoturyReportUpdate.AttendDate = temperoturyReportDto.AttendDate.Date;
                TemperoturyReportUpdate.ReportType = temperoturyReportDto.ReportType.Trim();
                TemperoturyReportUpdate.Temperotury = temperoturyReportDto.Temperotury;
                TemperoturyReportUpdate.Description = temperoturyReportDto.Description.Trim();
                TemperoturyReportUpdate.KeyDate = DateTime.Now;
                TemperoturyReportUpdate.KeyMan = temperoturyReportDto.KeyMan.Trim();
              
                Repo.Update(TemperoturyReportUpdate);

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
