using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repo
{
    public class NotifyMsgDllDto
    {
        public List<NotifyMsgFacade> NotifyMsgFacadeList { get; set; }
        public List<NotifyMsgTriggerDto> NotifyMsgTriggerDtoList { get; set; }

    }
}
