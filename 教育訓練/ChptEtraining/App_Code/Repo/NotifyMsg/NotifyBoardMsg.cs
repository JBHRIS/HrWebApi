using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Repo
{
    public class NotifyBoardMsg
    {
        public string Guid { get; set; }
        public string NotifyMsgGuid { get; set; }
        public string NotifyTarget { get; set; }
        public string NotifytargetType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime NotifyAdate { get; set; }
        public DateTime? NotifyDdate { get; set; }
        bool IsBbsChecked { get; set; }

        public void Check()
        {
            NotifyMsgDetailRepo msgDtlRepo = new NotifyMsgDetailRepo();
            NotifyMsgDetail obj = msgDtlRepo.GetByPK(Guid);
            obj.IsBbsChecked = true;
            obj.UpdateDate = DateTime.Now;
            msgDtlRepo.Update(obj);
            msgDtlRepo.Save();
        }
    }


}
