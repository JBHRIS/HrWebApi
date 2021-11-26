using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Dal.Dao.Att
{
    public class AttDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 出勤
        /// </summary>
        /// <param name="conn"></param>
        public AttDao(IDbConnection conn = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (conn != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 出勤
        /// </summary>
        /// <param name="ConnectionString"></param>
        public AttDao(string ConnectionString = null)
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();

            if (ConnectionString != null)
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 檢查是否出勤鎖檔
        /// </summary>
        /// <param name="dDateB">開始日期</param>
        /// <param name="dDateE">結束日期</param>
        /// <param name="sSaladr">薪資組</param>
        /// <returns>bool</returns>
        public bool IsLockSalaryBegin(DateTime dDateB, DateTime dDateE, string sSaladr = "")
        {
            bool Vdb = false;

            var rsDataPa = (from c in dcHr.DATA_PA
                            where dDateB.Date <= c.DATA_PASS.Date
                            && c.DATA_PASS.Date <= dDateE.Date
                            && (c.SALADR.Trim() == sSaladr || sSaladr == "")
                            select c).ToList();

            var rsDataPass = (from c in dcHr.DATA_PASS
                              where dDateB.Date <= c.DATA_PASS1.Date
                              && c.DATA_PASS1.Date <= dDateE.Date
                              && (c.SALADR.Trim() == sSaladr || sSaladr == "")
                              select c).ToList();

            Vdb = rsDataPa.Any() || rsDataPass.Any();

            return Vdb;
        }

        /// <summary>
        /// 檢查是否薪資鎖檔
        /// </summary>
        /// <param name="sYYMM">計薪年月</param>
        /// <param name="sSaladr">薪資組</param>
        /// <param name="sSeq">期別</param>
        /// <returns>bool</returns>
        public bool IsLockSalaryAfter(string sYYMM, string sSaladr = "", string sSeq = "2")
        {
            bool Vdb = (from c in dcHr.LOCK_WAGE
                        where c.YYMM.Trim() == sYYMM
                        && c.SEQ.Trim() == sSeq
                        && (c.SALADR.Trim() == sSaladr || sSaladr == "")
                        select c).ToList().Any();

            return Vdb;
        }
    }
}