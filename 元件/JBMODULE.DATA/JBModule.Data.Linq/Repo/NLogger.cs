using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class NLogger : JBHRIS.BLL.Repo.ILogger
    {

        #region ILogger 成員

        public void WriteLog(JBHRIS.BLL.Dto.LogMessage Msg)
        {
            //NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration( @"C:\Temp\NLog.config", true);
            //NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
            //NLog.Logger ll = new NLog.Logger();
            //NLog.GlobalDiagnosticsContext.Set("Msg", "測試自訂參數");
            //log.Error(Msg.Message);
            //log.Trace(Msg.Message);
        }

        #endregion
    }
}
