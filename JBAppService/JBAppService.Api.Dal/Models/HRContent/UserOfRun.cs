﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UserOfRun
    {
        public int Userid { get; set; }
        public int NumOfRunId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int? IsnotofRun { get; set; }
        public int? OrderRun { get; set; }
    }
}
