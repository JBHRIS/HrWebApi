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
    public class HOLICD_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public HOLICD_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public HOLICD_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<HOLICD> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.HOLICD select c).ToList();
            }
        }
    }    
}