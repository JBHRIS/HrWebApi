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
    public class QQMcqDetail_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QQMcqDetail_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QQMcqDetail_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(QQMcqDetail o)
        {
            dc.QQMcqDetail.InsertOnSubmit(o);            
        }

        public void Update(QQMcqDetail o)
        {
            DcHelper.Detach(o);
            dc.QQMcqDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QQMcqDetail o)
        {
            DcHelper.Detach(o);
            dc.QQMcqDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QQMcqDetail.DeleteOnSubmit(o);
        }

        public void Delete(List<QQMcqDetail> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.QQMcqDetail.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.QQMcqDetail.DeleteOnSubmit(o);
            }
        }

        public List<QQMcqDetail> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QQMcqDetail
                        select c).ToList();
            }
        }

        public List<QQMcqDetail> GetByQQMcqId(int id)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QQMcqDetail
                        where c.QQMcqId ==id
                        select c).ToList();
            }
        }

        public QQMcqDetail GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QQMcqDetail
                        where c.Id ==id
                        select c).FirstOrDefault();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}