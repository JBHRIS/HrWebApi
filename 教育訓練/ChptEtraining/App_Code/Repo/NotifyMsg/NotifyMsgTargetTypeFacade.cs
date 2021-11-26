using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repo
{
    public class NotifyMsgTargetTypeFacade
    {

        public string Guid { get; set; }
        /// <summary>
        /// 發送對象ID
        /// </summary>
        public string NotifyTarget { get; set; }
        /// <summary>
        /// 發送對象的型別  HrUser、Emp、Dept、Role
        /// </summary>
        public NotifyTargetTypeEnum? NotifyTargetType { get; set; }
        /// <summary>
        /// 發送方式，可多樣
        /// </summary>
        public List<NotifyTypeEnum> NotifyTypeList { get; set; }

        public NotifyMsgTargetTypeFacade()
        {
            Guid = System.Guid.NewGuid().ToString();
            NotifyTypeList = new List<NotifyTypeEnum>();
        }
    }
}
