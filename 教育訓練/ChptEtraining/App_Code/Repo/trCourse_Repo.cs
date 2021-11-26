using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingStudentM 的摘要描述
    /// </summary>
    public class trCourse_Repo
    {
        private trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        public dcTrainingDataContext dc { get; set; }
        public trCourse_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trCourse_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trCourse o)
        {
            dc.trCourse.InsertOnSubmit(o);
        }

        public void Delete(trCourse o)
        {
            DcHelper.Detach(o);
            dc.trCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trCourse.DeleteOnSubmit(o);
        }

        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.trCourse
                       where c.iAutoKey == id
                       select c).FirstOrDefault();
            dc.trCourse.DeleteOnSubmit(obj);
        }

        public void Update(trCourse o)
        {
            DcHelper.Detach(o);
            dc.trCourse.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public trCourse GetByPK(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from dm in ldc.trCourse
                        where dm.iAutoKey == id
                        select dm).FirstOrDefault();
            }
        }

        public trCourse GetByCode_Dlo(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from c in ldc.trCourse
                        where c.sCode == code
                        select c).FirstOrDefault();
            }
        }

        public trCourse GetByCode(string code)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.trCourse
                        where c.sCode == code
                        select c).FirstOrDefault();
            }
        }


        public List<trCourse> GetAll()
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from dm in ldc.trCourse
                        select dm).ToList();
            }
        }
    }
}