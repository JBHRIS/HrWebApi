using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class CoursePlanDetail_TeachingMethod_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public CoursePlanDetail_TeachingMethod_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public CoursePlanDetail_TeachingMethod_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(CoursePlanDetail_TeachingMethod o)
        {
            dc.CoursePlanDetail_TeachingMethod.InsertOnSubmit(o);            
        }

        public void Update(CoursePlanDetail_TeachingMethod o)
        {
            DcHelper.Detach(o);
            dc.CoursePlanDetail_TeachingMethod.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(CoursePlanDetail_TeachingMethod o)
        {
            DcHelper.Detach(o);
            dc.CoursePlanDetail_TeachingMethod.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.CoursePlanDetail_TeachingMethod.DeleteOnSubmit(o);
        }



        public CoursePlanDetail_TeachingMethod GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.CoursePlanDetail_TeachingMethod
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }




        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}