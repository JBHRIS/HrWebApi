using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Tools
{
    public class NumbericConvert
    {
        public static decimal RangeInterval(decimal Value, decimal Interval)
        {
            decimal set = decimal.Floor(Value / Interval);//取整數部分
            decimal dig = (Value / Interval) - decimal.Floor(Value / Interval);//取小數部分
            if (dig > 0) set++;
            return set * Interval;
        }
        public static decimal RangeInterval(decimal Value, decimal Interval, DigitalMode Mode)
        {
            if (Interval == 0) Interval = 1;//避免除0錯誤
            decimal set = decimal.Floor(Value / Interval);//取整數部分
            decimal dig = (Value / Interval) - decimal.Floor(Value / Interval);//取小數部分
            if (Mode == DigitalMode.Ceiling && dig > 0) set++;
            else if (Mode == DigitalMode.Round && Math.Round(dig, MidpointRounding.AwayFromZero) >= 1)
                set++;
            return set * Interval;
        }
        public enum DigitalMode
        {
            Ceiling,
            Floor,
            Round,
        }
    }
}
