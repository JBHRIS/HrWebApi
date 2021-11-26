using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message
{
    public class ReportStatus
    {
        public delegate void StatusChangedEvent(object sender, StatusEventArgs e);
        public event StatusChangedEvent StatusChanged;
        //public event EventHandler<StatusEventArgs> StatusChanged;
        public void Report(object result, int percent)
        {
            if (StatusChanged != null)
            {
                StatusEventArgs e = new StatusEventArgs(result, percent);
                StatusChanged(null, e);
            }
        }
        public void Report(int percent, object result)
        {
            Report(result, percent);
        }
    }
    public class StatusEventArgs : EventArgs
    {
        private object _result;
        private int _percent;
        public StatusEventArgs(object result, int percent)
            : base()
        {
            this._result = result;
            this._percent = percent;
        }
        /// <summary>
        /// 狀態內容
        /// </summary>
        public object Result
        {
            get
            {
                return _result;
            }
        }
        /// <summary>
        /// 進度,如50%請指定為50
        /// </summary>
        public int Percent
        {
            get
            {
                return _percent;
            }
        }
    }
}
