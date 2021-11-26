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
    public class QQMcq_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QQMcq_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QQMcq_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QQMcq o)
        {
            dc.QQMcq.InsertOnSubmit(o);            
        }

        public void Update(QQMcq o)
        {
            DcHelper.Detach(o);
            dc.QQMcq.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QQMcq o)
        {
            DcHelper.Detach(o);
            dc.QQMcq.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QQMcq.DeleteOnSubmit(o);
        }

        public List<QQMcq> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QQMcq
                        select c).ToList();
            }
        }

        public QQMcq GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QQMcq
                        where c.Id ==id
                        select c).FirstOrDefault();
            }
        }

        public QQMcq GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QQMcq
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}