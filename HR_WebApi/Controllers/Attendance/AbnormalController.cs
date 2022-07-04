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

namespace HR_WebApi.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbnormalController : ControllerBase
    {
        private IAbnormalService _abnormalService;
        public AbnormalController(IAbnormalService abnormalService)
        {
            _abnormalService = abnormalService;
        }

        /// <summary>
        /// 取得需要註記資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAbnormalAttendance")]
        [HttpPost]
        [Authorize(Roles = "Abnormal/GetAbnormalAttendance,Admin")]
        public ApiResult<List<AbnormalViewDto>> GetAbnormalAttendance(AttendanceEntry attendanceEntry)
        {
            ApiResult<List<AbnormalViewDto>> apiResult = new ApiResult<List<AbnormalViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _abnormalService.GetAbnormalViewDtosByCheckFalse(attendanceEntry);
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
        /// 註記檢核
        /// </summary>
        /// <param name="abnormalViewDtos"></param>
        /// <returns></returns>
        [Route("CheckAbnormalAttendanceComment")]
        [HttpPost]
        [Authorize(Roles = "Abnormal/CheckAbnormalAttendanceComment,Admin")]
        public ApiResult<string> CheckAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            return apiResult;
        }

        /// <summary>
        /// 註記存入後端系統
        /// </summary>
        /// <param name="abnormalViewDtos"></param>
        /// <returns></returns>
        [Route("SaveAbnormalAttendanceComment")]
        [HttpPost]
        [Authorize(Roles = "Abnormal/SaveAbnormalAttendanceComment,Admin")]
        public ApiResult<string> SaveAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos)
        {
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _abnormalService.SaveAbnormalAttendanceComment(abnormalViewDtos,KeyMan);
        }
    }
}
