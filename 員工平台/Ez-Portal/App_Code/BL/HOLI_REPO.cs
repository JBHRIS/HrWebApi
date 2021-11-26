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
    public class HOLI_REPO
    {
        public JBHRModelDataContext dc;
        public HOLI_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public HOLI_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<HOLI> GetByDateRange(DateTime adate, DateTime ddate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.HOLI where c.H_DATE >= adate && c.H_DATE <= ddate select c).ToList();
            }
        }

        public List<HOLI> GetByDateRange_Dlo(DateTime adate, DateTime ddate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<HOLI>(l => l.OTHCODE1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.HOLI where c.H_DATE >= adate && c.H_DATE <= ddate select c).ToList();
            }
        }

        public List<HOLI> GetByDateRange_Dlo(DateTime adate, DateTime ddate, string holiCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<HOLI>(l => l.OTHCODE1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.HOLI
                        where c.H_DATE >= adate && c.H_DATE <= ddate
                            && c.HOLI_CODE == holiCode
                        select c).ToList();
            }
        }
    }    
}