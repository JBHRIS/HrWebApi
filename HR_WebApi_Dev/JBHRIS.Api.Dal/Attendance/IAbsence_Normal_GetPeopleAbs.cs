using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsence_Normal_GetPeopleAbs
    {
        List<string> GetPeopleAbs(AbsenceEntryDto absenceEntryDto);
    }
}