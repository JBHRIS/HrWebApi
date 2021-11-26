using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Sal.Vdb;
using System.Data;
using Bll.MT.Vdb;

namespace Dal.Dao.Sal
{
    public class SalaryLockDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// 薪資鎖檔
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public SalaryLockDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 薪資鎖檔
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SalaryLockDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 計薪前鎖檔 包含出勤鎖檔 及 助理鎖檔
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>List</returns>
        public List<SalaryLockBeginRow> GetSalaryLockBegin(DateTime? dDateB, DateTime? dDateE, string sSaladr = "")
        {
            var Vdb1 = (from c in dcHr.DATA_PA
                        where dDateB.GetValueOrDefault(new DateTime(1900, 1, 1)).Date <= c.DATA_PASS.Date
                        && c.DATA_PASS.Date <= dDateE.GetValueOrDefault(new DateTime(2099, 1, 1)).Date
                        && (sSaladr == "" || c.SALADR.Trim() == sSaladr)
                        select new SalaryLockBeginRow
                        {
                            Date = c.DATA_PASS.Date,
                            Saladr = c.SALADR.Trim(),
                        }).ToList();

            var Vdb2 = (from c in dcHr.DATA_PASS
                        where dDateB.GetValueOrDefault(new DateTime(1900, 1, 1)).Date <= c.DATA_PASS1.Date
                        && c.DATA_PASS1.Date <= dDateE.GetValueOrDefault(new DateTime(2099, 1, 1)).Date
                        && (sSaladr == "" || c.SALADR.Trim() == sSaladr)
                        select new SalaryLockBeginRow
                        {
                            Date = c.DATA_PASS1.Date,
                            Saladr = c.SALADR.Trim(),
                        }).ToList();

            foreach (var rVdb1 in Vdb1)
                if (!Vdb2.Contains(rVdb1))
                    Vdb2.Add(rVdb1);

            return Vdb2;
        }

