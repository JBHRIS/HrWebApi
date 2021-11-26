using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsence_Normal_GetAbsBalance
    {
        List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntry absenceEntryDto);
    }
}