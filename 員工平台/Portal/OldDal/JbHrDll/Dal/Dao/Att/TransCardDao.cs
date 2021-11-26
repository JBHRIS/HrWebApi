using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Att.Vdb;
using Dal.Entity;
using System.Threading;
using System.Data;

namespace Dal.Dao.Att
{
    /// <summary>
    /// TransCardDao
    /// </summary>
    public class TransCardDao : JBModule.Message.ReportStatus
    {
        private dcHrDataContext dcHr;

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public TransCardDao(IDbConnection conn = null)
        {
            dcHr = new dcHrDataContext();

            if (conn != null)
                dcHr = new dcHrDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 取得員工基本判斷資料
        /// </summary>
        /// <param name="Cond">TransCardCondition</param>
        /// <returns>BaseTable</returns>
        private List<BaseTable> GetBaseByNobr(TransCardCondition Cond)
        {
            string[] arrTtscode = { "1", "4", "6" };
            var Vdb = (from c in dcHr.BASETTS
                       join d in dcHr.DEPT
                       on c.DEPT equals d.D_NO
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Convert.ToDateTime(c.ADATE.Date).Date <= Cond.dDateE
                       && Cond.dDateB <= c.DDATE.Value.Date
                       && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                       && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                       && arrTtscode.Contains(c.TTSCODE.Trim())
                       && dcHr.GetFilterByNobr(c.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                       select new BaseTable()
                       {
                           Nobr = c.NOBR.Trim(),
                           DateA = c.ADATE.Date,
                           DateD = c.DDATE.Value.Date,
                           NeedCard = c.CARD.Trim() == "Y",
                           NeedOnCard = true,
                           NeedOffCard = !c.ONLYONTIME,
                           NoTer = c.NOTER,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得班表資料
        /// </summary>
        /// <param name="arrRoteCode">null = 全部</param>
        /// <returns>RoteTable</returns>
        private List<RoteTable> GetRote(string[] arrRoteCode = null)
        {
            var iqRote = from c in dcHr.ROTE
                         where c.ROTE1.Trim() != "00"
                         select c;

            if (arrRoteCode != null)
                iqRote = from c in dcHr.ROTE
                         where c.ROTE1.Trim() != "00"
                         && arrRoteCode.Contains(c.ROTE1.Trim())
                         select c;

            var Vdb = (from c in iqRote
                       select new RoteTable()
                       {
                           RoteCode = c.ROTE1.Trim(),
                           OnTime = c.ON_TIME.Trim(),
                           OffTime = c.OFF_TIME.Trim(),
                           OffLastTime = c.OFFTIME2.Trim(),
                           LatesMin = Convert.ToInt32(c.ALLLATES),
                           ElasticityMin = Convert.ToInt32(c.ALLLATES1),
                           DayRes = GetRoteRes(c.RES_B_TIME.Trim(), c.RES_E_TIME.Trim()
                           , c.RES_B1_TIME.Trim(), c.RES_E1_TIME.Trim()
                           , c.RES_B2_TIME.Trim(), c.RES_E2_TIME.Trim()
                           , c.RES_B3_TIME.Trim(), c.RES_E3_TIME.Trim()
                           , c.RES_B4_TIME.Trim(), c.RES_E4_TIME.Trim())
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 休息時間
        /// </summary>
        /// <param name="sResB1">休息時間</param>
        /// <param name="sResE1">休息時間</param>
        /// <param name="sResB2">休息時間</param>
        /// <param name="sResE2">休息時間</param>
        /// <param name="sResB3">休息時間</param>
        /// <param name="sResE3">休息時間</param>
        /// <param name="sResB4">休息時間</param>
        /// <param name="sResE4">休息時間</param>
        /// <param name="sResB5">休息時間</param>
        /// <param name="sResE5">休息時間</param>
        /// <returns>RoteResTable</returns>
        private List<RoteResTable> GetRoteRes(string sResB1, string sResE1, string sResB2, string sResE2, string sResB3, string sResE3, string sResB4, string sResE4, string sResB5, string sResE5)
        {
            List<RoteResTable> ls = new List<RoteResTable>();

            var r = new RoteResTable();

            if (sResB1.Trim().Length == 4 && sResE1.Trim().Length == 4)
            {
                r = new RoteResTable();
                r.ResB = sResB1;
                r.ResE = sResE1;
                ls.Add(r);
            }

            if (sResB2.Trim().Length == 4 && sResE2.Trim().Length == 4)
            {
                r = new RoteResTable();
                r.ResB = sResB2;
                r.ResE = sResE2;
                ls.Add(r);
            }

            if (sResB3.Trim().Length == 4 && sResE3.Trim().Length == 4)
            {
                r = new RoteResTable();
                r.ResB = sResB3;
                r.ResE = sResE3;
                ls.Add(r);
            }

            if (sResB4.Trim().Length == 4 && sResE4.Trim().Length == 4)
            {
                r = new RoteResTable();
                r.ResB = sResB4;
                r.ResE = sResE4;
                ls.Add(r);
            }

            if (sResB5.Trim().Length == 4 && sResE5.Trim().Length == 4)
            {
                r = new RoteResTable();
                r.ResB = sResB5;
                r.ResE = sResE5;
                ls.Add(r);
            }

            return ls;
        }

        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="Cond">TransCardCondition</param>
        /// <returns>AbsTable</returns>
        private List<AbsTable> GetAbs(TransCardCondition Cond)
        {
            string[] arr = { "0", "2", "4", "6", "8" };

            var Vdb1 = (from a in dcHr.ABS
                        join h in dcHr.HCODE
                        on a.H_CODE.Trim() equals h.H_CODE.Trim()
                        where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                        && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                        && Cond.dDateB <= Convert.ToDateTime(a.BDATE.Date).Date
                        && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE
                        && a.BTIME.Trim().Length == 4
                        && a.ETIME.Trim().Length == 4
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == a.NOBR.Trim()
                                && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                                select b).Any()
                        && arr.Contains(h.YEAR_REST.Trim())
                        && dcHr.GetFilterByNobr(a.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                        select new AbsTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Date = a.BDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim()
                        }).ToList();

            var Vdb2 = (from a in dcHr.ABS1
                        join h in dcHr.HCODE
                        on a.H_CODE.Trim() equals h.H_CODE.Trim()
                        where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                        && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                        && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE
                        && Cond.dDateB <= a.BDATE.Date
                        && a.BTIME.Trim().Length == 4
                        && a.ETIME.Trim().Length == 4
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == a.NOBR.Trim()
                                && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                                select b).Any()
                        && arr.Contains(h.YEAR_REST.Trim())
                        && dcHr.GetFilterByNobr(a.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                        select new AbsTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Date = a.BDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim()
                        }).ToList();

            var Vdb = Vdb1.Union(Vdb2).
                Select(a => new AbsTable()
                {
                    Nobr = a.Nobr,
                    Date = a.Date,
                    TimeB = a.TimeB,
                    TimeE = a.TimeE,
                    DateTimeB = a.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeB)),
                    DateTimeE = a.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeE))
                }).ToList();


            return Vdb;
        }

        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="Cond">TransCardCondition</param>
        /// <returns>OtTable</returns>
        private List<OtTable> GetOt(TransCardCondition Cond)
        {
            var Vdb = (from a in dcHr.OT
                       join t in dcHr.ATTEND
                       on new { a.NOBR, a.BDATE.Date } equals new { t.NOBR, t.ADATE.Date }
                       where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                       && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB <= Convert.ToDateTime(a.BDATE.Date).Date
                       && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE
                       && t.ROTE.Trim() == "00" //只有假日才需要被取出來
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == a.NOBR.Trim()
                                && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                                select b).Any()
                       && dcHr.GetFilterByNobr(a.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                       select new OtTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.BDATE.Date,
                           RoteCode = a.OT_ROTE.Trim()
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="Cond">TransCardCondition</param>
        /// <returns>CardTable</returns>
        private List<CardTable> GetCard(TransCardCondition Cond)
        {
            var Vdb = (from c in dcHr.CARD
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB <= Convert.ToDateTime(c.ADATE.Date).Date
                       && Convert.ToDateTime(c.ADATE.Date).Date <= Cond.dDateE.AddDays(1)   //刷卡資料有可能是到隔天 所以要再加一天
                       && c.ONTIME.Trim().Length == 4
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == c.NOBR.Trim()
                                && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                                select b).Any()
                       && dcHr.GetFilterByNobr(c.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                       select new CardTable()
                       {
                           Nobr = c.NOBR.Trim(),
                           CardDate = c.ADATE.Date,
                           CardTime24 = c.ONTIME.Trim(),
                           Los = c.LOS,
                       }).ToList();

            Vdb = Vdb.Select(c => new CardTable()
            {
                Nobr = c.Nobr,
                CardDate = c.CardDate,
                CardTime24 = c.CardTime24,
                CardDateTime = c.CardDate.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(c.CardTime24)),
                Los = c.Los,
            }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得出勤資料
        /// </summary>
        /// <param name="Cond">TransCardCondition</param>
        /// <returns>AttCardTable</returns>
        private List<AttCardTable> GetAttCard(TransCardCondition Cond)
        {
            var Vdb = (from c in dcHr.ATTCARD
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB <= Convert.ToDateTime(c.ADATE.Date).Date
                       && Convert.ToDateTime(c.ADATE.Date).Date <= Cond.dDateE
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == c.NOBR.Trim()
                                && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                                select b).Any()
                       && dcHr.GetFilterByNobr(c.NOBR.Trim(), Cond.sUserID, Cond.sComp, Cond.bAdmin).Value
                       select new AttCardTable()
                       {
                           Nobr = c.NOBR.Trim(),
                           Date = c.ADATE.Date,
                           NoTrans = c.NOMODY,
                           OnCardTime48 = c.T1.Trim(),
                           OffCardTime48 = c.T2.Trim(),
                           OnCardTime24 = c.TT1.Trim(),
                           OffCardTime24 = c.TT2.Trim(),
                           OnLos = c.LOST1,
                           OffLos = c.LOST2
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 刷卡轉出勤 及 判斷異常
        /// </summary>
        /// <param name="sNobrB">開始工號</param>
        /// <param name="sNobrE">結束工號</param>
        /// <param name="sDeptB">開始部門</param>
        /// <param name="sDeptE">結束部門</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bAttCard">轉換刷卡時間</param>
        /// <param name="bAttEnd">判斷異常</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <param name="ThreadCount">啟用多少個執行緒(預設是2)</param>
        /// <returns>int</returns>
        public int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard, string sUserID, string sComp, bool bAdmin, int ThreadCount = 2)
        {
            TransCardCondition oCond = new TransCardCondition();
            oCond.sNobrB = sNobrB;
            oCond.sNobrE = sNobrE;
            oCond.sDeptB = sDeptB;
            oCond.sDeptE = sDeptE;
            oCond.dDateB = dDateB;
            oCond.dDateE = dDateE;
            oCond.sKeyMan = sKeyMan;
            oCond.bAttCard = bAttCard;
            oCond.bAttEnd = bAttCard;
            oCond.bEzAttCard = bEzAttCard;
            oCond.sUserID = sUserID;
            oCond.sComp = sComp;
            oCond.bAdmin = bAdmin;
            oCond.ThreadCount = ThreadCount;

            return TransCardPool(oCond);
        }

        /// <summary>
        /// 刷卡轉出勤 及 判斷異常
        /// </summary>
        /// <param name="oCond">TransCardCondition</param>
        /// <returns>int</returns>
        public int TransCard(TransCardCondition oCond)
        {
            int iPass = 0;

            TransCardVdb Vdb = new TransCardVdb();
            Vdb.TransCardCond = oCond;

            var rsATTEND = (from c in dcHr.ATTEND
                            where c.NOBR.Trim().CompareTo(oCond.sNobrB) >= 0
                            && c.NOBR.Trim().CompareTo(oCond.sNobrE) <= 0
                            && c.ADATE.Date >= oCond.dDateB.Date
                            && c.ADATE.Date <= oCond.dDateE.Date
                            && (from b in dcHr.BASETTS
                                join d in dcHr.DEPT
                                on b.DEPT equals d.D_NO
                                where b.NOBR.Trim() == c.NOBR.Trim()
                                && oCond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                                && d.D_NO_DISP.Trim().CompareTo(oCond.sDeptE) <= 0
                                select b).Any()
                            && dcHr.GetFilterByNobr(c.NOBR.Trim(), oCond.sUserID, oCond.sComp, oCond.bAdmin).Value
                            select c).ToList();

            //先刪除出勤刷卡資料
            if (oCond.bAttCard)
            {
                string delATTCARD = "Delete From ATTCARD" +
                    " Where NOBR Between {0} And {1}" +
                    " And ADATE Between {2} And {3}" +
                    " And Exists (Select * From BASETTS Inner Join DEPT" +
                    " On BASETTS.DEPT = DEPT.D_NO" +
                      " Where BASETTS.NOBR = ATTCARD.NOBR And DEPT.D_NO_DISP Between {4} And {5})" +
                    " And NOMODY = 0" +
                    " And dbo.GetFilterByNobr(NOBR , {6} , {7} , {8}) = 1";

                dcHr.ExecuteCommand(delATTCARD, oCond.sNobrB, oCond.sNobrE, oCond.dDateB, oCond.dDateE, oCond.sDeptB, oCond.sDeptE, oCond.sUserID, oCond.sComp, oCond.bAdmin);
            }

            Vdb.BaseData = GetBaseByNobr(oCond);
            Vdb.AbsData = GetAbs(oCond);
            Vdb.AttCardData = GetAttCard(oCond);
            Vdb.CardData = GetCard(oCond);
            Vdb.OtData = GetOt(oCond);
            Vdb.RoteData = GetRote(null);

            Bll.Att.TransCard oTransCard = new Bll.Att.TransCard();

            List<ATTCARD> lsATTCARD = new List<ATTCARD>();

            DateTime Date, DateTimeB, DateTimeE;
            Date = DateTime.Now.Date;
            string RoteCode;
            foreach (var rATTEND in rsATTEND)
            {
                iPass += 1;

                //取得需要轉的出勤資料 沒有出勤資料就不用轉
                if (oCond.dDateB <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE)
                {
                    //取得員工設定檔
                    var rBaseData = Vdb.BaseData.Where(p => p.Nobr.Trim() == rATTEND.NOBR.Trim()
                        && p.DateA <= rATTEND.ADATE.Date
                        && rATTEND.ADATE.Date <= p.DateD).FirstOrDefault();
                    if (rBaseData != null)
                    {
                        RoteCode = rATTEND.ROTE.Trim();

                        //如果是假日班就置換班別 先從加班資料尋找 再按照客戶規則找預設班別
                        if (RoteCode == "00")
                        {
                            var rOt = Vdb.OtData.Where(p => p.Nobr == rATTEND.NOBR.Trim()
                                && p.Date == rATTEND.ADATE.Date).FirstOrDefault();

                            if (rOt != null)
                                RoteCode = rOt.RoteCode;
                            else
                                RoteCode = GetRoteCode(rsATTEND, rATTEND.NOBR.Trim(), rATTEND.ADATE.Date, RoteCode);
                        }

                        //一定要非假日班別能轉換 而且班別一定要存在
                        //Vdb.RoteDataDay = Vdb.RoteData.Where(p => p.RoteCode == RoteCode).FirstOrDefault();
                        RoteTable rRoteDataDay = Vdb.RoteData.Where(p => p.RoteCode == RoteCode).FirstOrDefault();
                        if (rRoteDataDay != null && rRoteDataDay.RoteCode != "00")
                        {
                            //取得正確的刷卡資料
                            DateTimeB = rATTEND.ADATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRoteDataDay.OffLastTime));  //今天的最早上班時間
                            DateTimeE = DateTimeB.AddDays(1);   //今天的最晚下班時間

                            List<AttCardTable> lsAttCard = new List<AttCardTable>();

                            //需要重新拼上下班時間
                            if (oCond.bAttCard)
                            {
                                //將刷卡時間丟入物件集合 準備涵數使用
                                //Vdb.CardDataDay = Vdb.CardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && DateTimeB <= p.CardDateTime && p.CardDateTime <= DateTimeE).ToList();
                                List<CardTable> rsCardDataDay = Vdb.CardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && DateTimeB <= p.CardDateTime && p.CardDateTime <= DateTimeE).ToList();

                                //判斷當日是否不用轉換                             
                                lsAttCard = Vdb.AttCardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && p.Date == rATTEND.ADATE.Date).ToList();

                                //至少要有一筆刷卡資料
                                if (!lsAttCard.Any() && rsCardDataDay.Any())
                                {
                                    //Vdb.AttCardDataDay = oTransCard.AttCardByOneDay(rsCardDataDay, rATTEND.ADATE.Date, oCond.bEzAttCard);
                                    var rsAttCardData = oTransCard.AttCardByOneDay(rsCardDataDay, rATTEND.ADATE.Date, oCond.bEzAttCard);

                                    //有可能會有一天多筆資料
                                    foreach (var rAttCardDataDay in rsAttCardData)
                                    {
                                        //新增到ATTCARD
                                        var rATTACRD = new ATTCARD();
                                        Bll.Tools.DefaultData.SetRowDefaultValue(rATTACRD);
                                        rATTACRD.NOBR = rATTEND.NOBR.Trim();
                                        rATTACRD.ADATE = rATTEND.ADATE.Date;
                                        rATTACRD.SER = 1;
                                        rATTACRD.KEY_MAN = oCond.sKeyMan;
                                        rATTACRD.T1 = rAttCardDataDay.OnCardTime48;
                                        rATTACRD.T2 = rAttCardDataDay.OffCardTime48;
                                        rATTACRD.LOST1 = rAttCardDataDay.OnLos;
                                        rATTACRD.LOST2 = rAttCardDataDay.OffLos;
                                        rATTACRD.TT1 = rAttCardDataDay.OnCardTime24;
                                        rATTACRD.TT2 = rAttCardDataDay.OffCardTime24;
                                        lsATTCARD.Add(rATTACRD);

                                        //將資料加入到vdb
                                        lsAttCard.Add(rAttCardDataDay);
                                    }   //end foreach by attcard
                                }   //end if by 至少要有一筆刷卡資料
                            }   //end if by 需要重新拼上下班時間

                            //需要判斷異常
                            if (oCond.bAttEnd)
                            {
                                rATTEND.LATE_MINS = 0;  //遲到
                                rATTEND.E_MINS = 0; //早退
                                rATTEND.ABS = false;    //曠職
                                rATTEND.FORGET = 0; //忘刷

                                //一定要有刷卡資料 才需要判斷
                                if (rBaseData.NeedCard && rATTEND.ROTE.Trim() != "00")
                                {
                                    //放入請假資料
                                    //Vdb.AbsDataDay = Vdb.AbsData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && p.Date == rATTEND.ADATE.Date).ToList();
                                    List<AbsTable> rsAbs = Vdb.AbsData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && p.Date == rATTEND.ADATE.Date).ToList();
                                    var rAttEndByOneDay = oTransCard.AttEndByOneDay(lsAttCard, rRoteDataDay, rsAbs, rATTEND.ADATE.Date);

                                    rATTEND.LATE_MINS = rAttEndByOneDay.LatesMin;
                                    rATTEND.E_MINS = rAttEndByOneDay.EarlierMin;
                                    rATTEND.ABS = rAttEndByOneDay.Abs;
                                    rATTEND.FORGET = rAttEndByOneDay.Card;
                                    rATTEND.KEY_MAN = oCond.sKeyMan;
                                    rATTEND.KEY_DATE = DateTime.Now;
                                }
                            }
                        }   //end if by 一定要非假日班別能轉換 而且班別一定要存在
                    }   // end if by 取得員工設定檔
                }   //end if by 取得需要轉的出勤資料 沒有出勤資料就不用轉
            }   //end foreach

            dcHr.ATTCARD.InsertAllOnSubmit(lsATTCARD);
            dcHr.SubmitChanges();

            //try
            //{
            //    dcHr.SubmitChanges();
            //}
            //catch (System.Data.Linq.DuplicateKeyException ex)
            //{
            //    string s = ex.ToString();
            //}

            return iPass;
        }

        /// <summary>
        /// 尋找客制班別
        /// </summary>
        /// <param name="rsATTEND">ATTEND</param>
        /// <param name="Nobr">工號</param>
        /// <param name="Date">日期</param>
        /// <param name="RoteCode">班別</param>
        /// <returns>string</returns>
        private string GetRoteCode(List<ATTEND> rsATTEND, string Nobr, DateTime Date, string RoteCode = "00")
        {
            //先往前抓，如果前一天是00再往後抓
            var rR = rsATTEND.Where(p => p.NOBR.Trim() == Nobr && p.ADATE.Date == Date.Date.AddDays(-1)).FirstOrDefault();
            if (rR == null || rR.ROTE.Trim() == "00")
            {
                int i = 1;
                do
                {
                    rR = rsATTEND.Where(p => p.NOBR.Trim() == Nobr && p.ADATE.Date == Date.Date.AddDays(i)).FirstOrDefault();
                    i++;
                    if (rR != null)
                        RoteCode = rR.ROTE.Trim();
                } while (rR != null && rR.ROTE.Trim() == "00");
            }
            else if (rR != null)
                RoteCode = rR.ROTE.Trim();

            return RoteCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc">dcAttDataContext</param>
        public static void dcSubmitChanges(dcHrDataContext dc)
        {
            try
            {
                dc.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in dc.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);
                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }
                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                dc.SubmitChanges();
            }
        }

