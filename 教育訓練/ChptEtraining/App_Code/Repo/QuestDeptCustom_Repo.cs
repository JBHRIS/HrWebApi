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
    public class QuestDeptCustom_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QuestDeptCustom_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QuestDeptCustom_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QuestDeptCustom o)
        {
            dc.QuestDeptCustom.InsertOnSubmit(o);            
        }

        public void Update(QuestDeptCustom o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptCustom.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QuestDeptCustom o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptCustom.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QuestDeptCustom.DeleteOnSubmit(o);
        }

        //public List<QuestDeptCustom> GetAll()
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.QuestDeptCustom
        //                select c).ToList();
        //    }
        //}

        public List<QuestDeptCustom> GetByYear(int year)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QuestDeptCustom
                        where c.Year==year
                        select c).ToList();
            }
        }

        public QuestDeptCustom GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDeptCustom
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }


        public QuestDeptCustom GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptCustom
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }



        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<QuestDeptCustom> GetByYearDeptCode(int year , string deptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QuestDeptCustom
                        where c.Year == year
                        && c.DeptCode == deptCode
                        select c).ToList();
            }
        }
    }
}