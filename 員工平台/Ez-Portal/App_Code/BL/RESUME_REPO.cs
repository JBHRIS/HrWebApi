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
    public class RESUME_D_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }

        public RESUME_D_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public RESUME_D_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public void Add(RESUME_D o)
        {
            dc.RESUME_D.InsertOnSubmit(o);
        }

        public void Delete(RESUME_D o)
        {
            DcHelper.Detach(o);
            dc.RESUME_D.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.RESUME_D.DeleteOnSubmit(o);            
        }

        public RESUME_D GetByPk(int value)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.RESUME_D
                        where c.Id == value
                        select c).FirstOrDefault();
            }
        }


        public List<RESUME_D> GetAll_Dlo()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<RESUME_D>(l => l.RESUME);
                ldc.LoadOptions = dlo;
                return (from c in ldc.RESUME_D
                        select c).ToList();
            }
        }
    }    
}