using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.View
{
    public interface IAttend_View_GetAbsenceEntitleView
    {
        ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry abseneceEntitleViewEntry);
    }
}
