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
    public class UPLOAD_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public UPLOAD_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public UPLOAD_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(UPLOAD o)
        {
            dc.UPLOAD.InsertOnSubmit(o);            
        }

        public void Delete(UPLOAD o)
        {
            dc.UPLOAD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.UPLOAD.DeleteOnSubmit(o);
        }


        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.UPLOAD
                       where c.iAutoKey == id
                       select c).FirstOrDefault();
            dc.UPLOAD.DeleteOnSubmit(obj);
        }

        public void Update(UPLOAD o)
        {
            dc.UPLOAD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}