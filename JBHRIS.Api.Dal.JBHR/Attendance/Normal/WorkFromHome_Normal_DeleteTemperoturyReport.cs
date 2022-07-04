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
    public class WorkFromHome_Normal_DeleteTemperoturyReport : IWorkFromHome_Normal_DeleteTemperoturyReport
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_DeleteTemperoturyReport(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 刪除體溫回報資料
        /// </summary>
        /// <param name="temperoturyReportDto"></param>
        /// <returns></returns>
        public ApiResult<string> DeleteTemperoturyReport(TemperoturyReportDto temperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<TemperoturyReport>();

                var TemperoturyReportDelete = Repo.Read(x => x.AutoKey == temperoturyReportDto.AutoKey);

                if (TemperoturyReportDelete != null)
                {
                    Repo.Delete(TemperoturyReportDelete);

                    Repo.SaveChanges();

                    apiResult.State = true;
                }
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
