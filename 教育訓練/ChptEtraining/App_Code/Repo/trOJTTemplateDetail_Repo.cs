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
    public class trOJTTemplateDetail_Repo
    {
        private dcTrainingDataContext dc;

        public trOJTTemplateDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trOJTTemplateDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(trOJTTemplateDetail o)
        {
            dc.trOJTTemplateDetail.InsertOnSubmit(o);            
        }

        public void Delete(trOJTTemplateDetail o)
        {
            dc.trOJTTemplateDetail.DeleteOnSubmit(o);
        }

        //public void Delete(int id)
        //{
        //    var obj = (from c in dc.trOJTTemplateDetail
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.trOJTTemplateDetail.DeleteOnSubmit(obj);
        //}

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<trOJTTemplateDetail> GetByOjtTplCode(string Acode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTTemplateDetail
                        where c.OJT_sCode ==Acode
                        select c).ToList();
            }

        }

    }
}