using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;
using JBHRModel;
namespace BL
{
    public class NotifyMsgAttachmentRepo
    {        
        public JBHRModelDataContext dc { get; set; }
        public NotifyMsgAttachmentRepo()
        {
            dc = new JBHRModelDataContext();
        }

        public NotifyMsgAttachmentRepo(DbConnection conn)
        {
            dc = new JBHRModelDataContext(conn);                     
        }

        public NotifyMsgAttachmentRepo(JBHRModelDataContext o)
        {
            dc = o; 
        }

        public void Add(NotifyMsgAttachment o)
        {
            o.Guid = System.Guid.NewGuid().ToString();
            dc.NotifyMsgAttachment.InsertOnSubmit(o);
        }

        public void Delete(NotifyMsgAttachment o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgAttachment.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyMsgAttachment.DeleteOnSubmit(o);
        }

        public void Delete(List<NotifyMsgAttachment> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.NotifyMsgAttachment.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.NotifyMsgAttachment.DeleteOnSubmit(o);
            }
        }

        public void Update(NotifyMsgAttachment o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgAttachment.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<NotifyMsgAttachment> GetByNotifyMsgGuid(string Aid)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NotifyMsgAttachment
                        where c.NotifyMsgGuid==Aid
                        select c).ToList();
            }
        }

        //public NotifyMsgAttachment GetByPK(string pk)
        //{
        //    using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //    {
        //        return (from c in ldc.NotifyMsgAttachment
        //                where c.Guid==pk
        //                select c).FirstOrDefault();
        //    }
        //}
    }
}
