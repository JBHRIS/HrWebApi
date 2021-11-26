using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;
namespace Repo
{
    public class NotifyMsgTargetRepo
    {        
        public dcTrainingDataContext dc { get; set; }
        public NotifyMsgTargetRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public NotifyMsgTargetRepo(DbConnection conn)
        {
            dc = new dcTrainingDataContext(conn);                     
        }

        public NotifyMsgTargetRepo(dcTrainingDataContext o)
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
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyMsgTarget
                        where c.NotifyMsgGuid == Aid
                        select c).ToList();
            }
        }

        //public NotifyMsgTarget GetByPK(string pk)
        //{
        //    using (dcTrainingDataContext ldc = new dcTrainingDataContext())
        //    {
        //        return (from c in ldc.NotifyMsgTarget
        //                where c.Guid==pk
        //                select c).FirstOrDefault();
        //    }
        //}
    }
}
