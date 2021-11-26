using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public class AbsenceTakenViewService : IAbsenceTakenViewService
    {
        IAttend_View_GetAbsenceTakenView _attend_View_GetAbsence;

        public AbsenceTakenViewService(IAttend_View_GetAbsenceTakenView attend_View_GetAbsence)
        {
            _attend_View_GetAbsence = attend_View_GetAbsence;
        }

        public ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry)
        {
            return _attend_View_GetAbsence.GetAbsenceTakenView(abseneceTakenViewEntry);
        }
    }
}
