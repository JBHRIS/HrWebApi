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
    public class PARAMETER_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public PARAMETER_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public PARAMETER_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<PARAMETER> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.PARAMETER select c).ToList();
            }
        }
    }    
}