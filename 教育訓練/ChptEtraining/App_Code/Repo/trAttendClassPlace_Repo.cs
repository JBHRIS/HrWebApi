using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Repo
{    
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class trAttendClassPlace_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trAttendClassPlace_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trAttendClassPlace_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trAttendClassPlace o)
        {
            dc.trAttendClassPlace.InsertOnSubmit(o);
        }

        public void Delete(trAttendClassPlace o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassPlace.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trAttendClassPlace.DeleteOnSubmit(o);
        }

        public void Update(trAttendClassPlace o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassPlace.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trAttendClassPlace> GetByClassKey(int id)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.trAttendClassPlace where c.iClassAutoKey == id select c).ToList();
            }
        }
    }
}