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
    public class QADetail_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QADetail_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QADetail_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QADetail o)
        {
            dc.QADetail.InsertOnSubmit(o);            
        }

        public void Update(QADetail o)
        {
            DcHelper.Detach(o);
            dc.QADetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Update(List<QADetail> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.QADetail.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            }
        }

        public void Delete(QADetail o)
        {
            DcHelper.Detach(o);
            dc.QADetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QADetail.DeleteOnSubmit(o);
        }

        public void Delete(List<QADetail> list)
        {
            foreach (QADetail o in list)
            {
                DcHelper.Detach(o);
                dc.QADetail.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.QADetail.DeleteOnSubmit(o);
            }
        }

        public List<QADetail> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QADetail
                        select c).ToList();
            }
        }

        public QADetail GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QADetail
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }

        public List<QADetail> GetByQAMasterId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QADetail
                        where c.QAMasterId == id
                        select c).ToList();
            }
        }
 
        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}