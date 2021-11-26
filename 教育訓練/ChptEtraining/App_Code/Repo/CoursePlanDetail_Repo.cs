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
    public class CoursePlanDetail_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public CoursePlanDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public CoursePlanDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }


        public void Add(CoursePlanDetail o)
        {
            dc.CoursePlanDetail.InsertOnSubmit(o);
        }

        public void Update(CoursePlanDetail o)
        {
            DcHelper.Detach(o);
            dc.CoursePlanDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(CoursePlanDetail o)
        {
            DcHelper.Detach(o);
            dc.CoursePlanDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.CoursePlanDetail.DeleteOnSubmit(o);
        }

        public List<CoursePlanDetail> GetByClassId_Dlo(int classId)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingMethod);
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingResource);
                ldc.LoadOptions = dlo;
                return (from c in ldc.CoursePlanDetail
                        where c.ClassAutoKey == classId
                        select c).ToList();
            }
        }

        public List<CoursePlanDetailView> GetCoursePlanDetailViewListByClassId_Dlo(int classId)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingMethod);
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingResource);
                ldc.LoadOptions = dlo;

                var list = (from c in ldc.CoursePlanDetail
                            where c.ClassAutoKey == classId
                            select c).ToList();

                List<CoursePlanDetailView> cpdvList = new List<CoursePlanDetailView>();

                StringBuilder sb = new StringBuilder();

                foreach (CoursePlanDetail i in list)
                {
                    CoursePlanDetailView obj = new CoursePlanDetailView();
                    obj.ClassAutoKey = i.ClassAutoKey;
                    obj.Id = i.Id;
                    obj.PlanDetailName = i.PlanDetailName;
                    obj.PlanDetailNote = i.PlanDetailNote;
                    obj.PlanDetailOrder = i.PlanDetailOrder;
                    obj.PlanDetailOutline = i.PlanDetailOutline;
                    obj.PlanDetailTimeMin = i.PlanDetailTimeMin;

                    sb.Clear();
                    sb.Append("");

                    foreach (var m in i.CoursePlanDetail_TeachingMethod)
                    {
                        sb.Append(m.trTeachingMethod.sName);
                        sb.Append("、");
                    }

                    if (sb.Length > 0)
                        if (sb[sb.Length - 1].Equals('、'))
                        {
                            sb.Remove(sb.Length - 1, 1).ToString();
                        }

                    obj.TeachingMethod = sb.ToString();

                    sb.Clear();

                    foreach (var r in i.CoursePlanDetail_TeachingResource)
                    {
                        sb.Append(r.trTeachingResource.ResourceName);
                        sb.Append("、");
                    }

                    if (sb.Length > 0)
                        if (sb[sb.Length - 1].Equals('、'))
                        {
                            sb.Remove(sb.Length - 1, 1).ToString();
                        }

                    obj.TeachingResource = sb.ToString();
                    cpdvList.Add(obj);
                }

                return cpdvList.OrderBy(p=>p.PlanDetailOrder).ToList();
            }
        }


        public CoursePlanDetail GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.CoursePlanDetail
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }


        public CoursePlanDetail GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingMethod);
                dlo.LoadWith<CoursePlanDetail>(l => l.CoursePlanDetail_TeachingResource);
                ldc.LoadOptions = dlo;

                return (from c in ldc.CoursePlanDetail
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}