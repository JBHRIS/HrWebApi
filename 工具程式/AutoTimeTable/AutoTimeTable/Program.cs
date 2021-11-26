using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using JBModule.Data;
namespace AutoTimeTable
{
    class Program
    {
        private bool isBreak;
        static void Main(string[] args)
        {
            JBModule.Message.TextLog.WriteLog("開始執行自動班表作業");
            var CheckMonthInterval = Convert.ToInt32(ConfigSetting.AppSettingValue("CheckMonthInterval"));
            if (CheckMonthInterval <= 0)
            {
                JBModule.Message.TextLog.WriteLog("檢查月份不可以小於等於0");
                return;
            }
            var CheckPreviousMonthInterval = Convert.ToInt32(ConfigSetting.AppSettingValue("CheckPreviousMonthInterval"));
            if (CheckPreviousMonthInterval <= 0)
            {
                JBModule.Message.TextLog.WriteLog("檢查月份不可以小於等於0");
                return;
            }
            //人事異動變更
            string yymm_b = DateTime.Today.AddMonths(CheckPreviousMonthInterval * -1).ToString("yyyyMM");
            string yymm_e = DateTime.Today.AddMonths(CheckMonthInterval - 1).ToString("yyyyMM");

            var db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Message.TextLog.WriteLog("確認連線：" + db.Connection.ConnectionString);

            var sql0 = (from a in db.TMTABLE//行事曆異動變更
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       where a.YYMM.CompareTo(yymm_b) >= 0 && a.YYMM.CompareTo(yymm_e) <= 0
                       && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1) >= b.ADATE && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1) <= b.DDATE.Value
                       && (from h in db.HOLI
                           where h.HOLI_CODE == b.HOLI_CODE
                               && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1) <= h.H_DATE
                               && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1).AddMonths(1).AddDays(-1) >= h.H_DATE
                               && a.KEY_DATE < h.KEY_DATE
                           select 1).Any()
                       select new { a.NOBR, a.YYMM }).ToList();
            foreach (var it in sql0)
            {
                JBModule.Message.TextLog.WriteLog("正在更新" + it + "班表" + it.YYMM);
                JBHR.BLL.Att.TimeTableGenerator tg = new JBHR.BLL.Att.TimeTableGenerator(it.NOBR, it.YYMM);
                tg.Generate();
            }

            var sql = from a in db.TMTABLE//人事異動變更
                      where a.YYMM.CompareTo(yymm_b) >= 0 && a.YYMM.CompareTo(yymm_e) <= 0
                      && (from b in db.BASETTS
                          where a.NOBR == b.NOBR
                              && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1) <= b.DDATE.Value
                              && new DateTime(Convert.ToInt32(a.YYMM.Substring(0, 4)), Convert.ToInt32(a.YYMM.Substring(4, 2)), 1).AddMonths(1).AddDays(-1) >= b.ADATE
                              && a.KEY_DATE < b.KEY_DATE
                          select 1).Any()
                      select new { a.NOBR, a.YYMM };
            foreach (var it in sql)
            {
                JBModule.Message.TextLog.WriteLog("正在更新" + it + "班表" + it.YYMM);
                JBHR.BLL.Att.TimeTableGenerator tg = new JBHR.BLL.Att.TimeTableGenerator(it.NOBR, it.YYMM);
                tg.Generate();
            }

            for (int i = CheckMonthInterval * -1; i < CheckMonthInterval; i++)//沒有班表
            {
                string yymm = DateTime.Today.AddMonths(i).ToString("yyyyMM");
                var d1 = new DateTime(Convert.ToInt32(yymm.Substring(0, 4)), Convert.ToInt32(yymm.Substring(4, 2)), 1);
                var d2 = d1.AddMonths(1).AddDays(-1);
                var sql1 = from a in db.BASETTS//沒有班表
                           where a.ADATE <= d2 && a.DDATE.Value >= d1
                           && new string[] { "1", "4", "6" }.Contains(a.TTSCODE)
                           && !(from b in db.TMTABLE where a.NOBR == b.NOBR && b.YYMM == yymm select b).Any()
                           select a.NOBR;
                foreach (var it in sql1)
                {
                    JBModule.Message.TextLog.WriteLog("正在產生" + it + "班表" + yymm);
                    JBHR.BLL.Att.TimeTableGenerator tg = new JBHR.BLL.Att.TimeTableGenerator(it, yymm);
                    tg.Generate();
                }
                var sql2 = from a in db.ROTECHG//調班
                           where a.ADATE >= d1 && a.ADATE <= d2
                           && (from b in db.ATTEND where a.NOBR == b.NOBR && a.ADATE == b.ADATE && a.ROTE != b.ROTE select 1).Any()
                           select new { a.NOBR, a.ADATE };
                foreach (var it in sql2)
                {
                    JBModule.Message.TextLog.WriteLog("正在產生" + it.NOBR + "調班" + it.ADATE.ToShortDateString());

                    JBHR.BLL.Att.AttendanceGenerator ag = new JBHR.BLL.Att.AttendanceGenerator(it.NOBR, it.ADATE, it.ADATE);
                    ag.Generate();
                }
                //JBTools.Intersection its = new JBTools.Intersection();
                //its.Inert(d1, d2);
                //var sql3 = from a in db.TMTABLE//調班
                //           let cc = (from b in db.ATTEND where a.NOBR == b.NOBR && b.ADATE >= d1 && b.ADATE <= d2 && a.KEY_DATE < b.KEY_DATE select 1).Count()
                //           where a.YYMM == yymm && its.GetDays() > cc
                //           select new { a.NOBR, a.YYMM, Count = cc };
                //foreach (var it in sql3)
                //{
                //    JBModule.Message.TextLog.WriteLog("正在產生" + it.NOBR + "更新出勤" + it.YYMM);

                //    JBHR.BLL.Att.AttendanceGenerator ag = new JBHR.BLL.Att.AttendanceGenerator(it.NOBR, d1, d2);
                //    ag.Generate();
                //}
            }

        }

    }
}
