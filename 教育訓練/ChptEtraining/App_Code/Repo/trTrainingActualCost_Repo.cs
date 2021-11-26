using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Repo
{
    /// <summary>trTrainingActualCost
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class trTrainingActualCost_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trTrainingActualCost_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTrainingActualCost_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trTrainingActualCost o)
        {
            dc.trTrainingActualCost.InsertOnSubmit(o);
        }

        public void Delete(trTrainingActualCost o)
        {
            dc.trTrainingActualCost.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trTrainingActualCost.DeleteOnSubmit(o);
        }

        public void Update(trTrainingActualCost o)
        {
            dc.trTrainingActualCost.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trTrainingActualCost> GetByClassKey(int classId)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.trTrainingActualCost where c.iClassAutoKey == classId select c).ToList();
           }
        }

        public trTrainingActualCost GetByClassKeyCostItemCode(int classId , string sCode)
        {
            using ( dcTrainingDataContext tdc = new dcTrainingDataContext() )
            {
                return (from c in tdc.trTrainingActualCost
                        where c.iClassAutoKey == classId
                        && c.trCostItem_sCode ==sCode
                        select c).FirstOrDefault();
            }
        }
    }
}