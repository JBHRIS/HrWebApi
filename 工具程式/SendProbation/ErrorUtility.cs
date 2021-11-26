using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
/// <summary>
/// ErrorUtility 的摘要描述
/// </summary>
public class ErrorUtility
{
    public ErrorUtility()
    {

    }
    public static void WriteLog(Exception ex, string url)
    {
        WriteToText(ex, url);
    }
    public static void WriteLog(string msg)
    {
        WriteToText(msg);
    }
    static void WriteToText(string log)
    {
        //HttpContext context = HttpContext.Current;
        //HttpRequest req = context.Request;
        //HttpServerUtility ser = HttpContext.Current.Server;
        string SaveDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");//取得年月日
        using (System.IO.FileStream ds = new System.IO.FileStream(Application.StartupPath + "\\log\\er" + SaveDate + ".log", System.IO.FileMode.Append))//寫入error\er200979.log
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ds, Encoding.UTF8))
            {

                //Exception err = ex;
                //while (err.InnerException != null)//遞回
                //    err = err.InnerException;
                //ErrorUtility.LastError = err;
                StringBuilder builder = new StringBuilder();

                builder.Append(DateTime.Now.ToString());

                builder.Append("\u0009");

                builder.Append(log);

                builder.Append("\u0009");

                sw.WriteLine(builder);

                sw.Flush();

                sw.Close();

            }

            ds.Close();

        }
    }

    static void WriteToText(Exception ex, string url)
    {
        //HttpContext context = HttpContext.Current;
        //HttpRequest req = context.Request;
        //HttpServerUtility ser = HttpContext.Current.Server;
        string SaveDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");//取得年月日
        using (System.IO.FileStream ds = new System.IO.FileStream(Application.StartupPath + "\\log\\er" + SaveDate + ".log", System.IO.FileMode.Append))//寫入error\er200979.log
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ds, Encoding.UTF8))
            {

                Exception err = ex;
                while (err.InnerException != null)//遞回
                    err = err.InnerException;
                ErrorUtility.LastError = err;
                StringBuilder builder = new StringBuilder();

                builder.Append(DateTime.Now.ToString());

                builder.Append("\u0009");

                builder.Append(url);

                builder.Append("\u0009");

                builder.Append(err.Message);

                builder.Append(Environment.NewLine);

                builder.Append(err.StackTrace);

                sw.WriteLine(builder);

                sw.Flush();

                sw.Close();

            }

            ds.Close();

        }
    }

    public static Exception LastError = null;
}
