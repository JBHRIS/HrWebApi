using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class DeptsRepo
    {
        Linq.HrDBDataContext db;
        public DeptsRepo()
        {
            db = new Linq.HrDBDataContext();
        }
        /// <summary>
        /// 取得指定公司別的所有部門代碼
        /// </summary>
        /// <param name="Comp">公司代碼</param>
        /// <returns></returns>
        public List<Linq.DEPTS> GetDeptsListByCompany(string Comp)
        {
            var sql = from a in db.DEPTS where db.GetCodeFilter("DEPTS", a.D_NO, "", Comp, true).Value select a;
            return sql.ToList();
        }
    }
}
