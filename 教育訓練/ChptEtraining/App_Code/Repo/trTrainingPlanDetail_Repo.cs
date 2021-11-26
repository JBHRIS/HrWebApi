using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class trTrainingPlanDetail_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trTrainingPlanDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTrainingPlanDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trTrainingPlanDetail o)
        {
            dc.trTrainingPlanDetail.InsertOnSubmit(o);
        }

        public void Delete(trTrainingPlanDetail o)
        {
            DcHelper.Detach(o);
            dc.trTrainingPlanDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingPlanDetail.DeleteOnSubmit(o);
        }

        public void Update(trTrainingPlanDetail o)
        {
            DcHelper.Detach(o);
            dc.trTrainingPlanDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingPlanDetail GetByPk(int pk)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingPlanDetail
                        where c.iAutoKey == pk
                        select c).FirstOrDefault();
            }
        }

        public List<trTrainingPlanDetail> GetByCourseCode(string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingPlanDetail
                        where c.trCourse_sCode == courseCode
                        select c).ToList();
            }
        }

        public trTrainingPlanDetail GetByYear(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingPlanDetail
                        where c.iYear == year
                        select c).FirstOrDefault();
            }
        }


        public List<trTrainingPlanDetail> GetByYear_Dlo(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trTrainingDetailM);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from c in ldc.trTrainingPlanDetail
                        where c.iYear == year
                        && c.trCourse.trCategoryCourse.Any()
                        select c).ToList();
            }
        }

        public List<trTrainingPlanDetail> GetByYearMonth_Dlo(int year, int month)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from c in ldc.trTrainingPlanDetail
                        where c.iYear == year
                        && c.iMonth == month
                        select c).ToList();
            }
        }


        public List<trTrainingPlanDetail> GetByUnRunningYear_Dlo(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trTrainingDetailM);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingPlanDetail>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from c in ldc.trTrainingPlanDetail
                        where c.iYear == year
                        && c.trCourse.trCategoryCourse.Any()
                        && c.iClassAutoKey == null
                        select c).ToList();
            }
        }
    }
}