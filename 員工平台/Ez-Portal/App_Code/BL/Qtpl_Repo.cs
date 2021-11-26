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
    public class QTpl_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QTpl_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QTpl_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QTpl o)
        {
            dc.QTpl.InsertOnSubmit(o);            
        }

        public void Update(QTpl o)
        {
            DcHelper.Detach(o);
            dc.QTpl.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QTpl o)
        {
            DcHelper.Detach(o);
            dc.QTpl.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QTpl.DeleteOnSubmit(o);
        }

        public List<QTpl> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QTpl
                        select c).ToList();
            }
        }

        public QTpl GetByPk(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QTpl
                        where c.Code ==code
                        select c).FirstOrDefault();
            }
        }

        public QTpl GetByPk_Dlo(string code)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QTpl>(l => l.QTplCategory);
                dlo.LoadWith<QTplCategory>(l => l.QCategory);
                dlo.LoadWith<QTplCategory>(l => l.QDetail);
                dlo.LoadWith<QDetail>(l => l.QQItem);                
                dlo.LoadWith<QQItem>(l => l.QQMcq);
                dlo.LoadWith<QQItem>(l => l.QQType);
                dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QTpl
                        where c.Code == code
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<QQItem> GetQQItemListByPk_Dlo(string code)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QTpl>(l => l.QTplCategory);
                dlo.LoadWith<QTplCategory>(l => l.QCategory);
                dlo.LoadWith<QTplCategory>(l => l.QDetail);
                dlo.LoadWith<QDetail>(l => l.QQItem);
                dlo.LoadWith<QQItem>(l => l.QQMcq);
                dlo.LoadWith<QQItem>(l => l.QQType);
                dlo.LoadWith<QQMcq>(l => l.QQMcqDetail);
                ldc.LoadOptions = dlo;
                var qObj = (from c in ldc.QTpl
                            where c.Code == code
                            select c).FirstOrDefault();

                List<QQItem> qqItemList = new List<QQItem>();
                foreach ( var cat in qObj.QTplCategory )
                {
                    foreach ( var qd in cat.QDetail )
                    {
                        qqItemList.Add(qd.QQItem);
                    }
                }
                return qqItemList;
            }
        }
    }
}