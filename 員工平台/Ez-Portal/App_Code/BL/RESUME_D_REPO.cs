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
    public class RESUME_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }

        public RESUME_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public RESUME_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public void Add(RESUME o)
        {
            dc.RESUME.InsertOnSubmit(o);
        }

        public void Delete(RESUME o)
        {
            DcHelper.Detach(o);
            dc.RESUME.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.RESUME.DeleteOnSubmit(o);            
        }

        public RESUME GetByPk(string value)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.RESUME
                        where c.PNO == value
                        select c).FirstOrDefault();
            }
        }


        public List<RESUME> GetAll_Dlo()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<RESUME>(l => l.RESUME_D);
                ldc.LoadOptions = dlo;
                return (from c in ldc.RESUME
                        select c).ToList();
            }
        }
    }    
}