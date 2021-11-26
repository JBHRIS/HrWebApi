using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message.Notify
{
    public class NotifyTarget
    {
        public string Sponsor;
        public JBModule.Message.Notify.NotifyHelper.TargetTypeEnum targetTypeEnum;
        public string Target;
        public string TargetName;
        public string Email;
    }
}
