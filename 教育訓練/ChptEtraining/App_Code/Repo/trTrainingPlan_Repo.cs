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
    public class trTrainingPlan_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public trTrainingPlan_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTrainingPlan_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trTrainingPlan o)
        {
            dc.trTrainingPlan.InsertOnSubmit(o);
        }

        public void Delete(trTrainingPlan o)
        {
            dc.trTrainingPlan.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.trTrainingPlan.DeleteOnSubmit(o);
        }

        public void Update(trTrainingPlan o)
        {
            dc.trTrainingPlan.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public trTrainingPlan GetDefault()
        {
            trTrainingPlan obj = new trTrainingPlan();
            obj.bEditable = true;
            obj.sGoal = "";
            obj.sNote = "";
            obj.sPolicy = "";
            obj.sProspect = "";
            return obj;
        }

        public trTrainingPlan GetByYear(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingPlan
                        where c.iYear == year
                        select c).FirstOrDefault();
            }
        }
    }
}