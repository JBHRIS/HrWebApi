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
    public class WorkFromHome_Normal_GetWorkLog : IWorkFromHome_Normal_GetWorkLog
    {
        private IUnitOfWork _unitOfWork;
        public WorkFromHome_Normal_GetWorkLog(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 取得工作日誌資料
        /// </summary>
        /// <param name="getWorkLogEntry"></param>
        /// <returns></returns>
        public ApiResult<List<WorkLogDto>> GetWorkLog(GetWorkLogEntry getWorkLogEntry)
        {
            ApiResult<List<WorkLogDto>> apiResult = new ApiResult<List<WorkLogDto>>();
            apiResult.State = false;
            try
            {
                var GetWorkLogList = from a in _unitOfWork.Repository<WorkLog>().Reads()
                                     join b in _unitOfWork.Repository<Base>().Reads() on a.EmployeeId equals b.Nobr
                                     where getWorkLogEntry.EmployeeList.Contains(a.EmployeeId)
                                        && getWorkLogEntry.DateBegin <= a.AttendDate
                                        && getWorkLogEntry.DateEnd >= a.AttendDate
                                     select new WorkLogDto
                                     {
                                         EmployeeId = a.EmployeeId,
                                         EmployeeName = b.NameC,
                                         AttendDate = a.AttendDate,
                                         BeginTime = a.BeginTime,
                                         EndTime = a.EndTime,
                                         WorkHours = a.WorkHours,
                                         Workitem = a.Workitem,
                                         Description = a.Description,
                                         FileId = a.FileId,
                                         AutoKey = a.AutoKey,
                                         Guid = a.Guid
                                     };

                apiResult.Result = GetWorkLogList.ToList();
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