        /// <summary>
        /// 計薪後鎖檔
        /// </summary>
        /// <param name="sYymmB">開始計薪年月</param>
        /// <param name="sYymmE">結束計薪年月</param>
        /// <param name="sSeq">期別</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>List</returns>
        public List<SalaryLockAfterRow> GetSalaryLockAfter(string sYymmB = "0", string sYymmE = "z", string sSeq = "", string sSaladr = "")
        {
            sYymmB = sYymmB.Trim().Length > 0 ? sYymmB : "0";
            sYymmE = sYymmE.Trim().Length > 0 ? sYymmE : "z";

            var Vdb = (from c in dcHr.LOCK_WAGE
                       where (sYymmB.CompareTo(c.YYMM.Trim()) <= 0 && c.YYMM.Trim().CompareTo(sYymmE) <= 0)
                       && (sSeq == "" || c.SEQ.Trim() == sSeq)
                       && (sSaladr == "" || c.SALADR.Trim() == sSaladr)
                       select new SalaryLockAfterRow
                       {
                           Yymm = c.YYMM.Trim(),
                           Seq = c.SEQ.Trim(),
                           Saladr = c.SALADR.Trim(),
                           Meno = c.MENO.Trim(),
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 計薪月份日期最後一天
        /// </summary>
        /// <param name="sComp">公司別</param>
        /// <returns>List</returns>
        public List<SalaryMonthDay> GetSalaryMonthDay(string sComp = "")
        {
            var Vdb = (from c in dcHr.U_SYS2
                       where sComp == "" || c.Comp.Trim() == sComp
                       select new SalaryMonthDay
                       {
                           Comp = c.Comp.Trim(),
                           Day = c.ATTMONTH.Value,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 計薪年月
        /// </summary>
        /// <param name="lsSalaryDateBE">計算區間</param>
        /// <param name="iSalaryDay">每月計算最後一天</param>
        /// <param name="sSeq">期別</param>
        /// <returns>List SalaryYymm</returns>
        public List<SalaryYymm> GetSalaryYymm(List<SalaryDateBE> lsSalaryDateBE, int iSalaryDay = 0, string sSeq = "2")
        {
            List<SalaryYymm> Vdb = new List<SalaryYymm>();

            List<string> lsNobr = lsSalaryDateBE.Select(p => p.Nobr).Distinct().ToList();

            Dao.Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rsBas = oBasDao.GetBaseByNobr(lsNobr, DateTime.Now);

            var rsSalaryMonthDay = GetSalaryMonthDay();

            int iMonthDay = iSalaryDay;

            foreach (var rSalaryDateBE in lsSalaryDateBE)
            {
                for (DateTime dt = rSalaryDateBE.DateB; dt <= rSalaryDateBE.DateE; dt = dt.AddDays(1))
                {
                    if (!Vdb.Where(p => p.Nobr == rSalaryDateBE.Nobr && p.Date == dt).Any())
                    {
                        SalaryYymm rSalaryYymm = new SalaryYymm();
                        rSalaryYymm.Nobr = rSalaryDateBE.Nobr;
                        rSalaryYymm.Date = dt;
                        Vdb.Add(rSalaryYymm);
                    }
                }
            }

            if (Vdb.Any())
            {
                DateTime dDateB = Vdb.Min(p => p.Date).Date;
                DateTime dDateE = Vdb.Max(p => p.Date).Date;
                string sYymmB = Bll.Tools.TimeTrans.DateToYyMm(dDateB.AddMonths(-1).Date);
                string sYymmE = Bll.Tools.TimeTrans.DateToYyMm(dDateE.AddMonths(1).Date);

                var rsSalaryLockBegin = GetSalaryLockBegin(dDateB , null);
                //var rsSalaryLockAfter = GetSalaryLockAfter(sYymmB, sYymmE);

                foreach (var rVdb in Vdb)
                {
                    DateTime dDate = rVdb.Date;

                    var rBas = rsBas.Where(p => p.Nobr == rVdb.Nobr).FirstOrDefault();
                    if (rBas != null)
                    {
                        var rSalaryMonthDay = rsSalaryMonthDay.Where(p => p.Comp == rBas.Comp).FirstOrDefault();
                        if (rSalaryMonthDay != null)
                        {
                            //更變計變年月日期
                            if (iSalaryDay == 0)
                                iMonthDay = rSalaryMonthDay.Day;

                            var rsSalaryLockBeginWhere = rsSalaryLockBegin.Where(p => p.Saladr == rBas.Saladr);

                            //如果有鎖檔 以鎖檔日期再加一次為新的日期 20200312 註解
                            //if (rsSalaryLockBeginWhere.Any())
                            //{
                            //    var rSalaryLockBeginWhere = rsSalaryLockBeginWhere.OrderByDescending(p => p.Date).First();
                            //    dDate = rSalaryLockBeginWhere.Date >= dDate ? rSalaryLockBeginWhere.Date.AddDays(1) : dDate;
                            //}

                            //出勤鎖檔有兩種加日期的方式 1.一直加，加到沒有鎖檔的日期 ； 2.固定加1個月，加到沒有鎖檔的日期

                            var any = false;
                            //do
                            //{
                            //    any = rsSalaryLockBeginWhere.Any(p => p.Date == dDate);
                            //    dDate = dDate.AddDays(1);
                            //} while (any);

                            do
                            {
                                any = rsSalaryLockBeginWhere.Any(p => p.Date == dDate);

                                if (any)
                                    dDate = dDate.AddMonths(1);
                            } while (any);

                            //判斷是否大於計算週期
                            dDate = dDate.Day > iMonthDay ? dDate.AddMonths(1).Date : dDate;

                            rVdb.Yymm = Bll.Tools.TimeTrans.DateToYyMm(dDate);

                            //判斷是否是當月的最後一天
                            //int iDaysInMonth = DateTime.DaysInMonth(dDate.Year, dDate.Month);
                            //DateTime dDateA = new DateTime(dDate.Year, dDate.Month, (iDaysInMonth <= iSalaryDay ? iDaysInMonth : iSalaryDay)).AddDays(1).AddMonths(-1).Date;
                        }
                    }
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 計薪年月
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">計期日期</param>
        /// <param name="iSalaryDay">每月計算最後一天</param>
        /// <param name="sSeq">期別</param>
        /// <returns>List SalaryYymm</returns>
        public string GetSalaryYymm(string sNobr, DateTime dDate, int iSalaryDay = 0, string sSeq = "2")
        {
            Dao.Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rsBas = oBasDao.GetBaseByNobr(sNobr, DateTime.Now);

            var rsSalaryMonthDay = GetSalaryMonthDay();

            int iMonthDay = iSalaryDay;

            var rsSalaryLockBegin = GetSalaryLockBegin(dDate, null);

            var rBas = rsBas.Where(p => p.Nobr == sNobr).FirstOrDefault();
            if (rBas != null)
            {
                var rSalaryMonthDay = rsSalaryMonthDay.Where(p => p.Comp == rBas.Comp).FirstOrDefault();
                if (rSalaryMonthDay != null)
                {
                    //更變計變年月日期
                    if (iSalaryDay == 0)
                        iMonthDay = rSalaryMonthDay.Day;

                    var rsSalaryLockBeginWhere = rsSalaryLockBegin.Where(p => p.Saladr == rBas.Saladr);

                    //如果有鎖檔 以鎖檔日期再加一次為新的日期
                    //if (rsSalaryLockBeginWhere.Any())
                    //{
                    //    var rSalaryLockBeginWhere = rsSalaryLockBeginWhere.OrderByDescending(p => p.Date).First();
                    //    dDate = rSalaryLockBeginWhere.Date >= dDate ? rSalaryLockBeginWhere.Date.AddDays(1) : dDate;
                    //}

                    var any = false;
                    //do
                    //{
                    //    any = rsSalaryLockBeginWhere.Any(p => p.Date == dDate);
                    //    dDate = dDate.AddDays(1);
                    //} while (any);

                    do
                    {
                        any = rsSalaryLockBeginWhere.Any(p => p.Date == dDate);
                        if (any)
                            dDate = dDate.AddMonths(1);
                    } while (any);

                    //判斷是否大於計算週期
                    dDate = dDate.Day > iMonthDay ? dDate.AddMonths(1).Date : dDate;

                    //判斷是否是當月的最後一天
                    //int iDaysInMonth = DateTime.DaysInMonth(dDate.Year, dDate.Month);
                    //DateTime dDateA = new DateTime(dDate.Year, dDate.Month, (iDaysInMonth <= iSalaryDay ? iDaysInMonth : iSalaryDay)).AddDays(1).AddMonths(-1).Date;
                }
            }

            return Bll.Tools.TimeTrans.DateToYyMm(dDate);
        }
        /// <summary>
        /// 取得計薪週期
        /// </summary>
        /// <param name="dDate">申請日期</param>
        /// <param name="sComp">公司別</param>
        /// <param name="iSalaryDay">判斷日期</param>
        /// <returns>TwoDateTime</returns>
        public TwoDateTime GetSalDate(DateTime dDate, string sComp = "", int iSalaryDay = 0)
        {
            TwoDateTime Vdb = new TwoDateTime();

            //預設 是0 直接以次月初到月底
            DateTime DateA = new DateTime(dDate.Year, dDate.Month, 1).AddMonths(1).Date;
            DateTime DateD = new DateTime(DateA.Year, DateA.Month, DateTime.DaysInMonth(DateA.Year, DateA.Month)).Date;

            if (iSalaryDay == 0)
                iSalaryDay = GetSalaryMonthDay(sComp).First().Day;

            //計薪日期 大於等於 申請日期的最後一天 直接以本月初到月底
            if (iSalaryDay >= DateTime.DaysInMonth(dDate.Year, dDate.Month))
            {
                DateA = new DateTime(dDate.Year, dDate.Month, 1).Date;
                DateD = new DateTime(DateA.Year, DateA.Month, DateTime.DaysInMonth(DateA.Year, DateA.Month)).Date;
            }
            else
            {
                //上月某日 到 本月某日
                DateD = new DateTime(dDate.Year, dDate.Month, iSalaryDay).Date;
                DateA = DateD.AddMonths(-1).AddDays(1);

                //申請日期 大於 計職日期 直接以本月某日 到 下月某日
                int Day = dDate.Day;
                if (Day > iSalaryDay)
                {
                    DateD = DateD.AddMonths(1);
                    DateA = DateD.AddMonths(-1).AddDays(1);
                }
            }

            Vdb.DateA = DateA;
            Vdb.DateD = DateD;

            return Vdb;
        }
    }
}