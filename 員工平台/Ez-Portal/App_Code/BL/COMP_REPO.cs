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
    public class COMP_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public COMP_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public COMP_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<COMP> GetAll()
        {
            List<COMP> list = new List<COMP>();
            return (from c in dc.COMP           
                    select c).ToList();            
        }

        public COMP GetByPk(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.COMP
                        where c.COMP1 == Avalue
                        select c).FirstOrDefault();
            }
        }

    }
    

}