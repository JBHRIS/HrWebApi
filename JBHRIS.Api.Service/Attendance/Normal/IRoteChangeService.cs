using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IRoteChangeService
    {
        /// <summary>
        /// 取得調班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        public List<RoteChangeDto> GetRoteChange(AttendanceEntry attendanceEntry);

        /// <summary>
        /// 調班存入後端系統
        /// </summary>
        /// <param name="longShiftChangeApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> SaveLongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto);

        /// <summary>
        /// 調班檢核（勞基法判斷）
        /// </summary>
        /// <param name="longShiftChangeApplyDto"></param>
        /// <returns></returns>
        ApiResult<string> CheckLongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto);
    }
}
