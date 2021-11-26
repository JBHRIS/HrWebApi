using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;


namespace BL
{
    /// <summary>
    /// DEPTSS 的摘要描述
    /// </summary>
    public class DEPTS_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public DEPTS_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }        

        public DEPTS_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<DEPTS> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.DEPTS
                        select c).ToList();
            }
        }

        /// <summary>
        /// 取得有效的成本部門 By 日期
        /// </summary>
        /// <param name="Adatetime"></param>
        /// <returns></returns>
        public List<DEPTS> GetAllValidByDate(DateTime Adatetime)
        {            
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DEPTS
                        where Adatetime >= c.ADATE && Adatetime<= c.DDATE
                        select c).ToList();
            }
        }

        public DEPTS GetByID(string id)
        {
            return (from c in dc.DEPTS
                    where c.D_NO== id
                    select c).FirstOrDefault();
        }
    }
}