using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBHRModel;
using System.Data.Linq;
namespace BL
{
    /// <summary>
    /// RELCODE_REPO 的摘要描述
    /// </summary>
    public class RELCODE_REPO
    {
        public JBHRModel.JBHRModelDataContext dc{get;set;}
        public RELCODE_REPO(JBHRModel.JBHRModelDataContext o)
        {
            dc = o;
        }

        public RELCODE_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Update(RELCODE o)
        {
            DcHelper.Detach(o);
            dc.RELCODE.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<RELCODE> GetAll()
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.RELCODE select c).ToList();
            }
        }

        public RELCODE GetByPk(string Avalue)
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.RELCODE where c.REL_CODE==Avalue select c).FirstOrDefault();
            }
        }
    }
}
