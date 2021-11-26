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
    public class EmpTts_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public EmpTts_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public EmpTts_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(EmpTts o)
        {
            dc.EmpTts.InsertOnSubmit(o);
        }

        public void Update(EmpTts o)
        {
            DcHelper.Detach(o);
            dc.EmpTts.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<EmpTts> GetAll()
        {
            List<EmpTts> list = new List<EmpTts>();
            return (from c in dc.EmpTts           
                    select c).ToList();            
        }

        public List<EmpTts> GetByNobr(string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.EmpTts
                        where c.nobr == nobr
                        select c).ToList();
            }
        }
    }
    

}