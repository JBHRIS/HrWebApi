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
    public class QuestDeptDetail3_Repo
    {
        public dcTrainingDataContext dc
        {
            get;
            set;
        }

        public QuestDeptDetail3_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QuestDeptDetail3_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }


        public void Add(QuestDeptDetail3 o)
        {
            dc.QuestDeptDetail3.InsertOnSubmit(o);
        }

        public void Update(QuestDeptDetail3 o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptDetail3.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }


        public void Delete(QuestDeptDetail3 o)
        {
            DcHelper.Detach(o);
            dc.QuestDeptDetail3.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.QuestDeptDetail3.DeleteOnSubmit(o);
        }


        public QuestDeptDetail3 GetByPk(int id)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QuestDeptDetail3
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }


        public List<QuestDeptDetail3> GetByQuestDeptId(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDeptDetail3
                        where c.QuestDeptId == id
                        select c).ToList();
            }
        }


        public QuestDeptDetail3 GetByPk_Dlo(int id)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptDetail3
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<QuestDeptDetail3> GetByYearDeptCode_Dlo(int year , string deptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QuestDeptDetail3>(l => l.QuestDept);
                dlo.LoadWith<QuestDeptDetail3>(l => l.trTrainingMethod);
                dlo.LoadWith<QuestDept>(l => l.DEPT);
                dlo.LoadWith<QuestDeptDetail3>(l => l.BASE);
                dlo.LoadWith<QuestDeptDetail3>(l => l.trRequirementTemplateCourse);
                dlo.LoadWith<QuestDeptDetail3>(l => l.trKnotTeaches);
                dlo.LoadWith<trRequirementTemplateCourse>(l => l.trCourse);
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDeptDetail3
                        where c.QuestDept.Year == year
                        && c.QuestDept.DeptCode == deptCode
                        select c).ToList();
            }
        }

        public QuestDeptDetail3 GetByQDId_RTCId(int qdId , int rtcId)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {

                return (from c in ldc.QuestDeptDetail3
                        where c.QuestDeptId == qdId
                        && c.trRequirementTemplateCourseId == rtcId
                        select c).FirstOrDefault();
            }
        }
    }
}