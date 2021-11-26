using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Repo
{
    public class JBSystemEventTriggerMsgRepo
    {        
        public dcTrainingDataContext dc { get; set; }
        public JBSystemEventTriggerMsgRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public JBSystemEventTriggerMsgRepo(dcTrainingDataContext o)
        {
            dc = o;
        }

        public void Add(JBSystemEventTriggerMsg o)
        {
            dc.JBSystemEventTriggerMsg.InsertOnSubmit(o);
        }

        public void Delete(JBSystemEventTriggerMsg o)
        {
            DcHelper.Detach(o);
            dc.JBSystemEventTriggerMsg.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.JBSystemEventTriggerMsg.DeleteOnSubmit(o);
        }

        public void Update(JBSystemEventTriggerMsg o)
        {
            DcHelper.Detach(o);
            dc.JBSystemEventTriggerMsg.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// 取得 By SystemEvent Code
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public List<JBSystemEventTriggerMsg> GetBySystemEventGuid(string Aguid)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.JBSystemEventTriggerMsg
                        where c.SystemEventGuid == Aguid
                        select c).ToList();
            }
        }


        public List<JBSystemEventTriggerMsg> GetBySystemEventGuidEnable(string Aguid)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.JBSystemEventTriggerMsg
                        where c.SystemEventGuid == Aguid
                        && c.Enable
                        select c).ToList();
            }
        }
    }
}
