using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message.Notify
{
  public  class NotifyMessage
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Target { get; set; }
    }
}
