using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using JBHR.Dto;
using JBModule.Data.Linq;

namespace JBHR.Repo
{
    public class AttRepo
    {
        private readonly List<RoteDto> _RoteDtoList = new List<RoteDto>();

        public AttRepo()
        {
            _RoteDtoList = GetRoteAll();
        }

        public RoteDto GetRote(string rote)
        {
            return _RoteDtoList.Where(p => p.Rote == rote).FirstOrDefault();
        }

        public static DataTable GetRote(bool withHoliday = true, bool ShowHide = true)
        {
            var db = new HrDBDataContext();
            var sql = from a in db.ROTE
                      where (withHoliday || a.ROTE1 != "00")
                            && (ShowHide || a.SORT > 0)
                      orderby a.ROTE_DISP
                      orderby a.SORT
                      select new
                      {
                          _ROTE = a.ROTE1,
                          班別代碼 = a.ROTE_DISP,
                          班別名稱 = a.ROTENAME,
                          上班時間 = a.ON_TIME,
                          下班時間 = a.OFF_TIME
                      };
            return sql.CopyToDataTable();
        }

        public static DataTable GetHcodeType(List<string> HtypeList = null)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HcodeType
                      where db.GetCodeFilter("HcodeType", a.HTYPE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      select new
                      {
                          _HTYPE = a.HTYPE,
                          假別種類代碼 = a.HTYPE_DISP,
                          假別種類名稱 = a.TYPE_NAME,
                      };
            if (HtypeList != null)
                sql = sql.Where(p => HtypeList.Contains(p._HTYPE));
            return sql.CopyToDataTable();
        }

        public static List<RoteDto> GetRoteAll()
        {
            var db = new HrDBDataContext();
            var sql = (from a in db.ROTE
                       orderby a.ROTE_DISP
                       orderby a.SORT
                       select new RoteDto
                       {
                           Rote = a.ROTE1,
                           RoteDisp = a.ROTE_DISP,
                           RoteName = a.ROTENAME,
                           OffTime = a.OFF_TIME,
                           OnTime = a.ON_TIME,
                           WorkHours = a.WK_HRS,
                           RestTimes = new Dictionary<string, string>(),
                           FlexMinutes = Convert.ToInt32(a.ALLLATES1),
                       }).ToList();
            foreach (var it in sql)
            {
                it.RestTimes = new Dictionary<string, string>();
                var rote = db.ROTE.SingleOrDefault(p => p.ROTE1 == it.Rote);
                if (!it.RestTimes.ContainsKey(rote.RES_B_TIME) && rote.RES_B_TIME.Trim().Length > 0 &&
                    rote.RES_E_TIME.Trim().Length > 0)
                    it.RestTimes.Add(rote.RES_B_TIME, rote.RES_E_TIME);
                if (!it.RestTimes.ContainsKey(rote.RES_B1_TIME) && rote.RES_B1_TIME.Trim().Length > 0 &&
                    rote.RES_E1_TIME.Trim().Length > 0)
                    it.RestTimes.Add(rote.RES_B1_TIME, rote.RES_E1_TIME);
                if (!it.RestTimes.ContainsKey(rote.RES_B2_TIME) && rote.RES_B2_TIME.Trim().Length > 0 &&
                    rote.RES_E2_TIME.Trim().Length > 0)
                    it.RestTimes.Add(rote.RES_B2_TIME, rote.RES_E2_TIME);
                if (!it.RestTimes.ContainsKey(rote.RES_B3_TIME) && rote.RES_B3_TIME.Trim().Length > 0 &&
                    rote.RES_E3_TIME.Trim().Length > 0)
                    it.RestTimes.Add(rote.RES_B3_TIME, rote.RES_E3_TIME);
                if (!it.RestTimes.ContainsKey(rote.RES_B4_TIME) && rote.RES_B4_TIME.Trim().Length > 0 &&
                    rote.RES_E4_TIME.Trim().Length > 0)
                    it.RestTimes.Add(rote.RES_B4_TIME, rote.RES_E4_TIME);
            }

            return sql.ToList();
        }

