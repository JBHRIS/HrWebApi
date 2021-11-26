using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace JBHR
{
    static class Program
    {
        static string errMsg = "";
        static DateTime errDt = DateTime.Now;
        public static string SystemConfigPath = @"C:\temp\App.Config";
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch
            {
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new U_SETDB());
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            JBModule.Message.TextLog.WriteLog(e.Exception);
            JBModule.Message.DbLog.WriteLog(e.Exception, e.Exception.Source, -1);
            Form mainForm = null;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "MainForm")
                {
                    mainForm = openForm;
                    break;
                }
            }

            if (mainForm != null && mainForm.Visible)
            {
                if (errMsg != e.Exception.Message)
                {
                    errMsg = e.Exception.Message;
                    errDt = DateTime.Now;
                    MessageBox.Show(e.Exception.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if ((DateTime.Now - errDt).TotalSeconds <= 30)
                    {
                        mainForm.Visible = false;
                    }
                }
            }
        }
    }
}
