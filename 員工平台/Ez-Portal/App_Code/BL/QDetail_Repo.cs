using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// QDetail_Repo 的摘要描述
    /// </summary>
    public class QDetail_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QDetail_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QDetail_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QDetail o)
        {
            dc.QDetail.InsertOnSubmit(o);            
        }

        public void Update(QDetail o)
        {
            DcHelper.Detach(o);
            dc.QDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QDetail o)
        {
            DcHelper.Detach(o);
            dc.QDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QDetail.DeleteOnSubmit(o);
        }

        public List<QDetail> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QDetail
                        select c).ToList();
            }
        }

        public List<QDetail> GetByTplCatId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QDetail
                        where c.QTplCategoryId == id
                        select c).ToList();
            }
        }

        public List<QDetail> GetByQQItemId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QDetail
                        where c.QQItemId == id
                        select c).ToList();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}