﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface ISchedule
    {
        List<Dto.ScheduleParameter> Parameters { get; set; }
        bool Run(out string Msg);
    }
}
