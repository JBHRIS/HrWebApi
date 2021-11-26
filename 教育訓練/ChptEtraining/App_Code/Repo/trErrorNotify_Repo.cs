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
    public class trErrorNotify_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public trErrorNotify_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trErrorNotify_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        public void Add(trErrorNotify o)
        {
            dc.trErrorNotify.InsertOnSubmit(o);            
        }

        //public void Delete(trErrorNotify o)
        //{
        //    dc.trErrorNotify.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //    dc.trErrorNotify.DeleteOnSubmit(o);
        //}


        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}