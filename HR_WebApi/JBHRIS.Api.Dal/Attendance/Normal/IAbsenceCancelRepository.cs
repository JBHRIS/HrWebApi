﻿using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsenceCancelRepository
    {
        List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntry absenceEntryDto);
    }
}
