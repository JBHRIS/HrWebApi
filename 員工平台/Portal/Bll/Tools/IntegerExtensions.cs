using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bll.Tools
{
    public static class IntegerExtensions
    {
        public static int ParseInt(this string value, int defaultValue = 0)
        {
            int parsed;
            if (int.TryParse(value, out parsed))
                return parsed;

            return defaultValue;
        }

        public static int? ParseNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseInt();
        }

        public static decimal ParseDecimal(this string value, decimal defaultValue = 0)
        {
            decimal parsed;
            if (decimal.TryParse(value, out parsed))
                return parsed;

            return defaultValue;
        }

        public static decimal? ParseNullableDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseDecimal();
        }

        public static short ParseShort(this string value, short defaultValue = 0)
        {
            short parsed;
            if (short.TryParse(value, out parsed))
                return parsed;

            return defaultValue;
        }

        public static short? ParseNullableShort(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseShort();
        }
    }
}