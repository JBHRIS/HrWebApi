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
    public class UpBaseRecord_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public UpBaseRecord_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public UpBaseRecord_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<UpBaseRecord> GetByNobr_DateRange(string nobr, DateTime adate, DateTime ddate)
        {
            return (from c in dc.UpBaseRecord where c.NOBR==nobr 
                        && c.KEY_DATE >= adate 
                        && c.KEY_DATE<=ddate select c).ToList();
        }
    }    
}