using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Text;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class trRequirementTemplateCourse_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trRequirementTemplateCourse_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trRequirementTemplateCourse_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }


        public void Add(trRequirementTemplateCourse o)
        {
            dc.trRequirementTemplateCourse.InsertOnSubmit(o);
        }

        public void Update(trRequirementTemplateCourse o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplateCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(trRequirementTemplateCourse o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplateCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trRequirementTemplateCourse.DeleteOnSubmit(o);
        }


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<trRequirementTemplateCourse> GetByRT_CodeDlo(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trRequirementTemplateCourse>(l => l.trCourse);
                ldc.LoadOptions = dlo;
                return (from c in ldc.trRequirementTemplateCourse
                        where c.RT_Code==code
                        select c).ToList();
            }
        }

        public List<trRequirementTemplateCourse> GetByRT_Code(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplateCourse
                        where c.RT_Code == code
                        select c).ToList();
            }
        }

        public trRequirementTemplateCourse GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplateCourse
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
}