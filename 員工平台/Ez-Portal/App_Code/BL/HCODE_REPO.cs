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
    public class HCODE_REPO
    {
        private JBHRModelDataContext oc;
        public HCODE_REPO(JBHRModelDataContext o)
        {
            oc = o;
        }

        public HCODE_REPO()
        {
            oc = new JBHRModelDataContext();
        }

        public List<HCODE> GetAll()
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                return (from c in loc.HCODE
                        select c).ToList();
            }
        }



        public List<HCODE> GetByCompany(string companyCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.HCODE
                        where ldc.GetCodeFilter("HCODE", c.H_CODE, "", companyCode, true).Value
                        select c).ToList();
            }
        }
    }
    

}