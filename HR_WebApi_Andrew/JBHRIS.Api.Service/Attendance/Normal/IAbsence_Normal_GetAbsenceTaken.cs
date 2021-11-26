using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsence_Normal_GetAbsenceTaken
    {
        List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntry absenceEntryDto);
    }
}