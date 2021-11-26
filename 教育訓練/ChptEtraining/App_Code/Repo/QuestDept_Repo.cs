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
    public class QuestDept_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QuestDept_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QuestDept_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QuestDept o)
        {
            dc.QuestDept.InsertOnSubmit(o);            
        }

        public void Update(QuestDept o)
        {
            DcHelper.Detach(o);
            dc.QuestDept.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QuestDept o)
        {
            DcHelper.Detach(o);
            dc.QuestDept.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QuestDept.DeleteOnSubmit(o);
        }

        //public List<QuestDept> GetAll()
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.QuestDept
        //                select c).ToList();
        //    }
        //}

        public List<QuestDept> GetByYear(int year)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QuestDept
                        where c.Year==year
                        select c).ToList();
            }
        }

        public QuestDept GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDept
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }


        public QuestDept GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QuestDept
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public QuestDept GetByYearDept(int year, string deptCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QuestDept
                        where c.Year==year
                        && c.DeptCode == deptCode
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 重新計算該年度，該部門的預估金額
        /// </summary>
        /// <param name="year"></param>
        /// <param name="deptCode"></param>
        public void CalcAmtByYearDept(int year , string deptCode)
        {
            QuestDept qdObj = GetByYearDept(year , deptCode);
            if ( qdObj == null )
                return;
            else
            {

                QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
                List<QuestDeptDetail3> qdd3List = qdd3Repo.GetByYearDeptCode_Dlo(year , deptCode);

                QuestDeptCustom3_Repo qdc3Repo = new QuestDeptCustom3_Repo();
                List<QuestDeptCustom3> qdc3List = qdc3Repo.GetByYearDeptCode_Dlo(year , deptCode);

                int amt = (from c in qdd3List
                           where c.IsRejection == false
                           && c.IsRequired
                           && c.Amt.HasValue
                           select c.Amt.Value).Sum();

                amt = amt + (from c in qdc3List
                             where c.IsRejection == false
                             && c.IsRequired
                                 && c.Amt.HasValue
                             select c.Amt.Value).Sum();

                qdObj.Amt = amt;
                Update(qdObj);
                Save();
            }
        }
    }
}