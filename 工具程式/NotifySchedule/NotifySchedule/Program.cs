using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifySchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JBHR.BLL.Sys.NotifyService nService = new JBHR.BLL.Sys.NotifyService();
                int i = nService.CheckNotifyAuto();
            }
            catch(Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
            }
        }
    }
}
