using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class AbsenceRepo
    {
        public AbsenceRepo()
        {

        }

        public static List<Dto.AbsenceDto> GetAbsTakenByEntitleGuid(string EntitleGuid)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var sql = from a in db.ABS
                      join b in db.ABSD on a.Guid equals b.ABSSUBTRACT
                      join c in db.HCODE on a.H_CODE equals c.H_CODE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      where b.ABSADD == EntitleGuid
                      select new Dto.AbsenceDto { Adate = a.BDATE.Date, BeginTime = a.BDATE.Date.AddTime(a.BTIME), EndTime = a.BDATE.Date.AddTime(a.ETIME), Guid = a.Guid, Hcode = a.H_CODE, Memo = a.NOTE, Nobr = a.NOBR, Serno = a.SERNO, Taken = b.USEHOUR, Hname = c.H_NAME, Unit = c.UNIT, NameC = d.NAME_C, HcodeDisp = c.H_CODE_DISP };
            return sql.ToList();

        }
        public static List<Dto.AbsenceDto> GetAbsTakenByByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList, List<string> HtypeList = null)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            if (HtypeList == null)
                HtypeList = db.HcodeType.Select(p => p.HTYPE).ToList();
            var sql = from a in db.ABS
                      join c in db.HCODE on a.H_CODE equals c.H_CODE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      where c.FLAG == "-"
                      && (EmployeeIdList.Contains(a.NOBR))
                      && (HtypeList == null || HtypeList.Contains(c.HTYPE))
                      && DateBegin <= a.EDATE && DateEnd >= a.BDATE
                      select new Dto.AbsenceDto { Adate = a.BDATE.Date, BeginTime = a.BDATE.Date.AddTime(a.BTIME), EndTime = a.BDATE.Date.AddTime(a.ETIME), Guid = a.Guid, Hcode = a.H_CODE, Memo = a.NOTE, Nobr = a.NOBR, Serno = a.SERNO, Taken = a.TOL_HOURS, Hname = c.H_NAME, Unit = c.UNIT, NameC = d.NAME_C, HcodeDisp = c.H_CODE_DISP };
            return sql.ToList();

        }
        public static List<Dto.AbsenceDetail> GetAbsEntitleByTakenGuid(string TakenGuid)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var sql = from a in db.ABS
                      join b in db.ABSD on a.Guid equals b.ABSADD
                      join c in db.HCODE on a.H_CODE equals c.H_CODE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      where b.ABSSUBTRACT == TakenGuid
                      select new Dto.AbsenceDetail { Balance = a.Balance.GetValueOrDefault(0), BeginDate = a.BDATE, EndDate = a.EDATE, Entitled = a.TOL_HOURS, HCode = c.H_CODE, HCodeDisp = c.H_CODE_DISP, HName = c.H_NAME, NameC = d.NAME_C, Nobr = a.NOBR, Taken = a.LeaveHours.GetValueOrDefault(0), Unit = c.UNIT };
            return sql.ToList();
        }
        public static List<Dto.AbsenceDetail> GetAbsEntitleByEmployeeIdList(DateTime DateBegin, DateTime DateEnd, bool WithFlowData, List<string> EmployeeIdList = null, List<string> HtypeList = null)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            if (HtypeList == null)
                HtypeList = db.HcodeType.Select(p => p.HTYPE).ToList();
            var sql = from a in db.ABS
                      join c in db.HCODE on a.H_CODE equals c.H_CODE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      join f in db.HcodeType on c.HTYPE equals f.HTYPE
                      where c.FLAG == "+"
                      && (EmployeeIdList.Contains(a.NOBR))
                       && (HtypeList == null || HtypeList.Contains(c.HTYPE))
                       && DateBegin <= a.EDATE && DateEnd >= a.BDATE
                      select new Dto.AbsenceDetail { Balance = a.Balance.GetValueOrDefault(0), BeginDate = a.BDATE, EndDate = a.EDATE, Entitled = a.TOL_HOURS, HCode = c.H_CODE, HCodeDisp = c.H_CODE_DISP, HName = c.H_NAME, NameC = d.NAME_C, Nobr = a.NOBR, Taken = a.LeaveHours.GetValueOrDefault(0), Unit = c.UNIT, Guid = a.Guid };
            return sql.ToList();
        }

    }
}
