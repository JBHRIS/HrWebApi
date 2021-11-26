using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bll.Bas.Vdb;
using System.Data;

namespace Dal.Dao.Bas
{
    public class JoboDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// JoboDao
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public JoboDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// JoboDao
        /// </summary>
        /// <param name="ConnectionString"></param>
        public JoboDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        public List<JoboRow> GetJobo(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.JOBO
                       where (sCode == "" || c.JOBO1.Trim() == sCode)
                       select new JoboRow
                       {
                           Code = c.JOBO1.Trim(),
                           Name = c.JOB_NAME.Trim(),
                           DisplayName = c.JOB_NAME.Trim(),
                       }).ToList();

            return Vdb;
        }

        public List<JoboRow> GetJobs(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.JOBS
                       where (sCode == "" || c.JOBS1.Trim() == sCode)
                       select new JoboRow
                       {
                           Code = c.JOBS1.Trim(),
                           Name = c.JOB_NAME.Trim(),
                           DisplayName = c.JOB_NAME.Trim(),
                       }).ToList();

            return Vdb;
        }
    }
}
