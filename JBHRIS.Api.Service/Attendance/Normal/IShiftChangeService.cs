using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IShiftChangeService
    {
        /// <summary>
        /// 調班存入後端系統
        /// </summary>
        /// <param name="dayShiftChangeApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> SaveDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto);

        /// <summary>
        /// 調班檢核（勞基法判斷）
        /// </summary>
        /// <param name="dayShiftChangeApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> CheckDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto);
    }
}
