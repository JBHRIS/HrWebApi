using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public interface IWorkScheduleCheck
    {
        WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck);
    }
}