        public static List<HcodeDto> GetHcode(bool withHoliday = true, bool ShowHide = true)
        {
            var db = new HrDBDataContext();
            var sql = from a in db.HCODE
                      where a.FLAG == "-"
                      select new HcodeDto
                      {
                          Hcode = a.H_CODE,
                          HcodeDisp = a.H_CODE_DISP,
                          HcodeGroup = a.HTYPE,
                          HcodeName = a.H_NAME,
                          Unit = a.UNIT,
                          Min = a.MIN_NUM,
                          Interval = a.ABSUNIT
                      };
            return sql.ToList();
        }

        public static HcodeDto GetHcode(string hcode)
        {
            var db = new HrDBDataContext();
            var sql = from a in db.HCODE
                      where a.H_CODE == hcode
                      select new HcodeDto
                      {
                          Hcode = a.H_CODE,
                          HcodeDisp = a.H_CODE_DISP,
                          HcodeGroup = a.HTYPE,
                          HcodeName = a.H_NAME,
                          Unit = a.UNIT,
                          Min = a.MIN_NUM,
                          Interval = a.ABSUNIT
                      };
            return sql.First();
        }

        public static List<AttendDto> GetAttend(List<string> EmployeeIdList, DateTime DateBegin, DateTime DateEnd,
            List<string> RoteList)
        {
            var i = 0;
            var size = 1000;
            var result = new List<AttendDto>();
            do
            {
                var lst = EmployeeIdList.Skip(i).Take(size).ToList();
                result.AddRange(_GetAttend(lst, DateBegin, DateEnd, RoteList));
                i += size;
            } while (i < EmployeeIdList.Count());

            return result;
        }

        private static List<AttendDto> _GetAttend(List<string> EmployeeIdList, DateTime DateBegin, DateTime DateEnd,
            List<string> RoteList)
        {
            var db = new HrDBDataContext();
            var ATTCARDs = (from x in db.ATTCARD
                            where EmployeeIdList.Contains(x.NOBR)
                                  && x.ADATE >= DateBegin && x.ADATE <= DateEnd
                            select new { x.NOBR, x.ADATE, x.T1, x.T2 }).ToList();
            var ABSs = (from x in db.ABS
                        join b in db.HCODE on x.H_CODE equals b.H_CODE
                        where EmployeeIdList.Contains(x.NOBR)
                              && x.BDATE >= DateBegin && x.BDATE <= DateEnd
                        select new { x.NOBR, ADATE = x.BDATE, T1 = x.BTIME, T2 = x.ETIME }).ToList();

            var sql = (from a in db.ATTEND
                       join b in db.BASE on a.NOBR equals b.NOBR
                       join c in db.ROTE on a.ROTE equals c.ROTE1
                       where EmployeeIdList.Contains(a.NOBR)
                             && a.ADATE >= DateBegin && a.ADATE <= DateEnd
                             && RoteList.Contains(a.ROTE)
                       select new AttendDto
                       {
                           EmployeeID = a.NOBR,
                           EmployeeName = b.NAME_C,
                           ABS = a.ABS,
                           AttendDate = a.ADATE,
                           EarilyMins = Convert.ToInt32(a.E_MINS),
                           Rote = c.ROTE1,
                           TimeBegin = a.ADATE.AddTime(c.ON_TIME),
                           LateMins = Convert.ToInt32(a.LATE_MINS),
                           TimeEnd = a.ADATE.AddTime(c.OFF_TIME),
                           RoteName = c.ROTENAME,
                           AttRecords = new List<Tuple<string, string>>(),
                           WorkHours = c.WK_HRS
                       }).ToList();
            foreach (var it in sql)
            {
                var absOfNobr = ABSs.Where(p => p.ADATE == it.AttendDate && p.NOBR == it.EmployeeID);
                var attcardOfNobr = ATTCARDs.Where(p => p.ADATE == it.AttendDate && p.NOBR == it.EmployeeID);
                it.AttRecords = new List<Tuple<string, string>>();
                it.AttRecords.AddRange(absOfNobr.Select(p => new Tuple<string, string>(p.T1, p.T2)));
                it.AttRecords.AddRange(attcardOfNobr.Select(p => new Tuple<string, string>(p.T1, p.T2)));
                it.CardTimeBegin = it.AttRecords.Any()
                    ? it.AttendDate.AddTime(it.AttRecords.Min(p => p.Item1))
                    : new DateTime?();
                it.CardTimeEnd = it.AttRecords.Any()
                    ? it.AttendDate.AddTime(it.AttRecords.Max(p => p.Item2))
                    : new DateTime?();
            }

            return sql.ToList();
        }
    }
}