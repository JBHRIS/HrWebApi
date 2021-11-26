using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBTools
{
    public class DataTransform
    {
        public static List<Tuple<DateTime, DateTime>> GetAbsenteeismList(List<Tuple<DateTime, DateTime>> workTimeList, List<Tuple<DateTime, DateTime>> AttendList)
        {
            List<Tuple<DateTime, DateTime>> timeErrList = new List<Tuple<DateTime, DateTime>>();
            foreach (var work in workTimeList)
            {
                DateTime wBtime = work.Item1;
                DateTime wEtime = work.Item2;
                DateTime oldEtime = DateTime.MinValue;
                var processTimeList = from a in AttendList where wEtime > a.Item1 && a.Item2 > wBtime orderby a.Item1 select a;
                //只處理有交集的資料
                if (processTimeList.Any())
                {
                    foreach (var BEit in processTimeList)
                    {
                        if (BEit.Equals(processTimeList.First()))//處理第一筆資料
                        {
                            if (wBtime < BEit.Item1)
                                timeErrList.Add(new Tuple<DateTime, DateTime>(wBtime, BEit.Item1));
                        }
                        else//其餘直接抓前一筆的Etime和此筆的Btime當異常時間
                        {
                            timeErrList.Add(new Tuple<DateTime, DateTime>(oldEtime, BEit.Item1));
                        }

                        if (BEit.Equals(processTimeList.Last()))//處理最後一筆資料
                        {
                            if (wEtime > BEit.Item2)
                                timeErrList.Add(new Tuple<DateTime, DateTime>(BEit.Item2, wEtime));
                        }
                        oldEtime = BEit.Item2;//計錄此筆的Etime給下次用。
                    }
                }
                else
                {
                    timeErrList.Add(new Tuple<DateTime, DateTime>(wBtime, wEtime));
                }
            }
            return timeErrList;
        }
        /// <summary>
        /// 抓出不重疊的時段並排序
        /// </summary>
        /// <param name="AttendList"></param>
        /// <returns></returns>
        public static List<Tuple<DateTime, DateTime>> ReBindAttend(List<Tuple<DateTime, DateTime>> AttendList)
        {
            var sortList = AttendList.OrderBy(p => p.Item1);
            Tuple<DateTime, DateTime> newTime = new Tuple<DateTime, DateTime>(DateTime.MinValue, DateTime.MinValue);
            List<Tuple<DateTime, DateTime>> newList = new List<Tuple<DateTime, DateTime>>();
            foreach (var it in sortList)
            {
                if (newTime.Item1 <= it.Item2 && newTime.Item2 >= it.Item1)//交集
                {
                    if (it.Item2 > newList.Last().Item2)
                    {
                        var cloneItem = newList.Single(pp => pp.Item1 == newList.Max(p => p.Item1));
                        newList.Remove(cloneItem);
                        newList.Add(new Tuple<DateTime, DateTime>(cloneItem.Item1, it.Item2));
                        newTime = new Tuple<DateTime, DateTime>(cloneItem.Item1, it.Item2);
                    }
                }
                else
                {
                    newTime = new Tuple<DateTime, DateTime>(it.Item1, it.Item2);
                    newList.Add(new Tuple<DateTime, DateTime>(it.Item1, it.Item2));
                }
            }
            return newList;
        }
        public static List<Tuple<string, string>> ReBindAttend(List<Tuple<string, string>> AttendList)
        {
            var sortList = AttendList.OrderBy(p => p.Item1);
            Tuple<string, string> newTime = new Tuple<string, string>("0000", "0000");
            List<Tuple<string, string>> newList = new List<Tuple<string, string>>();
            foreach (var it in sortList)
            {
                if (newTime.Item1.CompareTo(it.Item2) <= 0 && newTime.Item2.CompareTo(it.Item1) >= 0)//交集
                {
                    if (it.Item2.CompareTo(newList.Last().Item2) > 0)
                    {
                        var cloneItem = newList.Single(pp => pp.Item1 == newList.Max(p => p.Item1));
                        newList.Remove(cloneItem);
                        newList.Add(new Tuple<string, string>(cloneItem.Item1, it.Item2));
                        newTime = new Tuple<string, string>(cloneItem.Item1, it.Item2);
                    }
                }
                else
                {
                    newTime = new Tuple<string, string>(it.Item1, it.Item2);
                    newList.Add(new Tuple<string, string>(it.Item1, it.Item2));
                }
            }
            return newList;
        }
        public static List<Tuple<TimeSpan, TimeSpan>> ReBindAttend(List<Tuple<TimeSpan, TimeSpan>> AttendList)
        {
            var sortList = AttendList.OrderBy(p => p.Item1);
            Tuple<TimeSpan, TimeSpan> newTime = new Tuple<TimeSpan, TimeSpan>(TimeSpan.MinValue, TimeSpan.MinValue);
            List<Tuple<TimeSpan, TimeSpan>> newList = new List<Tuple<TimeSpan, TimeSpan>>();
            foreach (var it in sortList)
            {
                if (newTime.Item1.CompareTo(it.Item2) <= 0 && newTime.Item2.CompareTo(it.Item1) >= 0)//交集
                {
                    if (it.Item2.CompareTo(newList.Last().Item2) > 0)
                    {
                        var cloneItem = newList.Single(pp => pp.Item1 == newList.Max(p => p.Item1));
                        newList.Remove(cloneItem);
                        newList.Add(new Tuple<TimeSpan, TimeSpan>(cloneItem.Item1, it.Item2));
                        newTime = new Tuple<TimeSpan, TimeSpan>(cloneItem.Item1, it.Item2);
                    }
                }
                else
                {
                    newTime = new Tuple<TimeSpan, TimeSpan>(it.Item1, it.Item2);
                    newList.Add(new Tuple<TimeSpan, TimeSpan>(it.Item1, it.Item2));
                }
            }
            return newList;
        }
        public static string JsonSerializeObject(object obj)
        {
            string result = Newtonsoft.Json.JsonConvert.SerializeObject(obj, new Newtonsoft.Json.JsonSerializerSettings
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,

            });
            return result;
        }

        public static DateTime DateIntervalCalc(DateTime StartDate, string unit, int value)
        {
            DateTime resultDate = StartDate;
            if (unit == "天")
            {
                resultDate = StartDate.AddDays(value);
            }
            else if (unit == "月")
            {
                resultDate = StartDate.AddMonths(value);
            }
            else if (unit == "年")
            {
                resultDate = StartDate.AddYears(value);
            }
            else if (unit == "月底")
            {
                var refDate = StartDate.AddMonths(value);
                resultDate = new DateTime(refDate.Year, refDate.Month, DateTime.DaysInMonth(refDate.Year, refDate.Month));
            }
            else if (unit == "年底")
            {
                var refDate = StartDate.AddYears(value);
                resultDate = new DateTime(refDate.Year, 12, 31);
            }
            return resultDate;
        }
    }
}
