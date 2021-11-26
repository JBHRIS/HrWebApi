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
    public class trAttendClassTeacher_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trAttendClassTeacher_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trAttendClassTeacher_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trAttendClassTeacher o)
        {
            dc.trAttendClassTeacher.InsertOnSubmit(o);
        }

        public void Delete(trAttendClassTeacher o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trAttendClassTeacher.DeleteOnSubmit(o);
        }

        public void Update(trAttendClassTeacher o)
        {
            DcHelper.Detach(o); 
            dc.trAttendClassTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trAttendClassTeacher> GetByClassKey(int id)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.trAttendClassTeacher where c.iClassAutoKey == id select c).ToList();
            }
        }
    }
}