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
    public class QCategory_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QCategory_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QCategory_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QCategory o)
        {
            dc.QCategory.InsertOnSubmit(o);            
        }

        public void Update(QCategory o)
        {
            DcHelper.Detach(o);
            dc.QCategory.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QCategory o)
        {
            DcHelper.Detach(o);
            dc.QCategory.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QCategory.DeleteOnSubmit(o);
        }

        public List<QCategory> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QCategory
                        select c).ToList();
            }
        }

        public QCategory GetByPk(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QCategory
                        where c.Code ==code
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}