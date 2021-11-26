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
    public class trTrainingEstimateCost_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trTrainingEstimateCost_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTrainingEstimateCost_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trTrainingEstimateCost o)
        {
            dc.trTrainingEstimateCost.InsertOnSubmit(o);
        }

        public void Delete(trTrainingEstimateCost o)
        {
            dc.trTrainingEstimateCost.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trTrainingEstimateCost.DeleteOnSubmit(o);
        }

        public void Update(trTrainingEstimateCost o)
        {
            dc.trTrainingEstimateCost.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trTrainingEstimateCost> GetByClassKey(int id)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.trTrainingEstimateCost where c.iClassAutoKey == id select c).ToList();
           }
        }
    }
}