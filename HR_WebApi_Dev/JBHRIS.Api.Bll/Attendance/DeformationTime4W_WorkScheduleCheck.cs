using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime4W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime4W_WorkScheduleCheck()
        {
            NWeeksN0Z_Weeks = 2;
            NWeeksN0Z_0Z = 2;
            NWeeksN0ZN00_Weeks = 4;
            NWeeksN0ZN00_0Z = 4;
            NWeeksN0ZN00_00 = 4;
            Error = "CDT4";
        }
    }
}
