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
    public class MailLog_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public MailLog_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public MailLog_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }

        public void Add(MailLog o)
        {
            dc.MailLog.InsertOnSubmit(o);            
        }

        //public void Delete(MailLog o)
        //{
        //    dc.MailLog.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //    dc.MailLog.DeleteOnSubmit(o);
        //}

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.MailLog
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.MailLog.DeleteOnSubmit(obj);
        //}

        //public void Update(MailLog o)
        //{
        //    dc.MailLog.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //}

        public List<MailLog> GetByDateRange_DLO(DateTime bdate,DateTime edate)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<MailLog>(l =>l.trMailTemplate);                                
                
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.MailLog
                        where c.dKeyDate >= bdate && c.dKeyDate <=edate                        
                        select c).ToList();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}