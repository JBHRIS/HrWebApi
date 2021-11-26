using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface IScheduleRepo
    {
        int MaxRetry { get; set; }
        List<ISchedule> GetScheduleList();
    }
}
