using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Repo
{    
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class mtCode_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public mtCode_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public mtCode_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(mtCode o)
        {
            dc.mtCode.InsertOnSubmit(o);
        }

        //public void Delete(mtCode o)
        //{
        //    dc.mtCode.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        //    dc.mtCode.DeleteOnSubmit(o);
        //}

        public void Update(mtCode o)
        {
            dc.mtCode.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<mtCode> GetByCategroy(string code)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.mtCode where c.sCategory==code select c).ToList();
            }
        }

        public mtCode GetByCategroyCode(string cat,string code)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                var result= (from c in tdc.mtCode where c.sCategory == cat && c.sCode == code select c).FirstOrDefault();
                if (result == null)
                    throw new ApplicationException("can't find Categroy:" + cat + ",Code:" + code + " in mtcode");
                else
                    return result;
            }
        }
    }
}