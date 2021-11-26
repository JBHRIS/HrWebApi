using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using JBHRIS.Api.Service.Attendance;

namespace HR_WebApi.Controllers.Attendance
{
    /*
        1.AB分流人員編制
            -工號,AB分流,工作地(生效日、失效日=>可能長期下來還是有機會改變)
        2.AB班出勤設定(班別：居家上班、公司上班、假日(可不設定))
            -日期,AB分流 (優先)
            -星期(1-7),AB班
            -週(1-52),AB班
        
        6.居家工作日誌未填寫報表
        7.公司工作體溫未填回報報表

        居家上班=>線上打卡、工作日誌
        公司上班=>體溫回報
     */
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFromHomeController : Controller
    {
        private IWorkFromHomeService _workFromHomeService;
        private ITemperoturyReportService _temperoturyReportService;
        private IWorkLogService _worklogService;
        private ILogger _logger;

        public WorkFromHomeController(IWorkFromHomeService workFromHomeService
            , ITemperoturyReportService temperoturyReportService
            , IWorkLogService workLogService
            , ILogger logger)
        {
            _workFromHomeService = workFromHomeService;
            _temperoturyReportService = temperoturyReportService;
            _worklogService = workLogService;
            _logger = logger;
        }

        #region 分流組別(AB分流人員編制)
        [NonAction]
        public ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry)
        {
            return _workFromHomeService.GetDiversionGroup(getDiversionGroupEntry);
        }
        [NonAction]
        public ApiResult<string> InsertDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        [NonAction]
        public ApiResult<string> UpdateDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        [NonAction]
        public ApiResult<string> DeleteDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        #endregion

        #region 分流班表(AB班出勤設定(班別：居家上班、公司上班、假日(可不設定)))
        [NonAction]
        public ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry)
        {
            return _workFromHomeService.GetDiversionShift(getDiversionShiftEntry);
        }
        [NonAction]
        public ApiResult<string> InsertDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        [NonAction]
        public ApiResult<string> UpdateDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        [NonAction]
        public ApiResult<string> DeleteDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            return apiResult;
        }
        #endregion

        #region 工作日誌

        /// <summary>
        /// 取得工作日誌資料
        /// </summary>
        /// <param name="getWorkLogEntry"></param>
        /// <returns></returns>
        [Route("GetWorkLog")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/GetWorkLog,Admin")]
        public ApiResult<List<WorkLogDto>> GetWorkLog(GetWorkLogEntry getWorkLogEntry)
        {
            ApiResult<List<WorkLogDto>> apiResult = new ApiResult<List<WorkLogDto>>();
            try
            {
                var getWorkLogList = _worklogService.GetWorkLog(getWorkLogEntry);

                apiResult.Result = getWorkLogList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 新增工作日誌資料
        /// </summary>
        /// <param name="WorkLogDto"></param>
        /// <returns></returns>
        [Route("InsertWorkLog")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/InsertWorkLog,Admin")]
        public ApiResult<string> InsertWorkLog(WorkLogDto WorkLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var insertWorkLogList = _worklogService.InsertWorkLog(WorkLogDto);

                apiResult.Result = insertWorkLogList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 更新工作日誌資料
        /// </summary>
        /// <param name="WorkLogDto"></param>
        /// <returns></returns>
        [Route("UpdateWorkLog")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/UpdateWorkLog,Admin")]
        public ApiResult<string> UpdateWorkLog(WorkLogDto WorkLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var updateWorkLogList = _worklogService.UpdateWorkLog(WorkLogDto);

                apiResult.Result = updateWorkLogList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 刪除工作日誌資料
        /// </summary>
        /// <param name="WorkLogDto"></param>
        /// <returns></returns>
        [Route("DeleteWorkLog")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/DeleteWorkLog,Admin")]
        public ApiResult<string> DeleteWorkLog(WorkLogDto WorkLogDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var deleteWorkLogList = _worklogService.DeleteWorkLog(WorkLogDto);

                apiResult.Result = deleteWorkLogList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }
        #endregion

        #region 體溫回報

        /// <summary>
        /// 取得體溫回報資料
        /// </summary>
        /// <param name="getTemperoturyReportEntry"></param>
        /// <returns></returns>
        [Route("GetTemperoturyReport")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/GetTemperoturyReport,Admin")]
        public ApiResult<List<TemperoturyReportDto>> GetTemperoturyReport(GetTemperoturyReportEntry getTemperoturyReportEntry)
        {
            ApiResult<List<TemperoturyReportDto>> apiResult = new ApiResult<List<TemperoturyReportDto>>();
            try
            {
                var getTemperoturyReportList = _temperoturyReportService.GetTemperoturyReport(getTemperoturyReportEntry);

                apiResult.Result = getTemperoturyReportList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 新增體溫回報資料
        /// </summary>
        /// <param name="TemperoturyReportDto"></param>
        /// <returns></returns>
        [Route("InsertTemperoturyReport")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/InsertTemperoturyReport,Admin")]
        public ApiResult<string> InsertTemperoturyReport(TemperoturyReportDto TemperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var insertTemperoturyReportList = _temperoturyReportService.InsertTemperoturyReport(TemperoturyReportDto);

                apiResult.Result = insertTemperoturyReportList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 更新體溫回報資料
        /// </summary>
        /// <param name="TemperoturyReportDto"></param>
        /// <returns></returns>
        [Route("UpdateTemperoturyReport")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/UpdateTemperoturyReport,Admin")]
        public ApiResult<string> UpdateTemperoturyReport(TemperoturyReportDto TemperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var updateTemperoturyReportList = _temperoturyReportService.UpdateTemperoturyReport(TemperoturyReportDto);

                apiResult.Result = updateTemperoturyReportList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 刪除體溫回報資料
        /// </summary>
        /// <param name="TemperoturyReportDto"></param>
        /// <returns></returns>
        [Route("DeleteTemperoturyReport")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/DeleteTemperoturyReport,Admin")]
        public ApiResult<string> DeleteTemperoturyReport(TemperoturyReportDto TemperoturyReportDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            try
            {
                var deleteTemperoturyReportList = _temperoturyReportService.DeleteTemperoturyReport(TemperoturyReportDto);

                apiResult.Result = deleteTemperoturyReportList.Result;

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        #endregion

        #region 分流出勤明細表
        /// <summary>
        /// 分流出勤明細表
        /// </summary>
        /// <param name="getDiversionShiftAttendReportEntry"></param>
        /// <returns></returns>
        [Route("GetDiversionShiftAttendReport")]
        [HttpPost]
        [Authorize(Roles = "WorkFromHome/GetDiversionShiftAttendReport,Admin")]
        public ApiResult<List<DiversionShiftAttendReportDto>> GetDiversionShiftAttendReport(GetDiversionShiftAttendReportEntry getDiversionShiftAttendReportEntry)
        {
            //ApiResult<List<DiversionShiftAttendReportDto>> apiResult = new ApiResult<List<DiversionShiftAttendReportDto>>();

            return _workFromHomeService.GetDiversionShiftAttendReport(getDiversionShiftAttendReportEntry);
        } 
        #endregion
    }
}
