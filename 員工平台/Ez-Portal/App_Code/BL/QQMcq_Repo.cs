using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class QQMcq_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QQMcq_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QQMcq_Repo(JBHRModelDataContext d)
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
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcq
                        select c).ToList();
            }
        }

        public QQMcq GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcq
                        where c.Id ==id
                        select c).FirstOrDefault();
            }
        }

        public QQMcq GetByPk_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
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