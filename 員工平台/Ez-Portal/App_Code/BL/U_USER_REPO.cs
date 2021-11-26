using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    /// <summary>
    ///  的摘要描述
    /// </summary>
    public class U_USER_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public U_USER_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public U_USER_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<U_USER> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in dc.U_USER
                        select c).ToList();
            }
        }

        public U_USER GetByNobr(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.U_USER
                        where c.NOBR==Avalue
                        select c).FirstOrDefault();
            }
        }
    }
}