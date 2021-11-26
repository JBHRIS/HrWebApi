using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBModule.Data.Dto;
using JBHRIS.BLL.Repo;
namespace JBModule.Data.Repo
{
    public class AbsRepo : ObjectRepo, IAbsRepo
    {
        public AbsRepo()
        {
            db = JBModule.Data.Linq.DcHelper.GetHrDBDataContext();
        }
        public AbsRepo(System.Data.IDbConnection connection)
        {
            db = new JBModule.Data.Linq.HrDBDataContext(connection);
        }
        public AbsRepo(JBModule.Data.Linq.HrDBDataContext context)
        {
            db = context;
        }

        public bool UpdateAbs(JBModule.Data.Linq.ABS Abs, out string Msg)
        {
            Msg = "";
            if (db.Connection.State != System.Data.ConnectionState.Open)
                db.Connection.Open();
            db.Transaction = db.Connection.BeginTransaction();
            using (db.Transaction)
            {
                try
                {
                    Linq.DcHelper.Detach(Abs);
                    var orignal_abs = GetAbsByGuid(Abs.Guid);
                    if (orignal_abs == null)
                    {
                        Msg = "找不到要更新的資料";
                        return false;
                    }
                    //update
                    {
                        orignal_abs.Balance = Abs.Balance;
                        orignal_abs.BDATE = Abs.BDATE;
                        orignal_abs.BTIME = Abs.BTIME;
                        orignal_abs.EDATE = Abs.EDATE;
                        orignal_abs.ETIME = Abs.ETIME;
                        orignal_abs.Guid = Abs.Guid;
                        orignal_abs.H_CODE = Abs.H_CODE;
                        orignal_abs.KEY_DATE = Abs.KEY_DATE;
                        orignal_abs.KEY_MAN = Abs.KEY_MAN;
                        orignal_abs.LeaveHours = Abs.LeaveHours;
                        orignal_abs.NOTE = Abs.NOTE;
                        orignal_abs.SERNO = Abs.SERNO;
                        orignal_abs.TOL_HOURS = Abs.TOL_HOURS;
                        orignal_abs.YYMM = Abs.YYMM;
                    }
                    var hcode = GetHcode(Abs.H_CODE);
                    if (hcode == null)
                    {
                        Msg = "無效的假別代碼" + Abs.H_CODE;
                        return false;
                    }
                    if (hcode.FLAG == "+")//來源為得假
                    {
                        var absdList = GetAbsd(Abs.Guid, true);
                        if (absdList.Any())//已經衝過假
                        {
                            if (Abs.TOL_HOURS < absdList.Sum(p => p.USEHOUR))
                            {
                                Msg = "時數不足";
                                return false;
                            }
                        }
                    }
                    else
                    {
                        var absdList = GetAbsd(Abs.Guid, false);
                        var absList = GetAbsByGuid(absdList.Select(p => p.ABSADD).ToList());
                        RemoveAbsD(absList, absdList);
                        db.ABSD.DeleteAllOnSubmit(absdList);

                        var absdList_U = SetAbsd(absList, Abs, out Msg);
                        if (absdList_U == null)
                        {
                            var entitles = GetAbsEntitle(Abs).Where(p => p.Balance > 0).ToList();
                            absdList_U = SetAbsd(entitles, Abs, out Msg);
                            if (absdList_U == null)
                                return false;
                        }
                        db.ABSD.InsertAllOnSubmit(absdList_U);
                    }
                    db.SubmitChanges();
                    db.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Msg = ex.Message;
                    db.Transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        public bool DeleteAbs(JBModule.Data.Linq.ABS Abs, out string Msg)
        {
            Msg = "";
            db.ABS.DeleteOnSubmit(Abs);
            var hcode = GetHcode(Abs.H_CODE);
            if (hcode == null)
            {
                Msg = "無效的假別代碼" + Abs.H_CODE;
                return false;
            }
            if (hcode.FLAG == "+")//來源為得假
            {
                var absdList = GetAbsd(Abs.Guid, true);
                db.ABSD.DeleteAllOnSubmit(absdList);
            }
            else
            {
                var absdList = GetAbsd(Abs.Guid, false);
                var absList = GetAbsByGuid(absdList.Select(p => p.ABSADD).ToList());
                RemoveAbsD(absList, absdList);
                db.ABSD.DeleteAllOnSubmit(absdList);
            }
            db.SubmitChanges();

            return true;
        }
        public bool RemoveAbsD(List<JBModule.Data.Linq.ABS> AbsEntitleList, List<JBModule.Data.Linq.ABSD> AbsdList)
        {
            foreach (var it in AbsdList)
            {
                var absEntitleOfAbsd = AbsEntitleList.SingleOrDefault(p => p.Guid == it.ABSADD);
                if (absEntitleOfAbsd != null)
                {
                    if (absEntitleOfAbsd.LeaveHours == null) absEntitleOfAbsd.LeaveHours = 0;//避免exception
                    absEntitleOfAbsd.LeaveHours -= it.USEHOUR;
                    absEntitleOfAbsd.Balance = absEntitleOfAbsd.TOL_HOURS - absEntitleOfAbsd.LeaveHours.Value;
                }
            }
            return true;
        }
        public List<JBModule.Data.Linq.ABS> GetAbsByGuid(List<string> GuidList)
        {
            var sql = from a in db.ABS where GuidList.Contains(a.Guid) select a;
            return sql.ToList();
        }

        public List<JBModule.Data.Linq.ABSD> GetAbsd(string Guid, bool IsEntitle)
        {
            var sql = from a in db.ABSD select a;
            if (IsEntitle) sql = from a in sql where a.ABSADD == Guid select a;
            else sql = from a in sql where a.ABSSUBTRACT == Guid select a;
            return sql.ToList();
        }
        public JBModule.Data.Linq.ABS ConvertAbsTakenDtoToAbs(JBHRIS.BLL.Dto.AbsTakenDto AbsTaken, out string Msg)
        {
            Msg = "";
            JBModule.Data.Linq.ABS Abs = new Linq.ABS();
            Abs.A_NAME = "";
            Abs.Balance = 0;
            Abs.BDATE = AbsTaken.AttendDate;
            Abs.EDATE = AbsTaken.AttendDate;
            Abs.BTIME = AbsTaken.BeginTime.TimeStringBy48HR(AbsTaken.AttendDate);
            Abs.ETIME = AbsTaken.EndTime.TimeStringBy48HR(AbsTaken.AttendDate);
            Abs.Guid = Guid.NewGuid().ToString();
            Abs.H_CODE = AbsTaken.Hcode;
            Abs.KEY_DATE = DateTime.Now;
            Abs.KEY_MAN = AbsTaken.CreateMan;
            Abs.LeaveHours = 0;
            Abs.NOBR = AbsTaken.EmployeeID;
            Abs.nocalc = false;
            Abs.NOTE = AbsTaken.Remark;
            Abs.NOTEDIT = false;
            Abs.SERNO = AbsTaken.Serno;
            Abs.SYSCREATE = AbsTaken.Syscreate;
            Abs.SYSCREATE1 = false;
            Abs.TOL_DAY = 0;
            Abs.TOL_HOURS = AbsTaken.Taken;
            Abs.YYMM = AbsTaken.YYMM;
            return Abs;
        }
        public JBModule.Data.Linq.ABS ConvertAbsEntitleDtoToAbs(AbsEntitleDto AbsEntitle, out string Msg)
        {
            Msg = "";
            JBModule.Data.Linq.ABS Abs = new Linq.ABS();
            Abs.A_NAME = "";
            Abs.BDATE = AbsEntitle.BeginDate;
            Abs.EDATE = AbsEntitle.EndDate;
            Abs.BTIME = AbsEntitle.SubKey;
            Abs.ETIME = "";
            Abs.Guid = Guid.NewGuid().ToString();
            Abs.H_CODE = AbsEntitle.Hcode;
            Abs.KEY_DATE = DateTime.Now;
            Abs.KEY_MAN = AbsEntitle.CreateMan;
            Abs.LeaveHours = 0;
            Abs.NOBR = AbsEntitle.EmployeeID;
            Abs.nocalc = false;
            Abs.NOTE = AbsEntitle.Remark;
            Abs.NOTEDIT = false;
            Abs.SERNO = AbsEntitle.Serno;
            Abs.SYSCREATE = false;
            Abs.SYSCREATE1 = false;
            Abs.TOL_DAY = 0;
            Abs.TOL_HOURS = AbsEntitle.Taken != null ? AbsEntitle.Taken.Value : 0;
            Abs.Balance = Abs.TOL_HOURS - Abs.LeaveHours;
            Abs.YYMM = AbsEntitle.YYMM;
            return Abs;
        }

        public bool InsertAbs(JBHRIS.BLL.Dto.AbsTakenDto absTaken, out string Msg)
        {
            Msg = "";
            var Abs = ConvertAbsTakenDtoToAbs(absTaken, out Msg);
            Linq.DcHelper.Detach(Abs);
            if (CheckConflict(absTaken, out Msg))
            {
                return false;
            }
            var rHcode = GetHcode(absTaken.Hcode);
            if (rHcode.MANG)
            {
                if (Abs.BTIME == "0000" || Abs.BTIME.Trim().Length == 0)
                    Abs.BTIME = "0000" + DateTime.Now.ToOADate().ToString();
                Abs.SERNO = absTaken.Field01 != null ? absTaken.Field01.ToString() : "";
            }
            var entitles = GetAbsEntitle(Abs);
            var absdList = SetAbsd(entitles, Abs, out Msg);
            if (absdList == null)
            {
                return false;
            }
            Abs.SERNO = "";
            db.ABSD.InsertAllOnSubmit(absdList);
            db.ABS.InsertOnSubmit(Abs);
            db.SubmitChanges();

            return true;
        }
        public bool InsertAbsEntitle(JBModule.Data.Linq.ABS Abs, out string Msg)
        {
            Msg = "";
            //if (!CheckConflict(Abs, out Msg))
            //{
            //    return false;
            //}
            //var entitles = GetAbsEntitle(Abs);
            //var absdList = SetAbsd(entitles, Abs, out Msg);
            //if (absdList == null)
            //{
            //    return false;
            //}
            //db.ABSD.InsertAllOnSubmit(absdList);

            db.ABS.InsertOnSubmit(Abs);
            db.SubmitChanges();

            return true;
        }
        public List<Linq.ABSD> SetAbsd(List<JBModule.Data.Linq.ABS> AbsEntitles, JBModule.Data.Linq.ABS AbsTaken, out string Msg)
        {
            Msg = "";
            List<Linq.ABSD> AbsdList = new List<Linq.ABSD>();
            var hcodeTaken = db.HCODE.Single(p => p.H_CODE == AbsTaken.H_CODE);
            if (!hcodeTaken.CHE) return AbsdList;//不檢查
            var hcodeList = db.HCODE.Where(p => p.FLAG == "+").ToList();
            var totalhrs = AbsEntitles.Sum(p => p.Balance.Value);
            if (totalhrs < AbsTaken.TOL_HOURS)
            {
                Msg = "時數不足";
                return null;
            }
            var absListOrderBy = (from a in AbsEntitles
                                  join b in hcodeList on a.H_CODE.Trim() equals b.H_CODE.Trim()
                                  orderby b.SORT
                                  select a).ToList();
            if (hcodeTaken.MANG && AbsTaken.SERNO.Trim().Length > 0)//如有指定
                absListOrderBy = absListOrderBy.Where(p => p.Guid == AbsTaken.SERNO).ToList();
            //var absListOrderBy = AbsEntitles.Where(p => p.Balance > 0).OrderBy(p => p.EDATE)
            //    .OrderBy(p => hcodeList.Single(pp => pp.H_CODE == p.H_CODE).SORT);
            decimal AbsTakenHours = AbsTaken.TOL_HOURS;
            foreach (var it in absListOrderBy)
            {
                decimal AbsdUseHours = 0;
                if (it.Balance > AbsTakenHours)
                {
                    AbsdUseHours = AbsTakenHours;
                    it.Balance -= AbsdUseHours;
                    it.LeaveHours += AbsdUseHours;
                    AbsTakenHours -= AbsdUseHours;
                }
                else
                {
                    AbsdUseHours = it.Balance.Value;
                    it.LeaveHours += AbsdUseHours;
                    AbsTakenHours -= AbsdUseHours;
                    it.Balance -= AbsdUseHours;
                }
                Linq.ABSD absd = new Linq.ABSD();
                absd.ABSADD = it.Guid;
                absd.ABSSUBTRACT = AbsTaken.Guid;
                absd.KEY_DATE = DateTime.Now;
                absd.KEY_MAN = AbsTaken.KEY_MAN;
                absd.USEHOUR = AbsdUseHours;
                AbsdList.Add(absd);
                if (AbsTakenHours == 0)
                    break;

            }

            if (AbsTakenHours > 0)
            {
                if (hcodeTaken.CHE)
                {
                    Msg = "沖假時數不足";
                    return null;
                }
                else
                {
                    foreach (var it in absListOrderBy)
                    {
                        decimal AbsdUseHours = 0;

                        AbsdUseHours = AbsTakenHours;
                        it.Balance -= AbsdUseHours;
                        it.LeaveHours += AbsdUseHours;
                        AbsTakenHours -= AbsdUseHours;

                        Linq.ABSD absd = new Linq.ABSD();
                        absd.ABSADD = it.Guid;
                        absd.ABSSUBTRACT = AbsTaken.Guid;
                        absd.KEY_DATE = DateTime.Now;
                        absd.KEY_MAN = AbsTaken.KEY_MAN;
                        absd.USEHOUR = AbsdUseHours;
                        AbsdList.Add(absd);
                        if (AbsTakenHours == 0) break;
                    }
                }
            }
            return AbsdList;
        }
        public JBModule.Data.Linq.ABS GetAbsByGuid(string Guid)
        {
            var sql = from a in db.ABS where a.Guid == Guid select a;
            return sql.FirstOrDefault();
        }
        public List<JBModule.Data.Linq.ABS> GetAbsEntitle(JBHRIS.BLL.Dto.AbsTakenDto AbsTaken)
        {
            string Msg = "";
            var abs = ConvertAbsTakenDtoToAbs(AbsTaken, out Msg);
            var sql = GetAbsEntitle(abs);
            return sql;
        }
        public List<JBModule.Data.Linq.ABS> GetAbsEntitle(Linq.ABS AbsTaken)
        {
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      join c in db.HCODE on b.HTYPE equals c.HTYPE
                      where c.H_CODE == AbsTaken.H_CODE
                      && b.FLAG == "+"
                      && a.NOBR == AbsTaken.NOBR
                      && AbsTaken.BDATE >= a.BDATE && AbsTaken.BDATE <= a.EDATE
                      select a;
            return sql.ToList();
        }
        public List<JBModule.Data.Linq.ABS> GetAbsEntitle(List<string> EmployeeList, DateTime Adate, List<string> HcodeTypeList)
        {
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      where HcodeTypeList.Contains(b.HTYPE)
                      && b.FLAG == "+"
                      && EmployeeList.Contains(a.NOBR)
                      && Adate >= a.BDATE && Adate <= a.EDATE
                      select a;
            return sql.ToList();
        }
        public bool CheckConflict(JBHRIS.BLL.Dto.AbsTakenDto entity, out string Msg)
        {
            Msg = "";
            var Abs = ConvertAbsTakenDtoToAbs(entity, out Msg);
            var rHcode = GetHcode(Abs.H_CODE);
            if (rHcode != null)
            {

                JBModule.Data.Linq.ROTE rote = null;
                if (!rHcode.MANG)
                {
                    var sqlAttend = from a in db.ATTEND
                                    join b in db.ROTE on a.ROTE equals b.ROTE1
                                    where a.NOBR == Abs.NOBR && a.ADATE == Abs.BDATE
                                    select b;
                    if (sqlAttend.Any())
                    {
                        rote = sqlAttend.First();
                    }
                    else
                    {
                        Msg = "申請日當天無出勤資料";
                        return true;
                    }

                    var sqlRepeat = from a in db.ABS
                                    join b in db.HCODE on a.H_CODE equals b.H_CODE
                                    where a.NOBR == Abs.NOBR && a.BDATE == Abs.BDATE
                                    && b.FLAG == "-"
                                    && a.BTIME.CompareTo(Abs.ETIME) < 0 && a.ETIME.CompareTo(Abs.BTIME) > 0
                                    select a;
                    if (sqlRepeat.Any())
                    {
                        Msg = "申請時段已有請假資料";
                        return true;
                    }
                }
                var entitles = GetAbsEntitle(Abs);

                if (rHcode.CHE)
                {
                    decimal Entitle = entitles.Sum(pp => pp.TOL_HOURS);
                    if (Entitle < Abs.TOL_HOURS)
                    {
                        Msg = "時數不足";
                        return true;
                    }
                }
            }
            else
            {
                Msg = "無效的假別代碼";
                return true;
            }

            return false;
        }
        public List<JBModule.Data.Linq.HcodeType> GetHcodeTypeList()
        {
            return db.HcodeType.ToList();
        }
        public JBModule.Data.Linq.HcodeType GetHcodeType(string Htype)
        {
            return db.HcodeType.SingleOrDefault(p => p.HTYPE == Htype);
        }
        public List<JBModule.Data.Linq.HCODE> GetHcodeList()
        {
            return db.HCODE.ToList();
        }
        public JBModule.Data.Linq.HCODE GetHcode(string Hcode)
        {
            return db.HCODE.SingleOrDefault(p => p.H_CODE == Hcode);
        }

        #region IAbsRepo 成員

        public bool Insert(JBHRIS.BLL.Dto.AbsTakenDto entity, out string msg)
        {
            msg = "";
            //var ConflictAbsList = GetConflictAbsTaken(entity);
            //if (ConflictAbsList.Any())
            //{
            //    msg = "已存在重疊時段的請假資料";
            //    return false;
            //}
            //var Abs = ConvertAbsTakenDtoToAbs(entity, out msg);
            return InsertAbs(entity, out msg);
        }

        public bool Update(JBHRIS.BLL.Dto.AbsTakenDto entity, out string msg)
        {
            msg = "";
            var Abs = GetAbsByGuid(entity.Guid);
            return UpdateAbs(Abs, out msg);
        }

        public bool Delete(JBHRIS.BLL.Dto.AbsTakenDto entity, out string msg)
        {
            msg = "";
            var Abs = GetAbsByGuid(entity.Guid);
            return DeleteAbs(Abs, out msg);
        }

        public List<JBHRIS.BLL.Dto.AbsTakenDto> GetAbsTakenByEmployeeListDate(List<string> EmployeeIdList, DateTime DateBegin, DateTime DateEnd)
        {
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      where b.FLAG == "-"
                      && EmployeeIdList.Contains(a.NOBR) && a.BDATE >= DateBegin && a.EDATE <= DateEnd
                      select new JBHRIS.BLL.Dto.AbsTakenDto
                      {
                          AttendDate = a.BDATE,
                          BeginTime = a.BDATE.AddTime(a.BTIME),
                          EndTime = a.BDATE.AddTime(a.ETIME),
                          CreateMan = a.KEY_MAN,
                          EmployeeID = a.NOBR,
                          Guid = a.Guid,
                          Hcode = a.H_CODE,
                          PrimaryKey = a.Guid,
                          Remark = a.NOTE,
                          Serno = a.SERNO,
                          Taken = a.TOL_HOURS,
                          YYMM = a.YYMM,
                          Syscreate = a.SYSCREATE,
                      };
            return sql.ToList();
        }
        public List<JBHRIS.BLL.Dto.AbsTakenDto> GetAbsTakenByEmployeeListDateTime(List<string> EmployeeIdList, DateTime TimeBegin, DateTime TimeEnd)
        {
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      where b.FLAG == "-" && b.MANG
                      && EmployeeIdList.Contains(a.NOBR) && a.BDATE >= TimeBegin.Date.AddDays(-1) && a.EDATE <= TimeEnd.Date
                      select new JBHRIS.BLL.Dto.AbsTakenDto
                      {
                          AttendDate = a.BDATE,
                          BeginTime = a.BDATE.AddTime(a.BTIME),
                          EndTime = a.BDATE.AddTime(a.ETIME),
                          CreateMan = a.KEY_MAN,
                          EmployeeID = a.NOBR,
                          Guid = a.Guid,
                          Hcode = a.H_CODE,
                          PrimaryKey = a.Guid,
                          Remark = a.NOTE,
                          Serno = a.SERNO,
                          Taken = a.TOL_HOURS,
                          YYMM = a.YYMM,
                          Syscreate = a.SYSCREATE,
                      };
            var data = from a in sql.ToList()
                       where a.BeginTime < TimeEnd && a.EndTime > TimeBegin
                       select a;
            return data.ToList();
        }
        public JBModule.Data.Linq.ROTE GetRote(string EmployeeID, DateTime Adate)
        {
            var sql = from a in db.ATTEND
                      join b in db.ROTE on a.ROTE equals b.ROTE1
                      where a.NOBR == EmployeeID && a.ADATE == Adate
                      select b;
            return sql.FirstOrDefault();
        }
        public decimal GetAbsHours(JBHRIS.BLL.Dto.AbsTakenDto entity)
        {
            var rRote = GetRote(entity.EmployeeID, entity.AttendDate);
            if (rRote == null) return 0;
            JBTools.Intersection its = new JBTools.Intersection();
            its.Inert(entity.BeginTime, entity.EndTime);
            its.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
            decimal FullHours = its.GetHours();
            decimal RestHours = 0;
            if (rRote.RES_B_TIME.Trim().Length == 4 || rRote.RES_E_TIME.Trim().Length == 4)
            {
                JBTools.Intersection itsRest = new JBTools.Intersection();
                itsRest.Inert(entity.BeginTime, entity.EndTime);
                itsRest.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
                itsRest.Inert(entity.AttendDate.AddTime(rRote.RES_B_TIME), entity.AttendDate.AddTime(rRote.RES_E_TIME));
                RestHours += itsRest.GetHours();
            }
            if (rRote.RES_B1_TIME.Trim().Length == 4 || rRote.RES_E1_TIME.Trim().Length == 4)
            {
                JBTools.Intersection itsRest = new JBTools.Intersection();
                itsRest.Inert(entity.BeginTime, entity.EndTime);
                itsRest.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
                itsRest.Inert(entity.AttendDate.AddTime(rRote.RES_B1_TIME), entity.AttendDate.AddTime(rRote.RES_E1_TIME));
                RestHours += itsRest.GetHours();
            }
            if (rRote.RES_B2_TIME.Trim().Length == 4 || rRote.RES_E2_TIME.Trim().Length == 4)
            {
                JBTools.Intersection itsRest = new JBTools.Intersection();
                itsRest.Inert(entity.BeginTime, entity.EndTime);
                itsRest.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
                itsRest.Inert(entity.AttendDate.AddTime(rRote.RES_B2_TIME), entity.AttendDate.AddTime(rRote.RES_E2_TIME));
                RestHours += itsRest.GetHours();
            }
            if (rRote.RES_B3_TIME.Trim().Length == 4 || rRote.RES_E3_TIME.Trim().Length == 4)
            {
                JBTools.Intersection itsRest = new JBTools.Intersection();
                itsRest.Inert(entity.BeginTime, entity.EndTime);
                itsRest.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
                itsRest.Inert(entity.AttendDate.AddTime(rRote.RES_B3_TIME), entity.AttendDate.AddTime(rRote.RES_E3_TIME));
                RestHours += itsRest.GetHours();
            }
            if (rRote.RES_B4_TIME.Trim().Length == 4 || rRote.RES_E4_TIME.Trim().Length == 4)
            {
                JBTools.Intersection itsRest = new JBTools.Intersection();
                itsRest.Inert(entity.BeginTime, entity.EndTime);
                itsRest.Inert(entity.AttendDate.AddTime(rRote.ON_TIME), entity.AttendDate.AddTime(rRote.OFF_TIME));
                itsRest.Inert(entity.AttendDate.AddTime(rRote.RES_B4_TIME), entity.AttendDate.AddTime(rRote.RES_E4_TIME));
                RestHours += itsRest.GetHours();
            }
            decimal AbsHours = FullHours - RestHours;
            var rHcode = GetHcode(entity.Hcode);
            if (AbsHours > 0 && rHcode != null)
            {
                if (rHcode.MIN_NUM > AbsHours)
                    AbsHours = rHcode.MIN_NUM;
                else
                {
                    decimal hrs = AbsHours - rHcode.MIN_NUM;
                    var hrs1 = JBTools.NumbericConvert.RangeInterval(hrs, rHcode.ABSUNIT, JBTools.NumbericConvert.DigitalMode.Ceiling);
                    AbsHours = rHcode.MIN_NUM + hrs1;
                }
                if (rHcode.UNIT == "天")
                    AbsHours = JBTools.NumbericConvert.RangeInterval(AbsHours / rRote.WK_HRS, rHcode.ABSUNIT, JBTools.NumbericConvert.DigitalMode.Ceiling);
            }
            return AbsHours;
        }

        public List<JBHRIS.BLL.Dto.AbsTakenDto> GetConflictAbsTaken(JBHRIS.BLL.Dto.AbsTakenDto entity)
        {
            return GetAbsTakenByEmployeeListDateTime(new List<string> { entity.EmployeeID }, entity.BeginTime, entity.EndTime);
        }

        #endregion
    }
}
