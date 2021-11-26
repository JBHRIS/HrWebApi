using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.View
{
    public interface IAbsenceEntitleViewService
    {
        ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry abseneceEntitleViewEntry);
        decimal GetAnnualLeave(string Nobr, DateTime dateTime);
        decimal GetCompensatoryLeave(string Nobr, DateTime dateTime);
    }
}
