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
    public class trAttendClassDate_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trAttendClassDate_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trAttendClassDate_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trAttendClassDate o)
        {
            dc.trAttendClassDate.InsertOnSubmit(o);
        }

        public void Delete(trAttendClassDate o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassDate.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trAttendClassDate.DeleteOnSubmit(o);
        }

        public void Update(trAttendClassDate o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassDate.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trAttendClassDate> GetByClassKey(int id)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.trAttendClassDate where c.iClassAutoKey == id select c).ToList();
            }
        }
    }
}