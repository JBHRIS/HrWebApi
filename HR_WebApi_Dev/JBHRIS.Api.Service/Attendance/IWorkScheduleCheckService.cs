using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkScheduleCheckService
    {
        WorkScheduleCheckResult Check(WorkScheduleCheckEntry workScheduleCheckEntry);
    }
}
