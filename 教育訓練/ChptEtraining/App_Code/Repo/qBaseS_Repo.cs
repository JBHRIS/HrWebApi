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
    public class qBaseS_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public qBaseS_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public qBaseS_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(qBaseS o)
        {
            dc.qBaseS.InsertOnSubmit(o);            
        }

        public void Delete(qBaseS o)
        {
            DcHelper.Detach(o); 
            dc.qBaseS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.qBaseS.DeleteOnSubmit(o);
        }


        public void DeleteList(List<qBaseS> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.qBaseS.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.qBaseS.DeleteOnSubmit(o);
            }
        }

        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.qBaseS
                       where c.iAutokey == id
                       select c).FirstOrDefault();
            dc.qBaseS.DeleteOnSubmit(obj);
        }

        public void Update(qBaseS o)
        {
            DcHelper.Detach(o); 
            dc.qBaseS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<qBaseS> GetByQbaseCode(string qBaseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseS
                        where c.qBase_sCode == qBaseCode
                        select c).ToList();
            }
        }




        public qBaseS GetById(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseS
                        where c.iAutokey == id
                        select c).SingleOrDefault();
            }
        }

    }
}