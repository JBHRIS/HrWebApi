using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Att.Vdb;

namespace Dal.Dao.Att
{
    public class HolicdDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="conn"></param>
        public HolicdDao(IDbConnection conn = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public HolicdDao(string ConnectionString = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        public HolicdDao()
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();
        }

        /// <summary>
        /// 取得行事曆資料
        /// </summary>
        /// <param name="sCode">行事曆代碼</param>
        /// <returns>List HolicdRow</returns>
        public List<HolicdRow> GetHolicd(string sCode = "")
        {
            var Vdb = (from c in dcHr.HOLICD
                       where sCode == "" || c.HOLI_CODE == sCode
                       select new HolicdRow
                       {
                           HolicdCode = c.HOLI_CODE,
                           HolicdName = c.HOLI_NAME,
                           Name = c.HOLI_NAME + "(" + c.HOLI_CODE_DISP + ")",
                       }).ToList();

            return Vdb;
        }
    }
}
