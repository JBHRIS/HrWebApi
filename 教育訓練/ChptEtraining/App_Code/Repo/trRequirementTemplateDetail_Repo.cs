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
    public class trRequirementTemplateDetail_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trRequirementTemplateDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trRequirementTemplateDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(trRequirementTemplateDetail o)
        {
            dc.trRequirementTemplateDetail.InsertOnSubmit(o);            
        }

        public void Update(trRequirementTemplateDetail o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplateDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(trRequirementTemplateDetail o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplateDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trRequirementTemplateDetail.DeleteOnSubmit(o);
        }

        //public List<trRequirementTemplateDetail> GetAll()
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.trRequirementTemplateDetail
        //                select c).ToList();
        //    }
        //}


        public trRequirementTemplateDetail GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplateDetail
                        where c.iAutoKey==id
                        select c).FirstOrDefault();
            }
        }

        public List<trRequirementTemplateDetail> GetByTplCode(string code)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.trRequirementTemplateDetail
                        where c.Rt_sCode==code
                        select c).ToList();
            }
        }

        public trRequirementTemplateDetail GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;

                return (from c in ldc.trRequirementTemplateDetail
                        where c.iAutoKey == id
                        select c).FirstOrDefault();
            }
        }



        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}