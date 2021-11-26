using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class DeptRepo
    {
        Linq.HrDBDataContext db;
        public DeptRepo()
        {
            db = new Linq.HrDBDataContext();
        }
        /// <summary>
        /// 取得指定公司別的所有部門代碼
        /// </summary>
        /// <param name="Comp">公司代碼</param>
        /// <returns></returns>
        public List<Linq.DEPT> GetDeptListByCompany(string Comp)
        {
            var sql = from a in db.DEPT where db.GetCodeFilter("DEPT", a.D_NO, "", Comp, true).Value select a;
            return sql.ToList();
        }
    }
}
