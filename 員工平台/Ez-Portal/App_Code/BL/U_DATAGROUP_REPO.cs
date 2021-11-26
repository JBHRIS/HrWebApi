using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Data.Linq;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class U_DATAGROUP_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public U_DATAGROUP_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public U_DATAGROUP_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<U_DATAGROUP> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.U_DATAGROUP
                        select c).ToList();
            }
        }

        public List<U_DATAGROUP> GetByUserId_Dlo(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<U_DATAGROUP>(l =>l.COMP);
                ldc.LoadOptions = dlo;
                return (from c in ldc.U_DATAGROUP 
                        where c.USER_ID==Avalue
                        select c).ToList();
            }
        }
    }
    

}