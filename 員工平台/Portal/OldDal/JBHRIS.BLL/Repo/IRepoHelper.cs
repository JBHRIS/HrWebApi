using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface IRepoHelper
    {
        IAbsRepo GetAbsRepo();
        IScheduleRepo GetScheduleRepo();
        ScheduleManager GetScheduleManager();
        ILogger GetLogger();
    }
}
