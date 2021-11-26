using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime8W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime8W_WorkScheduleCheck()
        {
            NWeeksN0Z_Weeks = 1;
            NWeeksN0Z_0Z = 1;
            NWeeksN0ZN00_Weeks = 8;
            NWeeksN0ZN00_0Z = 8;
            NWeeksN0ZN00_00 = 8;
            Error = "CDT8";
        }

    }
}
