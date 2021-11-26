using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Att.Vdb;

namespace Dal.Dao.Att
{
    public class AttcardDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="conn"></param>
        public AttcardDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 出勤資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public AttcardDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 出勤刷卡資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">出勤日期</param>
        /// <returns>List AttcardRow</returns>
        public List<AttcardRow> GetAttcard(string sNobr, DateTime dDate)
        {
            var Vdb = (from a in dcHr.ATTCARD
                       where a.NOBR.Trim() == sNobr
                       && a.ADATE.Date == dDate
                       select new AttcardRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           NoTrans = a.NOMODY,
                           OnCardTime24 = a.TT1,
                           OffCardTime24 = a.TT2,
                           OnCardTime48 = a.T1,
                           OffCardTime48 = a.T2,
                           OnLos = a.LOST1,
                           OffLos = a.LOST2,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.OnCardTime48.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OnCardTime48));

                if (rVdb.OffCardTime48.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OffCardTime48));
            }

            return Vdb;
        }

        /// <summary>
        /// 出勤刷卡資料(依日期)
        /// </summary>
        /// <param name="dDate">出勤日期</param>
        /// <returns>List AttcardRow</returns>
        public List<AttcardRow> GetAttcard( DateTime dDate)
        {
            var Vdb = (from a in dcHr.ATTCARD
                       where  a.ADATE.Date == dDate
                       select new AttcardRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           NoTrans = a.NOMODY,
                           OnCardTime24 = a.TT1,
                           OffCardTime24 = a.TT2,
                           OnCardTime48 = a.T1,
                           OffCardTime48 = a.T2,
                           OnLos = a.LOST1,
                           OffLos = a.LOST2,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.OnCardTime48.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OnCardTime48));

                if (rVdb.OffCardTime48.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OffCardTime48));
            }

            return Vdb;
        }

        /// <summary>
        /// 出勤刷卡資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List AttcardRow</returns>
        public List<AttcardRow> GetAttcard(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from a in dcHr.ATTCARD
                       where a.NOBR.Trim() == sNobr
                       && dDateB.Date <= a.ADATE.Date
                       && a.ADATE.Date <= dDateE.Date
                       select new AttcardRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           NoTrans = a.NOMODY,
                           OnCardTime24 = a.TT1,
                           OffCardTime24 = a.TT2,
                           OnCardTime48 = a.T1,
                           OffCardTime48 = a.T2,
                           OnLos = a.LOST1,
                           OffLos = a.LOST2,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.OnCardTime48.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OnCardTime48));

                if (rVdb.OffCardTime48.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OffCardTime48));
            }

            return Vdb;
        }

        /// <summary>
        /// 出勤刷卡資料(不規則日期)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="lsDate">開始出勤日期</param>
        /// <returns>List AttcardRow</returns>
        public List<AttcardRow> GetAttcard(string sNobr, List<DateTime> lsDate)
        {
            var Vdb = (from a in dcHr.ATTCARD
                       where a.NOBR.Trim() == sNobr
                       && lsDate.Contains(a.ADATE.Date)
                       select new AttcardRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           NoTrans = a.NOMODY,
                           OnCardTime24 = a.TT1,
                           OffCardTime24 = a.TT2,
                           OnCardTime48 = a.T1,
                           OffCardTime48 = a.T2,
                           OnLos = a.LOST1,
                           OffLos = a.LOST2,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.OnCardTime48.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OnCardTime48));

                if (rVdb.OffCardTime48.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OffCardTime48));
            }

            return Vdb;
        }

        /// <summary>
        /// 是否為刷卡時間 True = 是刷卡時間
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <returns>bool</returns>
        public bool IsCardTime(string sNobr, DateTime dDate, string sTimeB, string sTimeE)
        {
            bool bCardTime = false;
            DateTime dDateTimeB, dDateTimeE;
            dDateTimeB = dDate.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));    //加班開始日期時間
            dDateTimeE = dDate.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));    //加班結束日期時間

            //取今天跟前一天兩筆資料來判斷
            var rsAttcard = GetAttcard(sNobr, dDate.AddDays(-1), dDate);

            foreach(var rAttcard in rsAttcard)
            {
                bCardTime = false;

                bCardTime = rAttcard.DateTimeB <= dDateTimeB && dDateTimeB <= rAttcard.DateTimeE;
                bCardTime = bCardTime && (rAttcard.DateTimeB <= dDateTimeE && dDateTimeE <= rAttcard.DateTimeE);

                if (bCardTime) break;
            }

            return bCardTime;
        }

        /// <summary>
        /// 是否為刷卡時間 True = 是刷卡時間
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">日期</param>
        /// <param name="dDateE">日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <returns>bool</returns>
        public bool IsCardTime(string sNobr, DateTime dDateB , DateTime dDateE, string sTimeB, string sTimeE)
        {
            bool bCardTime = false;
            DateTime dDateTimeB, dDateTimeE;
            dDateTimeB = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));    //加班開始日期時間
            dDateTimeE = dDateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));    //加班結束日期時間

            //取今天跟前一天兩筆資料來判斷
            var rsAttcard = GetAttcard(sNobr, dDateB.AddDays(-1), dDateE);

            foreach (var rAttcard in rsAttcard)
            {
                bCardTime = false;

                bCardTime = rAttcard.DateTimeB <= dDateTimeB && dDateTimeB <= rAttcard.DateTimeE;
                bCardTime = bCardTime && (rAttcard.DateTimeB <= dDateTimeE && dDateTimeE <= rAttcard.DateTimeE);

                if (bCardTime) break;
            }

            return bCardTime;
        }
        /// <summary>
        /// 出勤刷卡資料(日期區間)
        /// </summary>
        /// <param name="lsNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List AttcardRow</returns>
        public List<AttcardRow> GetAttcard(List<string> lsNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from a in dcHr.ATTCARD
                       where lsNobr.Contains(a.NOBR.Trim())
                       && dDateB.Date <= a.ADATE.Date
                       && a.ADATE.Date <= dDateE.Date
                       select new AttcardRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.ADATE.Date,
                           NoTrans = a.NOMODY,
                           OnCardTime24 = a.TT1,
                           OffCardTime24 = a.TT2,
                           OnCardTime48 = a.T1,
                           OffCardTime48 = a.T2,
                           OnLos = a.LOST1,
                           OffLos = a.LOST2,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.OnCardTime48.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OnCardTime48));

                if (rVdb.OffCardTime48.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.OffCardTime48));
            }

            return Vdb;
        }
    }
}