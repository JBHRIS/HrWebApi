using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance.Action
{
    public interface IAbsence_Action_CalculateBll
    {
        List<CalAbsHoursDto> AbsCalculate(GetAbsenceDataDetailEntry absEntry, HcodeDto getHcode, List<AttRoteViewDto> attRoteViewDtos);
    }
}
