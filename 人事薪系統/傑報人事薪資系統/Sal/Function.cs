using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Sal
{
    public class Function
    {
        static Sal.SalaryDS.BASEDataTable dtBase = new SalaryDS.BASEDataTable();
        public static string ShowView(string Title, DataTable dt)
        {
            PreviewForm vw = new PreviewForm();
            vw.Form_Title = Title;
            vw.DataTable = dt;
            vw.ShowDialog();
            return vw.SelectKey;
        }
        public static void ShowView(string Title, DataTable dt, int width, int height)
        {
            PreviewForm vw = new PreviewForm();
            vw.Form_Title = Title;
            vw.DataTable = dt;
            if (width > 0) vw.Width = width;
            if (height > 0) vw.Height = height;
            vw.ShowDialog();
        }

        //public static void SetAvaliableBase(DataTable dt, DateTime bdate)
        //{
        //    dt.Clear();
        //    SalaryMDDataContext smd = new SalaryMDDataContext();
        //    try
        //    {
        //        if (smd.Connection.State != ConnectionState.Open) smd.Connection.Open();
        //        var bb = from data in smd.BASE
        //                 join bt in smd.BASETTS on data.NOBR equals bt.NOBR
        //                 where bdate.Date >= bt.ADATE && bdate <= bt.DDATE
        //                 &&
        //                 //(MainForm.PROCSUPER || bt.SALADR == MainForm.WORKADR)
        //                 select new { data.NOBR, data.NAME_C };
        //        var cmd = smd.GetCommand(bb);
        //        dt.Load(cmd.ExecuteReader());
        //        cmd.ExecuteReader().Close();
        //    }
        //    catch { }
        //    finally
        //    {
        //        smd.Connection.Close();
        //    }
        //}
        public static void SetAvaliableBase(DataTable dt)
        {
            dt.Clear();
            JBModule.Data.Linq.HrDBDataContext smd = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                if (smd.Connection.State != ConnectionState.Open) smd.Connection.Open();
                var bb = from data in smd.BASE
                         let SALADR = (from a in smd.BASETTS where data.NOBR == a.NOBR && DateTime.Today <= a.DDATE.Value select a.SALADR).FirstOrDefault()
                         orderby data.NOBR
                         select new { data.NOBR, data.NAME_C, data.ACCOUNT_NO, data.NAME_E, data.BANKNO, data.NAME_P, SALADR };
                if (MainForm.ADMIN)
                {
                    bb = from a in bb
                         where (from b in smd.COMP_DATAGROUP where a.SALADR == b.DATAGROUP && b.COMP == MainForm.COMPANY select b).Any()
                         select a;
                }
                else
                {
                    bb = from a in bb
                         where (from b in smd.U_DATAGROUP where a.SALADR == b.DATAGROUP && b.USER_ID == MainForm.USER_ID && b.COMPANY == MainForm.COMPANY select b).Any()
                         select a;
                }

                var cmd = smd.GetCommand(bb);

                dt.Load(cmd.ExecuteReader());
                cmd.ExecuteReader().Close();
            }
            catch { }
            finally
            {
                smd.Connection.Close();
            }
        }
        public static void SetAvaliableVBase(DataTable dt)
        {
            dt.Clear();
            JBModule.Data.Linq.HrDBDataContext smd = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                if (smd.Connection.State != ConnectionState.Open) smd.Connection.Open();
                var bb = from data in smd.BASE
                         let SALADR = (from a in smd.BASETTS where data.NOBR == a.NOBR && DateTime.Today <= a.DDATE.Value select a.SALADR).FirstOrDefault()
                         select new { data.NOBR, data.NAME_C, data.NAME_E, data.NAME_P, data.IDNO, SALADR };
                if (MainForm.ADMIN)
                {
                    bb = from a in bb
                         where (from b in smd.COMP_DATAGROUP where a.SALADR == b.DATAGROUP && b.COMP == MainForm.COMPANY select b).Any()
                         select a;
                }
                else
                {
                    bb = from a in bb
                         where (from b in smd.U_DATAGROUP where a.SALADR == b.DATAGROUP && b.USER_ID == MainForm.USER_ID && b.COMPANY == MainForm.COMPANY select b).Any()
                         select a;
                }

                var cmd = smd.GetCommand(bb);

                dt.Load(cmd.ExecuteReader());
                cmd.ExecuteReader().Close();
            }
            catch { }
            finally
            {
                smd.Connection.Close();
            }
        }
        public static string DeleteCommand(string TargetTable, string NobrB, string NobrE, string DeptB, string DeptE)
        {
            string DDATE = GetDate();
            //string cmd = string.Format("DELETE {0} WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE '{8}' BETWEEN A.ADATE AND A.DDATE AND A.NOBR BETWEEN '{1}' AND '{2}' AND B.D_NO_DISP BETWEEN '{3}' AND '{4}' AND A.NOBR={0}.NOBR) AND dbo.GetFilterByNobr({0}.NOBR,'{5}','{6}',{7})=1", new object[] { TargetTable, NobrB, NobrE, DeptB, DeptE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? 1 : 0, DDATE });
            string cmd = string.Format("DELETE {0} WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE '{8}' BETWEEN A.ADATE AND A.DDATE AND A.NOBR BETWEEN '{1}' AND '{2}' AND B.D_NO_DISP BETWEEN '{3}' AND '{4}' AND A.NOBR={0}.NOBR) AND exists(select 1 from BASETTS x where x.NOBR={0}.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList('{5}','{6}',{7})))", new object[] { TargetTable, NobrB, NobrE, DeptB, DeptE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? 1 : 0, DDATE });
            return cmd;
        }
        //public static string DeleteCommand(string TargetTable, string NobrB, string NobrE, string DeptB, string DeptE,DateTime DDATE)
        //{
        //    string DDATE = GetDate();
        //    string cmd = string.Format("DELETE {0} WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE A.NOBR BETWEEN '{1}' AND '{2}' AND B.D_NO_DISP BETWEEN '{3}' AND '{4}' AND A.NOBR={0}.NOBR) AND dbo.GetFilterByNobr({0}.NOBR,'{5}','{6}',{7})=1", new object[] { TargetTable, NobrB, NobrE, DeptB, DeptE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? 1 : 0 });
        //    return cmd;
        //}
        //public static void SetAvaliableBase(DataTable dt, bool CheckRule)
        //{
        //    dt.Clear();
        //    SalaryMDDataContext smd = new SalaryMDDataContext();
        //    try
        //    {
        //        if (smd.Connection.State != ConnectionState.Open) smd.Connection.Open();
        //        var bb = from data in smd.BASE
        //                 where
        //                     (
        //                     from dr in data.BASETTS
        //                     where dr.ADATE <= DateTime.Now.Date && DateTime.Now.Date <= dr.DDATE
        //                     && new string[] { "1", "4", "6" }.Contains(dr.TTSCODE)
        //                     && ((MainForm.PROCSUPER || dr.SALADR == MainForm.WORKADR) || !CheckRule)
        //                     select dr
        //                     ).Any()
        //                 select data;
        //        dt.Load(smd.GetCommand(bb).ExecuteReader());
        //        smd.GetCommand(bb).ExecuteReader().Close();
        //    }
        //    catch { }
        //    finally
        //    {
        //        smd.Connection.Close();
        //    }
        //}
        public static BASETTS GetCurrentBasetts(string Nobr)
        {
            SalaryMDDataContext smd = new SalaryMDDataContext();
            var basetts = from basetts_row in smd.BASETTS where basetts_row.NOBR == Nobr && DateTime.Now.Date >= basetts_row.ADATE && DateTime.Now.Date <= basetts_row.DDATE select basetts_row;
            if (basetts.Count() > 0) return basetts.First();
            else return null;
        }

        public static decimal RangeMix(decimal RangeB, decimal RangeE, decimal ValueB, decimal ValueE)
        {
            if (RangeB <= ValueE && RangeE >= ValueB)
            {
                decimal v1 = MaxValueB(RangeB, ValueB);
                decimal v2 = MinValueE(RangeE, ValueE);
                return v2 - v1;
            }
            return 0;
        }
        public static int RangeMix(DateTime RangeB, DateTime RangeE, DateTime ValueB, DateTime ValueE)
        {
            if (RangeB <= ValueE && RangeE >= ValueB)
            {
                DateTime v1 = MaxValueB(RangeB, ValueB);
                DateTime v2 = MinValueE(RangeE, ValueE);
                return Convert.ToInt32((v2 - v1).TotalDays) + 1;
            }
            return 0;
        }
        public static int GetTotalDays(DateTime d1, DateTime d2)
        {
            TimeSpan ts = (d2 - d1);
            if (ts.TotalDays < 0) return 0;
            else return Convert.ToInt32(ts.TotalDays) + 1;
        }
        static decimal MaxValueB(decimal v1, decimal v2)
        {
            return v1 > v2 ? v1 : v2;
        }
        static decimal MinValueE(decimal v1, decimal v2)
        {
            return v1 < v2 ? v1 : v2;
        }
        public static DateTime MaxValueB(DateTime v1, DateTime v2)
        {
            return v1 > v2 ? v1 : v2;
        }
        public static DateTime MinValueE(DateTime v1, DateTime v2)
        {
            return v1 < v2 ? v1 : v2;
        }
        //public static string GetFilterCmd(string TABLE, string WORKADR)
        //{
        //    string cmd = " exists (select * from basetts QueryBASETTS where QueryBASETTS.NOBR="
        //                + TABLE +
        //                ".NOBR AND CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),111)) BETWEEN QueryBASETTS.ADATE AND QueryBASETTS.DDATE AND QueryBASETTS.SALADR='"
        //                + WORKADR + "') ";
        //    return cmd;
        //}
        public static string GetFilterCmd(string TABLE)
        {
            return GetFilterCmdByNobr(TABLE + ".NOBR");
        }
        public static string GetFilterCmdByNobr(string NobrColumn)
        {
            //string cmd = string.Format(" exists (select * from dbo.ReadRuleTable('{0}','{1}',{2}) BTS where BTS.NOBR="
            //    + NobrColumn + ")", MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? "1" : "0");
            string cmd = string.Format("(select top 1 SALADR from BASETTS x where x.NOBR = {0} and dbo.Today()<=DDATE order by DDATE desc)" +
                "in (select DATAGROUP from dbo.UserReadDataGroupList('{1}', '{2}', {3}))", NobrColumn, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? "1" : "0");
            return cmd;
        }
        public static string GetFilterCmdByNobrOfWrite(string NobrColumn)
        {
            //string cmd = " exists (select * from basetts BTS where BTS.NOBR="
            //            + NobrColumn +
            //            " AND CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN BTS.ADATE AND BTS.DDATE AND EXISTS(SELECT * FROM U_DATAGROUP WHERE USER_ID='" + MainForm.USER_ID + "' AND COMPANY='" + MainForm.COMPANY + "' AND DATAGROUP= BTS.SALADR AND WRITERULE=1))";
            //if (MainForm.ADMIN) cmd = " exists (select * from basetts BTS where BTS.NOBR="
            //            + NobrColumn +
            //            " AND CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN BTS.ADATE AND BTS.DDATE AND EXISTS(SELECT * FROM COMP_DATAGROUP WHERE COMP='" + MainForm.COMPANY + "' AND DATAGROUP= BTS.SALADR))";//如果有最大權限

            string cmd = string.Format("exists(select 1 from BASETTS x where x.NOBR = {0} and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList('{1}', '{2}', {3})))", NobrColumn, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? "1" : "0");

            return cmd;
        }
        public static string GetFilterCmdBySource(string Source)
        {
            string cmd = " EXISTS(SELECT * FROM CODE_FILTER WHERE CODE_FILTER.SOURCE='"
                        + Source
                        + "' AND CODE_FILTER.CODE=SALCODE.SAL_CODE AND EXISTS(SELECT * FROM COMP_CODE_GROUP WHERE COMP_CODE_GROUP.COMP='"
                        + MainForm.COMPANY + "' AND COMP_CODE_GROUP.CODEGROUP=CODE_FILTER.CODEGROUP ))";
            return cmd;
        }
        public static string GetFilterCmdByDataGroup(string DataGroup)
        {
            string cmd = " EXISTS(SELECT * FROM U_DATAGROUP WHERE USER_ID='" + MainForm.USER_ID + "' AND COMPANY='" + MainForm.COMPANY + "' AND DATAGROUP= " + DataGroup + " AND READRULE=1)";
            if (MainForm.ADMIN) cmd = " EXISTS(SELECT * FROM COMP_DATAGROUP WHERE COMP='" + MainForm.COMPANY + "' AND DATAGROUP= " + DataGroup + ")";//如果有最大權限
            return cmd;
        }
        public static string GetFilterCmdByDataGroupOfWrite(string DataGroup)
        {
            string cmd = " EXISTS(SELECT * FROM U_DATAGROUP WHERE USER_ID='" + MainForm.USER_ID + "' AND COMPANY='" + MainForm.COMPANY + "' AND DATAGROUP= " + DataGroup + " AND WRITERULE=1)";
            if (MainForm.ADMIN) cmd = " EXISTS(SELECT * FROM COMP_DATAGROUP WHERE COMP='" + MainForm.COMPANY + "' AND DATAGROUP= " + DataGroup + ")";//如果有最大權限
            return cmd;
        }
        public static bool CheckLeaveForbid(string Nobr, DateTime date)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("2");
            ttscodeList.Add("3");
            ttscodeList.Add("5");
            var sql = from a in db.BASETTS where a.NOBR == Nobr && a.ADATE <= date && a.DDATE >= date && ttscodeList.Contains(a.TTSCODE) select a;
            return sql.Any();
        }

        public static bool CanModify(string nobr)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (MainForm.ADMIN)
            {
                var sqlAdmin = from b in db.BASETTS
                               where DateTime.Now.Date <= b.DDATE
                               && b.NOBR == nobr
                               //&& (from a in db.COMP_DATAGROUP where a.DATAGROUP == b.SALADR &&  a.COMP == MainForm.COMPANY select a).Any()
                               select b;
                return sqlAdmin.Any() && MainForm.WriteRules.Where(p => p.DATAGROUP == sqlAdmin.First().SALADR).Any();
            }

            var sql = from b in db.BASETTS
                      where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE
                      && b.NOBR == nobr
                      //&& (from a in db.U_DATAGROUP where a.DATAGROUP == b.SALADR && a.READRULE && a.USER_ID == MainForm.USER_ID && a.COMPANY == MainForm.COMPANY select a).Any()
                      select b;
            if (!sql.Any())
            {
                sql = (from b in db.BASETTS
                      where DateTime.Now.Date <= b.ADATE
                      && b.NOBR == nobr
                      //&& (from a in db.U_DATAGROUP where a.DATAGROUP == b.SALADR && a.READRULE && a.USER_ID == MainForm.USER_ID && a.COMPANY == MainForm.COMPANY select a).Any()
                      select  b).Take(1);
            }
            return sql.Any() && MainForm.WriteRules.Where(p => p.DATAGROUP == sql.First().SALADR).Any();
        }
        public static bool CanView(string nobr)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (MainForm.ADMIN)
            {
                var sqlAdmin = from b in db.BASETTS
                               where DateTime.Now.Date <= b.DDATE
                               && b.NOBR == nobr
                               //&& (from a in db.COMP_DATAGROUP where a.DATAGROUP == b.SALADR &&  a.COMP == MainForm.COMPANY select a).Any()
                               select b;
                return sqlAdmin.Any() && MainForm.ReadRules.Where(p => p.DATAGROUP == sqlAdmin.First().SALADR).Any();
            }

            var sql = from b in db.BASETTS
                      where DateTime.Now.Date <= b.DDATE
                      && b.NOBR == nobr
                      //&& (from a in db.U_DATAGROUP where a.DATAGROUP == b.SALADR && a.READRULE && a.USER_ID == MainForm.USER_ID && a.COMPANY == MainForm.COMPANY select a).Any()
                      select b;
            return sql.Any() && MainForm.ReadRules.Where(p => p.DATAGROUP == sql.First().SALADR).Any();
        }
        public static Sal.SalaryDS.BASEDataTable getBase()
        {
            if (dtBase.Rows.Count == 0)
            {
                new Sal.SalaryDSTableAdapters.BASETableAdapter().Fill(dtBase);
            }
            return dtBase;
        }
        public static string GetYear()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            //year = year - 1911;
            return year.ToString("0000");
        }
        public static string GetMonth()
        {
            DateTime date = DateTime.Now;
            int month = date.Month;
            return month.ToString("00");
        }
        public static string GetDate()
        {
            DateTime date = DateTime.Now;

            return date.ToString("yyyy/MM/dd");
        }
        public static string GetDate(DateTime date)
        {

            return date.ToString("yyyy/MM/dd");
        }
        public static bool ValidateTimeStringFormat(string time)
        {
            return ValidateTimeStringFormat(time, 48);
        }
        public static bool ValidateTimeStringFormat(string time, int HourSet)
        {
            if (time.Trim().Length == 4)
            {
                string hh = time.Substring(0, 2);
                string mm = time.Substring(2);
                int hour = 0;
                int minute = 0;
                if (int.TryParse(hh, out hour) && int.TryParse(mm, out minute))
                {
                    if (hour >= 0 && hour < HourSet && minute >= 0 && minute < 60) return true;
                }
            }
            return false;

        }
        public static bool IsSalaryLocked(string yymm, string seq, string saladr)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.LOCK_WAGE
                      where a.YYMM == yymm && a.SEQ == seq && MainForm.WriteRules.Where(pp => pp.COMPANY == MainForm.COMPANY).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            return sql.Any();
        }
        public static bool IsSalaryLockedByNobr(string yymm, string seq, string nobr)
        {
            if (!string.IsNullOrWhiteSpace(yymm) && !string.IsNullOrWhiteSpace(seq) && !string.IsNullOrWhiteSpace(nobr))
            {
                SalaryMDDataContext db = new SalaryMDDataContext();
                JBHR.Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(yymm);
                var saladr = string.Empty;
                var sqlNobr = db.BASETTS.Where(p => p.NOBR == nobr && p.ADATE <= sd.LastDayOfSalary && p.DDATE >= sd.LastDayOfSalary);
                if (sqlNobr.Any())
                    saladr = sqlNobr.FirstOrDefault().SALADR;

                var sql = from a in db.LOCK_WAGE
                          where a.YYMM == yymm && a.SEQ == seq && a.SALADR == saladr
                          select a;
                return sql.Any();
            }
            else
                return false;
        }
        //public static bool IsSalaryLocked(string yymm, string seq, string nobr, DateTime adate)
        //{
        //    SalaryMDDataContext db = new SalaryMDDataContext();
        //    var sql = from a in db.BASETTS
        //              where a.NOBR == nobr && adate >= a.ADATE && adate <= a.DDATE.Value
        //              select a;
        //    if (sql.Any())
        //        return IsSalaryLocked(yymm, seq, sql.First().SALADR);

        //    return false;
        //}
        public static bool IsAttendLocked(DateTime date, string nobr)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.DATA_PA
                      join b in db.BASETTS on a.SALADR equals b.SALADR
                      where a.DATA_PASS == date && b.NOBR == nobr
                      && date >= b.ADATE && date <= b.DDATE.Value
                      select a;
            return sql.Any();
        }
        //public static bool IsAttendLocked(DateTime date)
        //{
        //    SalaryMDDataContext db = new SalaryMDDataContext();
        //    var sql = from a in db.DATA_PA
        //              where a.DATA_PASS == date
        //              select a;
        //    return sql.Any();
        //}
        public static string ColumnsSum(JBControls.DataGridView gv, int column_idx)
        {
            if (Type.GetType(gv.Columns[column_idx].ValueType.FullName) == Type.GetType("System.Decimal") || Type.GetType(gv.Columns[column_idx].ValueType.FullName) == Type.GetType("System.Int32"))
            {
                string columnName = gv.Columns[column_idx].HeaderText;
                decimal i = 0;
                foreach (System.Windows.Forms.DataGridViewRow itm in gv.Rows)
                {
                    try
                    {
                        i += Convert.ToDecimal(itm.Cells[column_idx].Value);
                    }
                    catch
                    {
                        return "";
                    }
                }
                return columnName + "總計共：" + i.ToString();
            }
            return "";
        }
        public static string AttendAlert(DateTime date_b, DateTime date_e)
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var attendSQL = from a in db.ATTEND where a.ADATE >= date_b && a.ADATE <= date_e select a;
            var sql = from a in db.BASETTS
                      join b in attendSQL on a.NOBR equals b.NOBR into ATTENDs
                      from attend in ATTENDs
                      let d1 = a.ADATE > date_b ? a.ADATE : date_b
                      let d2 = a.DDATE.Value < date_e ? a.DDATE.Value : date_e
                      let TotalDays = Convert.ToDecimal((d2 - d1).TotalDays) + 1
                      let AttendList = ATTENDs.Where(p => p.ADATE >= d1 && p.ADATE <= d2)
                      where ttscodeList.Contains(a.TTSCODE) && a.ADATE <= date_e && a.DDATE >= date_b
                      && d1 <= d2
                      && AttendList.Count() != TotalDays
                      select new { a.NOBR, TotalDays, d1, d2 };
            if (sql.Any())
            {
                string msg = "出勤資料有缺漏";
                msg += "，工號" + sql.First().NOBR + "於" + sql.First().d1.ToString("yyyy/MM/dd") + "~" + sql.First().d2.ToString("yyyy/MM/dd");
                return msg;
            }
            return "";

        }
        public static DataTable GetAttend(string nobr, DateTime DateB, DateTime DateE)
        {
            if (DateB != new DateTime() && DateE != new DateTime())
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.ATTEND
                          join b in db.ROTE on a.ROTE equals b.ROTE1
                          where a.NOBR == nobr && a.ADATE >= DateB.AddDays(-1) && a.ADATE <= DateE
                          select new { a.ADATE, b.ROTENAME };
                Dictionary<DateTime, string> dic = new Dictionary<DateTime, string>();
                foreach (var it in sql)
                    dic.Add(it.ADATE, it.ROTENAME);
                var data = from a in dic select new { 日期 = a.Key, 班別 = a.Value };
                return data.CopyToDataTable();
            }
            return null;
        }

    }

}
