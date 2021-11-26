using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class TmtableImportRepo
    {
        Linq.HrDBDataContext db = new Linq.HrDBDataContext();
        public bool hasRestInWeek(DataTable tmt_i, string Nobr, string Yymm, List<string>HoliRoteList, out string errMsg)
        {
            errMsg = "";
            try
            {
                int yy = Convert.ToInt32(Yymm.Substring(0, 4));
                int mm = Convert.ToInt32(Yymm.Substring(4, 2));
                DateTime bDate = new DateTime(yy, mm, 1);
                DateTime eDate = new DateTime(yy, mm, DateTime.DaysInMonth(yy, mm));
                DateTime check_Bdate = bDate.AddDays(-6);
                DateTime check_Edate = eDate.AddDays(-6);
                Dictionary<DateTime, string> dic = new Dictionary<DateTime, string>();
                Dictionary<DateTime, bool> dics = new Dictionary<DateTime, bool>();
                //將上個月的班表先確認
                //JBHR.BLL.Att.TimeTableGenerator ttg = new JBHR.BLL.Att.TimeTableGenerator(Nobr, bDate.ToString("yyyyMM"));
                //ttg.KeyMan = "JB";
                //ttg.Generate(true);
                //確認好就可以抓最後六天
                var attend = from a in db.ATTEND
                             where a.NOBR == Nobr
                             && a.ADATE >= check_Bdate && a.ADATE < bDate
                             orderby a.ADATE
                             select a;
                if (attend.Any())
                {
                    foreach (var att in attend)
                        dic.Add(att.ADATE, att.ROTE);
                }
                //變更檢查開始日
                check_Bdate = attend.Any() ? attend.First().ADATE : bDate;
                int day = 1;
                for (DateTime date = bDate; date <= eDate; date = date.AddDays(1))
                {
                    string columnName = string.Format("D{0}",day.ToString());
                    string rote = tmt_i.Rows[0][columnName].ToString();
                    dic.Add(date, rote);
                    day++;
                }
                //開始檢查
                if (!CheckErrorDay(Yymm, HoliRoteList, dic, out errMsg))
                {
                    errMsg = string.Format("({0})違反七休一", errMsg);
                    return false;
                }

                //檢查調班資料-----------------------------------------------------
                var rotechgList = (from a in db.ROTECHG
                              where a.NOBR == Nobr
                             && a.ADATE >= bDate && a.ADATE < eDate
                              orderby a.ADATE
                              select a).ToList();
                //沒調班資料就直接離開
                if (rotechgList == null) return true;

                //置換調班資料為新的班表
                foreach (var rotechg in rotechgList)
                    dic[rotechg.ADATE] = rotechg.ROTE.Trim().ToString();
                //再檢查一次有無違反
                if (!CheckErrorDay(Yymm, HoliRoteList, dic, out errMsg))
                {
                    errMsg = string.Format("調班資料會導致({0})違反七休一", errMsg);
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        private bool CheckErrorDay(string Yymm, List<string> HoliRoteList, Dictionary<DateTime, string> dic, out string errMsg)
        {
            errMsg = "";
            int falseCount = 0;
            Dictionary<DateTime, int> errDic = new Dictionary<DateTime, int>();
            Dictionary<DateTime, bool> dics = TransBoolToDic(dic, HoliRoteList);
            foreach (var item in dics)
            {
                if (item.Value) falseCount = 0;
                else falseCount++;
                if (falseCount >= 7)
                {
                    DateTime ckDate = item.Key.AddDays(-1);
                    if (errDic.Keys.Contains(ckDate)) errDic.Remove(ckDate);
                    errDic.Add(item.Key, falseCount);
                }
            }
            foreach (var item in errDic)
            {
                DateTime d1 = item.Key.AddDays((item.Value - 1) * -1);
                DateTime d2 = item.Key;
                int bd = 1;
                int ed = d2.Day;
                if (d1.ToString("yyyyMM") == Yymm)
                    bd = d1.Day;
                //只顯示匯入班表有問題日期區間
                if (errMsg.Length > 0) errMsg += ", ";
                errMsg += string.Format("D{0}~D{1}", bd, ed);
            }
            if (errMsg.Length > 0) return false;
            return true;
        }
        Dictionary<DateTime, bool> TransBoolToDic(Dictionary<DateTime, string> dic, List<string> holiRoteList)
        {
            Dictionary<DateTime, bool> dics = new Dictionary<DateTime, bool>();
            foreach (var it in dic)
            {
                dics.Add(it.Key, holiRoteList.Contains(it.Value));
            }
            return dics;
        }
    }
}
