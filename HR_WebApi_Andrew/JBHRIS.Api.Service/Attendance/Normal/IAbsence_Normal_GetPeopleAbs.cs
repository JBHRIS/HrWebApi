using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbsence_Normal_GetPeopleAbs
    {
        List<string> GetPeopleAbs(AbsenceEntry absenceEntryDto);
    }
}