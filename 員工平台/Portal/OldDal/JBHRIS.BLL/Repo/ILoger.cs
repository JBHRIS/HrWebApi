using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public interface ILogger
    {
        void WriteLog(Dto.LogMessage Msg);
        //void Debug(string Msg);
        //void Info(string Msg);
        //void Trace(string Msg);
        //void Warn(string Msg);
        //void Error(string Msg);
        //void Fatal(string Msg);
    }
}
