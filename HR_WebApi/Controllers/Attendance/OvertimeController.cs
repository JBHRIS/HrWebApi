using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 加班服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeController : ControllerBase
    {
        private IOvertimeService _overtimeService;
        private ILogger _logger;
        /// <summary>
        /// 加班控制器
        /// </summary>
        /// <param name="overtimeService">加班服務</param>
        /// <param name="logger"></param>
        public OvertimeController(IOvertimeService overtimeService, ILogger logger)
        {
            _overtimeService = overtimeService ;
            _logger = logger;
        }

        /// <summary>
        /// 取得期間加班資料
        /// </summary>
        /// <param name="overtimeByDateEntry"></param>
        /// <returns></returns>
        [Route("GetOvertimeByDate")]
        [HttpPost]
        //[Authorize(Roles = "Overtime/GetOvertimeByDate,Admin")]
        public ApiResult<List<OvertimeByDateDto>> GetOvertimeByDate(OvertimeByDateEntry overtimeByDateEntry)
        {
            _logger.Info("開始呼叫OvertimeService.GetOvertimeByDate");
            ApiResult<List<OvertimeByDateDto>> apiResult = new ApiResult<List<OvertimeByDateDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetOvertimeByDate(overtimeByDateEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 判斷加班異常
        /// </summary>
        /// <param name="overtimeByDateDtos"></param>
        /// <returns></returns>
        [Route("CheckOvertimeData")]
        [HttpPost]
        //[Authorize(Roles = "Overtime/CheckOvertimeData,Admin")]
        public ApiResult<List<CheckOvertimeDataDto>> CheckOvertimeData(List<OvertimeByDateDto> overtimeByDateDtos)
        {
            _logger.Info("開始呼叫OvertimeService.CheckOvertimeData");
            ApiResult<List<CheckOvertimeDataDto>> apiResult = _overtimeService.CheckOvertimeData(overtimeByDateDtos);
            return apiResult;
        }

        /// <summary>
        /// 加班名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetPeopleOvertime")]
        [HttpPost]
        [Authorize(Roles = "Overtime/GetPeopleOvertime,Admin")]
        public ApiResult<List<string>> GetPeopleOvertime(AttendanceEntry attendanceEntry)
        {
            _logger.Info("開始呼叫OvertimeService.GetPeopleOvertime");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetPeopleOvertime(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得加班類型?目前沒有
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeType")]
        [HttpPost]
        [Authorize(Roles = "Overtime/GetOvertimeType,Admin")]
        public ApiResult<List<OvertimeTypeDto>> GetOvertimeType()
        {
            _logger.Info("開始呼叫OvertimeService.GetOvertimeType");
            ApiResult<List<OvertimeTypeDto>> apiResult = new ApiResult<List<OvertimeTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetOvertimeType();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 加班計算
        /// </summary>
        /// <returns></returns>
        [Route("CalculateOvertime")]
        [HttpPost]
        [Authorize(Roles = "Overtime/CalculateOvertime,Admin")]
        public ApiResult<OvertimeDto> CalculateOvertime(OvertimeApplyDto overtimeApplyDto)
        {
            _logger.Info("開始呼叫OvertimeService.CalculateOvertime");
            return _overtimeService.CalculateOvertime(overtimeApplyDto);
        }

        /// <summary>
        /// 加班檢核
        /// </summary>
        /// <returns></returns>
        [Route("CheckOvertime")]
        [HttpPost]
        [Authorize(Roles = "Overtime/CheckOvertime,Admin")]
        public ApiResult<string> CheckOvertime(OvertimeDto overtimeDto)
        {
            _logger.Info("開始呼叫OvertimeService.CheckOvertime");
            return _overtimeService.CheckOvertime(overtimeDto);
        }

        /// <summary>
        /// 加班存入
        /// </summary>
        /// <returns></returns>
        [Route("SaveOvertime")]
        [HttpPost]
        [Authorize(Roles = "Overtime/SaveOvertime,Admin")]
        public ApiResult<string> SaveOvertime(List<OvertimeDto> overtimeDtos)
        {
            _logger.Info("SaveOvertime.CheckOvertime");
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _overtimeService.SaveOvertime(overtimeDtos, KeyMan);
        }
    }
}