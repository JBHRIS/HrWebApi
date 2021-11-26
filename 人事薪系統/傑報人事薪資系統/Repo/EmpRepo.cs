using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using JBTools.Extend;

namespace JBHR.Repo
{
    public class EmpRepo
    {
        public static DataTable GetEmpAllWithDept()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      join e in db.MTCODE on b.TTSCODE equals e.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && e.CATEGORY == "TTSCODE"
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR
                      orderby JobState
                      select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
            return sql.CopyToDataTable();
        }

        public static DataTable GetEmpAllWithDept(DateTime CheckDate,bool OnJob)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      join e in db.MTCODE on b.TTSCODE equals e.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                      where CheckDate >= b.ADATE && CheckDate <= b.DDATE.Value
                      && e.CATEGORY == "TTSCODE"
                      && (OnJob ? new string[] { "1", "4", "6" }.Contains(b.TTSCODE) : true)
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR
                      orderby JobState
                      select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
            return sql.CopyToDataTable();
        }

        public static DataTable GetEmpAllWithDeptByApDate(int BeforeDays ,bool OnJob)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      join e in db.MTCODE on b.TTSCODE equals e.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                      let diffday = (b.AP_DATE - DateTime.Today).Value.Days
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && diffday >= 0 && diffday <= BeforeDays
                      && e.CATEGORY == "TTSCODE"
                      && (OnJob ? new string[] { "1", "4", "6" }.Contains(b.TTSCODE) : true)
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR
                      orderby JobState
                      select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME,試用期滿日 = b.AP_DATE,差異天數 = diffday };
            return sql.CopyToDataTable();
        }

        public static DataTable GetEmpData(List<string> EmpList, DateTime CheckDate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DataTable dt = new DataTable();

            foreach (var item in EmpList.Split(1000))
            {
                var sql = (from a in db.BASE
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           join c in db.DEPT on b.DEPT equals c.D_NO
                           //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                           join e in db.MTCODE on b.TTSCODE equals e.CODE
                           let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                           where CheckDate >= b.ADATE && CheckDate <= b.DDATE.Value
                           && e.CATEGORY == "TTSCODE"
                           && item.Contains(a.NOBR)
                           && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           orderby a.NOBR
                           orderby JobState
                           select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 離職日期 = b.OUDT, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME }).ToList();
                dt.Merge(sql.CopyToDataTable());
            }
            return dt;

        }
        public static DataTable GetEmpAllWithDept(List<string> EmpList)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DataTable dt = new DataTable();

            foreach (var item in EmpList.Split(1000))
            {
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join c in db.DEPT on b.DEPT equals c.D_NO
                          //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                          join e in db.MTCODE on b.TTSCODE equals e.CODE
                          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                          where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                          && e.CATEGORY == "TTSCODE"
                          && item.Contains(a.NOBR)
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          orderby a.NOBR
                          orderby JobState
                          select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
                dt.Merge(sql.CopyToDataTable());
            }
            return dt;

        }

        public static DataTable GetEmpAllWithDeptCard(List<string> EmployeeList)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DataTable dt = new DataTable();

            foreach (var item in EmployeeList.Split(1000))
            {
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join c in db.DEPT on b.DEPT equals c.D_NO
                          //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                          join e in db.MTCODE on b.TTSCODE equals e.CODE
                          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                          where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                          && e.CATEGORY == "TTSCODE"
                          && item.Contains(a.NOBR)
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          orderby a.NOBR
                          orderby JobState
                          select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
                dt.Merge(sql.CopyToDataTable()); 
            }

            return dt; 
        }

        public static List<string> GetEmpListByAttendDate(DateTime dateBegin, DateTime dateEnd)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ATTEND
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      where a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select a.NOBR;
            return sql.Distinct().ToList();
        }

        public static DataTable GetLeaveEmp1WithDept(DateTime OutBegin, DateTime OutEnd, DateTime AttOutBegin, DateTime AttOutEnd)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //var sql = from a in db.BASE
            //          join b in db.BASETTS on a.NOBR equals b.NOBR
            //          join c in db.DEPT on b.DEPT equals c.D_NO
            //          join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
            //          join e in db.MTCODE on b.TTSCODE equals e.CODE
            //          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
            //          where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
            //          && e.CATEGORY == "TTSCODE"
            //          && new string[] { "2", "3", "5" }.Contains(b.TTSCODE)
            //          && (b.OUDT != null && b.OUDT.Value >= OutBegin && b.OUDT.Value <= OutEnd)
            //          orderby a.NOBR
            //          orderby JobState
            //          select new
            //          {
            //              員工編號 = a.NOBR,
            //              員工姓名 = a.NAME_C,
            //              //在離職 = JobState,
            //              部門代碼 = c.D_NO_DISP,
            //              部門名稱 = c.D_NAME
            //          };

            var sql2 = from a in db.BASE
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       join c in db.DEPT on b.DEPT equals c.D_NO
                       //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                       join e in db.MTCODE on b.TTSCODE equals e.CODE
                       let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                       where DateTime.Today.AddYears(1) >= b.ADATE && DateTime.Today.AddYears(1) <= b.DDATE.Value
                       && e.CATEGORY == "TTSCODE"
                       && ((b.OUDT!=null && b.OUDT>=OutBegin && b.OUDT<=OutEnd) || (b.STDT != null && b.STDT >= OutBegin && b.STDT <= OutEnd))
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       orderby a.NOBR
                       orderby JobState
                       select new
                       {
                           員工編號 = a.NOBR,
                           員工姓名 = a.NAME_C,
                           //在離職 = JobState,
                           部門代碼 = c.D_NO_DISP,
                           部門名稱 = c.D_NAME,
                           離職日期 = b.OUDT,
                           留職停薪日 = b.STDT
                       };
            return sql2.CopyToDataTable();

        }

        public static DataTable GetOTwithDateYYMM(List<string> EmployeeList,DateTime BDate, DateTime Edate,String YYMM)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DataTable dt = new DataTable();

            foreach (var item in EmployeeList.Split(1000))
            {
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join c in db.DEPT on b.DEPT equals c.D_NO
                          //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                          join e in db.MTCODE on b.TTSCODE equals e.CODE
                          join ot in db.OT on a.NOBR equals ot.NOBR
                          join re in db.ROTE on ot.OT_ROTE equals re.ROTE1
                          join att in db.ATTEND on new { ot.NOBR, ADATE = ot.BDATE } equals new { att.NOBR, att.ADATE }
                          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                          where DateTime.Today.AddYears(1) >= b.ADATE && DateTime.Today.AddYears(1) <= b.DDATE.Value
                          && e.CATEGORY == "TTSCODE"
                          where item.Contains(a.NOBR)
                          && BDate <= ot.BDATE && Edate >= ot.BDATE
                          && ot.YYMM != YYMM
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          orderby a.NOBR
                          select new
                          {
                              員工編號 = a.NOBR,
                              員工姓名 = a.NAME_C,
                              計薪年月 = ot.YYMM,
                              加班日期 = ot.BDATE,
                              加班班別 = re.ROTENAME,
                              加班時數 = ot.TOT_HOURS,
                              備註 = ot.NOBR + "," + ot.BDATE + "," + ot.BTIME
                          };
                dt.Merge(sql.CopyToDataTable());
            }
            return dt;
        }

        public static DataTable GetABSwithDateYYMM(List<string> EmployeeList, DateTime BDate, DateTime Edate, String YYMM)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DataTable dt = new DataTable();

            foreach (var item in EmployeeList.Split(1000))
            {
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join c in db.DEPT on b.DEPT equals c.D_NO
                          //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                          join e in db.MTCODE on b.TTSCODE equals e.CODE
                          join abs in db.ABS on a.NOBR equals abs.NOBR
                          join hc in db.HCODE on abs.H_CODE equals hc.H_CODE
                          join att in db.ATTEND on new { abs.NOBR, ADATE = abs.BDATE } equals new { att.NOBR, att.ADATE }
                          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                          where DateTime.Today.AddYears(1) >= b.ADATE && DateTime.Today.AddYears(1) <= b.DDATE.Value
                          && e.CATEGORY == "TTSCODE"
                          where EmployeeList.Contains(a.NOBR)
                          && BDate <= abs.BDATE && Edate >= abs.BDATE
                          && hc.FLAG == "-"
                          && abs.YYMM != YYMM
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          orderby a.NOBR
                          select new
                          {
                              員工編號 = a.NOBR,
                              員工姓名 = a.NAME_C,
                              計薪年月 = abs.YYMM,
                              請假日期 = abs.BDATE,
                              請假假別 = hc.H_NAME,
                              請假時數 = abs.TOL_HOURS,
                              備註 = abs.NOBR + "," + abs.BDATE + "," + abs.BTIME + "," + abs.H_CODE
                          };
                dt.Merge(sql.CopyToDataTable());
            }
            return dt;
        }
        //private class Employee
        //{
        //    public string 員工編號;
        //    public string 員工姓名;
        //    public string 在離職;
        //    public DateTime? 離職日期;
        //    public string 部門代碼;
        //    public string 部門名稱;
        //}
    }
}
