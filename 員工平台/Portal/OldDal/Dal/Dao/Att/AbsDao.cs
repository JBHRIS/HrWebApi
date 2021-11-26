using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Att.Vdb;
using OldBll.Tools;
using JBModule.Data.Linq;

namespace OldDal.Dao.Att
{
    public class AbsDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="conn"></param>
        public AbsDao(IDbConnection conn = null)
        {
            dcHr = new HrDBDataContext();

            if (conn != null)
                dcHr = new HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 請假資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public AbsDao(string ConnectionString = null)
        {
            dcHr = new HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 出勤資料(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <returns>List</returns>
        public List<AbsDataTable> GetAbs(string sNobr, DateTime dDateB, DateTime dDateE)
        {
            var Vdb1 = (from a in dcHr.ABS
                        where a.NOBR == sNobr
                        && dDateB.Date <= a.BDATE.Date
                        && a.BDATE.Date <= dDateE.Date
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            Use = a.TOL_HOURS,
                            NameA = a.A_NAME != null ? a.A_NAME.Trim() : "",
                            NoCal = a.nocalc.GetValueOrDefault(false),
                        }).ToList();

            var Vdb2 = (from a in dcHr.ABS1
                        where a.NOBR == sNobr
                        && dDateB.Date <= a.BDATE.Date
                        && a.BDATE.Date <= dDateE.Date
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            Use = a.TOL_HOURS,
                            NameA = "",
                            NoCal = false,
                        }).ToList();

            var Vdb = Vdb1.Union(Vdb2)
                .Select(a => new AbsDataTable()
                {
                    Nobr = a.Nobr.Trim(),
                    DateB = a.DateB.Date,
                    DateE = a.DateE.Date,
                    TimeB = a.TimeB.Trim(),
                    TimeE = a.TimeE.Trim(),
                    Hcode = a.Hcode.Trim(),
                    Use = a.Use,
                    NameA = a.NameA,
                    NoCal = a.NoCal,
                    DateTimeB = a.DateB.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeB)),
                    DateTimeE = a.DateE.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeE))
                }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 出勤資料並可依照加減項進行(日期區間)
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始出勤日期</param>
        /// <param name="dDateE">結束出勤日期</param>
        /// <param name="bAdd">加減項</param>
        /// <returns>List</returns>
        public List<AbsDataTable> GetAbs(string sNobr, DateTime dDateB, DateTime dDateE, bool bAdd = false)
        {
            var Vdb1 = (from a in dcHr.ABS
                        join b in dcHr.HCODE on a.H_CODE equals b.H_CODE
                        join ba in dcHr.BASE on a.NOBR equals ba.NOBR
                        where a.NOBR == sNobr
                        && dDateB.Date <= a.BDATE.Date
                        && a.BDATE.Date <= dDateE.Date
                        && (bAdd ? (b.FLAG == "+") : (b.FLAG == "-"))
                        && b.MANG == false
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Name = ba.NAME_C.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            HcodeName = b.H_NAME.Trim(),
                            HcodeUnit = b.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                            Use = a.TOL_HOURS,
                            NameA = a.A_NAME != null ? a.A_NAME.Trim() : "",
                            NoCal = a.nocalc.GetValueOrDefault(false),
                            Serno = a.SERNO.Trim(),
                        }).ToList();

            var Vdb2 = (from a in dcHr.ABS1
                        join b in dcHr.HCODE on a.H_CODE equals b.H_CODE
                        join ba in dcHr.BASE on a.NOBR equals ba.NOBR
                        where a.NOBR == sNobr
                        && dDateB.Date <= a.BDATE.Date
                        && a.BDATE.Date <= dDateE.Date
                        && (bAdd ? (b.FLAG == "+") : (b.FLAG == "-"))
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Name = ba.NAME_C.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            HcodeName = b.H_NAME.Trim(),
                            HcodeUnit = b.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                            Use = a.TOL_HOURS,
                            NameA = "",
                            NoCal = false,
                            Serno = a.SERNO.Trim(),
                        }).ToList();

            var Vdb = Vdb1.Union(Vdb2)
                .Select(a => new AbsDataTable()
                {
                    Nobr = a.Nobr.Trim(),
                    Name = a.Name.Trim(),
                    DateB = a.DateB.Date,
                    DateE = a.DateE.Date,
                    TimeB = a.TimeB.Trim(),
                    TimeE = a.TimeE.Trim(),
                    Hcode = a.Hcode.Trim(),
                    HcodeName = a.HcodeName.Trim(),
                    HcodeUnit = a.HcodeUnit,
                    Use = a.Use,
                    NameA = a.NameA,
                    NoCal = a.NoCal,
                    Serno = a.Serno.Trim(),
                    DateTimeB = a.DateB.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeB)),
                    DateTimeE = a.DateE.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeE)),
                }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 得假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">開始出勤日期</param>
        /// <returns>List</returns>
        public List<AbstRow> GetAbst(string sNobr, DateTime dDate)
        {
            var Vdb = (from a in dcHr.ABST
                       where a.NOBR == sNobr
                       && a.BDATE.Date <= dDate.Date
                       && dDate.Date <= a.EDATE.Date
                       select new AbstRow()
                       {
                           Nobr = a.NOBR.Trim(),
                           DateB = a.BDATE.Date,
                           DateE = a.EDATE.Date,
                           Hcode = a.H_CODE.Trim(),
                           Use = a.TOL_HOURS,
                           NameA = a.A_NAME != null ? a.A_NAME.Trim() : "",
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 得假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">開始出勤日期</param>
        /// <returns>List</returns>
        public List<BalanceAbstRow> GetAbst(string sNobr, DateTime dDate, string sHcode)
        {
            var HType = (from h in dcHr.HCODE
                         where h.H_CODE == sHcode
                         select h.HTYPE).FirstOrDefault();

            List<BalanceAbstRow> Vdb = new List<BalanceAbstRow>();

            if (HType != null && HType.Length > 0)
            {
                Vdb = (from a in dcHr.ABS
                       join h in dcHr.HCODE on a.H_CODE equals h.H_CODE
                       where a.BDATE.Date <= dDate.Date && dDate.Date <= a.EDATE.Date
                       && h.FLAG == "+"
                       && a.NOBR == sNobr
                       && h.HTYPE == HType
                       orderby a.EDATE.Date
                       select new BalanceAbstRow
                       {
                           DateB = a.BDATE.Date,
                           DateE = a.EDATE.Date,
                           Hcode = a.H_CODE.Trim(),
                           HcodeName = h.H_NAME.Trim(),
                           Unit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                           HType = h.HTYPE.Trim(),
                           Max = a.TOL_HOURS,
                           Use = a.LeaveHours.GetValueOrDefault(0),
                           Balance = a.Balance.GetValueOrDefault(0),
                       }).ToList();
            }

            return Vdb;
        }

        /// <summary>
        /// 3.取得請假明細 銷加班有關係
        /// </summary>
        /// <param name="sSerno">加項資料</param>
        /// <returns>List</returns>
        public List<AbsdDataTable> GetAbsd(string sSerno)
        {
            var rsABSD = (from c in dcHr.ABSD
                          where c.ABSADD == sSerno || c.ABSSUBTRACT == sSerno
                          select new AbsdDataTable
                          {
                              AbsAdd = c.ABSADD,
                              AbsSubtract = c.ABSSUBTRACT,
                              Use = c.USEHOUR,
                          }).ToList();

            return rsABSD;
        }

        /// <summary>
        /// 刪除請假資料
        /// </summary>
        /// <param name="sProcessID">ProcessID</param>
        /// <returns>string</returns>
        public string DeleteAbs(string sProcessID)
        {
            string Vdb = string.Empty;

            var rsABS = (from c in dcHr.ABS
                         where c.SERNO == sProcessID
                         select c).ToList();

            //if(Vdb.Any())
            if (rsABS.Any())
            {
                Vdb = sProcessID;
            }

            foreach (var rABS in rsABS)
            {
                //寫入銷假資料記錄
                var rABSC = new ABSC();
                rABSC.NOBR = rABS.NOBR.Trim();
                rABSC.BDATE = rABS.BDATE.Date;
                rABSC.EDATE = rABS.EDATE.Date;
                rABSC.BTIME = rABS.BTIME.Trim();
                rABSC.ETIME = rABS.ETIME.Trim();
                rABSC.H_CODE = rABS.H_CODE.Trim();
                rABSC.TOL_HOURS = rABS.TOL_HOURS;
                rABSC.KEY_DATE = rABS.KEY_DATE;
                rABSC.KEY_MAN = rABS.KEY_MAN.Trim();
                rABSC.YYMM = rABS.YYMM.Trim();
                rABSC.NOTE = rABS.NOTE.Trim();
                rABSC.A_NAME = rABS.A_NAME.Trim();
                rABSC.SERNO = rABS.SERNO.Trim();
                dcHr.ABSC.InsertOnSubmit(rABSC);
            }

            var rsABSD = (from c in dcHr.ABSD
                          where c.ABSSUBTRACT == sProcessID
                          select c).ToList();

            dcHr.ABSD.DeleteAllOnSubmit(rsABSD);

            dcHr.ABS.DeleteAllOnSubmit(rsABS);
            dcHr.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 刪除請假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="sTimeB">結束日期</param>
        /// <param name="dDateE">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sHcode">假別</param>
        /// <returns>int</returns>
        public int DeleteAbs(string sNobr, DateTime dDateB, string sTimeB, DateTime dDateE, string sTimeE, string sHcode)
        {
            int Vdb = 0;

            var rsABS = (from c in dcHr.ABS
                         where c.NOBR == sNobr
                         && dDateB <= c.BDATE.Date && c.BDATE.Date <= dDateE.Date
                         && c.H_CODE == sHcode
                         select c).ToList();

            DateTime dDateTimeA, dDateTimeD, dDateTimeB, dDateTimeE;

            dDateTimeA = dDateB.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));
            dDateTimeD = dDateE.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));

            List<ABS> lsABS = new List<ABS>();

            foreach (var rABS in rsABS)
            {
                dDateTimeB = rABS.BDATE.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(rABS.BTIME.Trim()));
                dDateTimeE = rABS.BDATE.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(rABS.ETIME.Trim()));

                if (dDateTimeA <= dDateTimeB && dDateTimeE <= dDateTimeD)
                {
                    //寫入銷假資料記錄
                    var rABSC = new ABSC();
                    rABSC.NOBR = rABS.NOBR.Trim();
                    rABSC.BDATE = rABS.BDATE.Date;
                    rABSC.EDATE = rABS.EDATE.Date;
                    rABSC.BTIME = rABS.BTIME.Trim();
                    rABSC.ETIME = rABS.ETIME.Trim();
                    rABSC.H_CODE = rABS.H_CODE.Trim();
                    rABSC.TOL_HOURS = rABS.TOL_HOURS;
                    rABSC.KEY_DATE = rABS.KEY_DATE;
                    rABSC.KEY_MAN = rABS.KEY_MAN.Trim();
                    rABSC.YYMM = rABS.YYMM.Trim();
                    rABSC.NOTE = rABS.NOTE.Trim();
                    rABSC.A_NAME = rABS.A_NAME.Trim();
                    rABSC.SERNO = rABS.SERNO.Trim();
                    dcHr.ABSC.InsertOnSubmit(rABSC);

                    lsABS.Add(rABS);

                    Vdb++;
                }
            }

            dcHr.ABS.DeleteAllOnSubmit(lsABS);
            dcHr.SubmitChanges();

            return Vdb;
        }

        /// <summary>
        /// 1.取得得假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sYearRest">年補休特性</param>
        /// <returns>List</returns>
        public List<AbsWDataTable> GetAbsByW(string sNobr, DateTime dDateB, DateTime dDateE, string sYearRest = "3")
        {
            //同時都成立才可以將資料取出
            var rsAbsW = (from a in dcHr.ABS
                          join h in dcHr.HCODE on a.H_CODE equals h.H_CODE
                          where a.NOBR == sNobr.Trim()
                          && a.BDATE.Date <= dDateB.Date
                          && dDateE.Date <= a.EDATE.Date
                          && h.YEAR_REST == sYearRest
                          select new AbsWDataTable
                          {
                              Nobr = a.NOBR.Trim(),
                              DateB = a.BDATE.Date,
                              DateE = a.EDATE.Date,
                              Hcode = a.H_CODE.Trim(),
                              ObtainUse = a.TOL_HOURS,
                              BalanceUse = a.TOL_HOURS,
                              Serno = a.SERNO,
                          }).ToList();

            if (rsAbsW.Any())
            {
                var lsSerno = rsAbsW.Select(p => p.Serno);

                //取得明細資料
                var rsAbsd = (from a in dcHr.ABSD
                              where lsSerno.Contains(a.ABSADD)
                              select new AbsdDataTable
                              {
                                  AbsAdd = a.ABSADD,
                                  AbsSubtract = a.ABSSUBTRACT,
                                  Use = a.USEHOUR,
                              }).ToList();

                if (rsAbsd.Any())
                {
                    lsSerno = rsAbsd.Select(p => p.AbsSubtract);

                    //帶出減項資資料
                    var rsAbs = (from a in dcHr.ABS
                                 where lsSerno.Contains(a.SERNO)
                                 select new AbsDataTable
                                 {
                                     Nobr = a.NOBR.Trim(),
                                     DateB = a.BDATE.Date,
                                     DateE = a.EDATE.Date,
                                     Hcode = a.H_CODE.Trim(),
                                     Use = a.TOL_HOURS,
                                     Serno = a.SERNO,
                                 }).ToList();

                    foreach (var rAbsW in rsAbsW)
                    {
                        var rsAbsdWhere = rsAbsd.Where(p => p.AbsAdd == rAbsW.Serno);
                        if (rsAbsdWhere.Any())
                        {
                            rAbsW.BalanceUse = rAbsW.BalanceUse - rsAbsdWhere.Sum(p => p.Use);

                            //將明細資料帶入
                            lsSerno = rsAbsdWhere.Select(p => p.AbsSubtract);
                            rAbsW.AbsData = rsAbs.Where(p => lsSerno.Contains(p.Serno)).ToList();
                        }
                    }
                }
            }

            return rsAbsW;
        }

        /// <summary>
        /// 2.寫入請假明細
        /// </summary>
        /// <param name="sAddSerno">得假序號</param>
        /// <param name="sSubtractSerno">請假序號</param>
        /// <param name="iUse">使用時數</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="bSave">強迫寫入</param>
        /// <returns>int</returns>
        public int SetAbsd(string sAddSerno, string sSubtractSerno, decimal iUse, string sKeyMan = "JB", bool bSave = false)
        {
            int Vdb = 0;

            var rABSD = (from a in dcHr.ABSD
                         where a.ABSADD == sAddSerno
                         && a.ABSSUBTRACT == sSubtractSerno
                         select a).FirstOrDefault();

            if (rABSD != null)
            {
                if (bSave)
                {
                    rABSD.USEHOUR = iUse;
                    rABSD.KEY_DATE = DateTime.Now;
                    rABSD.KEY_MAN = sKeyMan;

                    Vdb++;
                }
            }
            else
            {
                rABSD = new ABSD();
                rABSD.ABSADD = sAddSerno;
                rABSD.ABSSUBTRACT = sSubtractSerno;
                rABSD.USEHOUR = iUse;
                rABSD.KEY_DATE = DateTime.Now;
                rABSD.KEY_MAN = sKeyMan;
                dcHr.ABSD.InsertOnSubmit(rABSD);

                Vdb++;
            }

            dcHr.SubmitChanges();

            return Vdb;
        }

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

            dDateTimeB = dDateB.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeB));
            dDateTimeE = dDateE.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeE));

            OldDal.Dao.Att.AttendDao oAttendDao = new AttendDao(dcHr.Connection);
            var rsAttend = oAttendDao.GetAttend(sNobr, dDateB.AddDays(-1), dDateE);

            OldDal.Dao.Att.RoteDao oRoteDao = new RoteDao(dcHr.Connection);
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
                             DateTimeB = a.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OffLastTime)),    //最早上班時間
                             DateTimeE = a.Date.AddDays(1).AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(r.OffLastTime)), //最晚下班時間
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

            //出勤日期比結束日期小
            if (rAtt != null && rAtt.Date < dDateE.Date)
            {
                //結束日期減一天 時間加24小時
                dDateE = dDateE.AddDays(-1).Date;
                sTimeE = (Convert.ToInt32(sTimeE) + 2400).ToString("0000");
            }
        }

        /// <summary>
        /// 計算請假
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sHcode">假別</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="bCalculateWorkTime">只計算上班時間</param>
        /// <param name="bCalculateRes">扣除休息時數</param>
        /// <param name="iException">例外時數 時數之總合會分配給每一天</param>
        /// <param name="bFixedCycle">循環固定時間</param>
        /// <param name="sRoteCode">班別 某些特殊會需要 預設請帶空白</param>
        /// <param name="bTime24">24小時計算</param>
        /// <returns></returns>
        public AbsCalculateRow GetCalculate(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, bool bCalculateWorkTime = true, bool bCalculateRes = true, decimal iException = 0, bool bFixedCycle = false, string sRoteCode = "", bool bTime24 = false)
        {
            if (bTime24)
                ConvertTime24To48(sNobr, ref dDateB, ref dDateE, ref sTimeB, ref sTimeE);

            AbsCalculateRow Vdb = new AbsCalculateRow();
            Vdb.Day = new List<AbsRow>();

            //取得基本資料
            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBase = oBasDao.GetBaseByNobr(sNobr, dDateB.Date).FirstOrDefault();

            //取得員工每天班別資料減一天加十天
            AttendDao oAttendDao = new AttendDao(dcHr.Connection);
            var lsAttend = oAttendDao.GetAttend(sNobr, dDateB.Date.AddDays(-1), dDateE.Date.AddDays(10));

            List<string> lsRoteCode = lsAttend.Where(p => !p.IsHoliDay).Select(p => p.RoteCode).Distinct().ToList();
            if (sRoteCode != null && sRoteCode != "" && sRoteCode != "0" && !lsRoteCode.Contains(sRoteCode))
                lsRoteCode.Add(sRoteCode);

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

            ///取得假別資料
            HcodeDao oHcodeDao = new HcodeDao(dcHr.Connection);
            var rHcode = oHcodeDao.GetHocdeDetail(sHcode, false).FirstOrDefault();

            //套用請假計算公式
            OldBll.Att.Abs oAbs = new OldBll.Att.Abs();

            decimal iUse = 0;
            bool bException = iException > 0;
            for (DateTime dDay = dDateB.Date; dDay <= dDateE.Date; dDay = dDay.AddDays(1).Date)
            {
                string CalculateRoteCode = sRoteCode;   //計算班別
                string RealRoteCode = sRoteCode;    //實際班別

                var rAttend = lsAttend.Where(p => p.Date == dDay).FirstOrDefault();
                if (rAttend != null)
                {
                    CalculateRoteCode = rAttend.RoteCodeH;
                    RealRoteCode = rAttend.RoteCode;
                }

                //包含假日也要計算 如果單請一天0X班也要計算
                if (!(rAttend != null && rAttend.IsHoliDay && !rHcode.InHoli) || (dDateB.Date == dDateE.Date && rAttend.RoteCode == "0X"))
                {
                    //沒有出勤資料 或 要計算的班別為00
                    if (rAttend == null || lsRoteHoliDayRoteCode.Contains(CalculateRoteCode) || lsRoteHoliDayRoteCode.Contains(sRoteCode))
                    {
                        var rsAttendWhere = lsAttend.Where(p => !p.IsHoliDay);
                        if (rsAttendWhere.Any())
                        {
                            //採用正向排序法 取得非00的第一筆班別
                            var rAttendWhere = rsAttendWhere.OrderBy(p => p.Date).First();
                            CalculateRoteCode = rAttendWhere.RoteCode;
                        }
                        else
                        {
                            //如果最後還是找不到 就使用慣用班別
                            CalculateRoteCode = sFixedRoteCode;
                        }
                    }

                    //使用者代理固定班別
                    if (sRoteCode.Trim().Length > 0 && sRoteCode != "0" && !lsRoteHoliDayRoteCode.Contains(sRoteCode))
                        CalculateRoteCode = sRoteCode;

                    //沒有出勤資料時 計算班別暫代實際班別
                    if (rAttend == null)
                        RealRoteCode = CalculateRoteCode;

                    if (!lsRoteHoliDayRoteCode.Contains(CalculateRoteCode))
                    {
                        var rRote = lsRote.Where(p => p.RoteCode == CalculateRoteCode).FirstOrDefault();
                        if (rRote != null)
                        {
                            DateTime dRoteDateTimeB = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));
                            DateTime dRoteDateTimeE = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(rRote.AbsEndTime));

                            //計算用的時間 帶入循環週期會用到的時間
                            string sTimeCalB = sTimeB;
                            string sTimeCalE = sTimeE;

                            //循環週期性
                            if (!bFixedCycle)
                            {
                                //只計算上班時間
                                if (bCalculateWorkTime)
                                {
                                    sTimeCalB = sTimeCalB.CompareTo(rRote.OnTime) <= 0 ? rRote.OnTime : sTimeCalB;

                                    //同一天才會有彈性工時的問題
                                    if (dDateB == dDateE)
                                        sTimeCalE = sTimeCalE.CompareTo(rRote.AbsEndTime) >= 0 ? rRote.AbsEndTime : sTimeCalE;
                                    else
                                        sTimeCalE = sTimeCalE.CompareTo(rRote.OffTime) >= 0 ? rRote.OffTime : sTimeCalE;
                                }

                                //不是請假的第一天
                                if (dDateB != dDay)
                                    sTimeCalB = rRote.OnTime;

                                //不是請假的最後一天
                                if (dDateE != dDay)
                                    sTimeCalE = rRote.OffTime;// rRote.AbsEndTime;
                            }

                            DateTime dDateTimeB = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeCalB));
                            DateTime dDateTimeE = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeCalE));

                            //如果結束日期小於等於開始日期 直接結束後面的計算
                            if (!rHcode.InHoli && bCalculateWorkTime && dDateTimeE <= dDateTimeB)
                                break;

                            iUse = 0;

                            //特休以上半天及下半天來寫入
                            if ( rRote.MiddleTimeB.Trim().Length > 0 && rRote.MiddleTimeE.Trim().Length > 0
                                && (sTimeCalB == rRote.OnTime&& sTimeCalE.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalE.CompareTo(rRote.MiddleTimeE) <= 0
                                || sTimeCalE == rRote.AbsEndTime && sTimeCalB.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalB.CompareTo(rRote.MiddleTimeE) <= 0))
                            {
                                if (rHcode.Unit == OldBll.MT.mtEnum.HcodeUnit.Day)
                                {
                                    iUse += 0.5M;
                                    //if (sTimeCalB == rRote.OnTime && sTimeCalE.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalE.CompareTo(rRote.MiddleTimeE) <= 0)//誼山  判斷0.5天
                                    //    iUse += 0.5M;

                                    //if (sTimeCalE == rRote.AbsEndTime && sTimeCalB.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalB.CompareTo(rRote.MiddleTimeE) <= 0)//誼山 下班天判斷
                                    //    iUse += 0.5M;
                                }
                                else
                                {
                                    iUse += 4;
                                    //if (sTimeCalB == rRote.OnTime && sTimeCalE.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalE.CompareTo(rRote.MiddleTimeE) <= 0)//誼山  判斷0.5天
                                    //    iUse += 4;

                                    //if (sTimeCalE == rRote.AbsEndTime && sTimeCalB.CompareTo(rRote.MiddleTimeB) >= 0 && sTimeCalB.CompareTo(rRote.MiddleTimeE) <= 0)//誼山 下班天判斷
                                    //    iUse += 4;
                                }
                            }
                            else if (dRoteDateTimeB == dDateTimeB && dRoteDateTimeE == dDateTimeE)
                                if (rHcode.Unit == OldBll.MT.mtEnum.HcodeUnit.Day)
                                    iUse = 1;
                                else
                                    iUse = rRote.WorkHour;
                            else
                                iUse = oAbs.GetCalculate(sTimeCalB, sTimeCalE, rHcode.Unit, rRote.DayRes, rRote.WorkHour, rHcode.Min, rHcode.Interval, bCalculateRes);

                            //如果有例外時教 逐筆填入
                            if (bException)
                            {
                                //最後一天全部填入
                                if (dDay == dDateE)
                                    iUse = iException;
                                else
                                {
                                    //逐筆向下減 減到0為止
                                    if (iException >= iUse)
                                        iException = iException - iUse;
                                    else
                                    {
                                        iUse = iException;
                                        iException = 0;
                                    }
                                }
                            }

                            AbsRow rDay = new AbsRow();
                            rDay.Nobr = sNobr;
                            rDay.DateB = dDay;
                            rDay.DateE = dDay;
                            rDay.TimeB = sTimeCalB;
                            rDay.TimeE = sTimeCalE;
                            rDay.DateTimeB = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeCalB));
                            rDay.DateTimeE = dDay.Date.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(sTimeCalE));
                            rDay.Hcode = rHcode.Code;
                            rDay.Use = iUse;
                            rDay.Serno = Guid.NewGuid().ToString();
                            Vdb.Day.Add(rDay);

                            Vdb.TotalUse += iUse;
                        }
                    }
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 請假剩餘
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sNameA">對沖對象主鍵</param>
        /// <param name="dDateYB">年計開始日期預設年初</param>
        /// <param name="dDateYE">年計結束日期預設年底</param>
        /// <param name="dDateMB">月計開始日期預設月初</param>
        /// <param name="dDateME">月計結束日期預設月底</param>
        /// <param name="bProportion">事病假依照比例原則</param>
        /// <param name="lsAbs">進行中流程的請假資料</param>
        /// <returns>List AbsBalanceRow</returns>
        public List<AbsBalanceRow> GetBalance(string sNobr, DateTime dDate, string sNameA = "", DateTime? dDateYB = null, DateTime? dDateYE = null, DateTime? dDateMB = null, DateTime? dDateME = null, bool bProportion = true, List<AbsDataTable> lsAbs = null)
        {
            List<AbsBalanceRow> Vdb = new List<AbsBalanceRow>();

            //計算模式採用三種 任一種有資料情況下 有一種驗証過即可

            //取得員工到職日
            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBasetts = oBasDao.GetBasettsByNobr(sNobr, dDate.Date).FirstOrDefault();
            var rBase = oBasDao.GetBaseByNobr(sNobr, dDate.Date).FirstOrDefault();

            ///取得假別資料
            HcodeDao oHcodeDao = new HcodeDao(dcHr.Connection);
            var rsHcode = oHcodeDao.GetHocdeDetail("", false);

            //以年計算的假別
            DateTime dDateYearB = dDateYB.GetValueOrDefault(new DateTime(dDate.Year, 1, 1).Date);
            DateTime dDateYearE = dDateYE.GetValueOrDefault(new DateTime(dDate.Year, 12, DateTime.DaysInMonth(dDate.Year, 12)).Date);

            //以月計算的假別
            DateTime dDateMonthB = dDateMB.GetValueOrDefault(new DateTime(dDate.Year, dDate.Month, 1).Date);
            DateTime dDateMonthE = dDateME.GetValueOrDefault(new DateTime(dDate.Year, dDate.Month, DateTime.DaysInMonth(dDate.Year, dDate.Month)).Date);

            var rsAbst = GetAbst(sNobr, dDate);

            DateTime dDateB = dDateYearB;
            DateTime dDateE = dDateYearE;

            //取得更大的區間以符合喪假及產假的計算
            if (rsAbst.Any())
            {
                DateTime dDateMin = rsAbst.Min(p => p.DateB).Date;
                DateTime dDateMax = rsAbst.Max(p => p.DateB).Date;

                dDateB = dDateMin < dDateB ? dDateMin : dDateB;
                dDateE = dDateMax > dDateE ? dDateMax : dDateE;
            }

            var rsAbs = GetAbs(sNobr, dDateB, dDateE).Where(p => p.NoCal == false).ToList();

            if (lsAbs != null && lsAbs.Count > 0)
                rsAbs = rsAbs.Union(lsAbs).ToList();

            //取得年補休特性是0,2,4,6
            List<string> lsYearRest = new List<string>() { "0", "2", "4", "6" };
            List<string> lsYearRest246 = new List<string>() { "2", "4", "6" };

            var rsHcode0246 = rsHcode.Where(p => lsYearRest.Contains(p.YearRest));

            foreach (var rHcode0246 in rsHcode0246)
            {
                AbsBalanceRow rAbsBalanceRow = new AbsBalanceRow();
                rAbsBalanceRow.Hcode = rHcode0246.Code;

                decimal iMax = rHcode0246.Max;
                decimal iUse = 0;
                decimal iBalance = 0;
                decimal iRealBalance = 0;
                decimal iMaxGroup = rHcode0246.Max;
                decimal iUseGroup = 0;
                decimal iBalanceGroup = 0;
                decimal iRealBalanceGroup = 0;

                List<string> lsHcode = new List<string>();

                //取得該假別相關的假別
                if (rHcode0246.YearRest == "0")
                {
                    lsHcode.Add(rHcode0246.Code);

                    //第一種採用得假方式計算
                    var rsAbstWhere = rsAbst.Where(p => p.Hcode == rHcode0246.Code && p.NameA == sNameA).ToList();
                    if (rsAbstWhere.Any())
                    {
                        List<DateTime> dDateAbs = new List<DateTime>();

                        iMax = rsAbstWhere.Sum(p => p.Use);
                        foreach (var rAbstWhere in rsAbstWhere)
                        {
                            var rsAbsWhere = rsAbs.Where(p => rAbstWhere.DateB <= p.DateB
                                && p.DateB <= rAbstWhere.DateE
                                && p.Hcode == rAbstWhere.Hcode
                                && p.NameA == rAbstWhere.NameA
                                && !dDateAbs.Contains(p.DateB)).ToList();
                            if (rsAbsWhere.Any())
                            {
                                dDateAbs.AddRange(rsAbsWhere.Select(p => p.DateB).ToList());
                                iUse += rsAbsWhere.Sum(p => p.Use);
                            }
                        }

                        iRealBalance = iMax - iUse;
                        iBalance = iRealBalance;

                        iMaxGroup = iMax;
                        iUseGroup = iUse;
                        iRealBalanceGroup = iBalance;
                        iBalanceGroup = iBalance;

                        rAbsBalanceRow.CalCate = 1;
                    }
                    else
                    {
                        //第二種採用假別最大數 事、病假(此假別之最大數需按比例分配)
                        //如果有最大數才需要計算
                        //if (iMax > 0) //應該是有最大上限時數才需要計算
                        {
                            DateTime dDateCalB = rHcode0246.CalUnit == OldBll.MT.mtEnum.HcodeUnit.Year ? dDateYearB : dDateMonthB;
                            DateTime dDateCalE = rHcode0246.CalUnit == OldBll.MT.mtEnum.HcodeUnit.Year ? dDateYearE : dDateMonthE;

                            var rsAbsWhere = rsAbs.Where(p => p.Hcode == rHcode0246.Code && dDateCalB <= p.DateB && p.DateB <= dDateCalE).ToList();
                            if (rsAbsWhere.Any())
                                iUse = rsAbsWhere.Sum(p => p.Use);

                            iRealBalance = iMax - iUse;
                            iBalance = iRealBalance; //有可能會是負的
                            iBalance = rHcode0246.CheckBalance || iBalance > 0 ? iBalance : 0;  //要檢查或正數都顯示

                            int i = 0;
                            do
                            {
                                i = lsHcode.Count;

                                var rsHcodeWhere = rsHcode.Where(p => lsHcode.Contains(p.Code) || lsHcode.Contains(p.Dcode));
                                foreach (var rHcodeWhere in rsHcodeWhere)
                                {
                                    if (!lsHcode.Contains(rHcodeWhere.Code))
                                        lsHcode.Add(rHcodeWhere.Code);

                                    if (rHcodeWhere.Dcode.Trim().Length > 0 && !lsHcode.Contains(rHcodeWhere.Dcode))
                                        lsHcode.Add(rHcodeWhere.Dcode);
                                }
                            } while (lsHcode.Count > i);

                            //假別最大可請上限
                            iMaxGroup = rsHcode.Where(p => lsHcode.Contains(p.Code)).Max(p => p.Max);

                            if (iMaxGroup > 0)
                            {
                                //最大值需按照到職日比例分配 大於今年1月1日都要重新計算
                                //當做最大上限都是以年計算 所以不特別做判斷
                                if (bProportion)
                                {
                                    TimeSpan ts = dDateE - rBasetts.DateIn.Date;
                                    double iYearDay = DateTime.IsLeapYear(dDate.Year) ? 365 : 366;  //判斷潤年
                                    if (ts.TotalDays < iYearDay)
                                    {
                                        decimal iDay = Convert.ToDecimal(ts.TotalDays / iYearDay);
                                        iMaxGroup = Math.Round(iMaxGroup * iDay, 0);
                                    }
                                }

                                rsAbsWhere = rsAbs.Where(p => lsHcode.Contains(p.Hcode) && dDateYearB <= p.DateB && p.DateB <= dDateYearE).ToList();
                                if (rsAbsWhere.Any())
                                    iUseGroup = rsAbsWhere.Sum(p => p.Use);

                                iRealBalanceGroup = iMaxGroup - iUseGroup;
                                iBalanceGroup = iRealBalanceGroup;
                            }
                        }

                        rAbsBalanceRow.CalCate = 2;
                    }
                }
                else
                {
                    //第三種採用特彈補的方式計算
                    iMax = 0;

                    var rsHcodeWhere = rsHcode.Where(p => p.YearRest == rHcode0246.YearRest).ToList(); ;
                    foreach (var rHcodeWhere in rsHcodeWhere)
                        lsHcode.Add(rHcodeWhere.Code);

                    //利用減項去反推加項
                    List<string> lsHcodeAdd = new List<string>();
                    rsHcodeWhere = rsHcode.Where(p => p.YearRest == (Convert.ToInt32(rHcode0246.YearRest) - 1).ToString()).ToList();
                    foreach (var rHcodeWhere in rsHcodeWhere)
                        lsHcodeAdd.Add(rHcodeWhere.Code);

                    //新式的寫法
                    //var rsAbstWhere = rsAbs.Where(p => lsHcodeAdd.Contains(p.Hcode) && p.DateB <= dDate && dDate <= p.DateE);
                    //foreach (var rAbstWhere in rsAbstWhere)
                    //{
                    //    iMax += rAbstWhere.Use;
                    //    var rsAbsWhere = rsAbs.Where(p => lsHcode.Contains(p.Hcode) && rAbstWhere.DateB <= p.DateB && p.DateB <= rAbstWhere.DateE);
                    //    if (rsAbsWhere.Any())
                    //        iUse += rsAbsWhere.Sum(p => p.Use);
                    //}

                    //傳統寫法
                    //計算群組假別
                    var rsAbstWhere = rsAbs.Where(p => lsHcodeAdd.Contains(p.Hcode) && dDateYearB <= p.DateB && p.DateB <= dDateYearE).ToList();
                    var rsAbsWhere = rsAbs.Where(p => lsHcode.Contains(p.Hcode) && dDateYearB <= p.DateB && p.DateB <= dDateYearE).ToList();
                    if (rsAbstWhere.Any())
                        iMaxGroup = rsAbstWhere.Sum(p => p.Use);
                    if (rsAbsWhere.Any())
                        iUseGroup = rsAbsWhere.Sum(p => p.Use);

                    iRealBalanceGroup = iMaxGroup - iUseGroup;
                    iBalanceGroup = iRealBalanceGroup;

                    //計算單種假別
                    rsAbsWhere = rsAbs.Where(p => p.Hcode == rHcode0246.Code && dDateYearB <= p.DateB && p.DateB <= dDateYearE).ToList();
                    if (rsAbsWhere.Any())
                        iUse = rsAbsWhere.Sum(p => p.Use);

                    iMax = iMaxGroup;
                    iRealBalance = iMax - iUse;
                    iBalance = iRealBalance;

                    rAbsBalanceRow.CalCate = 3;
                }

                rAbsBalanceRow.HcodeName = rHcode0246.NameC;
                rAbsBalanceRow.HcodeUnit = rHcode0246.Unit;
                rAbsBalanceRow.Max = iMax;
                rAbsBalanceRow.Use = iUse;
                rAbsBalanceRow.Balance = (rHcode0246.Sex == OldBll.MT.mtEnum.SexCategroy.Both || rHcode0246.Sex == rBase.Sex) ? iBalance : 0;
                rAbsBalanceRow.RealBalance = (rHcode0246.Sex == OldBll.MT.mtEnum.SexCategroy.Both || rHcode0246.Sex == rBase.Sex) ? iRealBalance : 0;
                rAbsBalanceRow.MaxGroup = iMaxGroup;
                rAbsBalanceRow.UseGroup = iUseGroup;
                rAbsBalanceRow.BalanceGroup = (rHcode0246.Sex == OldBll.MT.mtEnum.SexCategroy.Both || rHcode0246.Sex == rBase.Sex) ? iBalanceGroup : 0;
                rAbsBalanceRow.RealBalanceGroup = (rHcode0246.Sex == OldBll.MT.mtEnum.SexCategroy.Both || rHcode0246.Sex == rBase.Sex) ? iRealBalanceGroup : 0;
                rAbsBalanceRow.HcodeGroup = lsHcode;
                rAbsBalanceRow.DisplayForm = rHcode0246.DisplayForm;
                rAbsBalanceRow.Sort = rHcode0246.Sort;
                Vdb.Add(rAbsBalanceRow);
            }

            return Vdb;
        }

        /// <summary>
        /// 請假剩餘
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sHcode">假別代碼</param>
        /// <param name="bProportion">事病假依照比例原則</param>
        /// <param name="lsAbs">進行中流程的請假資料</param>
        /// <returns>List AbsBalanceRow</returns>
        public List<AbsBalanceRow> GetBalanceNew(string sNobr, DateTime dDate, string sHcode = "", bool bProportion = true, List<BalanceAbsRow> lsAbs = null)
        {
            List<AbsBalanceRow> Vdb = new List<AbsBalanceRow>();

            //用假別減項去找加項
            //var rsHcodeSql = from h in dcHr.HCODE
            //                 join hr in dcHr.HcodeRule on h.DCODE.Trim() equals hr.Code.Trim() into hr1
            //                 from hr1Row in hr1.DefaultIfEmpty()
            //                 where h.FLAG.Trim() == "-"
            //                 && (sHcode == "" || h.H_CODE.Trim() == sHcode)
            //                 && h.CHE
            //                 select new BalanceHcodeRow
            //                 {
            //                     Hcode = h.H_CODE.Trim(),
            //                     HcodeName = h.H_NAME.Trim(),
            //                     HType = h.HTYPE.Trim(),
            //                     Unit = h.UNIT.Trim() == "天" ? Bll.MT.mtEnum.HcodeUnit.Day : Bll.MT.mtEnum.HcodeUnit.Hour,
            //                     Flag = h.FLAG.Trim(),
            //                     DisplayForm = h.DISPLAYFORM,
            //                     Sort = h.SORT,
            //                     DCode = h.DCODE.Trim(),
            //                     CalUnit = hr1Row != null ? (hr1Row.Interval == "Year" ? Bll.MT.mtEnum.HcodeUnit.Year : Bll.MT.mtEnum.HcodeUnit.Month) : Bll.MT.mtEnum.HcodeUnit.Year,
            //                     CalNum = hr1Row != null ? hr1Row.Value1 : 0,
            //                     CalMax = hr1Row != null ? hr1Row.Value2 : 0,
            //                     CalEnd = hr1Row != null ? Convert.ToInt32(hr1Row.Custom) : 0,
            //                     CalDateTimeB = DateTime.Now.Date,
            //                     CalDateTimeE = DateTime.Now.Date,
            //                 };

            //var  rsAbstSql = from a in dcHr.ABS
            //                 join h in dcHr.HCODE on a.H_CODE.Trim() equals h.H_CODE.Trim()
            //                 where a.BDATE.Date <= dDate.Date && dDate.Date <= a.EDATE.Date
            //                 && h.FLAG.Trim() == "+"
            //                 && a.NOBR.Trim() == sNobr
            //                 select new BalanceAbstRow
            //                 {
            //                     DateB = a.BDATE.Date,
            //                     DateE = a.EDATE.Date,
            //                     Hcode = a.H_CODE.Trim(),
            //                     HcodeName = h.H_NAME.Trim(),
            //                     Unit = h.UNIT.Trim() == "天" ? Bll.MT.mtEnum.HcodeUnit.Day : Bll.MT.mtEnum.HcodeUnit.Hour,
            //                     HType = h.HTYPE.Trim(),
            //                     Max = a.TOL_HOURS,
            //                     Use = a.LeaveHours.GetValueOrDefault(0),
            //                     Balance = a.Balance.GetValueOrDefault(0),
            //                 };

            var rsAbstSql = from a in dcHr.ABS
                            join h in dcHr.HCODE on a.H_CODE equals h.H_CODE
                            where a.BDATE.Date <= dDate.Date && dDate.Date <= a.EDATE.Date
                            && h.FLAG == "+"
                            && a.NOBR == sNobr
                            select new BalanceAbstRow
                            {
                                DateB = a.BDATE.Date,
                                DateE = a.EDATE.Date,
                                Hcode = a.H_CODE.Trim(),
                                HcodeName = h.H_NAME.Trim(),
                                Unit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                                HType = h.HTYPE.Trim(),
                                Max = a.TOL_HOURS,
                                Use = a.LeaveHours.GetValueOrDefault(0),
                                Balance = a.Balance.GetValueOrDefault(0),
                                Guid = a.Guid,
                            };

            var rsHcodeSql = from h in dcHr.HCODE
                             join hr in dcHr.HcodeRule on h.DCODE equals hr.Code into hr1
                             from hr1Row in hr1.DefaultIfEmpty()
                             where (from a in rsAbstSql where h.HTYPE == a.HType select 1).Any()
                             && h.FLAG == "-"
                             && (sHcode == "" || h.H_CODE == sHcode)
                             select new BalanceHcodeRow
                             {
                                 Hcode = h.H_CODE.Trim(),
                                 HcodeName = h.H_NAME.Trim(),
                                 HType = h.HTYPE.Trim(),
                                 Unit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                                 Flag = h.FLAG.Trim(),
                                 DisplayForm = h.DISPLAYFORM,
                                 Sort = h.SORT,
                                 DCode = hr1Row != null ? h.DCODE.Trim() : "",
                                 CalUnit = hr1Row != null ? (hr1Row.Interval == "Year" ? OldBll.MT.mtEnum.HcodeUnit.Year : OldBll.MT.mtEnum.HcodeUnit.Month) : OldBll.MT.mtEnum.HcodeUnit.Year,
                                 CalNum = hr1Row != null ? hr1Row.Value1 : 0,
                                 CalMax = hr1Row != null ? hr1Row.Value2 : 0,
                                 CalEnd = hr1Row != null ? Convert.ToInt32(hr1Row.Custom) : 0,
                                 CalDateTimeB = DateTime.Now.Date,
                                 CalDateTimeE = DateTime.Now.Date,
                                 CheckBalance = h.CHE,
                             };

            var rsHcode = rsHcodeSql.ToList();
            var rsAbst = rsAbstSql.ToList();

            foreach (var rHcode in rsHcode)
            {
                AbsBalanceRow rAbsBalanceRow = new AbsBalanceRow();
                rAbsBalanceRow.Hcode = rHcode.Hcode;
                rAbsBalanceRow.HcodeName = rHcode.HcodeName;
                rAbsBalanceRow.HcodeUnit = rHcode.Unit;

                var rsAbstWhere = rsAbst.Where(p => p.HType == rHcode.HType).ToList();

                //加入加項主索引鍵
                rAbsBalanceRow.lsGuid = rsAbstWhere.Select(p => p.Guid).ToList();

                decimal FlowUse = 0;
                if (lsAbs != null)
                {
                    DateTime DateTimeB = new DateTime(dDate.Year, 1, 1).Date;
                    DateTime DateTimeE = new DateTime(dDate.Year, 12, 31).Date;

                    if (rsAbstWhere.Count > 0)
                    {
                        DateTimeB = rsAbstWhere.Min(p => p.DateB.Date);
                        DateTimeE = rsAbstWhere.Max(p => p.DateE.Date);
                    }

                    FlowUse = lsAbs.Where(p => p.Hcode == rHcode.Hcode && DateTimeB <= p.DateB && p.DateB <= DateTimeE).Sum(p => p.Use);
                }

                //if (rsAbstWhere.Count > 0)
                {
                    rAbsBalanceRow.Use = rsAbstWhere.Sum(p => p.Use) + FlowUse;
                    rAbsBalanceRow.Balance = rsAbstWhere.Sum(p => p.Balance) - FlowUse;
                    rAbsBalanceRow.Max = rAbsBalanceRow.Use + rAbsBalanceRow.Balance;
                    rAbsBalanceRow.UseGroup = rAbsBalanceRow.Use;
                    rAbsBalanceRow.BalanceGroup = rAbsBalanceRow.Balance;
                    rAbsBalanceRow.MaxGroup = rAbsBalanceRow.Max;
                }

                //有特殊規則才需要進來 更改日期區間 並找出日期最大及最小
                if (rHcode.DCode.Length > 0)
                {
                    switch (rHcode.CalUnit)
                    {
                        case OldBll.MT.mtEnum.HcodeUnit.Year:
                            rHcode.CalEnd = rHcode.CalEnd != 0 ? rHcode.CalEnd : 12;

                            rHcode.CalDateTimeB = new DateTime(dDate.Year, rHcode.CalEnd, 1).AddMonths(1).Date;

                            if (dDate.Month <= rHcode.CalEnd)
                                rHcode.CalDateTimeB = new DateTime(dDate.Year, rHcode.CalEnd, 1).AddMonths(-11).Date;

                            rHcode.CalDateTimeE = rHcode.CalDateTimeB.AddMonths(11);
                            rHcode.CalDateTimeE = new DateTime(rHcode.CalDateTimeE.Year, rHcode.CalDateTimeE.Month, DateTime.DaysInMonth(rHcode.CalDateTimeE.Year, rHcode.CalDateTimeE.Month));
                            break;

                        case OldBll.MT.mtEnum.HcodeUnit.Month:
                            rHcode.CalEnd = rHcode.CalEnd != 0 ? rHcode.CalEnd : 31;

                            int DaysInMonth = DateTime.DaysInMonth(dDate.Year, dDate.Month);
                            int Day = DaysInMonth <= rHcode.CalEnd ? DaysInMonth : rHcode.CalEnd;

                            rHcode.CalDateTimeB = new DateTime(dDate.Year, dDate.Month, Day).AddDays(1).Date;

                            if (dDate.Day <= Day)
                                rHcode.CalDateTimeB = new DateTime(dDate.Year, dDate.Month, Day).AddDays(1).AddMonths(-1).Date;

                            rHcode.CalDateTimeE = rHcode.CalDateTimeB.AddMonths(1).AddDays(-1).Date;
                            break;

                        default:
                            break;
                    }

                    var rsAbs = (from a in dcHr.ABS
                                 where rHcode.CalDateTimeB <= a.BDATE.Date && a.BDATE.Date <= rHcode.CalDateTimeE
                                 && a.H_CODE == rHcode.Hcode
                                 && a.NOBR == sNobr
                                 select new BalanceAbsRow
                                 {
                                     DateB = a.BDATE.Date,
                                     Hcode = a.H_CODE.Trim(),
                                     Use = a.TOL_HOURS,
                                 }).ToList();

                    rAbsBalanceRow.Use = rsAbs.Sum(p => p.Use) + FlowUse;
                    rAbsBalanceRow.Balance = rHcode.CalMax - rAbsBalanceRow.Use - FlowUse;
                    rAbsBalanceRow.Max = rAbsBalanceRow.Use + rAbsBalanceRow.Balance;
                }

                rAbsBalanceRow.HcodeGroup = rsHcode.Where(p => p.HType == rHcode.HType).Select(p => p.Hcode).ToList();
                rAbsBalanceRow.DisplayForm = rHcode.DisplayForm;
                rAbsBalanceRow.Sort = rHcode.Sort;
                Vdb.Add(rAbsBalanceRow);
            }

            return Vdb;
        }

        /// <summary>
        /// 請假剩餘
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDate">日期</param>
        /// <param name="sNameA">對沖對象主鍵</param>
        /// <param name="dDateYB">年計開始日期預設年初</param>
        /// <param name="dDateYE">年計結束日期預設年底</param>
        /// <param name="dDateMB">月計開始日期預設月初</param>
        /// <param name="dDateME">月計結束日期預設月底</param>
        /// <param name="bProportion">事病假依照比例原則</param>
        /// <param name="lsAbs">進行中流程的請假資料</param>
        /// <returns>List AbsBalanceRow</returns>
        public DataTable GetBalanceView(string sNobr, DateTime dDate, string sNameA = "", DateTime? dDateYB = null, DateTime? dDateYE = null, DateTime? dDateMB = null, DateTime? dDateME = null, bool bProportion = true, List<AbsDataTable> lsAbs = null)
        {
            var rsBalance = GetBalance(sNobr, dDate, sNameA, dDateYB, dDateYE, dDateMB, dDateME, bProportion, lsAbs).OrderBy(p => p.Sort).ThenBy(p => p.Hcode).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Hcoode", typeof(string)).DefaultValue = "";

            //標題 類別計算2的一定要請過假才需要顯示
            foreach (var rBalance in rsBalance)
                if (rBalance.DisplayForm && (rBalance.CalCate != 2 || (rBalance.CalCate == 2 && (rBalance.Use > 0 || rBalance.BalanceGroup > 0))))
                    dt.Columns.Add(rBalance.Hcode, typeof(decimal)).DefaultValue = 0;

            //已用
            DataRow r = dt.NewRow();
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName != "Hcoode")
                {
                    var rBalance = rsBalance.Where(p => p.Hcode == dc.ColumnName).FirstOrDefault();
                    if (rBalance != null)
                        r[dc.ColumnName] = rBalance.Use;
                }
                else if (dc.ColumnName == "Hcoode")
                    r[dc.ColumnName] = "已用";
            }
            dt.Rows.Add(r);

            //剩餘
            r = dt.NewRow();
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName != "Hcoode")
                {
                    var rBalance = rsBalance.Where(p => p.Hcode == dc.ColumnName).FirstOrDefault();
                    if (rBalance != null)
                        r[dc.ColumnName] = rBalance.Balance;
                }
                else if (dc.ColumnName == "Hcoode")
                    r[dc.ColumnName] = "剩餘";
            }
            dt.Rows.Add(r);

            //群組已用
            //r = dt.NewRow();
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    if (dc.ColumnName != "Hcoode")
            //    {
            //        var rBalance = rsBalance.Where(p => p.Hcode == dc.ColumnName).FirstOrDefault();
            //        if (rBalance != null)
            //            r[dc.ColumnName] = rBalance.UseGroup;
            //    }
            //    else if (dc.ColumnName == "Hcoode")
            //        r[dc.ColumnName] = "群組已用";
            //}
            //dt.Rows.Add(r);

            //群組剩餘
            //r = dt.NewRow();
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    if (dc.ColumnName != "Hcoode")
            //    {
            //        var rBalance = rsBalance.Where(p => p.Hcode == dc.ColumnName).FirstOrDefault();
            //        if (rBalance != null)
            //            r[dc.ColumnName] = rBalance.BalanceGroup;
            //    }
            //    else if (dc.ColumnName == "Hcoode")
            //        r[dc.ColumnName] = "群組剩餘";
            //}
            //dt.Rows.Add(r);

            //更改標題
            dt.Columns["Hcoode"].ColumnName = "假別";
            foreach (var rBalance in rsBalance)
                if (dt.Columns.Contains(rBalance.Hcode))
                    dt.Columns[rBalance.Hcode].ColumnName = rBalance.HcodeName + "-" + (rBalance.HcodeUnit == OldBll.MT.mtEnum.HcodeUnit.Day ? "天" : "時");

            return dt;
        }

        /// <summary>
        /// 存入
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sHcode">假別</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sNote">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sNameA">對沖對象主鍵</param>
        /// <param name="sSerno">序號</param>
        /// <param name="sAbs1Code">公出固定採用代碼</param>
        /// <param name="sDeptsCode">成本部門代碼</param>
        /// <param name="bCalculateWorkTime">只計算上班時間</param>
        /// <param name="bCalculateRes">扣除休息時數</param>
        /// <param name="iException">例外時數 時數之總合會分配給每一天</param>
        /// <param name="bFixedCycle">循環固定時間</param>
        /// <param name="sRoteCode">班別 某些特殊會需要 預設請帶空白</param>
        /// <returns></returns>
        public int AbsSave(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sNote = "", string sKeyMan = "System", string sNameA = "", string sSerno = "", string sAbs1Code = "O", string sDeptsCode = "", bool bCalculateWorkTime = true, bool bCalculateRes = true, decimal iException = 0, bool bFixedCycle = false, string sRoteCode = "")
        {
            int iDay = 0;

            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBasetts = oBasDao.GetBasettsByNobr(sNobr, dDateB.Date).FirstOrDefault();
            sDeptsCode = sDeptsCode.Trim().Length > 0 ? sDeptsCode : rBasetts.Depts;
            sSerno = sSerno.Trim().Length > 0 ? sSerno : Guid.NewGuid().ToString();

            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHr.Connection);
            var rHcode = oHcodeDao.GetHocdeDetail(sHcode, false).FirstOrDefault();

            var rsAbs = GetAbs(sNobr, dDateB, dDateE, false);

            //計薪年月
            List<OldBll.Sal.Vdb.SalaryDateBE> lsSalaryDateBE = new List<OldBll.Sal.Vdb.SalaryDateBE>();
            OldBll.Sal.Vdb.SalaryDateBE rSalaryDateBE = new OldBll.Sal.Vdb.SalaryDateBE();
            rSalaryDateBE.Nobr = sNobr;
            rSalaryDateBE.DateB = dDateB;
            rSalaryDateBE.DateE = dDateE;
            lsSalaryDateBE.Add(rSalaryDateBE);

            OldDal.Dao.Sal.SalaryLockDao oSalaryLockDao = new Sal.SalaryLockDao(dcHr.Connection);
            var rsGetSalaryYymm = oSalaryLockDao.GetSalaryYymm(lsSalaryDateBE);

            var Vdb = GetCalculate(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, bCalculateWorkTime, bCalculateRes, iException, bFixedCycle, sRoteCode);

            //取得得假資料 快到期的先沖
            //取得得假資料 快到期的先沖
            List<ABS> rsABST = new List<ABS>();
            var rBalance = GetBalanceNew(sNobr, dDateB, sHcode).FirstOrDefault();
            if (rBalance != null && rBalance.lsGuid.Count > 0)
            {
                rsABST = (from c in dcHr.ABS
                          where rBalance.lsGuid.Contains(c.Guid)
                          && c.Balance.GetValueOrDefault(0) > 0
                          orderby c.EDATE
                          select c).ToList();
            }

            List<ABS> rsABS = new List<ABS>();
            List<ABS1> rsABS1 = new List<ABS1>();
            List<ABSD> rsABSD = new List<ABSD>();

            foreach (var rDay in Vdb.Day)
            {
                //檢查是否重複
                var rsAbsWhere = rsAbs.Where(p => p.DateTimeB < rDay.DateTimeE && p.DateTimeE > rDay.DateTimeB);
                if (!rsAbsWhere.Any())
                {
                    string sYYMM = "";
                    var rGetSalaryYymm = rsGetSalaryYymm.Where(p => p.Nobr == sNobr && p.Date.Date == rDay.DateB.Date).FirstOrDefault();
                    if (rGetSalaryYymm != null)
                        sYYMM = rGetSalaryYymm.Yymm;

                    if (sHcode != sAbs1Code)
                    {
                        var rABS = new ABS();
                        OldBll.Tools.DefaultData.SetRowDefaultValue(rABS);
                        rABS.NOBR = sNobr;
                        rABS.BDATE = rDay.DateB;
                        rABS.EDATE = rABS.BDATE;
                        rABS.BTIME = rDay.TimeB;
                        rABS.ETIME = rDay.TimeE;
                        rABS.H_CODE = sHcode;
                        rABS.TOL_HOURS = rDay.Use;
                        rABS.KEY_MAN = sKeyMan;
                        rABS.YYMM = sYYMM;
                        rABS.NOTE = sNote;
                        rABS.SERNO = sSerno;
                        rABS.A_NAME = sNameA;
                        rABS.nocalc = false;
                        rABS.SYSCREATE1 = false;
                        rABS.Guid = Guid.NewGuid().ToString();
                        rsABS.Add(rABS);

                        decimal iUse = rDay.Use;

                        int t = rsABST.Count;
                        int i = 1;

                        //減項資料新增
                        foreach (var rABST in rsABST)
                        {
                            if (rABST.Balance > 0)
                            {
                                var rABSD = new ABSD();
                                rABSD.ABSADD = rABST.Guid;
                                rABSD.ABSSUBTRACT = rABS.Guid;
                                rABSD.USEHOUR = iUse;
                                rABSD.KEY_MAN = sKeyMan;
                                rABSD.KEY_DATE = DateTime.Now;
                                rsABSD.Add(rABSD);

                                if (rABST.Balance >= iUse)
                                {
                                    rABST.Balance = rABST.Balance - iUse;
                                    rABST.LeaveHours = rABST.LeaveHours + iUse;
                                    break;
                                }
                                else
                                {
                                    rABSD.USEHOUR = rABST.Balance.GetValueOrDefault(0);
                                    iUse = iUse - rABST.Balance.GetValueOrDefault(0);
                                    rABST.LeaveHours = rABST.LeaveHours + rABST.Balance.GetValueOrDefault(0);

                                    //如果最後一次進來，就要寫入負數的可能
                                    if (i < t)
                                        rABST.Balance = 0;
                                    else
                                        rABST.Balance = 0 - iUse;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        var rABS1 = new ABS1();
                        OldBll.Tools.DefaultData.SetRowDefaultValue(rABS1);
                        rABS1.NOBR = sNobr;
                        rABS1.BDATE = rDay.DateB;
                        rABS1.EDATE = rABS1.BDATE;
                        rABS1.BTIME = rDay.TimeB;
                        rABS1.ETIME = rDay.TimeE;
                        rABS1.H_CODE = sHcode;
                        rABS1.TOL_HOURS = rDay.Use;
                        rABS1.KEY_MAN = sKeyMan;
                        rABS1.DEPT = sDeptsCode;
                        rABS1.NOTE = sNote;
                        rABS1.YYMM = sYYMM;
                        rABS1.SERNO = sSerno;
                        rsABS1.Add(rABS1);
                    }

                    iDay++;
                }
            }

            if (iDay > 0)
            {
                dcHr.ABS.InsertAllOnSubmit(rsABS);
                dcHr.ABS1.InsertAllOnSubmit(rsABS1);
                dcHr.ABSD.InsertAllOnSubmit(rsABSD);
                dcHr.SubmitChanges();

                OldDal.Dao.Att.TransCardDao oTransCardDao = new OldDal.Dao.Att.TransCardDao(dcHr.Connection);
                oTransCardDao.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateE, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
            }

            return iDay;
        }

        /// <summary>
        /// 刪除請假資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sHcode">假別代碼</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sSerno">序號</param>
        /// <returns>bool</returns>
        public bool AbsDelete(string sNobr, DateTime dDateB, string sTimeB, string sHcode, string sKeyMan, string sSerno)
        {
            //先取得要銷假的資料
            var rABS = (from c in dcHr.ABS
                        where c.NOBR == sNobr
                        && c.BDATE.Date == dDateB.Date
                        && c.BTIME == sTimeB
                        && c.H_CODE == sHcode
                        select c).FirstOrDefault();

            if (rABS != null)
            {
                //找出沖銷的資料
                var rsABSDSql = from c in dcHr.ABSD
                                where c.ABSSUBTRACT == rABS.Guid
                                select c;

                if (rsABSDSql.Any())
                {
                    //加回得假資料裡
                    var rsABST = (from c in dcHr.ABS
                                  where (from a in rsABSDSql where a.ABSADD == c.Guid select 1).Any()
                                  select c).ToList();

                    var rsABSD = rsABSDSql.ToList();

                    foreach (var rABST in rsABST)
                    {
                        var rABSD = rsABSD.Where(p => p.ABSADD == rABST.Guid).FirstOrDefault();
                        if (rABSD != null)
                        {
                            rABST.LeaveHours = rABST.LeaveHours.GetValueOrDefault(0) - rABSD.USEHOUR;
                            rABST.Balance = rABST.Balance.GetValueOrDefault(0) + rABSD.USEHOUR;
                        }
                    }

                    dcHr.ABSD.DeleteAllOnSubmit(rsABSD);
                }

                var rABSC = new ABSC();
                rABSC.NOBR = rABS.NOBR;
                rABSC.BDATE = rABS.BDATE.Date;
                rABSC.EDATE = rABS.EDATE.Date;
                rABSC.BTIME = rABS.BTIME;
                rABSC.ETIME = rABS.ETIME;
                rABSC.H_CODE = rABS.H_CODE;
                rABSC.TOL_HOURS = rABS.TOL_HOURS;
                rABSC.KEY_MAN = sKeyMan;
                rABSC.KEY_DATE = DateTime.Now;
                rABSC.YYMM = rABS.YYMM;
                rABSC.NOTE = rABS.NOTE;
                rABSC.A_NAME = "";
                rABSC.SERNO = sSerno;
                dcHr.ABSC.InsertOnSubmit(rABSC);

                dcHr.ABS.DeleteOnSubmit(rABS);

                dcHr.SubmitChanges();
            }

            return true;
        }
        /// <summary>
        /// 存入
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="sHcode">假別</param>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sTimeB">開始時間</param>
        /// <param name="sTimeE">結束時間</param>
        /// <param name="sNote">備註</param>
        /// <param name="sKeyMan">登錄者</param>
        /// <param name="sNameA">對沖對象主鍵</param>
        /// <param name="sSerno">序號</param>
        /// <param name="sAbs1Code">公出固定採用代碼</param>
        /// <param name="sDeptsCode">成本部門代碼</param>
        /// <param name="bCalculateWorkTime">只計算上班時間</param>
        /// <param name="bCalculateRes">扣除休息時數</param>
        /// <param name="iException">例外時數 時數之總合會分配給每一天</param>
        /// <param name="bFixedCycle">循環固定時間</param>
        /// <param name="sRoteCode">班別 某些特殊會需要 預設請帶空白</param>
        /// <param name="bTime24">24小時計算</param>
        /// <returns></returns>
        public int AbsSave(string sNobr, string sHcode, DateTime dDateB, DateTime dDateE, string sTimeB, string sTimeE, string sNote = "", string sKeyMan = "System", string sNameA = "", string sSerno = "", string sAbs1Code = "O", string sDeptsCode = "", bool bCalculateWorkTime = true, bool bCalculateRes = true, decimal iException = 0, bool bFixedCycle = false, string sRoteCode = "", bool bTime24 = false)
        {
            if (bTime24)
                ConvertTime24To48(sNobr, ref dDateB, ref dDateE, ref sTimeB, ref sTimeE);

            int iDay = 0;

            Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBasetts = oBasDao.GetBasettsByNobr(sNobr, dDateB.Date).FirstOrDefault();
            sDeptsCode = sDeptsCode.Trim().Length > 0 ? sDeptsCode : rBasetts.Depts;
            sSerno = sSerno.Trim().Length > 0 ? sSerno : Guid.NewGuid().ToString();

            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHr.Connection);
            var rHcode = oHcodeDao.GetHocdeDetail(sHcode, false).FirstOrDefault();

            var rsAbs = GetAbs(sNobr, dDateB, dDateE, false);

            //計薪年月
            List<OldBll.Sal.Vdb.SalaryDateBE> lsSalaryDateBE = new List<OldBll.Sal.Vdb.SalaryDateBE>();
            OldBll.Sal.Vdb.SalaryDateBE rSalaryDateBE = new OldBll.Sal.Vdb.SalaryDateBE();
            rSalaryDateBE.Nobr = sNobr;
            rSalaryDateBE.DateB = dDateB;
            rSalaryDateBE.DateE = dDateE;
            lsSalaryDateBE.Add(rSalaryDateBE);

            OldDal.Dao.Sal.SalaryLockDao oSalaryLockDao = new Sal.SalaryLockDao(dcHr.Connection);
            var rsGetSalaryYymm = oSalaryLockDao.GetSalaryYymm(lsSalaryDateBE);

            var Vdb = GetCalculate(sNobr, sHcode, dDateB, dDateE, sTimeB, sTimeE, bCalculateWorkTime, bCalculateRes, iException, bFixedCycle, sRoteCode);

            //取得得假資料 快到期的先沖
            List<ABS> rsABST = new List<ABS>();
            var rBalance = GetBalanceNew(sNobr, dDateB, sHcode).FirstOrDefault();
            if (rBalance != null && rBalance.lsGuid.Count > 0)
            {
                rsABST = (from c in dcHr.ABS
                          where rBalance.lsGuid.Contains(c.Guid)
                          && c.Balance.GetValueOrDefault(0) > 0
                          orderby c.EDATE
                          select c).ToList();
            }

            List<ABS> rsABS = new List<ABS>();
            List<ABS1> rsABS1 = new List<ABS1>();
            List<ABSD> rsABSD = new List<ABSD>();

            foreach (var rDay in Vdb.Day)
            {
                //檢查是否重複
                var rsAbsWhere = rsAbs.Where(p => p.DateTimeB < rDay.DateTimeE && p.DateTimeE > rDay.DateTimeB);
                if (!rsAbsWhere.Any())
                {
                    string sYYMM = "";
                    var rGetSalaryYymm = rsGetSalaryYymm.Where(p => p.Nobr == sNobr && p.Date.Date == rDay.DateB.Date).FirstOrDefault();
                    if (rGetSalaryYymm != null)
                        sYYMM = rGetSalaryYymm.Yymm;

                    if (sHcode != sAbs1Code)
                    {
                        var rABS = new ABS();
                        OldBll.Tools.DefaultData.SetRowDefaultValue(rABS);
                        rABS.NOBR = sNobr;
                        rABS.BDATE = rDay.DateB;
                        rABS.EDATE = rABS.BDATE;
                        rABS.BTIME = rDay.TimeB;
                        rABS.ETIME = rDay.TimeE;
                        rABS.H_CODE = sHcode;
                        rABS.TOL_HOURS = rDay.Use;
                        rABS.KEY_MAN = sKeyMan;
                        rABS.YYMM = sYYMM;
                        rABS.NOTE = sNote;
                        rABS.SERNO = sSerno;
                        rABS.A_NAME = sNameA;
                        rABS.nocalc = false;
                        rABS.SYSCREATE1 = false;
                        rABS.Guid = Guid.NewGuid().ToString();
                        rsABS.Add(rABS);

                        decimal iUse = rDay.Use;

                        //減項資料新增
                        foreach (var rABST in rsABST)
                        {
                            if (rABST.Balance > 0)
                            {
                                var rABSD = new ABSD();
                                rABSD.ABSADD = rABST.Guid;
                                rABSD.ABSSUBTRACT = rABS.Guid;
                                rABSD.USEHOUR = iUse;
                                rABSD.KEY_MAN = sKeyMan;
                                rABSD.KEY_DATE = DateTime.Now;
                                rsABSD.Add(rABSD);

                                if (rABST.Balance >= iUse)
                                {
                                    rABST.Balance = rABST.Balance - iUse;
                                    rABST.LeaveHours = rABST.LeaveHours + iUse;
                                    break;
                                }
                                else
                                {
                                    rABSD.USEHOUR = rABST.Balance.GetValueOrDefault(0);
                                    iUse = iUse - rABST.Balance.GetValueOrDefault(0);
                                    rABST.LeaveHours = rABST.LeaveHours + rABST.Balance.GetValueOrDefault(0);
                                    rABST.Balance = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        var rABS1 = new ABS1();
                        OldBll.Tools.DefaultData.SetRowDefaultValue(rABS1);
                        rABS1.NOBR = sNobr;
                        rABS1.BDATE = rDay.DateB;
                        rABS1.EDATE = rABS1.BDATE;
                        rABS1.BTIME = rDay.TimeB;
                        rABS1.ETIME = rDay.TimeE;
                        rABS1.H_CODE = sHcode;
                        rABS1.TOL_HOURS = rDay.Use;
                        rABS1.KEY_MAN = sKeyMan;
                        rABS1.DEPT = sDeptsCode;
                        rABS1.NOTE = sNote;
                        rABS1.YYMM = sYYMM;
                        rABS1.SERNO = sSerno;
                        rsABS1.Add(rABS1);
                    }

                    iDay++;
                }
            }

            if (iDay > 0)
            {
                dcHr.ABS.InsertAllOnSubmit(rsABS);
                dcHr.ABS1.InsertAllOnSubmit(rsABS1);
                dcHr.ABSD.InsertAllOnSubmit(rsABSD);
                dcHr.SubmitChanges();

                OldDal.Dao.Att.TransCardDao oTransCardDao = new OldDal.Dao.Att.TransCardDao(dcHr.Connection);
                oTransCardDao.TransCard(sNobr, sNobr, "0", "z", dDateB, dDateE, sKeyMan, true, true, true, "", "JB-TRANSCARD", true, 3);
            }

            return iDay;
        }
        /// <summary>
        /// 取得請假資料 尚未鎖檔的
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>List AbsDataTable</returns>
        public List<AbsDataTable> GetAbsByDelete(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new Bas.BasDao(dcHr.Connection);
            var rBase = oBasDao.GetBaseByNobr(sNobr, DateTime.Now.Date).FirstOrDefault();

            if (rBase == null)
                return null;

            var Vdb1 = (from a in dcHr.ABS
                        join h in dcHr.HCODE on a.H_CODE equals h.H_CODE
                        join ba in dcHr.BASE on a.NOBR equals ba.NOBR
                        where a.NOBR == sNobr
                        && h.FLAG == "-"
                        && !(from s in dcHr.DATA_PA where s.SALADR == rBase.Saladr && s.DATA_PASS.Date == a.BDATE.Date select 1).Any()
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Name = ba.NAME_C.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            HcodeName = h.H_NAME.Trim(),
                            HcodeUnit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                            Use = a.TOL_HOURS,
                            NameA = a.A_NAME != null ? a.A_NAME.Trim() : "",
                            NoCal = a.nocalc.GetValueOrDefault(false),
                            Serno = a.SERNO.Trim(),
                        }).ToList();

            var Vdb2 = (from a in dcHr.ABS1
                        join h in dcHr.HCODE on a.H_CODE equals h.H_CODE
                        join ba in dcHr.BASE on a.NOBR equals ba.NOBR
                        where a.NOBR == sNobr
                        && !(from s in dcHr.DATA_PA where s.SALADR == rBase.Saladr && s.DATA_PASS.Date == a.BDATE.Date select 1).Any()
                        select new AbsDataTable()
                        {
                            Nobr = a.NOBR.Trim(),
                            Name = ba.NAME_C.Trim(),
                            DateB = a.BDATE.Date,
                            DateE = a.EDATE.Date,
                            TimeB = a.BTIME.Trim(),
                            TimeE = a.ETIME.Trim(),
                            Hcode = a.H_CODE.Trim(),
                            HcodeName = h.H_NAME.Trim(),
                            HcodeUnit = h.UNIT.Trim() == "天" ? OldBll.MT.mtEnum.HcodeUnit.Day : OldBll.MT.mtEnum.HcodeUnit.Hour,
                            Use = a.TOL_HOURS,
                            NameA = "",
                            NoCal = false,
                            Serno = a.SERNO.Trim(),
                        }).ToList();

            var Vdb = Vdb1.Union(Vdb2)
                .Select(a => new AbsDataTable()
                {
                    Nobr = a.Nobr.Trim(),
                    Name = a.Name.Trim(),
                    DateB = a.DateB.Date,
                    DateE = a.DateE.Date,
                    TimeB = a.TimeB.Trim(),
                    TimeE = a.TimeE.Trim(),
                    Hcode = a.Hcode.Trim(),
                    HcodeName = a.HcodeName.Trim(),
                    HcodeUnit = a.HcodeUnit,
                    Use = a.Use,
                    NameA = a.NameA,
                    NoCal = a.NoCal,
                    Serno = a.Serno.Trim(),
                    DateTimeB = a.DateB.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeB)),
                    DateTimeE = a.DateE.AddMinutes(OldBll.Tools.TimeTrans.ConvertHhMmToMinutes(a.TimeE)),
                }).ToList();

            return Vdb;
        }
    }
}