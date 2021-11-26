using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;
namespace Repo
{
    public class NotifyMsgTargetTypeRepo
    {        
        public dcTrainingDataContext dc { get; set; }
        public NotifyMsgTargetTypeRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public NotifyMsgTargetTypeRepo(DbConnection conn)
        {
            dc = new dcTrainingDataContext(conn);                     
        }


        public NotifyMsgTargetTypeRepo(dcTrainingDataContext o)
        {
            dc = o;
        }

        public void Add(NotifyMsgTargetType o)
        {
            o.Guid = System.Guid.NewGuid().ToString();
            dc.NotifyMsgTargetType.InsertOnSubmit(o);
        }

        public void Delete(NotifyMsgTargetType o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgTargetType.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyMsgTargetType.DeleteOnSubmit(o);
        }

        public void Update(NotifyMsgTargetType o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgTargetType.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<NotifyMsgTargetType> GetByNotifyMsgTargetGuid(string Aid)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyMsgTargetType
                        where c.NotifyMsgTargetGuid == Aid
                        select c).ToList();
            }
        }
    }
}
