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
    public class sysLoginTime_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public sysLoginTime_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public sysLoginTime_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(sysLoginTime o)
        {
            dc.sysLoginTime.InsertOnSubmit(o);            
        }

        //public void Delete(sysLoginTime o)
        //{
        //    dc.sysLoginTime.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //    dc.sysLoginTime.DeleteOnSubmit(o);
        //}

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.sysLoginTime
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.sysLoginTime.DeleteOnSubmit(obj);
        //}

        //public void Update(sysLoginTime o)
        //{
        //    dc.sysLoginTime.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //}

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}