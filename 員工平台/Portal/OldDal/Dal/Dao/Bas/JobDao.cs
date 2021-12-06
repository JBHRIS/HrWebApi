using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldBll.Bas.Vdb;
using System.Data;

namespace OldDal.Dao.Bas
{
    public class JobDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;
        private DateTime DateNow = DateTime.Now.Date;

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="conn">連接字串 沒有等於預設</param>
        public JobDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 員工基本資料
        /// </summary>
        /// <param name="ConnectionString"></param>
        public JobDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        public List<JobRow> GetJob(string sCode = "", bool bValid = true)
        {
            var Vdb = (from c in dcHr.JOB
                       where (sCode == "" || c.JOB1.Trim() == sCode)
                       select new JobRow
                       {
                           Code = c.JOB1.Trim(),
                           Name = c.JOB_ENAME.Trim(),//鑫禾判斷副課長以上
                           DisplayName = c.JOB_NAME.Trim(),
                           Tree = c.JOB_TREE.Trim(),
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得職類
        /// </summary>
        public List<JobRow> GetJobs(string sCode = "")
        {
            var Vdb = (from c in dcHr.JOBS
                       where (sCode == "" || c.JOBS1.Trim() == sCode)
                       select new JobRow
                       {
                           Code = c.JOBS1.Trim(),
                           Name = c.JOB_NAME.Trim(),
                           DisplayName = c.JOB_NAME.Trim(),
                           Tree = c.JOBS1.Trim(),
                       }).ToList();

            return Vdb;
        }
        public List<JobRow> GetJobByJobl(string sCode = "", bool bValid = true, string sJobl = "")
        {
            var Vdb = (from c in dcHr.JOB
                       where (sCode == "" || c.JOB1.Trim() == sCode)
                       && (sJobl != "" ? c.JOBL.Contains(sJobl) : c.JOBL == c.JOBL)
                       select new JobRow
                       {
                           Code = c.JOB1.Trim(),
                           Name = c.JOB_NAME.Trim(),
                           DisplayName = c.JOB_NAME.Trim(),
                           Tree = c.JOB_TREE.Trim(),
                       }).ToList();

            return Vdb;
        }
        //public string GetDeptTreeByJob(string Job)
        //{
        //    var result = (from c in dcHr.JOB
        //                  where c.JOB1 == Job
        //                  select c.DEPT_TREE).FirstOrDefault();
        //    return result;
        //}
    }
}
