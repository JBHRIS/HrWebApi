using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime8W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime8W_WorkScheduleCheck()
        {
            NWeeksNHolidays_Weeks = 1;
            NWeeksNHolidays_Holidays = 1;
            NWeeksNHolidaysNOffdays_Weeks = 8;
            NWeeksNHolidaysNOffdays_Holidays = 8;
            NWeeksNHolidaysNOffdays_Offdays = 8;
            Error = "CDT8";
        }

    }
}
