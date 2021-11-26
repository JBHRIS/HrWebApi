using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System.Collections.Generic;
using System.Security.Claims;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsenceCalculateService
    {
        ApiResult<List<CalAbsHoursDto>> GetAbsenceDataDetail(GetAbsenceDataDetailEntry getAbsenceDataDetailEntry);
        /// <summary>
        /// 請假計算
        /// </summary>
        /// <returns></returns>
        ApiResult<List<CalAbsHoursDto>> CalAbsHours(GetAbsenceDataDetailEntry absEntry);
        /// <summary>
        /// 請假存入
        /// </summary>
        /// <returns></returns>
        ApiResult<string> AbsenceDataSave(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos);
        /// <summary>
        /// 檢查請假明細
        /// </summary>
        /// <returns></returns>
        ApiResult<List<string>> CheckAbsenceDataDetail(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos);
        /// <summary>
        /// 檢查請假重複
        /// </summary>
        /// <returns></returns>
        ApiResult<string> CheckAbsRepeat(List<CalAbsHoursDto> calAbsHoursDtos);
        /// <summary>
        /// 檢查性別
        /// </summary>
        /// <returns></returns>
        ApiResult<string> CheckAbsSex(List<CalAbsHoursDto> calAbsHoursDtos);
        /// <summary>
        /// 檢查剩餘時數
        /// </summary>
        /// <returns></returns>
        ApiResult<List<AbsBalanceOffsetViewDto>> CheckRemainHours(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos);
        /// <summary>
        /// 沖假
        /// </summary>
        /// <returns></returns>
        ApiResult<List<AbsBalanceOffsetViewDto>> AbsBalanceOffset(ClaimsPrincipal user, List<CalAbsHoursDto> calAbsHoursDtos);
    }
}