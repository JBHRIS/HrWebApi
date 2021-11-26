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
    public class ROTE_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public ROTE_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ROTE_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<ROTE> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.ROTE
                        select c).ToList();
            }
        }

        public ROTE GetByPk(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.ROTE where c.ROTE1==Avalue
                        select c).FirstOrDefault();
            }
        }
    }
    

}