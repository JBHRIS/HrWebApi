using JBHRIS.Api.Bll.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkScheduleFactory
    {
        IWorkScheduleCheck Create(string CheckType);
    }
}
