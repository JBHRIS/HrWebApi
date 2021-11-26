using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace JBTools.IO
{
    public interface ILogger
    {
        void Logger(string FormName, LogStatus Status, string Descr, IListSource BeforeData, IListSource AfterData, string KeyMan);
    }
    public enum LogStatus
    {
        Insert,
        Update,
        Delete,
        Error,
        Info,
    }
}
