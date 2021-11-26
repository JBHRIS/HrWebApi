using JBHRIS.Api.Bll.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkScheduleFacotry
    {
        IWorkScheduleCheck Create(string CheckType);
    }
}
