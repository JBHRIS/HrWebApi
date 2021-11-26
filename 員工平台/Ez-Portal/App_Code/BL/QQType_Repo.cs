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
    public class QQType_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QQType_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public QQType_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(QQType o)
        {
            dc.QQType.InsertOnSubmit(o);            
        }

        public void Update(QQType o)
        {
            DcHelper.Detach(o);
            dc.QQType.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(QQType o)
        {
            DcHelper.Detach(o);
            dc.QQType.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QQType.DeleteOnSubmit(o);
        }

        public List<QQType> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQType
                        select c).ToList();
            }
        }

        public QQType GetByPk(string code)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QQType
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