using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SalaryWeb
{
    public class Config
    {
        private static double? _validateUpperUpperbound;

        public static double ValidateUpperUpperbound()
        {
            if (_validateUpperUpperbound != null) return _validateUpperUpperbound.Value;

            const string  settingParameter = "TimeSpanUpperUpperbound";
            string strVal = ConfigurationManager.AppSettings[settingParameter] as string;

            if (strVal == null)
            {
                throw new ArgumentNullException("Appsetting is null,parameter is "+settingParameter);
            }

            double currentVal;
            bool canParse = double.TryParse(strVal, out currentVal);
            if (!(canParse))
            {
                throw new NotSupportedException("無法轉換Appsetting '"+settingParameter+"' 資料("+strVal+")");
            }

            _validateUpperUpperbound= currentVal;

            return _validateUpperUpperbound.Value;
        }

        private static int? _deadline;

        public static int Deadline()
        {
            if (_deadline != null) return _deadline.Value;

            const string settingParameter = "DeadlineTimeSecs";
            string strVal = ConfigurationManager.AppSettings[settingParameter] as string;

            if (strVal == null)
            {
                throw new ArgumentNullException("Apsetting is null,parameter is "+settingParameter);
            }

            int currentVal;
            bool canParse = int.TryParse(strVal, out currentVal);

            if ((!canParse))
            {
                throw new NotSupportedException("無法轉換Appsetting '"+settingParameter+"' 資料("+strVal+")");
            }

            _deadline = currentVal;
            return currentVal;
        }
    }
}