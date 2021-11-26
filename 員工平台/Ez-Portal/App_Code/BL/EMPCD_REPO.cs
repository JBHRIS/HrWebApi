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
    public class EMPCD_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public EMPCD_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public EMPCD_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<EMPCD> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.EMPCD select c).ToList();
            }
        }
    }    
}