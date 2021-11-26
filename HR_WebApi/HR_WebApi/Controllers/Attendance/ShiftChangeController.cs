using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 換班
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftChangeController : ControllerBase
    {
        private IShiftChangeService _shiftChangeService;
        private ILogger _logger;

        /// <summary>
        /// 換班控制器
        /// </summary>
        /// <param name="shiftChangeService">調班服務</param>
        public ShiftChangeController(IShiftChangeService shiftChangeService, ILogger logger)
        {
            _shiftChangeService = shiftChangeService;
            _logger = logger;
        }

        /// <summary>
        /// 換班檢核與存入後端系統
        /// </summary>
        /// <returns></returns>
        [Route("DayShiftChange")]
        [HttpPost]
        //[Authorize(Roles = "Card/ForgetCard,Admin")]
        public ApiResult<string> DayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto)
        {

            _logger.Info("開始呼叫ShifChangeService.DayShiftChange");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {

                //換班檢核
                var checkDayShiftChange = _shiftChangeService.CheckDayShiftChange(dayShiftChangeApplyDto);

                //若換班檢核通過（True）則存入
                if (checkDayShiftChange.State)
                {
                    var saveDayShiftChange = _shiftChangeService.SaveDayShiftChange(dayShiftChangeApplyDto);
                }
                apiResult.Result = "Success";

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