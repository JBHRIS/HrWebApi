using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// QTplCategory_Repo 的摘要描述
    /// </summary>
    public class QTplCategory_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QTplCategory_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QTplCategory_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QTplCategory o)
        {
            dc.QTplCategory.InsertOnSubmit(o);            
        }

        public void Update(QTplCategory o)
        {
            DcHelper.Detach(o);
            dc.QTplCategory.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QTplCategory o)
        {
            DcHelper.Detach(o);
            dc.QTplCategory.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QTplCategory.DeleteOnSubmit(o);
        }

        public List<QTplCategory> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QTplCategory
                        select c).ToList();
            }
        }

        public List<QTplCategory> GetByCatCode(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QTplCategory
                        where c.QCategoryCode==code
                        select c).ToList();
            }
        }

        public List<QTplCategory> GetByTplCode(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QTplCategory
                        where c.QTplCode == code
                        select c).ToList();
            }
        }

        public List<QTplCategory> GetByTplCode_Dlo(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QTplCategory>(l => l.QCategory);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QTplCategory
                        where c.QTplCode == code
                        select c).ToList();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}