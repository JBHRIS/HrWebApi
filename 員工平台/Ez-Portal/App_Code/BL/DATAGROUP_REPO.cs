using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class DATAGROUP_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public DATAGROUP_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public DATAGROUP_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<DATAGROUP> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.DATAGROUP
                        select c).ToList();
            }
        }

        public DATAGROUP GetByPk(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DATAGROUP where c.DATAGROUP1==Avalue
                        select c).FirstOrDefault();
            }
        }


    }
    

}