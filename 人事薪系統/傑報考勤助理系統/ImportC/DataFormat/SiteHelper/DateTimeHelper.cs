using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBModule.Data.Linq;

namespace JBHR.ImportC.DataFormat.SiteHelper
{
    class DateTimeHelper
    {

        public bool CheckDateTime(string strDT) {
            try
            {
                Convert.ToDateTime(strDT);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CompTime(string bTime, string eTime) {

            bool flag = true ;

            if (!CheckTime(bTime))
            {
                flag = false;
            }
            if (!CheckTime(eTime))
            {
                flag = false;
            }
            int bHr = Convert.ToInt32(bTime.Substring(0, 2)) ;
            int eHr = Convert.ToInt32(eTime.Substring(0, 2)) ;
            int bMin = Convert.ToInt32(bTime.Substring(2, 2)) ;
            int eMin = Convert.ToInt32(eTime.Substring(2, 2)) ;
            int bTime_min = (bHr * 60) + bMin;
            int eTime_min = (eHr * 60) + eMin;
            if (bTime_min > eTime_min)
            {
                flag = false;
            }
            return flag;
        }

        public bool CheckTime(string Time) {

            bool flag = true;

            try
            {
                Convert.ToInt32(Time);
            }
            catch (Exception)
            {
                flag = false;
            }

            if (Time.Length != 4)
            {
                flag = false;
            }
            return flag;
        }

        public Dictionary<string, DateTime> getDateTimeRange(DataTable dt, string datetimeColumnNmae) {
            Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
            DateTime dtMax = DateTime.MinValue;
            DateTime dtMin = DateTime.MaxValue;
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    DateTime dtComp = Convert.ToDateTime(item[datetimeColumnNmae]).Date;
                    if (dtMax.CompareTo(dtComp) < 0)
	                {
                        dtMax = dtComp;
	                }
                    if (dtMin.CompareTo(dtComp) > 0)
                    {
                        dtMin = dtComp;
                    }
                }
                catch (Exception)
                {
                }
            }
            dic.Add("dtMax", dtMax);
            dic.Add("dtMin", dtMin);
            return dic;
        }

        public bool CheckTimeWhitRote(ROTE rote , string bTime,string eTime){
            string roteBTime = rote.ON_TIME.Length == 0 ? "0000" : rote.ON_TIME;
            string roteETime = rote.OFF_TIME.Length == 0 ? "0000" : rote.OFF_TIME;
            bool flag = true;
            //(SQLBTIME.CompareTo(ClientETIME) >= 0 || SQLETIME.CompareTo(ClientBTIME) <= 0);

            if (!(roteBTime.CompareTo(eTime) >= 0 || roteETime.CompareTo(bTime) <= 0))
            {
                flag = false;
            }
            return flag;
        }


    }
}
