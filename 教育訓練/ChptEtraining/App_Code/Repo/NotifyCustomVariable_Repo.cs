using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
namespace Repo
{
    /// <summary>
    ///
    /// </summary>
    public class NotifyCustomVariable_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public NotifyCustomVariable_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public NotifyCustomVariable_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        public void Add(NotifyCustomVariable o)
        {
            dc.NotifyCustomVariable.InsertOnSubmit(o);
        }

        public NotifyCustomVariable GetByPk(string Acode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyCustomVariable
                        where c.Code ==Acode
                        select c).FirstOrDefault();
            }
        }

        //public void Delete(NotifyCustomVariable o)
        //{
        //    dc.NotifyCustomVariable.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //    dc.NotifyCustomVariable.DeleteOnSubmit(o);
        //}

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.NotifyCustomVariable
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.NotifyCustomVariable.DeleteOnSubmit(obj);
        //}

        public void Update(NotifyCustomVariable o)
        {
            DcHelper.Detach(o);
            dc.NotifyCustomVariable.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public List<NotifyCustomVariable> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyCustomVariable
                        select c).ToList();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}