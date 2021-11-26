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
    public class JOB_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public JOB_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public JOB_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<JOB> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.JOB
                        select c).ToList();
            }
        }
    }
    

}