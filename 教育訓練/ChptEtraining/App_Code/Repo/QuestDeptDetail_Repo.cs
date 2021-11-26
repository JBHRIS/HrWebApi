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
    public class QuestDeptDetail_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QuestDeptDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QuestDeptDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QuestDeptDetail o)
        {
            dc.QuestDeptDetail.InsertOnSubmit(o);            
        }

        public void Update(QuestDeptDetail o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QuestDeptDetail o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QuestDeptDetail.DeleteOnSubmit(o);
        }

        //public List<QuestDeptDetail> GetAll()
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.QuestDeptDetail
        //                select c).ToList();
        //    }
        //}


        public QuestDeptDetail GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDeptDetail
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }


        public QuestDeptDetail GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptDetail
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }



        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<QuestDeptDetail> GetByYearDeptCode_Dlo(int year , string deptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QuestDeptDetail>(l => l.QuestDept);
                dlo.LoadWith<QuestDeptDetail>(l => l.trRequirementTemplateDetail);
                dlo.LoadWith<trRequirementTemplateDetail>(l => l.trRequirementTemplateCat);
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptDetail
                        where c.QuestDept.Year==year
                        && c.QuestDept.DeptCode==deptCode
                        select c).ToList();
            }
        }
    }
}