using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceCancelController : ControllerBase
    {
        private IAbsenceCancelService _absenceCancelService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="absenceCancelService"></param>
        public AbsenceCancelController(IAbsenceCancelService absenceCancelService)
        {
            _absenceCancelService = absenceCancelService;
        }

        /// <summary>
        /// 取得可銷假資料
        /// </summary>
        /// <param name="dateBetweenQueryDto"></param>
        /// <returns></returns>
        [Route("GetCancelableLeave")]
        [HttpPost]
        [Authorize(Roles = "AbsenceCancel/GetCancelableLeave,Admin")]
        public ApiResult<List<CancelLeaveApplyDto>> GetCancelableLeave(DateBetweenQueryDto dateBetweenQueryDto)
        {
            return _absenceCancelService.GetCancelableLeave(dateBetweenQueryDto);
        }

        /// <summary>
        /// 銷假檢核
        /// </summary>
        /// <param name="cancelLeaveApplyDtos"></param>
        /// <returns></returns>
        [Route("CheckCancelLeave")]
        [HttpPost]
        [Authorize(Roles = "AbsenceCancel/CheckCancelLeave,Admin")]
        public ApiResult<string> CheckCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            return _absenceCancelService.CheckCancelLeave(cancelLeaveApplyDtos);
        }

        /// <summary>
        /// 銷假存入後端系統(刪除實體資料)
        /// </summary>
        /// <param name="cancelLeaveApplyDtos"></param>
        /// <returns></returns>
        [Route("SaveCancelLeave")]
        [HttpPost]
        [Authorize(Roles = "AbsenceCancel/SaveCancelLeave,Admin")]
        public ApiResult<string> SaveCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            return _absenceCancelService.SaveCancelLeave(cancelLeaveApplyDtos);
        }
    }
}
