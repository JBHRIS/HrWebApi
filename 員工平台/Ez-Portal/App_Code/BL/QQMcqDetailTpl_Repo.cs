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
    public class QQMcqDetailTpl_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QQMcqDetailTpl_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QQMcqDetailTpl_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QQMcqDetailTpl o)
        {
            dc.QQMcqDetailTpl.InsertOnSubmit(o);            
        }

        public void Add(List<QQMcqDetailTpl> list)
        {
            foreach(var o in list)
                dc.QQMcqDetailTpl.InsertOnSubmit(o);
        }

        public void Update(QQMcqDetailTpl o)
        {
            DcHelper.Detach(o);
            dc.QQMcqDetailTpl.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QQMcqDetailTpl o)
        {
            DcHelper.Detach(o);
            dc.QQMcqDetailTpl.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QQMcqDetailTpl.DeleteOnSubmit(o);
        }

        public List<QQMcqDetailTpl> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcqDetailTpl
                        select c).ToList();
            }
        }

        public QQMcqDetailTpl GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcqDetailTpl
                        where c.Id ==id
                        select c).FirstOrDefault();
            }
        }

        public List<QQMcqDetailTpl> GetByGroupCode(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcqDetailTpl
                        where c.GroupCode == code
                        select c).ToList();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<string> GetDistinctGroup()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQMcqDetailTpl
                        select c.GroupCode).Distinct().ToList();
            }
        }
    }
}