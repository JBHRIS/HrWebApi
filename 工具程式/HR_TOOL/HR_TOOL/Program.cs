using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HR_TOOL
{
    static class Program
    {
        public static string SystemConfigPath = "";
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ExcelReaderForm());
            SystemConfigPath = Environment.CurrentDirectory + @"\Sys.config";
            Application.ThreadException += Application_ThreadException;
            Application.Run(new Main());
            //Application.Run(new DbLoger.DbLoggerForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
