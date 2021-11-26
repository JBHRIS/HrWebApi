using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime2W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime2W_WorkScheduleCheck()
        {
            NWeeksN0Z_Weeks = 1;
            NWeeksN0Z_0Z = 1;
            NWeeksN0ZN00_Weeks = 2;
            NWeeksN0ZN00_0Z = 2;
            NWeeksN0ZN00_00 = 2;
            Error = "CDT2";
        }
    }
}
