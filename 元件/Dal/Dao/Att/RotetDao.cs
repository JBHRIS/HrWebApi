using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Bll.Att.Vdb;

namespace Dal.Dao.Att
{
    public class RotetDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="conn"></param>
        public RotetDao(IDbConnection conn = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public RotetDao(string ConnectionString = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        public RotetDao()
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();
        }

        /// <summary>
        /// 取得班別資料
        /// </summary>
        /// <param name="sCode">班別代碼</param>
        /// <returns>List RotetRow</returns>
        public List<RotetRow> GetRotet(string sCode = "")
        {
            var Vdb = (from c in dcHr.ROTET
                       where sCode == "" || c.ROTET1 == sCode
                       select new RotetRow
                       {
                           RotetCode = c.ROTET1,
                           RotetName = c.ROTETNAME,
                           Name = c.ROTETNAME + "(" + c.ROTET_DISP + ")",
                       }).ToList();

            return Vdb;
        }
    }
}
