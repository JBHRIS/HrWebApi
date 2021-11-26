using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Bas.Vdb;
using System.Data;

namespace Dal.Dao.Bas
{
    public class DeptDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public DeptDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public DeptDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        public List<DeptRow> GetDept(string sCode = "", string sNobr = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.DEPT
                       where (sCode == "" || c.D_NO.Trim() == sCode)
                       && (sNobr == "" || c.NOBR.Trim() == sNobr)
                       && (bValid ? (c.ADATE.Value.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(c.DDATE.Value.Date) <= 0) : true)
                       select new DeptRow
                       {
                           Code = c.D_NO.Trim(),
                           Name = c.D_NAME.Trim(),
                           ParentCode = c.DEPT_GROUP.Trim(),
                           Tree = c.DEPT_TREE.Trim(),
                           DateA = c.ADATE.Value.Date,
                           DateD = c.DDATE.Value.Date,
                           Manage = c.NOBR.Trim(),
                           Mail1 = c.EMAIL.Trim(),
                       }).ToList();

            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            oDept.SetDeptPath(Vdb);

            return Vdb;
        }

        public List<DeptRow> GetDeptm(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.DEPTA
                       where (sCode == "" || c.D_NO.Trim() == sCode)
                       && (bValid ? (c.ADATE.Value.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(c.DDATE.Value.Date) <= 0) : true)
                       select new DeptRow
                       {
                           Code = c.D_NO.Trim(),
                           Name = c.D_NAME.Trim(),
                           ParentCode = c.DEPT_GROUP.Trim(),
                           Tree = c.DEPT_TREE.Trim(),
                           DateA = c.ADATE.Value.Date,
                           DateD = c.DDATE.Value.Date,
                           Manage = c.NOBR.Trim(),
                           Mail1 = c.EMAIL.Trim(),
                           Mail2 = c.MANGEMAIL.Trim(),
                           DisplayCode = c.D_NO_DISP
                       }).ToList();

            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            oDept.SetDeptPath(Vdb);

            return Vdb;
        }
        public List<DeptRow> GetDeptmByManager(string sCode = "", string sNobr = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.DEPTA
                       join b in dcHr.BASE on c.NOBR equals b.NOBR into groupjoin
                       from a in groupjoin.DefaultIfEmpty()
                       where (sCode == "" || c.D_NO.Trim() == sCode)
                       && (sNobr == "" || c.NOBR.Trim() == sNobr)
                       && (bValid ? (c.ADATE.Value.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(c.DDATE.Value.Date) <= 0) : true)
                       select new DeptRow
                       {
                           Code = c.D_NO.Trim(),
                           Name = c.D_NAME.Trim(),
                           ParentCode = c.DEPT_GROUP.Trim(),
                           Tree = c.DEPT_TREE.Trim(),
                           DateA = c.ADATE.Value.Date,
                           DateD = c.DDATE.Value.Date,
                           Manage = c.NOBR.Trim(),
                           Mail1 = c.EMAIL.Trim(),
                           Mail2 = c.MANGEMAIL.Trim(),
                           DisplayCode = c.D_NAME + "-" + a.NAME_C,
                       }).ToList();

            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            oDept.SetDeptPath(Vdb);

            return Vdb;
        }

        public List<DeptRow> GetDeptm(List<string> lsCode, List<string> lsNobr, bool bValid = true)
        {
            var Vdb = (from c in dcHr.DEPTA
                       where (lsCode.Count == 0 || lsCode.Contains(c.D_NO.Trim()))
                       && (lsNobr.Count == 0 || lsNobr.Contains(c.NOBR.Trim()))
                       && (bValid ? (c.ADATE.Value.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(c.DDATE.Value.Date) <= 0) : true)
                       select new DeptRow
                       {
                           Code = c.D_NO.Trim(),
                           Name = c.D_NAME.Trim(),
                           ParentCode = c.DEPT_GROUP.Trim(),
                           Tree = c.DEPT_TREE.Trim(),
                           DateA = c.ADATE.Value.Date,
                           DateD = c.DDATE.Value.Date,
                           Manage = c.NOBR.Trim(),
                           Mail1 = c.EMAIL.Trim(),
                           Mail2 = c.MANGEMAIL.Trim(),
                       }).ToList();

            Bll.Bas.Dept oDept = new Bll.Bas.Dept();
            oDept.SetDeptPath(Vdb);

            return Vdb;
        }
        /// <summary>
        /// 取得成本部門
        /// </summary>
        public List<DeptRow> GetDepts(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.DEPTS
                       where (sCode == "" || c.D_NO.Trim() == sCode)
                       && (bValid ? (c.ADATE.Value.Date.CompareTo(DateNow) <= 0
                       && DateNow.CompareTo(c.DDATE.Value.Date) <= 0) : true)
                       select new DeptRow
                       {
                           Code = c.D_NO.Trim(),
                           Name = c.D_NAME.Trim(),
                           DateA = c.ADATE.Value.Date,
                           DateD = c.DDATE.Value.Date,
                       }).ToList();

            return Vdb;
        }
    }
}