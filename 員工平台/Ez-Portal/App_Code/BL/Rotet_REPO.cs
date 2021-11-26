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
    public class ROTET_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public ROTET_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ROTET_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<ROTET> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.ROTET
                        select c).ToList();
            }
        }

        public ROTET GetByPk(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.ROTET where c.ROTET1==Avalue
                        select c).FirstOrDefault();
            }
        }
    }
    

}