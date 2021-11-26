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
    /// CARDLOSD_REPO 的摘要描述
    /// </summary>
    public class CARDLOSD_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public CARDLOSD_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public CARDLOSD_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<CARDLOSD> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CARDLOSD select c).ToList();
            }
        }


        public CARDLOSD GetByCode(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.CARDLOSD where c.CODE == code select c).FirstOrDefault();
            }
        }
    }
}
