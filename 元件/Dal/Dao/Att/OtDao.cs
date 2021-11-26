using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Att.Vdb;
using JBModule.Data.Linq;

namespace Dal.Dao.Att
{
    public class OtDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="conn"></param>
        public OtDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public OtDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 取得加班類別代碼
        /// </summary>
        /// <param name="sCode">代碼</param>
        /// <param name="bAllDisplay">是否全部顯示</param>
        /// <returns>List</returns>
        public List<OtTypeTable> GetOtType(string sCode = "", bool bAllDisplay = false)
        {
            var Vdb = (from c in dcHr.MTCODE
                       where c.CATEGORY == "OTTYPE"
                       && (c.CODE == sCode || sCode == "")
                       && bAllDisplay ? true : c.DISPLAY == true
                       select new OtTypeTable
                       {
                           Code = c.CODE,
                           Name = c.NAME,
                           Sort = c.SORT,
                           Display = c.DISPLAY,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得加班類別代碼
        /// </summary>
        /// <param name="bOtType">True = 加班 , False = 津貼</param>
        /// <returns>List</returns>
        public List<OtTypeTable> GetOtType(bool bOtType)
        {
            var Vdb = (from c in dcHr.OVERTIME_TYPE
                       select new OtTypeTable
                       {
                           Code = c.CODE,
                           Name = c.TYPE_NAME,
                           Display = c.IS_OT != null ? c.IS_OT.Value : false,
                       }).ToList();

            var Vdb1 = Vdb.Where(p => p.Display == bOtType).ToList();

            return Vdb1;
        }

        /// <summary>
        /// 刪除加班資料
        /// </summary>
        /// <param name="sProcessID">ProcessID</param>
        /// <returns>string</returns>
        public string DeleteOt(string sProcessID)
        {
            string Vdb = string.Empty;

            var rsOT = (from c in dcHr.OT
                        where c.SERNO.Trim() == sProcessID
                        select c).ToList();

            //if (Vdb.Any())
            if (rsOT.Any())
                Vdb = sProcessID;

            foreach (var rOT in rsOT)
            {
                //寫入銷加班資料記錄
                var rOTC = new OTC();
                rOTC.NOBR = rOT.NOBR.Trim();
                rOTC.BDATE = rOT.BDATE.Date;
                rOTC.BTIME = rOT.BTIME.Trim();
                rOTC.ETIME = rOT.ETIME.Trim();
                rOTC.TOT_HOURS = rOT.TOT_HOURS;
                rOTC.OT_HRS = rOT.OT_HRS;
                rOTC.REST_HRS = rOT.REST_HRS;
                rOTC.KEY_DATE = rOT.KEY_DATE;
                rOTC.KEY_MAN = rOT.KEY_MAN.Trim();
                rOTC.YYMM = rOT.YYMM.Trim();
                rOTC.NOTE = rOT.NOTE.Trim();
                rOTC.SERNO = rOT.SERNO.Trim();
                dcHr.OTC.InsertOnSubmit(rOTC);
            }

            //var rsABSD = (from c in dcHr.ABSD
            //              where c.ABSADD == sProcessID
            //              select c).ToList();

            //dcHr.ABSD.DeleteAllOnSubmit(rsABSD);

            dcHr.OT.DeleteAllOnSubmit(rsOT);
            dcHr.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 刪除加班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="sTimeB">結束日期</param>
        /// <param name="dDateE">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sType">加班類別</param>
        /// <returns>int</returns>
        public int DeleteOt(string sNobr, DateTime dDateB, string sTimeB, DateTime dDateE, string sTimeE, string sType)
        {
            int Vdb = 0;

            var rsOT = (from c in dcHr.OT
                        where c.NOBR.Trim() == sNobr
                        && dDateB <= c.BDATE.Date && c.BDATE.Date <= dDateE.Date
                        select c).ToList();

            DateTime dDateTimeA, dDateTimeD, dDateTimeB, dDateTimeE;

            dDateTimeA = dDateB.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));
            dDateTimeD = dDateE.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));

            List<OT> lsOT = new List<OT>();

            foreach (var rOT in rsOT)
            {
                dDateTimeB = rOT.BDATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rOT.BTIME.Trim()));
                dDateTimeE = rOT.BDATE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rOT.ETIME.Trim()));

                if (dDateTimeA <= dDateTimeB && dDateTimeE <= dDateTimeD)
                {
                    //寫入銷加班資料記錄
                    var rOTC = new OTC();
                    rOTC.NOBR = rOT.NOBR.Trim();
                    rOTC.BDATE = rOT.BDATE.Date;
                    rOTC.BTIME = rOT.BTIME.Trim();
                    rOTC.ETIME = rOT.ETIME.Trim();
                    rOTC.TOT_HOURS = rOT.TOT_HOURS;
                    rOTC.OT_HRS = rOT.OT_HRS;
                    rOTC.REST_HRS = rOT.REST_HRS;
                    rOTC.KEY_DATE = rOT.KEY_DATE;
                    rOTC.KEY_MAN = rOT.KEY_MAN.Trim();
                    rOTC.YYMM = rOT.YYMM.Trim();
                    rOTC.NOTE = rOT.NOTE.Trim();
                    rOTC.SERNO = rOT.SERNO.Trim();
                    dcHr.OTC.InsertOnSubmit(rOTC);

                    lsOT.Add(rOT);

                    Vdb++;
                }
            }

            dcHr.OT.DeleteAllOnSubmit(lsOT);
            dcHr.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 轉換成48小時
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時日</param>
        /// <param name="sTimeE">結束時間</param>
        public void ConvertTime24To48(string sNobr, ref DateTime dDateB, ref DateTime dDateE, ref string sTimeB, ref string sTimeE)
        {
            sTimeB = sTimeB.PadLeft(4, char.Parse("0"));
            sTimeE = sTimeE.PadLeft(4, char.Parse("0"));

            DateTime dDateTimeB, dDateTimeE;

            dDateTimeB = dDateB.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));
            dDateTimeE = dDateE.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));

            //先採用是否有在刷卡時間裡的方式優先判斷
            //取今天跟前一天兩筆資料來判斷
            AttcardDao oAttcardDao = new AttcardDao(dcHr.Connection);
            var rsAttcard = oAttcardDao.GetAttcard(sNobr, dDateB.AddDays(-1), dDateB);

            bool bCardTime = false;
            DateTime dDate = dDateB;
            foreach (var rAttcard in rsAttcard)
            {
                bCardTime = false;

                bCardTime = rAttcard.DateTimeB <= dDateTimeB && dDateTimeB <= rAttcard.DateTimeE;
                bCardTime = bCardTime && (rAttcard.DateTimeB <= dDateTimeE && dDateTimeE <= rAttcard.DateTimeE);

                if (bCardTime)
                {
                    dDate = rAttcard.Date;
                    break;
                }
            }

            if (bCardTime)
            {
                //刷卡日期比開始日期小
                if (dDate.Date < dDateB.Date)
                {
                    //開始日期減一天 時間加24小時
                    dDateB = dDateB.AddDays(-1).Date;
                    sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                }

                //刷卡日期比結束日期小 或 結束日期比開始日期大
                if ((dDate.Date < dDateE.Date) || (dDateB.Date < dDateE.Date))
                {
                    //結束日期減一天 時間加24小時
                    dDateE = dDateE.AddDays(-1).Date;
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                }
            }
            else
            {
                Dal.Dao.Att.AttendDao oAttendDao = new AttendDao(dcHr.Connection);
                var rsAttend = oAttendDao.GetAttend(sNobr, dDateB.AddDays(-1), dDateE);

                Dal.Dao.Att.RoteDao oRoteDao = new RoteDao(dcHr.Connection);
                var rsRote = oRoteDao.GetRoteDetail();

                var rsAtt = (from a in rsAttend
                             join r in rsRote on a.RoteCode equals r.RoteCode
                             select new
                             {
                                 Date = a.Date,
                                 OnTime = r.OnTime,
                                 OffTime = r.OffTime,
                                 //DateTimeB = a.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OnTime)),
                                 //DateTimeE = a.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OffTime)),
                                 DateTimeB = a.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OffLastTime)),    //最早上班時間
                                 DateTimeE = a.Date.AddDays(1).AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OffLastTime)), //最晚下班時間
                             }).ToList();

                //完全包含開始日期時間
                var rAtt = rsAtt.Where(p => p.DateTimeB <= dDateTimeB && dDateTimeB <= p.DateTimeE).FirstOrDefault();

                //出勤日期比開始日期小
                if (rAtt != null && rAtt.Date < dDateB.Date)
                {
                    //開始日期減一天 時間加24小時
                    dDateB = dDateB.AddDays(-1).Date;
                    sTimeB = (Convert.ToInt32(sTimeB) + 2400).ToString("0000");
                }

                //完全包含結束日期時間
                rAtt = rsAtt.Where(p => p.DateTimeB <= dDateTimeE && dDateTimeE <= p.DateTimeE).FirstOrDefault();

                //出勤日期比結束日期小 或 結束日期比開始日期大
                if ((rAtt != null && rAtt.Date < dDateE.Date) || (dDateB.Date < dDateE.Date))
                {
                    //結束日期減一天 時間加24小時
                    dDateE = dDateE.AddDays(-1).Date;
                    sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
                }
            }
        }

        /// <summary>
        /// 加班計算
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sOtCat">加班費或補休假</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sOtrcd">加班原因代碼</param>
        /// <param name="iException">例外時數</param>
        /// <param name="sRoteCode">加班班別代碼</param>
        /// <param name="bCalculateRes">扣除休息時數</param>
        /// <param name="bTime24">24小時計算</param>
        /// <returns>decimal</returns>
        public decimal GetCalculate(string sNobr, string sOtCat, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sOtrcd, decimal iException = 0, string sRoteCode = "", bool bCalculateRes = true, bool bTime24 = false)
        {
            if (bTime24)
                ConvertTime24To48(sNobr, ref dDateB, ref dDateE, ref sTimeB, ref sTimeE);

            decimal Vdb = 0;

            if (iException > 0)
                return iException;

            //取得基本資料
            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBase = oBasDao.GetBaseByNobr(sNobr, dDateB.Date).FirstOrDefault();

            //取得員工每天班別資料減一天加十天
            AttendDao oAttendDao = new AttendDao(dcHr.Connection);
            var lsAttend = oAttendDao.GetAttend(sNobr, dDateB.Date.AddDays(-1), dDateB.Date.AddDays(1));

            List<string> lsRoteCode = lsAttend.Where(p => !p.IsHoliDay).Select(p => p.RoteCode).Distinct().ToList();
            if (sRoteCode != null && sRoteCode != "" && sRoteCode != "0" && !lsRoteCode.Contains(sRoteCode))
                lsRoteCode.Add(sRoteCode);

            var rAttend = oAttendDao.GetAttend(sNobr, dDateB).FirstOrDefault();
            //string sFixedRoteCode = rAttend.RoteCodeH;

            //固定常用的班別 先向左抓 再向右抓
            string sFixedRoteCode = "";
            sFixedRoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDateB.Date);

            if (sFixedRoteCode == "")
                sFixedRoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDateB.Date, false);

            if (sFixedRoteCode != "" && !lsRoteCode.Contains(sFixedRoteCode))
                lsRoteCode.Add(sFixedRoteCode);

            //取得班別相關資料
            RoteDao oRoteDao = new RoteDao(dcHr.Connection);
            var lsRote = oRoteDao.GetRoteDetail();

            var lsRoteHoliDayRoteCode = lsRote.Where(p => p.OnTime.Length == 0 && p.OffTime.Length == 0 && p.WorkHour == 0).Select(p => p.RoteCode).ToList();

            //套用加班計算公式
            Bll.Att.Ot oOt = new Bll.Att.Ot();

            bool bException = iException > 0;
            {
                string CalculateRoteCode = sRoteCode;   //計算班別
                string RealRoteCode = sRoteCode;    //實際班別

                rAttend = lsAttend.Where(p => p.Date == dDateB.Date).FirstOrDefault();
                if (rAttend != null)
                {
                    CalculateRoteCode = sFixedRoteCode;
                    RealRoteCode = rAttend.RoteCode;

                    if (sRoteCode != null && sRoteCode != "" && sRoteCode != "0")
                        CalculateRoteCode = sRoteCode;

                    var rRote = lsRote.Where(p => p.RoteCode == CalculateRoteCode).FirstOrDefault();
                    if (rRote != null)
                    {
                        DateTime DateTimeB = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));
                        DateTime DateTimeE = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));

                        List<RoteResRow> rsRes = null;

                        //是否要扣除休息時間(包含上班時間)
                        if (bCalculateRes)
                        {
                            rsRes = rRote.DayRes;

                            //如果當天實際班別不是假日 就要進行上班時間合併休息時間
                            if (!lsRoteHoliDayRoteCode.Contains(RealRoteCode))
                            {
                                rsRes = new List<RoteResRow>();
                                RoteResRow rRes;

                                foreach (var rDayResRes in rRote.DayRes)
                                {
                                    DateTime DateTimeResB = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rDayResRes.ResTimeB));
                                    DateTime DateTimeResE = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rDayResRes.ResTimeE));

                                    if (!(DateTimeB <= DateTimeResB && DateTimeResE <= DateTimeE))
                                    {
                                        rRes = new RoteResRow();
                                        rRes.ResTimeB = rDayResRes.ResTimeB;
                                        rRes.ResTimeE = rDayResRes.ResTimeE;
                                        rsRes.Add(rRes);
                                    }
                                }

                                rRes = new RoteResRow();
                                rRes.ResTimeB = rRote.OnTime;
                                rRes.ResTimeE = rRote.OffTime;
                                rsRes.Add(rRes);
                            }
                        }

                        //非假日 且加起時間 小於等於 實際應出勤下班時間 則 需要減到彈性工時分鐘數
                        int ElasticityMin = 0;
                        if (!lsRoteHoliDayRoteCode.Contains(rRote.RoteCode))
                            if (sTimeB.CompareTo(rRote.OffTime) <= 0)
                                ElasticityMin = rAttend.ElasticityMin;

                        Vdb = oOt.GetCalculate(sTimeB, sTimeE, rsRes, 0, 0.5M, (ElasticityMin));
                    }
                }
            }

            return Vdb;
        }
        /// <summary>
        /// 存入
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sOtCat">加班費或補休假</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="iHour">時數</param>
        /// <param name="sOtrcd">加班原因代碼</param>
        /// <param name="sRoteCode">加班班別代碼</param>
        /// <param name="sDeptsCode">成本中心代碼</param>
        /// <param name="sAbstCode">補休得假代碼</param>
        /// <param name="sNote">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sSerno">序號</param>
        /// <param name="bTime24">24小時計算</param>
        /// <returns>int</returns>
        public int OtSave(string sNobr, string sOtCat, DateTime dDateB, DateTime dDateE, DateTime dDateD, string sTimeB, string sTimeE, decimal iHour, string sOtrcd, string sRoteCode, string sDeptsCode = "", string sAbstCode = "", string sNote = "", string sKeyMan = "System", string sSerno = "", bool bTime24 = false)
        {
            if (bTime24)
                ConvertTime24To48(sNobr, ref dDateB, ref dDateE, ref sTimeB, ref sTimeE);

            int iDay = 0;

            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBasetts = oBasDao.GetBasettsByNobr(sNobr, dDateB.Date).FirstOrDefault();

            if (rBasetts == null)
                return -1;

            sDeptsCode = sDeptsCode.Length > 0 ? sDeptsCode : rBasetts.Depts;

            sSerno = sSerno.Trim().Length > 0 ? sSerno : Guid.NewGuid().ToString();

            //計薪年月
            List<Bll.Sal.Vdb.SalaryDateBE> lsSalaryDateBE = new List<Bll.Sal.Vdb.SalaryDateBE>();
            Bll.Sal.Vdb.SalaryDateBE rSalaryDateBE = new Bll.Sal.Vdb.SalaryDateBE();
            rSalaryDateBE.Nobr = sNobr;
            rSalaryDateBE.DateB = dDateB;
            rSalaryDateBE.DateE = dDateB;
            lsSalaryDateBE.Add(rSalaryDateBE);

            Dal.Dao.Sal.SalaryLockDao oSalaryLockDao = new Sal.SalaryLockDao(dcHr.Connection);
            var rsGetSalaryYymm = oSalaryLockDao.GetSalaryYymm(lsSalaryDateBE);

            string sYYMM = "";
            var rGetSalaryYymm = rsGetSalaryYymm.Where(p => p.Nobr == sNobr && p.Date.Date == dDateB.Date).FirstOrDefault();
            if (rGetSalaryYymm != null)
                sYYMM = rGetSalaryYymm.Yymm;

            if (rGetSalaryYymm.Yymm.Length == 0)
                return -1;

            DateTime DateTimeB = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));
            DateTime DateTimeE = dDateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));

            //補休失效日
            //DateTime dDateD = new DateTime(dDateB.Year, 12, 31).Date;
            //if (dDateB.Month <= 6)
            //    dDateD = new DateTime(dDateB.Year, 6, 30).Date;

            //檢查重複資料
            var rsOt = GetOt(sNobr, dDateB.AddDays(-1).Date, dDateB.AddDays(1).Date);
            if (!rsOt.Where(p => p.Date == dDateB.Date && p.TimeB == sTimeB).Any())
                if (!rsOt.Where(p => p.DateTimeB < DateTimeE && p.DateTimeE > DateTimeB).Any())
                {
                    //帶入預設班別
                    if (sRoteCode.Length == 0)
                    {
                        AttendDao oAttendDao = new AttendDao(dcHr.Connection);
                        sRoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDateB.Date);

                        if (sRoteCode == "")
                            sRoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDateB.Date, false);
                    }

                    var rOT = new OT();
                    Bll.Tools.DefaultData.SetRowDefaultValue(rOT);
                    rOT.NOBR = sNobr;
                    rOT.BDATE = dDateB;
                    rOT.BTIME = sTimeB;
                    rOT.ETIME = sTimeE;
                    rOT.TOT_HOURS = iHour;
                    rOT.OT_HRS = (sOtCat == "1") ? rOT.TOT_HOURS : 0;
                    rOT.REST_HRS = (sOtCat == "2") ? rOT.TOT_HOURS : 0;
                    rOT.OT_DEPT = sDeptsCode;
                    rOT.KEY_MAN = sKeyMan;
                    rOT.NOTE = sNote.Length > 100 ? sNote.Substring(0, 99) : sNote;// +";" + oOtDetail.sRote;
                    rOT.YYMM = sYYMM;
                    rOT.OTRCD = sOtrcd;
                    rOT.OT_EDATE = dDateD;
                    rOT.OT_ROTE = sRoteCode;
                    rOT.SERNO = sSerno;
                    dcHr.OT.InsertOnSubmit(rOT);

                    iDay = 1;
                }

            //存入補休
            if (sOtCat == "2")
            {
                //補休代碼
                sAbstCode = sAbstCode.Length > 0 ? sAbstCode : "W2";

                Dal.Dao.Att.AbsDao oAbsDao = new AbsDao(dcHr.Connection);
                var rsAbst = oAbsDao.GetAbst(sNobr, dDateB, sAbstCode);

                //檢查是否有重複
                if (!rsAbst.Where(p => p.DateB.Date == dDateB.Date && p.TimeB == sTimeB).Any())
                {
                    var rABS = new ABS();
                    Bll.Tools.DefaultData.SetRowDefaultValue(rABS);
                    rABS.NOBR = sNobr;
                    rABS.BDATE = dDateB;
                    rABS.EDATE = dDateD;
                    rABS.BTIME = sTimeB;
                    rABS.ETIME = sTimeE;
                    rABS.H_CODE = sAbstCode;
                    rABS.TOL_HOURS = iHour;
                    rABS.KEY_MAN = sKeyMan;
                    rABS.YYMM = sYYMM;
                    rABS.NOTE = sNote.Length > 100 ? sNote.Substring(0, 99) : sNote;// +";" + oOtDetail.sRote;
                    rABS.SERNO = sSerno;
                    rABS.Balance = iHour;
                    rABS.LeaveHours = 0;
                    rABS.Guid = Guid.NewGuid().ToString();
                    dcHr.ABS.InsertOnSubmit(rABS);

                    iDay = 2;
                }
            }

            if (iDay > 0)
            {
                dcHr.SubmitChanges();

                if (iDay == 1)
                {
                    Dal.Dao.Att.TransCardDao oTransCardDao = new Dal.Dao.Att.TransCardDao(dcHr.Connection);
                    oTransCardDao.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateB.AddDays(1), sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
                }
            }

            return iDay;
        }
        /// <summary>
        /// 取得加班資料(區間)
        /// </summary>
        /// <param name="lsNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>List OtRow</returns>
        public List<OtRow> GetOt(List<string> lsNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from c in dcHr.OT
                       join b in dcHr.BASE on c.NOBR equals b.NOBR
                       join o in dcHr.OTRCD on c.OTRCD equals o.OTRCD1 into oRows
                       from oRow in oRows.DefaultIfEmpty()
                       where lsNobr.Contains(c.NOBR)
                       && dDateB.Date <= c.BDATE.Date
                       && c.BDATE.Date <= dDateE.Date
                       select new OtRow
                       {
                           Nobr = c.NOBR.Trim(),
                           Name = b.NAME_C.Trim(),
                           Date = c.BDATE.Date,
                           TimeB = c.BTIME.Trim(),
                           TimeE = c.ETIME.Trim(),
                           Hour = c.TOT_HOURS,
                           OtHour = c.OT_HRS,
                           ResHour = c.REST_HRS,
                           RoteCode = c.OT_ROTE,
                           Note = c.NOTE.Trim(),
                           Otrcd = c.OTRCD.Trim(),
                           OtrcdName = oRow != null ? oRow.OTRNAME.Trim() : "",
                           Serno = c.SERNO.Trim(),
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.TimeB.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeB));

                if (rVdb.TimeE.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeE));
            }

            return Vdb;
        }
        /// <summary>
        /// 取得加班資料(區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <returns>List OtRow</returns>
        public List<OtRow> GetOt(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb = (from c in dcHr.OT
                       join b in dcHr.BASE on c.NOBR equals b.NOBR
                       //join o in dcHr.OTRCD on c.OTRCD equals o.OTRCD1 
                       where c.NOBR == sNobr
                       && dDateB.Date <= c.BDATE.Date
                       && c.BDATE.Date <= dDateE.Date
                       select new OtRow
                       {
                           Nobr = c.NOBR,
                           Name = b.NAME_C,
                           Date = c.BDATE.Date,
                           TimeB = c.BTIME,
                           TimeE = c.ETIME,
                           Hour = c.TOT_HOURS,
                           OtHour = c.OT_HRS,
                           ResHour = c.REST_HRS,
                           RoteCode = c.OT_ROTE,
                           Note = c.NOTE,
                           Otrcd = c.OTRCD,
                           OtrcdName = "",
                           Serno = c.SERNO,
                       }).ToList();

            var rsOtrcd = (from c in dcHr.OTRCD
                           select c).ToList();

            foreach (var rVdb in Vdb)
            {
                var rOtrcd = rsOtrcd.Where(p => p.OTRCD1 == rVdb.Otrcd).FirstOrDefault();
                if (rOtrcd != null)
                    rVdb.OtrcdName = rOtrcd.OTRNAME;

                if (rVdb.TimeB.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeB));

                if (rVdb.TimeE.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeE));
            }

            return Vdb;
        }
        /// <summary>
        /// 取得加班原因代碼
        /// </summary>
        /// <param name="sCode">代碼</param>
        /// <returns>List</returns>
        public List<OtrcdRow> GetOtrcd(string sCode = "")
        {
            var Vdb = (from c in dcHr.OTRCD
                       where (c.OTRCD1 == sCode || sCode == "")
                       && c.SORT.Value > 0
                       orderby c.SORT.Value
                       select new OtrcdRow
                       {
                           Code = c.OTRCD1,
                           Name = c.OTRNAME,
                           Sort = c.SORT.Value,
                           DisplayName = c.OTRNAME + "(" + c.OTRCD_DISP + ")",
                           NoCalc = c.NOCALC.Value,
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 計算加班時數
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">計算開始日期</param>
        /// <param name="dDateE">計算結束日期</param>
        /// <param name="bFor46"></param>
        /// <returns></returns>
        public decimal GetHoursSum(string sNobr, DateTime dDateB, DateTime dDateE, bool bFor46)
        {
            decimal Vdb = 0;

            Dal.Dao.Att.AttendDao oAttendDao = new AttendDao(dcHr.Connection);
            Dal.Dao.Att.AbsDao oAbsDao = new AbsDao(dcHr.Connection);

            var rsAttend = oAttendDao.GetAttend(sNobr, dDateB.Date, dDateE.Date);
            var rsOt = GetOt(sNobr, dDateB.Date, dDateE.Date);
            var rsAbs = oAbsDao.GetAbs(sNobr, dDateB.Date, dDateE.Date, false);

            decimal iHour = 0;
            decimal iAbsHour = 0;
            foreach (var rAttend in rsAttend)
            {
                var rowsOt = rsOt.Where(p => p.Date == rAttend.Date).ToList();

                iHour = 0;
                foreach (var rOt in rowsOt)
                    iHour += rOt.OtHour + rOt.ResHour;

                var rowsAbs = rsAbs.Where(p => p.DateB == rAttend.Date).ToArray();

                iAbsHour = 0;
                foreach (var rAbs in rowsAbs)
                    iAbsHour += rAbs.Use;

                if (iHour > 0)
                {
                    switch (rAttend.RoteCode)
                    {
                        case "0Z":
                        case "00":
                            if (bFor46)
                            {
                                if (iHour >= 8)
                                    iHour -= 8;
                                else
                                    iHour = 0;
                            }
                            else
                            {
                                if (iHour <= 8)
                                    iHour = 8;
                            }

                            iHour -= iAbsHour;

                            break;
                        case "0X":
                            //if (iHour >= 8)
                            //{
                            //    if (iHour > 8 && iHour <= 12)
                            //        iHour = 12;
                            //}
                            //else if (iHour > 4)
                            //    iHour = 8;
                            //else
                            //    iHour = 4;

                            //iHour -= iAbsHour;

                            break;
                        case "0Y":
                            break;
                        default:
                            break;
                    }

                    if (iHour < 0)
                        iHour = 0;
                }

                Vdb += iHour;
            }

            return Vdb;
        }
        /// <summary>
        /// 取得加班原因代碼
        /// </summary>
        /// <param name="sCode">代碼</param>
        /// <returns>List</returns>
        public List<OtrcdRow> GetOtrcdByFilter(string sCode = "", bool bDisplay = true, string sNobr = "", DateTime? dDate = null)
        {
            var Vdb = (from c in dcHr.OTRCD
                       where (c.OTRCD1 == sCode || sCode == "")
                       && c.SORT.Value > 0
                        && dcHr.GetCodeFilterByNobr("OTRCD", c.OTRCD1, sNobr, dDate.Value.Date).Value
                       orderby c.SORT.Value
                       select new OtrcdRow
                       {
                           Code = c.OTRCD1,
                           Name = c.OTRNAME,
                           Sort = c.SORT.Value,
                           DisplayName = c.OTRNAME + "(" + c.OTRCD1 + ")",
                           NoCalc = c.NOCALC.Value,
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <returns>List OtRow</returns>
        public List<OtRow> GetOt(string sNobr, DateTime dDate)
        {
            var Vdb = (from c in dcHr.OT
                       where c.NOBR == sNobr
                       && c.BDATE.Date == dDate.Date
                       select new OtRow
                       {
                           Nobr = c.NOBR,
                           Date = c.BDATE.Date,
                           TimeB = c.BTIME,
                           TimeE = c.ETIME,
                           Hour = c.TOT_HOURS,
                           OtHour = c.OT_HRS,
                           ResHour = c.REST_HRS,
                           RoteCode = c.OT_ROTE,
                       }).ToList();

            foreach (var rVdb in Vdb)
            {
                if (rVdb.TimeB.Length > 0)
                    rVdb.DateTimeB = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeB));

                if (rVdb.TimeE.Length > 0)
                    rVdb.DateTimeE = rVdb.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rVdb.TimeE));
            }

            return Vdb;
        }
    }
}