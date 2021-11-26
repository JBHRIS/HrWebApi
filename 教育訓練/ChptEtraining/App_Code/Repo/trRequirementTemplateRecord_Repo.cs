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
    public class trRequirementTemplateRecord_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public trRequirementTemplateRecord_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trRequirementTemplateRecord_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(trRequirementTemplateRecord o)
        {
            dc.trRequirementTemplateRecord.InsertOnSubmit(o);            
        }

        public void Delete(trRequirementTemplateRecord o)
        {
            DcHelper.Detach(o); 
            dc.trRequirementTemplateRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trRequirementTemplateRecord.DeleteOnSubmit(o);
        }


        public void DeleteList(List<trRequirementTemplateRecord> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.trRequirementTemplateRecord.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.trRequirementTemplateRecord.DeleteOnSubmit(o);
            }
        }


        public void Update(trRequirementTemplateRecord o)
        {
            DcHelper.Detach(o); 
            dc.trRequirementTemplateRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// 抓取資料by isClosed
        /// </summary>
        /// <param name="AisClosed"></param>
        /// <returns></returns>
        public List<trRequirementTemplateRecord> GetByIsClosed(bool AisClosed)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplateRecord
                        where c.bIsClosed == AisClosed
                        select c).ToList();
            }
        }

        public trRequirementTemplateRecord GetByYear(int Ayear)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplateRecord
                        where c.iYear == Ayear
                        select c).FirstOrDefault();
            }
        }

        public List<trRequirementTemplateRecord> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return ldc.trRequirementTemplateRecord.ToList();
            }
        }
    }
}