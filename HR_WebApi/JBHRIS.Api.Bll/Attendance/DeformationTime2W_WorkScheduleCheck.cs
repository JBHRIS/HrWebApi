using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime2W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime2W_WorkScheduleCheck()
        {
            NWeeksNHolidays_Weeks = 1;
            NWeeksNHolidays_Holidays = 1;
            NWeeksNHolidaysNOffdays_Weeks = 2;
            NWeeksNHolidaysNOffdays_Holidays = 2;
            NWeeksNHolidaysNOffdays_Offdays = 2;
            Error = "CDT2";
        }
    }
}
