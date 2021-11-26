using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Collections;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class sysRole_Repo
    {
        public JBHRModelDataContext dc { get; set; }     

        public sysRole_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public sysRole_Repo(JBHRModelDataContext d)
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
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.sysRole
                        select c).ToList();
            }
        }

        public sysRole GetByPK(string pk)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.sysRole
                        where c.Code.Equals(pk)
                        select c).FirstOrDefault();
            }
        }

        public List<sysRole> GetVisibleRole()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.sysRole
                        where c.IsVisible == true
                        select c).ToList();
            }
        }
    }
}