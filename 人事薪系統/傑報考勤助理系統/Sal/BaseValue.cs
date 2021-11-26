using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal
{
    public class BaseValue
    {
        DateTime d1, d2;
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public BaseValue(DateTime DateB, DateTime DateE)
        {
            d1 = DateB;
            d2 = DateE;
        }
        #region 靜態屬性
        /// <summary>
        /// 最小工號，在員工基本資料中排序最小者
        /// </summary>
        public static string MinNobr
        {
            get
            {
                var dateNow = DateTime.Now.Date;
                JBModule.Data.Linq.HrDBDataContext HrDB = new JBModule.Data.Linq.HrDBDataContext();
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var dept = (from a in HrDB.U_DATAID where a.USER_ID==MainForm.USER_ID select a.DEPT).ToList();
                //var sql = (from a in smd.BASE where  smd.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value  select a.NOBR).ToList();
                var sql = from a in smd.BASETTS where dateNow <= a.DDATE && (MainForm.ADMIN == true || dept.Contains(a.DEPT)) || MainForm.COMPANY == "JB-TRANSCARD" select a.NOBR;
                string min = sql.Min();
                return min;
            }
        }
        /// <summary>
        /// 最大工號，在員工基本資料中排序最大者
        /// </summary>
        public static string MaxNobr
        {
            get
            {
                var dateNow = DateTime.Now.Date;
                JBModule.Data.Linq.HrDBDataContext HrDB = new JBModule.Data.Linq.HrDBDataContext();
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var dept = (from a in HrDB.U_DATAID where a.USER_ID == MainForm.USER_ID select a.DEPT).ToList();
                //var sql = (from a in smd.BASE where  smd.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value  select a.NOBR).ToList();
                var sql = from a in smd.BASETTS where dateNow <= a.DDATE && (MainForm.ADMIN == true || dept.Contains(a.DEPT)) || MainForm.COMPANY == "JB-TRANSCARD" select a.NOBR;
                string max = sql.Max();
                return max;
                //SalaryMDDataContext smd = new SalaryMDDataContext();
                //var sql = from a in smd.BASE where  smd.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value  select a;
                //string max = sql.Max(p => p.NOBR);
                //return max;
            }
        }
        /// <summary>
        /// 最小部門編號，在部門資料中排序最小者
        /// </summary>
        public static string MinDept
        {
            get
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var sql = from a in smd.DEPT select a;
                string min = sql.Min(p => p.D_NO);
                return min;
            }
        }
        /// <summary>
        /// 最大部門編號，在部門資料中排序最大者
        /// </summary>
        public static string MaxDept
        {
            get
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var sql = from a in smd.DEPT select a;
                string max = sql.Max(p => p.D_NO);
                return max;
            }
        }
        /// <summary>
        /// 最小職稱代碼
        /// </summary>
        public static string MinJob
        {
            get
            {
                Att.dcBasDataContext db = new JBHR.Att.dcBasDataContext();
                var sql = from a in db.JOB select a;
                string min = sql.Min(p => p.JOB1);
                return min;
            }
        }
        /// <summary>
        /// 最大職稱代碼
        /// </summary>
        public static string MaxJob
        {
            get
            {
                Att.dcBasDataContext db = new JBHR.Att.dcBasDataContext();
                var sql = from a in db.JOB select a;
                string max = sql.Max(p => p.JOB1);
                return max;
            }
        }
        /// <summary>
        /// 最小職等代碼
        /// </summary>
        public static string MinJobl
        {
            get
            {
                Att.dcBasDataContext db = new JBHR.Att.dcBasDataContext();
                var sql = from a in db.JOBL select a;
                string min = sql.Min(p => p.JOBL1);
                return min;
            }
        }
        /// <summary>
        /// 最大職等代碼
        /// </summary>
        public static string MaxJobl
        {
            get
            {
                Att.dcBasDataContext db = new JBHR.Att.dcBasDataContext();
                var sql = from a in db.JOBL select a;
                string max = sql.Max(p => p.JOBL1);
                return max;
            }
        }
        /// <summary>
        /// 最小班別代碼
        /// </summary>
        public static string MinRote
        {
            get
            {
                Att.dcAttDataContext db = new JBHR.Att.dcAttDataContext();
                var sql = from a in db.ROTE select a;
                string min = sql.Min(p => p.ROTE1);
                return min;
            }
        }
        /// <summary>
        /// 最大班別代碼
        /// </summary>
        public static string MaxRote
        {
            get
            {
                Att.dcAttDataContext db = new JBHR.Att.dcAttDataContext();
                var sql = from a in db.ROTE select a;
                string max = sql.Max(p => p.ROTE1);
                return max;
            }
        }
        #endregion
    }
}
