using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Att.Vdb;
using OldBll.Tools;

namespace OldBll.Att
{
    public class Abs
    {
        public decimal GetCalculate(string sTimeB, string sTimeE, OldBll.MT.mtEnum.HcodeUnit Unit = OldBll.MT.mtEnum.HcodeUnit.Hour, List<RoteResRow> lsRoteRes = null, decimal iWorkHour = 8, decimal iMin = 0.5M, decimal iInterval = 0.5M, bool bCalculateRes = true, int iDeduct = 0)
        {
            DateTime dDate = DateTime.Now.Date;
            DateTime dDateTimeB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeB));
            DateTime dDateTimeE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeE));

            int iResMinute = 0;
            TimeSpan ts;

            if (bCalculateRes && lsRoteRes != null && lsRoteRes.Count > 0)
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

            switch (Unit)
            {
                case OldBll.MT.mtEnum.HcodeUnit.Minute:
                    iMinMinute = Convert.ToInt32(iMin);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iInterval);  //間隔分鐘
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Hour:
                    iMinMinute = Convert.ToInt32(iMin * 60);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iInterval * 60);  //間隔分鐘
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Day:
                    iMinMinute = Convert.ToInt32(iWorkHour * iMin * 60);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iWorkHour * iInterval * 60);  //間隔分鐘
                    break;
                default:
                    break;
            }

            ts = dDateTimeE - dDateTimeB;
            int iMinute = Convert.ToInt32(ts.TotalMinutes);
            iMinute = (iMinute - iResMinute - iDeduct) >= iMinMinute ? iMinute : iMinMinute;
            int iModMinute = iMinute == iMinMinute ? 0 : Convert.ToInt32((iMinute - iResMinute - iDeduct) % iIntervalMinute);
            if (iModMinute > 0)
                iModMinute = iIntervalMinute - iModMinute;
            iMinute = (iMinute - iResMinute - iDeduct) + iModMinute;

            //再判斷一次 是否小於最小單位 2015/12/30 BY MING
            iMinute = (iMinute >= iMinMinute) ? iMinute : iMinMinute;

            decimal iCal = 0;
            switch (Unit)
            {
                case OldBll.MT.mtEnum.HcodeUnit.Minute:
                    iCal = iMinute;
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Hour:
                    iCal = iMinute / 60M;
                    iCal = iCal > iWorkHour ? iWorkHour : iCal; //大於工作時數就用工作時數計算
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Day:
                    iCal = Convert.ToDecimal(iMinute / 60M / iWorkHour);
                    iCal = iCal > 1 ? 1 : iCal; //大於一天就用一天計算
                    break;
                default:
                    break;
            }

            return iCal;
        }

        /// <summary>
        /// 請假計算 時碩專用
        /// </summary>
        /// <param name="sTimeB"></param>
        /// <param name="sTimeE"></param>
        /// <param name="Unit"></param>
        /// <param name="lsRoteRes"></param>
        /// <param name="iWorkHour"></param>
        /// <param name="iMin"></param>
        /// <param name="iInterval"></param>
        /// <param name="bCalculateRes"></param>
        /// <param name="iDeduct"></param>
        /// <returns></returns>
        public Dictionary<int , decimal> GetCalculateByGlobaltek(string sTimeB, string sTimeE, OldBll.MT.mtEnum.HcodeUnit Unit = OldBll.MT.mtEnum.HcodeUnit.Hour, List<RoteResRow> lsRoteRes = null, decimal iWorkHour = 8, decimal iMin = 0.5M, decimal iInterval = 0.5M, bool bCalculateRes = true, int iDeduct = 0)
        {
            DateTime dDate = DateTime.Now.Date;
            DateTime dDateTimeB = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeB));
            DateTime dDateTimeE = dDate.AddMinutes(TimeTrans.ConvertHhMmToMinutes(sTimeE));

            int iResMinute = 0;
            TimeSpan ts;

            if (bCalculateRes && lsRoteRes != null && lsRoteRes.Count > 0)
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

            ts = dDateTimeE - dDateTimeB;
            int iMinute = Convert.ToInt32(ts.TotalMinutes);
            iMinute = (iMinute - iResMinute - iDeduct);

            decimal iCal = 0;
            switch (Unit)
            {
                case OldBll.MT.mtEnum.HcodeUnit.Minute:
                    iCal = iMinute;
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Hour:
                    iCal = iMinute / 60M;
                    iCal = iCal > iWorkHour ? iWorkHour : iCal; //大於工作時數就用工作時數計算
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Day:
                    iCal = Convert.ToDecimal(iMinute / 60M / iWorkHour);
                    iCal = iCal > 1 ? 1 : iCal; //大於一天就用一天計算
                    break;
                default:
                    break;
            }

            var Vdb = new Dictionary<int, decimal>();
            Vdb.Add(iMinute, iCal);

            return Vdb;
        }

        /// <summary>
        /// 計算最小數及間隔數
        /// </summary>
        /// <param name="iMinutes"></param>
        /// <param name="Unit"></param>
        /// <param name="iWorkHour"></param>
        /// <param name="iMin"></param>
        /// <param name="iInterval"></param>
        /// <param name="bCalculateRes"></param>
        /// <param name="iDeduct"></param>
        /// <returns></returns>
        public decimal GetCalculateMinAndInterval(int iMinutes, OldBll.MT.mtEnum.HcodeUnit Unit = OldBll.MT.mtEnum.HcodeUnit.Hour, decimal iWorkHour = 8, decimal iMin = 0.5M, decimal iInterval = 0.5M, bool bCalculateRes = true, int iDeduct = 0)
        {
            int iMinMinute = 30;
            int iIntervalMinute = 30;

            switch (Unit)
            {
                case OldBll.MT.mtEnum.HcodeUnit.Minute:
                    iMinMinute = Convert.ToInt32(iMin);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iInterval);  //間隔分鐘
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Hour:
                    iMinMinute = Convert.ToInt32(iMin * 60);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iInterval * 60);  //間隔分鐘
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Day:
                    iMinMinute = Convert.ToInt32(iWorkHour * iMin * 60);    //最小分鐘
                    iIntervalMinute = Convert.ToInt32(iWorkHour * iInterval * 60);  //間隔分鐘
                    break;
                default:
                    break;
            }

            int iMinute = iMinutes >= iMinMinute ? iMinutes : iMinMinute;
            int iModMinute = iMinute == iMinMinute ? 0 : Convert.ToInt32(iMinutes % iIntervalMinute);
            if (iModMinute > 0)
                iModMinute = iIntervalMinute - iModMinute;
            iMinute = iMinutes + iModMinute;

            //再判斷一次 是否小於最小單位 2015/12/30 BY MING
            iMinute = (iMinute >= iMinMinute) ? iMinute : iMinMinute;

            decimal iCal = 0;
            switch (Unit)
            {
                case OldBll.MT.mtEnum.HcodeUnit.Minute:
                    iCal = iMinute;
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Hour:
                    iCal = iMinute / 60M;
                    //iCal = iCal > iWorkHour ? iWorkHour : iCal; //大於工作時數就用工作時數計算
                    break;
                case OldBll.MT.mtEnum.HcodeUnit.Day:
                    iCal = Convert.ToDecimal(iMinute / 60M / iWorkHour);
                    //iCal = iCal > 1 ? 1 : iCal; //大於一天就用一天計算
                    break;
                default:
                    break;
            }

            return iCal;
        }
    }
}