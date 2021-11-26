using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OldBll.Att.Vdb;

namespace OldDal.Dao.Att
{
    public class OtRatecdDao
    {
        private JBModule.Data.Linq.HrDBDataContext dcHr;

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="conn"></param>
        public OtRatecdDao(IDbConnection conn = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(conn.ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        /// <param name="ConnectionString"></param>
        public OtRatecdDao(string ConnectionString = null)
        {
                dcHr = new JBModule.Data.Linq.HrDBDataContext(ConnectionString);
        }

        /// <summary>
        /// 代碼
        /// </summary>
        public OtRatecdDao()
        {
            dcHr = new JBModule.Data.Linq.HrDBDataContext();
        }

        /// <summary>
        /// 取得加班頻率資料
        /// </summary>
        /// <param name="sCode">加班頻率代碼</param>
        /// <returns>List OtRatecdRow</returns>
        public List<OtRatecdRow> GetOtRatecd(string sCode = "")
        {
            var Vdb = (from c in dcHr.OTRATECD
                       where sCode == "" || c.OTRATE_CODE == sCode
                       select new OtRatecdRow
                       {
                           OtRatecdCode = c.OTRATE_CODE,
                           OtRatecdName = c.OTRATE_NAME,
                           Name = c.OTRATE_NAME + "(" + c.OTRATE_CODE + ")",
                       }).ToList();

            return Vdb;
        }
        /// <summary>
        /// 取得加班頻率資料
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>List OtRatecdRow</returns>
        public List<OtRatecdRow> GetOtRatecdByFilter(string sNobr = "", DateTime? dDate = null)
        {
            var Vdb = (from c in dcHr.OTRATECD
                       where dcHr.GetCodeFilterByNobr("OTRATECD", c.OTRATE_CODE, sNobr, dDate.Value.Date).Value
                       select new OtRatecdRow
                       {
                           OtRatecdCode = c.OTRATE_CODE,
                           OtRatecdName = c.OTRATE_NAME,
                           Name = c.OTRATE_NAME + "(" + c.OTRATE_CODE + ")",
                       }).ToList();

            return Vdb;
        }
    }
}