        public int TransCardPool(TransCardCondition oCond)
        {
            int iPass = 0;

            this.Report(5, "取得資料中...");

            TransCardVdb Vdb = new TransCardVdb();
            Vdb.TransCardCond = oCond;

            var lsNobr = (from c in dcHr.ATTEND
                          where c.NOBR.Trim().CompareTo(oCond.sNobrB) >= 0
                          && c.NOBR.Trim().CompareTo(oCond.sNobrE) <= 0
                          && c.ADATE.Date >= oCond.dDateB.Date
                          && c.ADATE.Date <= oCond.dDateE.Date
                          && (from b in dcHr.BASETTS
                              join d in dcHr.DEPT
                              on b.DEPT equals d.D_NO
                              where b.NOBR.Trim() == c.NOBR.Trim()
                              && oCond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                              && d.D_NO_DISP.Trim().CompareTo(oCond.sDeptE) <= 0
                              select b).Any()
                          && dcHr.GetFilterByNobr(c.NOBR.Trim(), oCond.sUserID, oCond.sComp, oCond.bAdmin).Value
                          orderby c.NOBR
                          group c by c.NOBR into d
                          select d.Key).ToList();

            //先刪除出勤刷卡資料
            if (oCond.bAttCard)
            {
                string delATTCARD = "Delete From ATTCARD" +
                    " Where NOBR Between {0} And {1}" +
                    " And ADATE Between {2} And {3}" +
                    " And Exists (Select * From BASETTS Inner Join DEPT" +
                    " On BASETTS.DEPT = DEPT.D_NO" +
                      " Where BASETTS.NOBR = ATTCARD.NOBR And DEPT.D_NO_DISP Between {4} And {5})" +
                    " And NOMODY = 0" +
                    " And dbo.GetFilterByNobr(NOBR , {6} , {7} , {8}) = 1";

                dcHr.ExecuteCommand(delATTCARD, oCond.sNobrB, oCond.sNobrE, oCond.dDateB, oCond.dDateE, oCond.sDeptB, oCond.sDeptE, oCond.sUserID, oCond.sComp, oCond.bAdmin);
            }

            Vdb.BaseData = GetBaseByNobr(oCond);
            Vdb.AbsData = GetAbs(oCond);
            Vdb.AttCardData = GetAttCard(oCond);
            Vdb.CardData = GetCard(oCond);
            Vdb.OtData = GetOt(oCond);
            Vdb.RoteData = GetRote(null);

            int _ThreadCount = oCond.ThreadCount;
            int _ThreadAvg = lsNobr.Count / _ThreadCount;
            TransCardPools tcp;

            this.Report(30, "判斷異常中...");

            Bll.Tools.ThreadPools stp = new Bll.Tools.ThreadPools(_ThreadCount, System.Threading.ThreadPriority.BelowNormal);
            for (int count = 0; count < lsNobr.Count; count++)
            {
                this.Report(50, "判斷異常中..." + lsNobr[count]);

                tcp = new TransCardPools(dcHr.Connection, null, Vdb, oCond, new List<string>(), lsNobr[count], iPass);

                stp.QueueUserWorkItem(new WaitCallback(tcp.TransCardThreadPoolCallback), string.Format("STP1[{0}]", count));
                Thread.Sleep(new Random().Next(500));
            }

            this.Report(70, "資料批次處理中(這裡要很久)...");
            stp.EndPool();

            this.Report(100, "寫入完成！");

            return iPass;
        }

