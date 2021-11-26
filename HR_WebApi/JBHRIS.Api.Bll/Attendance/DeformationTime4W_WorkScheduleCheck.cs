using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTime4W_WorkScheduleCheck : DeformationTimeNW_WorkScheduleCheck
    {
        public DeformationTime4W_WorkScheduleCheck()
        {
            NWeeksNHolidays_Weeks = 2;
            NWeeksNHolidays_Holidays = 2;
            NWeeksNHolidaysNOffdays_Weeks = 4;
            NWeeksNHolidaysNOffdays_Holidays = 4;
            NWeeksNHolidaysNOffdays_Offdays = 4;
            Error = "CDT4";
        }
    }
}
