using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Att.Vdb;
using Bll.MT.Vdb;

namespace Dal.Dao.Att
{
    public class AttendDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="conn"></param>
        public AttendDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public AttendDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttend(string sNobr, DateTime dDate)
        {
            var Vdb = (from a in dcHr.ATTEND
                       join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                       where a.NOBR.Trim() == sNobr
                       && a.ADATE.Date == dDate
                       select new AttendTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE.Trim(),
                           IsHoliDay = r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0,
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 出勤資料(ROTE_H)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttendH(string sNobr, DateTime dDate)
        {
            var Vdb = (from a in dcHr.ATTEND
                       join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                       where a.NOBR.Trim() == sNobr
                       && a.ADATE.Date == dDate
                       select new AttendTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE.Trim(),
                           RoteCodeH = a.ROTE_H.Trim(),
                           IsHoliDay = r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得可能慣用的班別
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="bLeft">向左第一筆開始找 反之 向右第一筆開始找</param>
        /// <returns>string</returns>
        public string GetAttendFixedRoteCode(string sNobr, DateTime dDate, bool bLeft = true)
        {
            string sRoteCode = "";

            if (bLeft)
            {
                var Vdb = (from a in dcHr.ATTEND
                           join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                           where a.NOBR.Trim() == sNobr
                           && !(r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0)
                           && bLeft ? a.ADATE.Date <= dDate : a.ADATE.Date >= dDate
                           orderby a.ADATE.Date descending
                           select a.ROTE).FirstOrDefault();

                if (Vdb != null)
                    sRoteCode = Vdb;
            }
            else
            {
                var Vdb = (from a in dcHr.ATTEND
                           join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                           where a.NOBR.Trim() == sNobr
                           && !(r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0)
                           && bLeft ? a.ADATE.Date <= dDate : a.ADATE.Date >= dDate
                           orderby a.ADATE.Date
                           select a.ROTE).FirstOrDefault();

                if (Vdb != null)
                    sRoteCode = Vdb;
            }

            return sRoteCode;
        }

        /// <summary>
        /// 出勤資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttend(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from a in dcHr.ATTEND
                       join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                       where a.NOBR.Trim() == sNobr
                       && dDateB.Date <= a.ADATE.Date
                       && a.ADATE.Date <= dDateE.Date
                       select new AttendTable()
                       {
                           Nobr = a.NOBR,
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE,
                           RoteCodeH = a.ROTE_H,
                           IsHoliDay = r.ON_TIME.Length == 0 && r.OFF_TIME.Length == 0 && r.WK_HRS == 0,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 出勤資料(不規則日期)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="lsDate">開始出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttend(string sNobr, List<DateTime> lsDate)
        {
            var Vdb = (from a in dcHr.ATTEND
                       where a.NOBR.Trim() == sNobr
                       && lsDate.Contains(a.ADATE.Date)
                       select new AttendTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE.Trim(),
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 尋找出勤正向或反向排序(以日期正負向為準)最近的一個日期
        /// </summary>
        /// <param name="Nobr">工號</param>
        /// <param name="Date">日期</param>
        /// <param name="Day">加或減幾天</param>
        /// <param name="SearchRangeDay">搜尋區間天數</param>
        /// <returns>Dictionary</returns>
        public List<TextValueRow> GetAttendDate(string Nobr, DateTime Date, int Day = -1, int SearchRangeDay = -10)
        {
            List<TextValueRow> dc = new List<TextValueRow>();
            TextValueRow tv;

            //Tuple<DateTime, string> lst = new Tuple<DateTime, string>();
            bool OrderDesc = SearchRangeDay < 0;

            DateTime Date1 = Date.Date;
            DateTime Date2 = Date.AddDays(SearchRangeDay).Date;

            DateTime DateB = Date1;
            DateTime DateE = Date2;

            if (Date1 > Date2)
            {
                DateB = Date2;
                DateE = Date1;
            }

            var rsAttend = (from c in dcHr.ATTEND
                            join r in dcHr.ROTE on c.ROTE equals r.ROTE1
                            where c.NOBR == Nobr
                            && DateB <= c.ADATE && c.ADATE <= DateE
                            && !(r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0)
                            orderby c.ADATE
                            select c).ToList();

            if (OrderDesc)
                rsAttend = (from c in dcHr.ATTEND
                            join r in dcHr.ROTE on c.ROTE equals r.ROTE1
                            where c.NOBR == Nobr
                            && DateB <= c.ADATE && c.ADATE <= DateE
                            && !(r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0)
                            orderby c.ADATE descending
                            select c).ToList();

            var rAttend = rsAttend.FirstOrDefault();
            if (rAttend == null)
                return dc;

            tv = new TextValueRow();
            tv.Text = rAttend.ADATE.ToShortDateString();
            tv.Value = rAttend.ROTE;
            dc.Add(tv);

            if (rsAttend.Count > 0)
            {
                rAttend = rsAttend[rsAttend.Count > Math.Abs(Day) ? Math.Abs(Day) : rsAttend.Count - 1];

                dc = new List<TextValueRow>();
                tv = new TextValueRow();
                tv.Text = rAttend.ADATE.ToShortDateString();
                tv.Value = rAttend.ROTE;
                dc.Add(tv);
            }

            //對於扣除假日的出勤料再進行一次比對
            //Date1 = Date.Date.AddDays(Day);

            //DateB = Date1;
            //DateE = Date2;

            //if (Date1 > Date2)
            //{
            //    DateB = Date2;
            //    DateE = Date1;
            //}

            //var rs = (from c in rsAttend
            //          where DateB <= c.ADATE && c.ADATE <= DateE
            //          select c).ToList();

            //if (!rs.Any())
            //    return dc;

            //rAttend = rs.OrderBy(p => p.ADATE).First();

            //if (OrderDesc)
            //    rAttend = rs.OrderByDescending(p => p.ADATE).First();

            //dc = new List<TextValueRow>();
            //tv = new TextValueRow();
            //tv.Text = rAttend.ADATE.ToShortDateString();
            //tv.Value = rAttend.ROTE;
            //dc.Add(tv);

            return dc;
        }
        /// <summary>
        /// 取得有忘刷次數的日期
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List</returns>
        public List<TextValueRow> GetAttendByForgetNum(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from c in dcHr.ATTEND
                       where c.NOBR.Trim() == sNobr
                       && dDateB.Date <= c.ADATE.Date
                       && c.ADATE.Date <= dDateE.Date
                       && c.FORGET > 0
                       select c);

            List<TextValueRow> dc = new List<TextValueRow>();
            foreach (var r in Vdb)
            {
                TextValueRow tv = new TextValueRow();
                tv.Text = r.ADATE.ToShortDateString();
                tv.Value = Convert.ToInt32(r.FORGET).ToString();
                dc.Add(tv);
            }

            return dc;
        }
        /// <summary>
        /// 寫入出勤資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sRoteCodeH">實際出勤班別</param>
        /// <returns>bool</returns>
        public bool SaveAttend(string sNobr, DateTime dDate, string sRoteCodeH)
        {
            bool bPass = false;

            var r = (from c in dcHr.ATTEND
                     where c.NOBR.Trim() == sNobr
                     && c.ADATE.Date == dDate
                     select c).FirstOrDefault();

            if (r != null)
            {
                r.CANT_ADJ = true;
                r.ROTE_H = sRoteCodeH;

                dcHr.SubmitChanges();

                bPass = true;
            }

            return bPass;
        }
        /// <summary>
        /// 出勤資料(日期區間)
        /// </summary>
        /// <param name="lsNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttend(List<string> lsNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from a in dcHr.ATTEND
                       where lsNobr.Contains(a.NOBR.Trim())
                       && dDateB.Date <= a.ADATE.Date
                       && a.ADATE.Date <= dDateE.Date
                       select new AttendTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE.Trim(),
                           //RoteCodeH = a.ROTE_H.Trim(),      
                           ElasticityMin = Convert.ToInt32(a.SER),
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 包含出勤鎖檔
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sSaladr">薪資群組</param>
        /// <returns>List</returns>
        public bool AttendDataPass(string sNobr, DateTime? dDateB, DateTime? dDateE)
        {
            Dal.Dao.Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBase = oBasDao.GetBaseByNobr(sNobr, DateTime.Now.Date).FirstOrDefault();

            if (rBase == null)
                return false;


            var Vdb = (from c in dcHr.DATA_PA
                       where dDateB.GetValueOrDefault(new DateTime(1900, 1, 1)).Date <= c.DATA_PASS.Date
                       && c.DATA_PASS.Date <= dDateE.GetValueOrDefault(new DateTime(2099, 1, 1)).Date
                       && (rBase.Saladr == "" || c.SALADR.Trim() == rBase.Saladr)
                       select new
                       {
                           Date = c.DATA_PASS.Date,
                           Saladr = c.SALADR.Trim(),
                       }).ToList();

            if (Vdb.Count() > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="dDate">出勤日期</param>
        /// <returns>List</returns>
        public List<AttendTable> GetAttend(DateTime dDate)
        {
            var Vdb = (from a in dcHr.ATTEND
                       join r in dcHr.ROTE on a.ROTE equals r.ROTE1
                       where a.ADATE.Date == dDate
                       select new AttendTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           RoteCode = a.ROTE.Trim(),
                           RoteCodeH = a.ROTE_H.Trim(),
                           IsHoliDay = r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0,
                       }).ToList();

            return Vdb;
        }

    }
}