using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Att.Vdb;

namespace OldDal.Dao.Att
{
    public class CardLosdDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="conn"></param>
        public CardLosdDao(IDbConnection conn = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CardLosdDao(string ConnectionString = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        public CardLosdDao()
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();
        }

        /// <summary>
        /// 取得忘刷原因代碼
        /// </summary>
        /// <param name="sCode">忘刷原因代碼</param>
        /// <returns>List CardLosdRow</returns>
        public List<CardLosdRow> GetData(string sCode = "")
        {
            var Vdb = (from c in dcHr.CARDLOSD
                       where (sCode == "" || c.CODE == sCode)
                       && c.SORT > 0
                       orderby c.SORT
                       select new CardLosdRow
                       {
                           Code = c.CODE,
                           Name = c.DESCR,
                           DisplayName = c.DESCR + "(" + c.CODE + ")",
                           Att = c.ATT,
                       }).ToList();

            return Vdb;
        }
    }
}
