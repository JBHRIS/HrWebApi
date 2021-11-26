using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Att.Vdb;
using Bll.Tools;
using JBModule.Data.Linq;
using System.Data;

namespace Dal.Dao.Att
{
    public class CardDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="conn"></param>
        public CardDao(IDbConnection conn = null)
        {
            dcHr = new HrDBDataContext();

            if (conn != null)
                dcHr = new HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CardDao(string ConnectionString = null)
        {
            dcHr = new HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new HrDBDataContext(ConnectionString);
        }

        public List<CardRow> GetData(string sNobr = "", DateTime? dDate = null, string sTime = "")
        {
            var Vdb = (from c in dcHr.CARD
                       where (sNobr == "" || c.NOBR.Trim() == sNobr)
                       && (dDate == null || c.ADATE.Date == dDate.Value.Date)
                       && (sTime == "" || c.ONTIME.Trim() == sTime)
                       select new CardRow
                       {
                           Nobr = c.NOBR.Trim(),
                           DateA = c.ADATE.Date,
                           OnTime = c.ONTIME.Trim(),
                           CardNo = c.CARDNO.Trim(),
                           NotTran = c.NOT_TRAN,
                           Reason = c.REASON.Trim(),
                           Los = c.LOS,
                           IpAdd = c.IPADD.Trim(),
                           Note = c.MENO.Trim(),
                           Serno = c.SERNO.Trim(),
                           KeyMan = c.KEY_MAN.Trim(),
                           keyDate = c.KEY_DATE,
                       }).ToList();

            return Vdb;
        }

        public bool Save(CardRow rs, bool bReplace = true)
        {
            bool Vdb = false;

            var rt = (from c in dcHr.CARD
                      where c.NOBR.Trim() == rs.Nobr
                              && c.ADATE.Date == rs.DateA
                              && c.ONTIME.Trim() == rs.OnTime
                      select c).FirstOrDefault();

            if (rt == null)
            {
                rt = new CARD();
                rt.NOBR = rs.Nobr;
                rt.ADATE = rs.DateA;
                rt.ONTIME = rs.OnTime;
                dcHr.CARD.InsertOnSubmit(rt);

                bReplace = true;
            }

            if (bReplace)
            {
                rt.CODE = "1";
                rt.CARDNO = rs.Nobr;
                rt.KEY_DATE = DateTime.Now;
                rt.KEY_MAN = rs.KeyMan;
                rt.NOT_TRAN = rs.NotTran;
                rt.DAYS = 0;
                rt.REASON = rs.Reason;
                rt.LOS = rs.Los;
                rt.IPADD = rs.IpAdd;
                rt.MENO = rs.Note;
                rt.SERNO = rs.Serno;

                dcHr.SubmitChanges();

                Vdb = true;
            }

            return Vdb;
        }
        /// <summary>
        /// 存入刷卡資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sTime">時間</param>
        /// <param name="sReason">忘刷原因</param>
        /// <param name="sNote">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sSerno">序號</param>
        /// <returns>bool</returns>
        public bool Save(string sNobr, DateTime dDate, string sTime, string sReason, string sNote = "", string sKeyMan = "System", string sSerno = "")
        {
            bool Vdb = false;

            var rCARD = (from c in dcHr.CARD
                         where c.NOBR.Trim() == sNobr
                         && c.ADATE.Date == dDate
                         && c.ONTIME.Trim() == sTime
                         select c).FirstOrDefault();

            if (rCARD == null)
            {
                rCARD = new CARD();
                Bll.Tools.DefaultData.SetRowDefaultValue(rCARD);
                rCARD.NOBR = sNobr;
                rCARD.ADATE = dDate;
                rCARD.ONTIME = sTime;
                rCARD.CODE = "1";
                rCARD.CARDNO = sNobr;
                rCARD.KEY_DATE = DateTime.Now;
                rCARD.KEY_MAN = sKeyMan;
                rCARD.NOT_TRAN = false;
                rCARD.DAYS = 0;
                rCARD.REASON = sReason;
                rCARD.LOS = true;
                rCARD.IPADD = "";
                rCARD.MENO = sNote;
                rCARD.SERNO = sSerno.Length > 0 ? sSerno : Guid.NewGuid().ToString();
                dcHr.CARD.InsertOnSubmit(rCARD);
                dcHr.SubmitChanges();

                Vdb = true;

                Dal.Dao.Att.TransCardDao oTransCardDao = new Dal.Dao.Att.TransCardDao(dcHr.Connection);
                oTransCardDao.TransCard(sNobr, sNobr, "0", "z", dDate, dDate.AddDays(1), sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
            }

            return Vdb;
        }
    }
}