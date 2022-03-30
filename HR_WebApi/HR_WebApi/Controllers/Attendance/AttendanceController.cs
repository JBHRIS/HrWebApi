using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Microsoft.AspNetCore.Authorization;
using JBHRIS.Api.Dto.Attendance.Action;
using JBHRIS.Api.Service.Attendance.Action;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 考勤服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceService _attendanceService;
        private ITimetableGenerateService _timetableGenerateService;
        private IAttendanceGenerateService _attendanceGenerateService;
        private ILogger _logger;

        public AttendanceController(IAttendanceService attendanceService,ITimetableGenerateService timetableGenerateService,IAttendanceGenerateService attendanceGenerateService, ILogger logger)
        {
            _attendanceService = attendanceService;
            _timetableGenerateService = timetableGenerateService;
            _attendanceGenerateService = attendanceGenerateService;
            _logger = logger;
        }
        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAttendance")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetAttendance,Admin")]
        public ApiResult<List<AttendanceDto>> GetAttendance(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetAttendance");
            ApiResult<List<AttendanceDto>> apiResult = new ApiResult<List<AttendanceDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetAttendance(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得行事曆資料(包含請假、加班、刷卡、班別資訊、異常資料)
        /// </summary>
        /// <remarks>
        ///{
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "attendTypeList": [
        ///    "AttendType_Attend","AttendType_Card","AttendType_Abs","AttendType_Ot","AttendType_Abnormal"
        ///  ],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        ///}
        /// </remarks>
        [Route("GetCalendar")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetCalendar,Admin")]
        public ApiResult<List<CalendarDto>> GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry)
        {
            return _attendanceService.GetCalendar(attendanceCalendarEntry);
        }
        /// <summary>
        /// 取得調班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetRoteChange,Admin")]
        public ApiResult<List<RoteChangeDto>> GetRoteChange(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetRoteChange");
            ApiResult<List<RoteChangeDto>> apiResult = new ApiResult<List<RoteChangeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetRoteChange(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得異常名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetPeopleAbnormal,Admin")]
        public ApiResult<List<string>> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetPeopleAbnormal");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetPeopleAbnormal(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得工作名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleWork")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetPeopleWork,Admin")]
        public ApiResult<List<string>> GetPeopleWork(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetPeopleWork");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetPeopleWork(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得班別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetRote")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetRote,Admin")]
        public ApiResult<List<RoteDto>> GetRote(string RoteCode)
        {
            _logger.Info("開始呼叫AttendanceService.GetRote");
            ApiResult<List<RoteDto>> apiResult = new ApiResult<List<RoteDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetRote(RoteCode);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 出勤種類
        /// </summary>
        [Route("GetAttendType")]
        [HttpGet]
        [Authorize(Roles = "Attendance/GetAttendType,Admin")]
        public ApiResult<List<AttendanceTypeDto>> GetAttendType()
        {
            _logger.Info("開始呼叫AttendanceService.GetRote");
            ApiResult<List<AttendanceTypeDto>> apiResult = new ApiResult<List<AttendanceTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetAttendType();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 出勤明細表
        /// </summary>
        /// <remarks>
        ///{
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "attendTypeList": [],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        ///}
        /// </remarks>
        [Route("GetAttendDetail")]
        [HttpPost]
        [Authorize(Roles = "Attendance/GetAttendDetail,Admin")]
        public ApiResult<List<AttendanceDetailDto>> GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry)
        {
            return _attendanceService.GetAttendDetail(attendanceDetailEntry);
        }

        /// <summary>
        /// 調換員工出勤班別
        /// </summary>
        /// <param name="updateAttendRoteEntry"></param>
        /// <returns></returns>
        [Route("UpdateAttendRote")]
        [HttpPost]
        [Authorize(Roles = "Attendance/UpdateAttendRote,Admin")]
        public ApiResult<string> UpdateAttendRote(UpdateAttendRoteEntry updateAttendRoteEntry)
        {
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _attendanceService.UpdateAttendRote(updateAttendRoteEntry, KeyMan);
        }
        /// <summary>
        /// 產生班表
        /// </summary>
        /// <param name="timetableGenerateEntry"></param>
        /// <returns></returns>
        [Route("TimetableGenerate")]
        [HttpPost]
        [Authorize(Roles = "Attendance/TimetableGenerate,Admin")]
        public ApiResult<List<TmtableDto>> TimetableGenerate(TimetableGenerateEntry timetableGenerateEntry)
        {
            return _timetableGenerateService.Generate(timetableGenerateEntry);
        }
        /// <summary>
        /// 產生出勤資料
        /// </summary>
        /// <param name="employeeList">員工編號</param>
        /// <param name="begindDate">開始日期</param>
        /// <param name="endDate">結束日期</param>
        /// <returns></returns>
        [Route("AttendanceGenerate")]
        [HttpPost]
        [Authorize(Roles = "Attendance/AttendanceGenerate,Admin")]
        public ApiResult<List<AttendDto>> AttendanceGenerate(List<string> employeeList,DateTime begindDate,DateTime endDate)
        {
            return _attendanceGenerateService.Generate(employeeList,begindDate, endDate);
        }
    }
}