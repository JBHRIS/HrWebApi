using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;
using JBHRModel;
namespace BL
{
    public class NotifyMsgTargetRepo
    {        
        public JBHRModelDataContext dc { get; set; }
        public NotifyMsgTargetRepo()
        {
            dc = new JBHRModelDataContext();
        }

        public NotifyMsgTargetRepo(DbConnection conn)
        {
            dc = new JBHRModelDataContext(conn);                     
        }

        public NotifyMsgTargetRepo(JBHRModelDataContext o)
        {
            dc = o;
        }

        public void Add(NotifyMsgTarget o)
        {
            dc.NotifyMsgTarget.InsertOnSubmit(o);
        }

        public void Delete(NotifyMsgTarget o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgTarget.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyMsgTarget.DeleteOnSubmit(o);
        }

        public void Update(NotifyMsgTarget o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgTarget.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<NotifyMsgTarget> GetByNotifyMsgGuid(string Aid)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NotifyMsgTarget
                        where c.NotifyMsgGuid == Aid
                        select c).ToList();
            }
        }

        //public NotifyMsgTarget GetByPK(string pk)
        //{
        //    using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //    {
        //        return (from c in ldc.NotifyMsgTarget
        //                where c.Guid==pk
        //                select c).FirstOrDefault();
        //    }
        //}
    }
}
