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
    /// DEPTA 的摘要描述
    /// </summary>
    public class COMP_DATAGROUP_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public COMP_DATAGROUP_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public COMP_DATAGROUP_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<COMP_DATAGROUP> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.COMP_DATAGROUP
                        select c).ToList();
            }
        }

        public List<COMP_DATAGROUP> GetByComp(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                return (from c in ldc.COMP_DATAGROUP 
                        where c.COMP == Avalue
                        select c).ToList();
            }
        }
    }
    

}