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
    public class trCategoryCourse_Repo
    {
        public dcTrainingDataContext dc { get; set; }
        private trCategory_Repo catRepo = new trCategory_Repo();
        public trCategoryCourse_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trCategoryCourse_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        public void Add(trCategoryCourse o)
        {
            if (!IsValid(o))
                throw new ApplicationException("此類別不允許關聯課程");

            dc.trCategoryCourse.InsertOnSubmit(o);            
        }

        public bool IsValid(trCategoryCourse o)
        {            
            //為最後一層課程類別才可以新增課程
            if (catRepo.IsLastCategoryLevel(o.sCateCode))
                return true;
            else
                return false;
        }


        public void Update(trCategoryCourse o)
        {
            DcHelper.Detach(o);
            dc.trCategoryCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(trCategoryCourse o)
        {
            DcHelper.Detach(o);
            dc.trCategoryCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trCategoryCourse.DeleteOnSubmit(o);
        }

        public trCategoryCourse GetByCatCourse(string catCode, string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trCategoryCourse
                        where c.sCateCode == catCode && c.sCourseCode == courseCode
                        select c).FirstOrDefault();
            }
        }

        public trCategoryCourse GetByCourseCode(string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trCategoryCourse
                        where c.sCourseCode == courseCode
                        select c).FirstOrDefault();
            }
        }



        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}