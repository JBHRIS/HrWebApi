using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsenceCancelService
    {
        /// <summary>
        /// 取得可銷假資料
        /// </summary>
        /// <param name="dateBetweenQueryDto"></param>
        /// <returns></returns>
        ApiResult<List<CancelLeaveApplyDto>> GetCancelableLeave(DateBetweenQueryDto dateBetweenQueryDto);
        /// <summary>
        /// 銷假檢核
        /// </summary>
        /// <param name="cancelLeaveApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> CheckCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos);
        /// <summary>
        /// 銷假存入後端系統(刪除實體資料)
        /// </summary>
        /// <param name="cancelLeaveApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> SaveCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos);
    }
}
