using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Sal.Vdb;
using System.Data;
using OldBll.MT.Vdb;

namespace OldDal.Dao.Sal
{
    public class Salary
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// 薪資鎖檔
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public Salary(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 薪資鎖檔
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Salary(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 薪資鎖檔
        /// </summary>
        public Salary()
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();
        }

        /// <summary>
        /// 取得薪資代碼
        /// </summary>
        /// <param name="Nobr">工號</param>
        /// <param name="Source">資源</param>
        /// <returns></returns>
        public List<SalCodeRow> GetSALCODE(string Nobr="",string Source = "")
        {
            var Vdb = (from c in dcHr.CODE_FILTER
                       join b in dcHr.BASETTS on c.CODEGROUP equals b.SALADR
                       join sl in dcHr.SALCODE on c.CODE equals sl.SAL_CODE
                       where c.SOURCE== Source 
                       && b.NOBR== Nobr
                       select new SalCodeRow
                       {
                           Name = sl.SAL_NAME.Trim(),
                           Code = c.CODE.Trim(),
                           Sal =sl.SAL_ATTR.Trim(),
                       }).ToList();

            return Vdb;
        }
    }
}