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
    public class QQItem_Repo
    {
        public JBHRModelDataContext dc { get; set; }
        public const string QQItemDisplayName = "JB_QQItem_Repo";

        public QQItem_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QQItem_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QQItem o)
        {
            dc.QQItem.InsertOnSubmit(o);            
        }

        public void Update(QQItem o)
        {
            DcHelper.Detach(o);
            dc.QQItem.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QQItem o)
        {
            DcHelper.Detach(o);
            dc.QQItem.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QQItem.DeleteOnSubmit(o);
        }

        public List<QQItem> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQItem
                        select c).ToList();
            }
        }

        public List<QQItem> GetAll_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QQItem>(l => l.QQType);
                dlo.LoadWith<QQItem>(l => l.QQMcq);
                dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QQItem
                        select c).ToList();
            }
        }


        public QQItem GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQItem
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }


        public QQItem GetByPk_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QQItem>(l => l.QQType);
                dlo.LoadWith<QQItem>(l => l.QQMcq);
                dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                ldc.LoadOptions = dlo;

                return (from c in ldc.QQItem
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<QQItem> GetByTplCode_Dlo(string tplCode)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QQItem>(l => l.QQType);
                //dlo.LoadWith<QQItem>(l => l.QQMcq);
                dlo.LoadWith<QQItem>(l => l.QDetail);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QQItem
                        where c.QDetail.Any(p=>p.QTplCategory.QTplCode==tplCode)
                        select c).ToList();
            }
        }

        public List<QQItem> GetByTpl(string tplCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                //DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QQItem>(l => l.QQType);
                //dlo.LoadWith<QQItem>(l => l.QQMcq);
                //dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                //ldc.LoadOptions = dlo;
                return (from c in ldc.QQItem
                        where c.QDetail.Any(p => p.QTplCategory.QTplCode == tplCode)
                        select c).ToList();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}