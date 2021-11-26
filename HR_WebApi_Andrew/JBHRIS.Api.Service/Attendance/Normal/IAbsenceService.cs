using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    /// <summary>
    /// 請假服務
    /// </summary>
    public interface IAbsenceService
    {
        /// <summary>
        /// 取得請假
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntry absenceEntryDto);
        /// <summary>
        /// 取得銷假
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntry absenceEntryDto);
        /// <summary>
        /// 取得剩餘時數
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntry absenceEntryDto);
        /// <summary>
        /// 取得請假名單
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        List<string> GetPeopleAbs(AbsenceEntry absenceEntryDto);
        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        List<HcodeDto> GetHcode();
    }
}