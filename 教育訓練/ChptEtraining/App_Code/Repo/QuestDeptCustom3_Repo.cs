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
    public class QuestDeptCustom3_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QuestDeptCustom3_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QuestDeptCustom3_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QuestDeptCustom3 o)
        {
            dc.QuestDeptCustom3.InsertOnSubmit(o);            
        }

        public void Update(QuestDeptCustom3 o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptCustom3.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QuestDeptCustom3 o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptCustom3.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QuestDeptCustom3.DeleteOnSubmit(o);
        }

        //public List<QuestDeptCustom3> GetAll()
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.QuestDeptCustom3
        //                select c).ToList();
        //    }
        //}

        public List<QuestDeptCustom3> GetByYear(int year)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QuestDeptCustom3
                        where c.Year==year
                        select c).ToList();
            }
        }

        public QuestDeptCustom3 GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDeptCustom3
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }


        public QuestDeptCustom3 GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptCustom3
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }



        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<QuestDeptCustom3> GetByYearDeptCode_Dlo(int year , string deptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QuestDeptCustom3>(l => l.trKnotTeaches);
                dlo.LoadWith<QuestDeptCustom3>(l => l.trTrainingMethod);
                dlo.LoadWith<QuestDeptCustom3>(l => l.DEPT);
                dlo.LoadWith<QuestDeptCustom3>(l => l.BASE);
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptCustom3
                        where c.Year == year
                        && c.DeptCode == deptCode
                        select c).ToList();
            }
        }
    }
}