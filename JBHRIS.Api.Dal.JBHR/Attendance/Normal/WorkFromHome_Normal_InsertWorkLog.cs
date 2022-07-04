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
    public class WorkFromHome_Normal_InsertWorkLog : IWorkFromHome_Normal_InsertWorkLog
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_InsertWorkLog(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 匯入工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> InsertWorkLog(WorkLogDto workLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<WorkLog>();

                WorkLog WorkdLogInsert = new WorkLog
                {
                    EmployeeId = workLogDto.EmployeeId.Trim(),
                    AttendDate = workLogDto.AttendDate.Date,
                    BeginTime = workLogDto.BeginTime.Trim(),
                    EndTime = workLogDto.EndTime.Trim(),
                    WorkHours = workLogDto.WorkHours,
                    Workitem = workLogDto.Workitem.Trim(),
                    Description = workLogDto.Description.Trim(),
                    FileId = workLogDto.FileId.Trim(),
                    KeyDate = DateTime.Now,
                    KeyMan = workLogDto.KeyMan.Trim(),
                    Guid = Guid.NewGuid()
                };

                Repo.Create(WorkdLogInsert);

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
