using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Bas.Vdb;
using System.Data;

namespace Dal.Dao.Bas
{
    public class JoblDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// JoblDao
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public JoblDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// JoblDao
        /// </summary>
        /// <param name="ConnectionString"></param>
        public JoblDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        public List<JoblRow> GetJobl(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.JOBL
                       where (sCode == "" || c.JOBL1.Trim() == sCode)
                       && c.JOB_NAME != "未定義"
                       orderby c.JOBL1 descending
                       select new JoblRow
                       {
                           Code = c.JOBL1.Trim(),
                           Name = c.JOB_NAME.Trim(),
                           DisplayName = c.JOB_NAME.Trim(),
                       }).ToList();

            return Vdb;
        }
    }
}
