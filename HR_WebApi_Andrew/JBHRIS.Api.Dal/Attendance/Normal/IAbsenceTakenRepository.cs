using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsenceTakenRepository
    {
        List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntry absenceEntryDto);
    }
}
