using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Collections;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class sysRole_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public sysRole_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public sysRole_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        public void Add(sysRole o)
        {
            dc.sysRole.InsertOnSubmit(o);            
        }

        //public void Delete(sysRole o)
        //{
        //    dc.sysRole.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //    dc.sysRole.DeleteOnSubmit(o);
        //}

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.sysRole
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.sysRole.DeleteOnSubmit(obj);
        //}


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<sysRole> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysRole
                        select c).ToList();
            }
        }

        public List<sysRole> GetVisibleRole()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysRole
                        where c.IsVisible == true
                        select c).ToList();
            }
        }
    }
}