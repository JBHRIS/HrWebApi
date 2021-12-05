using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using Bll.Att.Vdb;
using JBModule.Data.Linq;
using JBTools.Extend;

namespace Dal.Dao.Att
{
    /// <summary>
    /// TransCardDao
    /// </summary>
    public class TransCardDao_NS : JBModule.Message.ReportStatus
    {
        private HrDBDataContext dcHr;

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public TransCardDao_NS()
        {
            dcHr = new HrDBDataContext();
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public TransCardDao_NS(IDbConnection conn = null)
        {
                dcHr = new HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="ConnectionString"></param>
        public TransCardDao_NS(string ConnectionString = null)
        {
                dcHr = new HrDBDataContext(ConnectionString);
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
                       join d in dcHr.DEPT on c.DEPT equals d.D_NO
                       join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on c.NOBR equals x.NOBR
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && c.ADATE.Date <= Cond.dDateE && Cond.dDateB <= c.DDATE.Value.Date
                       && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0
                       && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                       && arrTtscode.Contains(c.TTSCODE.Trim())
                       //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(c.SALADR)
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
                         select c;

            if (arrRoteCode != null)
                iqRote = from c in dcHr.ROTE
                         where arrRoteCode.Contains(c.ROTE1.Trim())
                         select c;

            var Vdb = (from c in iqRote
                       select new RoteTable()
                       {
                           RoteCode = c.ROTE1.Trim(),
                           OnTime = c.ON_TIME.Trim(),
                           OffTime = c.ATT_END.Trim().Length > 0 ? c.ATT_END.Trim() : c.OFF_TIME.Trim(),
                           OffLastTime = c.OFFTIME2.Trim(),
                           LatesMin = Convert.ToInt32(c.ALLLATES),
                           ElasticityMin = Convert.ToInt32(c.ALLLATES1),
                           WorkHour = c.WK_HRS,
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
            var Vdb1 = (from a in dcHr.ABS
                        join b in dcHr.BASETTS on a.NOBR equals b.NOBR
                        join d in dcHr.DEPT on b.DEPT equals d.D_NO
                        join h in dcHr.HCODE on a.H_CODE.Trim() equals h.H_CODE.Trim()
                        join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on a.NOBR equals x.NOBR
                        where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                        && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                        && Cond.dDateB <= Convert.ToDateTime(a.BDATE.Date).Date
                        && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE
                        && a.BTIME.Trim().Length == 4
                        && a.ETIME.Trim().Length == 4
                        && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                        && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                        && h.FLAG == "-"
                        //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
                        select new AbsTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Date = a.BDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim()
                        }).ToList();

            var Vdb2 = (from a in dcHr.ABS1
                        join b in dcHr.BASETTS on a.NOBR equals b.NOBR
                        join d in dcHr.DEPT on b.DEPT equals d.D_NO
                        join h in dcHr.HCODE on a.H_CODE.Trim() equals h.H_CODE.Trim()
                        join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on a.NOBR equals x.NOBR
                        where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                        && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                        && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE
                        && Cond.dDateB <= a.BDATE.Date
                        && a.BTIME.Trim().Length == 4
                        && a.ETIME.Trim().Length == 4
                        && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                        && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                        //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
                        //&& h.FLAG == "-"
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
                       join b in dcHr.BASETTS on a.NOBR equals b.NOBR
                       join d in dcHr.DEPT on b.DEPT equals d.D_NO
                       join t in dcHr.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { t.NOBR, t.ADATE.Date }
                       join r in dcHr.ROTE on t.ROTE equals r.ROTE1
                       join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on a.NOBR equals x.NOBR
                       where Cond.sNobrB.CompareTo(a.NOBR.Trim()) <= 0
                       && a.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB.AddDays(-1) <= Convert.ToDateTime(a.BDATE.Date).Date
                       && Convert.ToDateTime(a.BDATE.Date).Date <= Cond.dDateE.AddDays(1)
                       //只有假日才需要被取出來
                       && r.ON_TIME.Trim().Length == 0 && r.OFF_TIME.Trim().Length == 0 && r.WK_HRS == 0
                       && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                       && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                       //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       select new OtTable()
                       {
                           Nobr = a.NOBR.Trim(),
                           Date = a.BDATE.Date,
                           RoteCode = a.OT_ROTE.Trim()
                       }).ToList(); ;

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
                       join b in dcHr.BASETTS on c.NOBR equals b.NOBR
                       join d in dcHr.DEPT on b.DEPT equals d.D_NO
                       join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on c.NOBR equals x.NOBR
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB.AddDays(-1) <= Convert.ToDateTime(c.ADATE.Date).Date
                       && Convert.ToDateTime(c.ADATE.Date).Date <= Cond.dDateE.AddDays(1)   //刷卡資料有可能是到隔天 所以要再加一天
                       && c.ONTIME.Trim().Length == 4
                       && c.ADATE >= b.ADATE && c.ADATE <= b.DDATE.Value
                       && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                       && !c.NOT_TRAN
                       //&& c.CODE != "9"
                       //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       select new CardTable()
                       {
                           Nobr = c.NOBR.Trim(),
                           CardDate = c.ADATE.Date,
                           CardTime24 = c.ONTIME.Trim(),
                           Los = c.LOS,
                           Reason = c.REASON ?? "",
                       }).ToList();
            var rs = (from c in dcHr.CARDLOSD
                      where c.ATT
                      select c.CODE).ToList();
            Vdb = Vdb.Select(c => new CardTable()
            {
                Nobr = c.Nobr,
                CardDate = c.CardDate,
                CardTime24 = c.CardTime24,
                CardDateTime = c.CardDate.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(c.CardTime24)),
                Los = rs.Contains(c.Reason),
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
                       join b in dcHr.BASETTS on c.NOBR equals b.NOBR
                       join d in dcHr.DEPT on b.DEPT equals d.D_NO
                       join x in dcHr.WriteRuleTable(Cond.sUserID, Cond.sComp, Cond.bAdmin) on c.NOBR equals x.NOBR
                       where Cond.sNobrB.CompareTo(c.NOBR.Trim()) <= 0
                       && c.NOBR.Trim().CompareTo(Cond.sNobrE) <= 0
                       && Cond.dDateB.AddDays(-1) <= Convert.ToDateTime(c.ADATE.Date).Date
                       && Convert.ToDateTime(c.ADATE.Date).Date <= Cond.dDateE.AddDays(1)
                       && c.ADATE >= b.ADATE && c.ADATE <= b.DDATE.Value
                       && Cond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(Cond.sDeptE) <= 0
                       //&& dcHr.UserReadDataGroupList(Cond.sUserID, Cond.sComp, Cond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
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
        public int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard, string sUserID, string sComp, bool bAdmin, int ThreadCount = 2, bool PassOtRote = false)
        {
            TransCardCondition oCond = new TransCardCondition();
            oCond.sNobrB = sNobrB;
            oCond.sNobrE = sNobrE;
            oCond.sDeptB = sDeptB;
            oCond.sDeptE = sDeptE;
            oCond.dDateB = dDateB;
            oCond.dDateE = dDateE;
            oCond.sRote = "0";
            oCond.sKeyMan = sKeyMan;
            oCond.bAttCard = bAttCard;
            oCond.bAttEnd = bAttCard;
            oCond.bEzAttCard = bEzAttCard;
            oCond.sUserID = sUserID;
            oCond.sComp = sComp;
            oCond.bAdmin = bAdmin;
            oCond.ThreadCount = ThreadCount;
            oCond.PassOtRote = PassOtRote;

            return TransCardPool(oCond);
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
        /// <param name="sRote">判斷班別</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bAttCard">轉換刷卡時間</param>
        /// <param name="bAttEnd">判斷異常</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)</param>
        /// <param name="sUserID">登入者工號</param>
        /// <param name="sComp">公司別</param>
        /// <param name="bAdmin">是否管理權限</param>
        /// <param name="ThreadCount">啟用多少個執行緒(預設是2)</param>
        /// <returns>int</returns>
        public int TransCard(string sNobrB, string sNobrE, string sDeptB, string sDeptE, DateTime dDateB, DateTime dDateE, string sRote, string sKeyMan, bool bAttCard, bool bAttEnd, bool bEzAttCard, string sUserID, string sComp, bool bAdmin, int ThreadCount = 2)
        {
            TransCardCondition oCond = new TransCardCondition();
            oCond.sNobrB = sNobrB;
            oCond.sNobrE = sNobrE;
            oCond.sDeptB = sDeptB;
            oCond.sDeptE = sDeptE;
            oCond.dDateB = dDateB;
            oCond.dDateE = dDateE;
            oCond.sRote = sRote;
            oCond.sKeyMan = sKeyMan;
            oCond.bAttCard = bAttCard;
            oCond.bAttEnd = bAttEnd;
            oCond.bEzAttCard = bEzAttCard;
            oCond.sUserID = sUserID;
            oCond.sComp = sComp;
            oCond.bAdmin = bAdmin;
            oCond.ThreadCount = ThreadCount;

            return TransCardPool(oCond);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc">dcAttDataContext</param>
        public static void dcSubmitChanges(JBModule.Data.Linq.HrDBDataContext dc)
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
            var lsNobr = (from c in dcHr.ATTEND
                          join b in dcHr.BASETTS on c.NOBR equals b.NOBR
                          join d in dcHr.DEPT on b.DEPT equals d.D_NO
                          join x in dcHr.WriteRuleTable(oCond.sUserID, oCond.sComp, oCond.bAdmin) on c.NOBR equals x.NOBR
                          where c.NOBR.Trim().CompareTo(oCond.sNobrB) >= 0 && c.NOBR.Trim().CompareTo(oCond.sNobrE) <= 0
                          && c.ADATE.Date >= oCond.dDateB.Date && c.ADATE.Date <= oCond.dDateE.Date
                          && c.ADATE >= b.ADATE && c.ADATE <= b.DDATE.Value
                          && oCond.sDeptB.CompareTo(d.D_NO_DISP.Trim()) <= 0 && d.D_NO_DISP.Trim().CompareTo(oCond.sDeptE) <= 0
                          //&& dcHr.UserReadDataGroupList(oCond.sUserID, oCond.sComp, oCond.bAdmin).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          orderby c.NOBR
                          group c by c.NOBR into d
                          select d.Key).ToList();

            TransCardVdb Vdb = new TransCardVdb();
            Vdb.TransCardCond = oCond;
            Vdb.BaseData = GetBaseByNobr(oCond);
            Vdb.AbsData = GetAbs(oCond);
            Vdb.CardData = GetCard(oCond);
            Vdb.OtData = GetOt(oCond);
            Vdb.RoteData = GetRote(null);

            int _ThreadCount = oCond.ThreadCount;
            int _ThreadAvg = lsNobr.Count / _ThreadCount;
            TransCardPools tcp;
            this.Report(30, "判斷異常中...");

            Bll.Tools.ThreadPools stp = new Bll.Tools.ThreadPools(_ThreadCount, System.Threading.ThreadPriority.BelowNormal);
            foreach (var item in lsNobr.Split(300))
            {
                //for (int count = 0; count < lsNobr.Count; count++)
                {
                    this.Report(50, "判斷異常中...");// + lsNobr[count]);

                    tcp = new TransCardPools(dcHr.Connection, null, Vdb, oCond, item, string.Empty, iPass);// new List<string>(), lsNobr[count], iPass);
                    stp.QueueUserWorkItem(new WaitCallback(tcp.TransCardThreadPoolCallback));//, string.Format("STP1[{0}]", count));
                    //Thread.Sleep(new Random().Next(500));
                    Thread.Sleep(0);
                } 
            }

            this.Report(70, "資料批次處理中(這裡要很久)...");
            stp.EndPool();

            this.Report(100, "寫入完成！");

            return iPass;
        }

        public class TransCardPools
        {
            private Bll.Att.TransCard oTransCard;

            private ManualResetEvent doneEvent;
            private TransCardVdb Vdb;
            private TransCardCondition oCond;
            private List<string> lsNobr;
            private string sNobr;
            private int iPass;
            private IDbConnection ConnectionString;
            private bool PassOtRote = false;
            public TransCardPools(IDbConnection conn, ManualResetEvent _doneEvent, TransCardVdb _Vdb, TransCardCondition _oCond, List<string> _lsNobr, string _sNobr, int _iPass)
            {
                oTransCard = new Bll.Att.TransCard();

                doneEvent = _doneEvent;
                Vdb = _Vdb;
                oCond = _oCond;
                lsNobr = _lsNobr;
                sNobr = _sNobr;
                iPass = _iPass;
                ConnectionString = conn;
                PassOtRote = _oCond.PassOtRote;
            }

            public void TransCardThreadPoolCallback(object obj)
            {
                //ManualResetEvent mre = (ManualResetEvent)obj;
                HrDBDataContext dcHr = new HrDBDataContext(ConnectionString.ConnectionString);

                //20140213這邊改分為抓單獨一個工號，或是一段工號，因之前兩個一起做，使用or，懷疑此方式會讓他Timeout
                //修改此方式測試看看
                List<ATTEND> rsATTEND = new List<ATTEND>();
                List<ATTCARD> rsATTCARD = new List<ATTCARD>();
                List<CardTable> rsCardData = new List<CardTable>();
                if (lsNobr.Count == 0)
                {
                    rsATTEND.AddRange((from c in dcHr.ATTEND
                                       join r in dcHr.ROTE on c.ROTE equals r.ROTE1
                                       where c.NOBR.Trim() == sNobr
                                       && c.ADATE.Date >= oCond.dDateB.AddDays(-1).Date
                                       && c.ADATE.Date <= oCond.dDateE.AddDays(1).Date
                                       //orderby c.ROTE descending, c.NOBR, c.ADATE
                                       //orderby c.ADATE, r.WK_HRS descending
                                       orderby r.WK_HRS descending, c.ROTE, c.ADATE
                                       select c).ToList());

                    rsATTCARD.AddRange((from c in dcHr.ATTCARD
                                        where c.NOBR.Trim() == sNobr
                                        && c.ADATE.Date >= oCond.dDateB.Date.AddDays(-1)
                                        && c.ADATE.Date <= oCond.dDateE.Date.AddDays(1)
                                        //orderby c.NOBR, c.ADATE
                                        orderby c.ADATE descending
                                        select c).ToList());

                    rsCardData.AddRange((from c in Vdb.CardData
                                         where c.Nobr == sNobr
                                         && c.CardDate >= oCond.dDateB.AddDays(-1).Date
                                         && c.CardDate <= oCond.dDateE.AddDays(1).Date
                                         select c).ToList());
                }
                else
                {
                    rsATTEND.AddRange((from c in dcHr.ATTEND
                                       join r in dcHr.ROTE on c.ROTE equals r.ROTE1
                                       where lsNobr.Contains(c.NOBR)
                                       && c.ADATE.Date >= oCond.dDateB.AddDays(-1).Date
                                       && c.ADATE.Date <= oCond.dDateE.AddDays(1).Date
                                       //orderby c.ROTE descending, c.NOBR, c.ADATE
                                       //orderby c.ADATE, r.WK_HRS descending
                                       orderby r.WK_HRS descending, c.ROTE, c.ADATE
                                       select c).ToList());

                    rsATTCARD.AddRange((from c in dcHr.ATTCARD
                                        where lsNobr.Contains(c.NOBR)
                                        && c.ADATE.Date >= oCond.dDateB.Date.AddDays(-1)
                                        && c.ADATE.Date <= oCond.dDateE.Date.AddDays(1)
                                        //orderby c.NOBR, c.ADATE
                                        orderby c.ADATE descending
                                        select c).ToList());

                    rsCardData.AddRange((from c in Vdb.CardData
                                         where lsNobr.Contains(c.Nobr)
                                         && c.CardDate >= oCond.dDateB.AddDays(-1).Date
                                         && c.CardDate <= oCond.dDateE.AddDays(1).Date
                                         select c).ToList());
                }
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
                    if (oCond.dDateB.AddDays(-1) <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE.AddDays(1))
                    {
                        //取得員工設定檔
                        var rBaseData = Vdb.BaseData.Where(p => p.Nobr.Trim() == rATTEND.NOBR.Trim()
                            && p.DateA <= rATTEND.ADATE.Date
                            && rATTEND.ADATE.Date <= p.DateD).FirstOrDefault();
                        if (rBaseData != null)
                        {
                            if (oCond.sRote == "0" || oCond.sRote.Trim().Length == 0)
                            {
                                RoteCode = rATTEND.ROTE_H.Trim();

                                var rRote = Vdb.RoteData.Where(p => p.RoteCode == RoteCode).FirstOrDefault();

                                //如果是假日班就置換班別 先從加班資料尋找 再按照客戶規則找預設班別
                                if (!PassOtRote && rRote != null && IsHoliDay(Vdb.RoteData, RoteCode))
                                {
                                    var rOt = Vdb.OtData.Where(p => p.Nobr == rATTEND.NOBR.Trim()
                                        && p.Date == rATTEND.ADATE.Date).FirstOrDefault();

                                    if (rOt != null)
                                    {
                                        if (IsHoliDay(Vdb.RoteData, rOt.RoteCode))
                                            RoteCode = rATTEND.ROTE_H;
                                        else
                                            RoteCode = rOt.RoteCode;
                                    }
                                    else
                                    {
                                        if (IsHoliDay(Vdb.RoteData, rATTEND.ROTE_H))
                                            RoteCode = GetRoteCode(rsATTEND, Vdb.RoteData, rATTEND.NOBR.Trim(), rATTEND.ADATE.Date, RoteCode);
                                        else
                                            RoteCode = rATTEND.ROTE_H;
                                    }
                                }
                            }
                            else
                                RoteCode = oCond.sRote;

                            List<AttCardTable> rsAttCardDataDay = new List<AttCardTable>();

                            //一定要非假日班別能轉換 而且班別一定要存在
                            RoteTable rRoteDataDay = Vdb.RoteData.Where(p => p.RoteCode == RoteCode).FirstOrDefault();
                            if (rRoteDataDay != null && !IsHoliDay(Vdb.RoteData, rRoteDataDay.RoteCode))
                            {
                                //今天上班時間 如果比轉換時間還要大 此資料不需判斷
                                DateTime DateOnTime = rATTEND.ADATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRoteDataDay.OnTime));
                                if (DateTime.Now < DateOnTime)
                                    continue;

                                //放入請假資料
                                List<AbsTable> rsAbs = Vdb.AbsData.Where(p => p.Nobr.Trim() == rATTEND.NOBR.Trim() && p.Date.Date == rATTEND.ADATE.Date).ToList();

                                //取得正確的刷卡資料
                                DateTimeB = rATTEND.ADATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRoteDataDay.OffLastTime));  //今天的最早上班時間
                                DateTimeE = DateTimeB.AddDays(1);   //今天的最晚下班時間

                                List<AttCardTable> lsAttCard = new List<AttCardTable>();

                                //取得當天的出勤上下班時間
                                //lsAttCard = Vdb.AttCardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && p.Date == rATTEND.ADATE.Date).ToList();
                                var rsATTCARD_Day = rsATTCARD.Where(p => p.NOBR.Trim() == rATTEND.NOBR.Trim() && p.ADATE.Date == rATTEND.ADATE.Date).ToList();
                                lsAttCard = rsATTCARD_Day.Select(c => new AttCardTable
                                {
                                    Nobr = c.NOBR.Trim(),
                                    Date = c.ADATE.Date,
                                    NoTrans = c.NOMODY,
                                    OnCardTime48 = c.T1.Trim(),
                                    OffCardTime48 = c.T2.Trim(),
                                    OnCardTime24 = c.TT1.Trim(),
                                    OffCardTime24 = c.TT2.Trim(),
                                    OnLos = c.LOST1,
                                    OffLos = c.LOST2,
                                }).ToList();

                                //需要重新拼上下班時間
                                if (oCond.bAttCard)
                                {
                                    //完全沒有資料 或是 沒有任何一筆勾不轉換 ※只要有一筆勾不轉換 全天就不轉換了 這邊可能會有爭議
                                    //if (lsAttCard.Count == 0 || !lsAttCard.Where(p => p.NoTrans).Any())
                                    if (true)
                                    {
                                        //lsAttCard = new List<AttCardTable>(); //重新初始

                                        //將刷卡時間丟入物件集合 準備涵數使用
                                        //List<CardTable> rsCardDataDay = Vdb.CardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && DateTimeB <= p.CardDateTime && p.CardDateTime <= DateTimeE).ToList();
                                        List<CardTable> rsCardDataDay = rsCardData.Where(p => p.Nobr == rATTEND.NOBR.Trim() && DateTimeB <= p.CardDateTime && p.CardDateTime <= DateTimeE).ToList();

                                        //創出另一個集合，等下要把這些資料刪除
                                        List<CardTable> rsCardDay = new List<CardTable>();
                                        foreach (var rCardDataDay in rsCardDataDay)
                                            rsCardDay.Add(rCardDataDay);

                                        //至少要有一筆刷卡資料
                                        if (rsCardDataDay.Any())
                                        {
                                            var rsAttCardData = oTransCard.AttCardByOneDay(rsCardDataDay, rATTEND.ADATE.Date, oCond.bEzAttCard);

                                            //刪除Vdb.CardData曾經使用過的資料
                                            foreach (var rCardDay in rsCardDay)
                                                if (rsCardData.Contains(rCardDay))
                                                    rsCardData.Remove(rCardDay);

                                            DateTime dTempDateTime = DateTime.Now;

                                            if ((lsAttCard.Count == 0 || !lsAttCard.Where(p => p.NoTrans).Any()) && oCond.dDateB <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE)
                                            {
                                                lsAttCard = new List<AttCardTable>(); //重新初始

                                                //有可能會有一天多筆資料
                                                foreach (var rAttCardDataDay in rsAttCardData)
                                                {
                                                    //新增到ATTCARD
                                                    var rATTACRD = new ATTCARD();
                                                    dcHr.ATTCARD.InsertOnSubmit(rATTACRD);

                                                    //不要的資料
                                                    rATTACRD.CODE = "";
                                                    rATTACRD.KEY_DATE = dTempDateTime;  //這個是關鍵
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

                                                    //將資料加入到vdb
                                                    lsAttCard.Add(rAttCardDataDay);
                                                }   //end foreach by attcard
                                            }
                                        }   //end if by 至少要有一筆刷卡資料

                                        //一律刪除 因為T1是主鍵
                                        if ((rsATTCARD_Day.Count > 0 && !rsATTCARD_Day.Where(p => p.NOMODY).Any()) && oCond.dDateB <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE)
                                            dcHr.ATTCARD.DeleteAllOnSubmit(rsATTCARD_Day);
                                    }
                                }   //end if by 需要重新拼上下班時間

                                //需要判斷異常
                                if (!rATTEND.CANT_ADJ && oCond.bAttEnd && oCond.dDateB <= rATTEND.ADATE.Date && rATTEND.ADATE.Date <= oCond.dDateE)
                                {
                                    rATTEND.LATE_MINS = 0;  //遲到
                                    rATTEND.E_MINS = 0; //早退
                                    rATTEND.ABS = false;    //曠職
                                    rATTEND.FORGET = 0; //忘刷
                                    rATTEND.EARLY_MINS = 0; //提早來
                                    rATTEND.DELAY_MINS = 0; //延後走

                                    //一定要有刷卡資料 才需要判斷
                                    if (rBaseData.NeedCard && !IsHoliDay(Vdb.RoteData, rATTEND.ROTE.Trim()))
                                    {
                                        var rAttEndByOneDay = oTransCard.AttEndByOneDay(lsAttCard, rRoteDataDay, rsAbs, rATTEND.ADATE.Date);
                                        //var rAttEndByOneDay = oTransCard.AttEndByOneDayByMultiRes(lsAttCard, rRoteDataDay, rsAbs, rATTEND.ADATE.Date);
                                        rATTEND.LATE_MINS = rAttEndByOneDay.LatesMin;
                                        rATTEND.E_MINS = rAttEndByOneDay.EarlierMin;
                                        rATTEND.ABS = rAttEndByOneDay.Abs;
                                        rATTEND.FORGET = rAttEndByOneDay.Card;

                                        rATTEND.EARLY_MINS = rAttEndByOneDay.EarlyMin;
                                        rATTEND.DELAY_MINS = rAttEndByOneDay.DelayMin;

                                        //不計算遲到早退
                                        if (rBaseData.NoTer)
                                        {
                                            rATTEND.LATE_MINS = 0;
                                            rATTEND.E_MINS = 0;
                                        }

                                        //大於今天日期不判早退
                                        if (rATTEND.ADATE.Date >= DateTime.Now.Date)
                                            rATTEND.E_MINS = 0;

                                        rATTEND.LATE_MINS = rBaseData.NeedOnCard ? rATTEND.LATE_MINS : 0;
                                        rATTEND.E_MINS = rBaseData.NeedOffCard ? rATTEND.E_MINS : 0;
                                    }
                                    else if (IsHoliDay(Vdb.RoteData, rATTEND.ROTE.Trim()) && lsAttCard.Count > 0)   //假日也要計算總分鐘數 20140106 家瑜
                                    {
                                        var rAttCard = lsAttCard[0];
                                        if (rAttCard.OnCardTime48.Trim().Length > 0 && rAttCard.OffCardTime48.Trim().Length > 0)
                                        {
                                            int iRoteMin = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);
                                            int iCardMin = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                                            rATTEND.DELAY_MINS = iCardMin - iRoteMin;
                                        }
                                    }

                                    rATTEND.KEY_MAN = oCond.sKeyMan;
                                    rATTEND.KEY_DATE = DateTime.Now;
                                }
                            }   //end if by 一定要非假日班別能轉換 而且班別一定要存在
                        }   // end if by 取得員工設定檔
                    }   //end if by 取得需要轉的出勤資料 沒有出勤資料就不用轉
                }   //end foreach
                #endregion

                try
                {
                    dcSubmitChanges(dcHr);
                    iPass += i;
                }
                catch { }

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
            private string GetRoteCode(List<ATTEND> rsATTEND, List<RoteTable> rsRote, string Nobr, DateTime Date, string RoteCode)
            {
                //抓非假日且日期遞增排序的第一筆班別
                var rs = rsATTEND.Where(p => p.NOBR.Trim() == Nobr && p.ADATE.Date >= Date.Date.AddDays(-1) && !IsHoliDay(rsRote, p.ROTE.Trim()));
                if (rs.Any())
                    RoteCode = rs.OrderBy(p => p.ADATE).First().ROTE.Trim();

                return RoteCode;
            }

            /// <summary>
            /// 判斷是否為假日班 True = 是假日
            /// </summary>
            /// <param name="rsRote"></param>
            /// <param name="RoteCode"></param>
            /// <returns>bool</returns>
            private bool IsHoliDay(List<RoteTable> rsRote, string RoteCode)
            {
                bool Vdb = false;
                var rRote = rsRote.Where(p => p.RoteCode == RoteCode).FirstOrDefault();

                if (rRote != null && rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0)
                    Vdb = true;

                return Vdb;
            }
        }
    }
}