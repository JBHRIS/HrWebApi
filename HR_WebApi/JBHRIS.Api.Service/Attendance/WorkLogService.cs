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
using JBHRIS.Api.Dto.Attendance.WorkFromHome;
using JBHRIS.Api.Dal.Attendance.Normal;
using NLog;

namespace JBHRIS.Api.Service.Attendance
{
    public class WorkLogService : IWorkLogService
    {
        private IWorkFromHome_Normal_GetWorkLog _workFromHome_Normal_GetWorkLog;
        private IWorkFromHome_Normal_InsertWorkLog _workFromHome_Normal_InsertWorkLog;
        private IWorkFromHome_Normal_UpdateWorkLog _workFromHome_Normal_UpdateWorkLog;
        private IWorkFromHome_Normal_DeleteWorkLog _workFromHome_Normal_DeleteWorkLog;
        private ILogger _logger;

        public WorkLogService(IWorkFromHome_Normal_GetWorkLog workFromHome_Normal_GetWorkLog
            , IWorkFromHome_Normal_InsertWorkLog workFromHome_Normal_InsertWorkLog
            , IWorkFromHome_Normal_UpdateWorkLog workFromHome_Normal_UpdateWorkLog
            , IWorkFromHome_Normal_DeleteWorkLog workFromHome_Normal_DeleteWorkLog
            , ILogger logger)
        {
            _workFromHome_Normal_GetWorkLog = workFromHome_Normal_GetWorkLog;
            _workFromHome_Normal_InsertWorkLog = workFromHome_Normal_InsertWorkLog;
            _workFromHome_Normal_UpdateWorkLog = workFromHome_Normal_UpdateWorkLog;
            _workFromHome_Normal_DeleteWorkLog = workFromHome_Normal_DeleteWorkLog;
            _logger = logger;
        }
        /// <summary>
        /// 取得工作日誌資料
        /// </summary>
        /// <param name="getWorkLogEntry"></param>
        /// <returns></returns>
        public ApiResult<List<WorkLogDto>> GetWorkLog(GetWorkLogEntry getWorkLogEntry)
        {
            return _workFromHome_Normal_GetWorkLog.GetWorkLog(getWorkLogEntry);
        }

        /// <summary>
        /// 新增工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> InsertWorkLog(WorkLogDto workLogDto)
        {
            return _workFromHome_Normal_InsertWorkLog.InsertWorkLog(workLogDto);
        }

        /// <summary>
        /// 更新工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> UpdateWorkLog(WorkLogDto workLogDto)
        {
            return _workFromHome_Normal_UpdateWorkLog.UpdateWorkLog(workLogDto);
        }

        /// <summary>
        /// 刪除工作日誌資料
        /// </summary>
        /// <param name="workLogDto"></param>
        /// <returns></returns>
        public ApiResult<string> DeleteWorkLog(WorkLogDto workLogDto)
        {
            return _workFromHome_Normal_DeleteWorkLog.DeleteWorkLog(workLogDto);
        }
    }
}
