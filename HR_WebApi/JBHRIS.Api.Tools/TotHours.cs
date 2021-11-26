using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Tools
{
    public static class TotHours
    {
        public static decimal IntervalTotHours(decimal min, decimal interval, decimal totHours)
        {
            decimal TotHours = totHours;
            if (totHours >= min)
            {
                decimal calTot = totHours - min; //最小數起算間隔數
                decimal calTotinterval = (Math.Ceiling(calTot / interval)) * interval;
                TotHours = min + calTotinterval;
            }
            return TotHours;
        }
    }
}
