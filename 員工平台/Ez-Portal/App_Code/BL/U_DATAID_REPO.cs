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
    public class U_DATAID_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public U_DATAID_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public U_DATAID_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<U_DATAID> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in dc.U_DATAID
                        select c).ToList();
            }
        }

        public List<U_DATAID> GetByUserIdSystem(string id,string system)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.U_DATAID
                        where c.USER_ID == id && c.SYSTEM.Equals(system)
                        select c).ToList();
            }
        }

        public List<U_DATAID> GetByUserIdSystem_Dlo(string id , string system)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<U_DATAID>(l => l.DEPT1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.U_DATAID
                        where c.USER_ID == id && c.SYSTEM.Equals(system)
                        select c).ToList();
            }
        }
    }
}