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
    public class WorkFromHome_Normal_UpdateWorkLog : IWorkFromHome_Normal_UpdateWorkLog
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_UpdateWorkLog(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 更新工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> UpdateWorkLog(WorkLogDto workLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<WorkLog>();

                var WorkdLogUpdate = Repo.Reads().Where(x => x.AutoKey == workLogDto.AutoKey).FirstOrDefault();

                WorkdLogUpdate.EmployeeId = workLogDto.EmployeeId.Trim();
                WorkdLogUpdate.AttendDate = workLogDto.AttendDate.Date;
                WorkdLogUpdate.BeginTime = workLogDto.BeginTime.Trim();
                WorkdLogUpdate.EndTime = workLogDto.EndTime.Trim();
                WorkdLogUpdate.WorkHours = workLogDto.WorkHours;
                WorkdLogUpdate.Workitem = workLogDto.Workitem.Trim();
                WorkdLogUpdate.Description = workLogDto.Description.Trim();
                WorkdLogUpdate.FileId = workLogDto.FileId.Trim();
                WorkdLogUpdate.KeyDate = DateTime.Now;
                WorkdLogUpdate.KeyMan = workLogDto.KeyMan.Trim();

                Repo.Update(WorkdLogUpdate);

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
