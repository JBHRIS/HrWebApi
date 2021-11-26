using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace JBTools
{
    public class Stopwatch
    {
        DateTime t1, t2;
        string msg = "共耗時{0}分{1}秒";
        string title = "";
        public Stopwatch()
        {

        }
        public DateTime Start()
        {
            t1 = DateTime.Now;
            return t1;
        }
        public DateTime Stop()
        {
            t2 = DateTime.Now;
            return t2;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Message
        {
            get
            {
                var ts = t2 - t1;
                return string.Format(title + Environment.NewLine + msg, Convert.ToInt32(ts.Minutes).ToString(), Convert.ToInt32(ts.Seconds).ToString());
            }
        }
        public void ShowMessage()
        {
            MessageBox.Show(Message, "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