        public class TransCardPools
        {
            private dcHrDataContext dcHr;
            private Bll.Att.TransCard oTransCard;

            private ManualResetEvent doneEvent;
            private TransCardVdb Vdb;
            private TransCardCondition oCond;
            private List<string> lsNobr;
            private string sNobr;
            private int iPass;

            public TransCardPools(IDbConnection conn, ManualResetEvent _doneEvent, TransCardVdb _Vdb, TransCardCondition _oCond, List<string> _lsNobr, string _sNobr, int _iPass)
            {
                dcHr = new dcHrDataContext(conn.ConnectionString);
                oTransCard = new Bll.Att.TransCard();

                doneEvent = _doneEvent;
                Vdb = _Vdb;
                oCond = _oCond;
                lsNobr = _lsNobr;
                sNobr = _sNobr;
                iPass = _iPass;
            }

            public void TransCardThreadPoolCallback(object obj)
            {
                //ManualResetEvent mre = (ManualResetEvent)obj;

                var rsATTEND = (from c in dcHr.ATTEND
                                where lsNobr.Contains(c.NOBR)
                                || c.NOBR.Trim() == sNobr
                                && c.ADATE.Date >= oCond.dDateB.AddDays(-2).Date
                                && c.ADATE.Date <= oCond.dDateE.AddDays(10).Date
                                orderby c.NOBR, c.ADATE
                                select c).ToList();

                //加一個月的主要原因，是因為當遇到最後一天是假日時，可以一直向後尋找，會影響效能

                int i = 0;

                #region
                DateTime Date, DateTimeB, DateTimeE;
                Date = DateTime.Now.Date;
                string RoteCode;
                foreach (var rATTEND in rsATTEND)
                {
                    i += 1;

                    //取得需要轉的出勤資料 沒有出勤資料就不用轉
                    if (oCond.dDateB <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE)
                    {
                        //取得員工設定檔
                        var rBaseData = Vdb.BaseData.Where(p => p.Nobr.Trim() == rATTEND.NOBR.Trim()
                            && p.DateA <= rATTEND.ADATE.Date
                            && rATTEND.ADATE.Date <= p.DateD).FirstOrDefault();
                        if (rBaseData != null)
                        {
                            RoteCode = rATTEND.ROTE.Trim();

                            //如果是假日班就置換班別 先從加班資料尋找 再按照客戶規則找預設班別
                            if (RoteCode == "00")
                            {
                                var rOt = Vdb.OtData.Where(p => p.Nobr == rATTEND.NOBR.Trim()
                                    && p.Date == rATTEND.ADATE.Date).FirstOrDefault();

                                if (rOt != null)
                                    RoteCode = rOt.RoteCode;
                                else
                                    RoteCode = GetRoteCode(rsATTEND, rATTEND.NOBR.Trim(), rATTEND.ADATE.Date, RoteCode);
                            }

                            List<AttCardTable> rsAttCardDataDay = new List<AttCardTable>();

                            //一定要非假日班別能轉換 而且班別一定要存在
                            RoteTable rRoteDataDay = Vdb.RoteData.Where(p => p.RoteCode == RoteCode).FirstOrDefault();
                            if (rRoteDataDay != null && rRoteDataDay.RoteCode != "00")
                            {
                                //取得正確的刷卡資料
                                DateTimeB = rATTEND.ADATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRoteDataDay.OffLastTime));  //今天的最早上班時間
                                DateTimeE = DateTimeB.AddDays(1);   //今天的最晚下班時間

                                List<AttCardTable> lsAttCard = new List<AttCardTable>();

                                //需要重新拼上下班時間
                                if (oCond.bAttCard)
                                {
                                    //將刷卡時間丟入物件集合 準備涵數使用
                                    List<CardTable> rsCardDataDay = Vdb.CardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && DateTimeB <= p.CardDateTime && p.CardDateTime <= DateTimeE).ToList();

                                    //判斷當日是否不用轉換                             
                                    lsAttCard = Vdb.AttCardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && p.Date == rATTEND.ADATE.Date).ToList();

                                    //至少要有一筆刷卡資料
                                    if (!lsAttCard.Any() && rsCardDataDay.Any())
                                    {
                                        var rsAttCardData = oTransCard.AttCardByOneDay(rsCardDataDay, rATTEND.ADATE.Date, oCond.bEzAttCard);

                                        //有可能會有一天多筆資料
                                        foreach (var rAttCardDataDay in rsAttCardData)
                                        {
                                            //新增到ATTCARD
                                            var rATTACRD = new ATTCARD();

                                            //不要的資料
                                            //Bll.Tools.DefaultData.SetRowDefaultValue(rATTACRD);
                                            rATTACRD.CODE = "";
                                            rATTACRD.KEY_DATE = DateTime.Now;
                                            rATTACRD.DD1 = "";
                                            rATTACRD.DD2 = "";
                                            rATTACRD.NOMODY = false;

                                            //要的資料
                                            rATTACRD.NOBR = rATTEND.NOBR.Trim();
                                            rATTACRD.ADATE = rATTEND.ADATE.Date;
                                            rATTACRD.SER = 1;
                                            rATTACRD.KEY_MAN = oCond.sKeyMan;
                                            rATTACRD.T1 = rAttCardDataDay.OnCardTime48;
                                            rATTACRD.T2 = rAttCardDataDay.OffCardTime48;
                                            rATTACRD.LOST1 = rAttCardDataDay.OnLos;
                                            rATTACRD.LOST2 = rAttCardDataDay.OffLos;
                                            rATTACRD.TT1 = rAttCardDataDay.OnCardTime24;
                                            rATTACRD.TT2 = rAttCardDataDay.OffCardTime24;
                                            dcHr.ATTCARD.InsertOnSubmit(rATTACRD);

                                            //將資料加入到vdb
                                            lsAttCard.Add(rAttCardDataDay);
                                        }   //end foreach by attcard
                                    }   //end if by 至少要有一筆刷卡資料
                                }   //end if by 需要重新拼上下班時間

                                //需要判斷異常
                                if (oCond.bAttEnd)
                                {
                                    rATTEND.LATE_MINS = 0;  //遲到
                                    rATTEND.E_MINS = 0; //早退
                                    rATTEND.ABS = false;    //曠職
                                    rATTEND.FORGET = 0; //忘刷

                                    //一定要有刷卡資料 才需要判斷
                                    if (rBaseData.NeedCard && rATTEND.ROTE.Trim() != "00")
                                    {
                                        //放入請假資料
                                        List<AbsTable> rsAbs = Vdb.AbsData.Where(p => p.Nobr.Trim() == rATTEND.NOBR.Trim() && p.Date.Date == rATTEND.ADATE.Date).ToList();
                                        var rAttEndByOneDay = oTransCard.AttEndByOneDay(lsAttCard, rRoteDataDay, rsAbs, rATTEND.ADATE.Date);

                                        rATTEND.LATE_MINS = rAttEndByOneDay.LatesMin;
                                        rATTEND.E_MINS = rAttEndByOneDay.EarlierMin;
                                        rATTEND.ABS = rAttEndByOneDay.Abs;
                                        rATTEND.FORGET = rAttEndByOneDay.Card;
                                    }

                                    rATTEND.KEY_MAN = oCond.sKeyMan;
                                    rATTEND.KEY_DATE = DateTime.Now;
                                }
                            }   //end if by 一定要非假日班別能轉換 而且班別一定要存在
                        }   // end if by 取得員工設定檔
                    }   //end if by 取得需要轉的出勤資料 沒有出勤資料就不用轉
                }   //end foreach
                #endregion

                dcHr.SubmitChanges();
                iPass += i;
                //doneEvent.Set();
                //return iPass;
            }

            /// <summary>
            /// 尋找客制班別
            /// </summary>
            /// <param name="rsATTEND">ATTEND</param>
            /// <param name="Nobr">工號</param>
            /// <param name="Date">日期</param>
            /// <param name="RoteCode">班別</param>
            /// <returns>string</returns>
            private string GetRoteCode(List<ATTEND> rsATTEND, string Nobr, DateTime Date, string RoteCode = "00")
            {
                //先往前抓，如果前一天是00再往後抓
                var rR = rsATTEND.Where(p => p.NOBR.Trim() == Nobr && p.ADATE.Date == Date.Date.AddDays(-1)).FirstOrDefault();
                if (rR == null || rR.ROTE.Trim() == "00")
                {
                    int i = 1;
                    do
                    {
                        rR = rsATTEND.Where(p => p.NOBR.Trim() == Nobr && p.ADATE.Date == Date.Date.AddDays(i)).FirstOrDefault();
                        i++;
                        if (rR != null)
                            RoteCode = rR.ROTE.Trim();
                    } while (rR != null && rR.ROTE.Trim() == "00");
                }
                else if (rR != null)
                    RoteCode = rR.ROTE.Trim();

                return RoteCode;
            }
        }
    }
}