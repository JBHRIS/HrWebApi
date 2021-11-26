using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace JBHRIS.Api.Attendance
{
    /// <summary>
    /// 調班服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoteChangeController : ControllerBase
    {
        private IRoteChangeService _roteChangeService;
        private ILogger _logger;

        /// <summary>
        /// 調班控制器
        /// </summary>
        /// <param name="roteChangeService">調班服務</param>
        public RoteChangeController (IRoteChangeService roteChangeService, ILogger logger)
        {
            _roteChangeService = roteChangeService;
            _logger = logger;
        }

        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="attendacneEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        [Authorize(Roles = "RoteChange/GetRoteChange,Admin")]
        public ApiResult<List<RoteChangeDto>> GetRoteChange(AttendanceEntry attendacneEntry)
        {
            _logger.Info("開始呼叫RoteChangeService.GetRoteChange");
            ApiResult<List<RoteChangeDto>> apiResult = new ApiResult<List<RoteChangeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _roteChangeService.GetRoteChange(attendacneEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 調班檢核與存入後端系統
        /// </summary>
        /// <param name="longShiftChangeApplyDto"></param>
        /// <returns></returns>
        [Route("LongShiftChange")]
        [HttpPost]
        //[Authorize(Roles = "RoteChange/LongShiftChange,Admin")]
        public ApiResult<string> LongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto)
        {
            _logger.Info("開始呼叫RoteChangeService.LongShiftChange");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {

                //調班檢核
                var checkLongShiftChange = _roteChangeService.CheckLongShiftChange(longShiftChangeApplyDto);

                //若調班檢核通過（True）則存入
                if (checkLongShiftChange.State)
                {
                    var saveLongShiftChange = _roteChangeService.SaveLongShiftChange(longShiftChangeApplyDto);
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
