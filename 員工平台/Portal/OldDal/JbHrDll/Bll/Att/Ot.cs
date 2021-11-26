using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Att.Vdb;
using OldBll.Tools;

namespace OldBll.Att
{
    public class Ot
    {
        public decimal GetCalculate(string sTimeB, string sTimeE, List<RoteResRow> lsRoteRes = null, decimal iMin = 0, decimal iInterval = 0.5M, int iDeduct = 0)
        {
            DateTime dDate = DateTime.Now.Date;
            DateTime dDateTimeB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeB));
            DateTime dDateTimeE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeE));

            int iResMinute = 0;
            TimeSpan ts;

            if (lsRoteRes != null && lsRoteRes.Count > 0)
            {
                foreach (var rRoteRes in lsRoteRes)
                {
                    DateTime dDateTimeResB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRes.ResTimeB));
                    DateTime dDateTimeResE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRes.ResTimeE));

                    //是否有交集
                    if (dDateTimeB < dDateTimeResE && dDateTimeE > dDateTimeResB)
                    {
                        dDateTimeResB = ((dDateTimeResB <= dDateTimeB) && (dDateTimeB <= dDateTimeResE)) ? dDateTimeB : dDateTimeResB;
                        dDateTimeResE = ((dDateTimeResB <= dDateTimeE) && (dDateTimeE <= dDateTimeResE)) ? dDateTimeE : dDateTimeResE;

                        ts = dDateTimeResE - dDateTimeResB;
                        iResMinute += Convert.ToInt32(ts.TotalMinutes);
                    }
                }
            }

            int iMinMinute = 30;
            int iIntervalMinute = 30;

            iMinMinute = Convert.ToInt32(iMin * 60);    //最小分鐘
            iIntervalMinute = Convert.ToInt32(iInterval * 60);  //間隔分鐘

            ts = dDateTimeE - dDateTimeB;
            int iMinute = Convert.ToInt32(ts.TotalMinutes);
            iMinute = (iMinute - iResMinute - iDeduct) >= iMinMinute ? iMinute : iMinMinute;
            int iModMinute = Convert.ToInt32((iMinute - iResMinute - iDeduct) % iIntervalMinute);
            //if (iModMinute > 0)
            //    iModMinute = iIntervalMinute - iModMinute;
            //iMinute = (iMinute - iResMinute) + iModMinute;
            iMinute = (iMinute - iResMinute - iDeduct) - iModMinute;
            iMinute = iMinute > 0 ? iMinute : 0;

            decimal iCal = iMinute / 60M;

            return iCal;
        }
        public decimal GetCalculate(string sTimeB, string sTimeE, decimal maxRestHours, List<RoteResRow> lsRoteRes = null, decimal iMin = 0, decimal iInterval = 0.5M, int iDeduct = 0)
        {
            DateTime dDate = DateTime.Now.Date;
            DateTime dDateTimeB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeB));
            DateTime dDateTimeE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeE));

            int iResMinute = 0;
            TimeSpan ts;

            if (lsRoteRes != null && lsRoteRes.Count > 0)
            {
                foreach (var rRoteRes in lsRoteRes)
                {
                    DateTime dDateTimeResB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRes.ResTimeB));
                    DateTime dDateTimeResE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRes.ResTimeE));

                    //是否有交集
                    if (dDateTimeB < dDateTimeResE && dDateTimeE > dDateTimeResB)
                    {
                        dDateTimeResB = ((dDateTimeResB <= dDateTimeB) && (dDateTimeB <= dDateTimeResE)) ? dDateTimeB : dDateTimeResB;
                        dDateTimeResE = ((dDateTimeResB <= dDateTimeE) && (dDateTimeE <= dDateTimeResE)) ? dDateTimeE : dDateTimeResE;

                        ts = dDateTimeResE - dDateTimeResB;
                        iResMinute += Convert.ToInt32(ts.TotalMinutes);
                    }
                }
            }
            //限制最大休息時數
            if (iResMinute > maxRestHours * 60) iResMinute = Convert.ToInt16(maxRestHours * 60);
            int iMinMinute = 30;
            int iIntervalMinute = 30;

            iMinMinute = Convert.ToInt32(iMin * 60);    //最小分鐘
            iIntervalMinute = Convert.ToInt32(iInterval * 60);  //間隔分鐘

            ts = dDateTimeE - dDateTimeB;
            int iMinute = Convert.ToInt32(ts.TotalMinutes);
            iMinute = (iMinute - iResMinute - iDeduct) >= iMinMinute ? iMinute : iMinMinute;
            int iModMinute = Convert.ToInt32((iMinute - iResMinute - iDeduct) % iIntervalMinute);
            //if (iModMinute > 0)
            //    iModMinute = iIntervalMinute - iModMinute;
            //iMinute = (iMinute - iResMinute) + iModMinute;
            iMinute = (iMinute - iResMinute - iDeduct) - iModMinute;
            iMinute = iMinute > 0 ? iMinute : 0;

            decimal iCal = iMinute / 60M;

            return iCal;
        }
    }
}