/* ======================================================================================================
 * 功能名稱：出勤異常通知
 * 功能代號：
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\工具程式\SendAttend\Program.cs
 * 功能用途：
 *  用於發送出勤異常通知到員工個人信箱
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/20    Daniel Chih    Ver 1.0.01     1. 將測試模式等AppConfig參數寫在ZZ2S內
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/20
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using System.Linq;
using System.Configuration;
using JBModule.Message;

using JBModule.Data.Linq;

namespace sendAttendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            HrDBDataContext dcHr = new HrDBDataContext();

            TextLog.WriteLog("伺服器：" + dcHr.Connection.DataSource + "，資料庫：" + dcHr.Connection.Database);

            var configs = dcHr.AppConfig.Where(p => p.Category == "ZZ2S" && p.Comp == string.Empty);

            DateTime RunDate = DateTime.Today;
            DateTime beginDate = DateTime.Today;
            DateTime endDate = DateTime.Today;

            int beginDayShift = 0;
            int endDayShift = 0;
            int AttendCheckDay = 1;
            string TestMail = "";
            bool TestMode = true;
            bool RangeMode = false;

            //出勤異常通知：測試模式開關
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "SendAttendTestMode").Any())
                    str = configs.Where(p => p.Code == "SendAttendTestMode").FirstOrDefault().Value;

                if (!string.IsNullOrEmpty(str))
                {
                    TestMode = bool.Parse(str);
                }
                else
                {
                    TestMode = true;
                }
            }
            catch { }

            //出勤異常通知：起日回推天數
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "SendAttendBeginDayShift").Any())
                    str = configs.Where(p => p.Code == "SendAttendBeginDayShift").FirstOrDefault().Value;

                if (!string.IsNullOrEmpty(str))
                {
                    beginDayShift = Int32.Parse(str);
                }
            }
            catch { }

            //出勤異常通知：迄日回推天數
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "SendAttendEndDayShift").Any())
                    str = configs.Where(p => p.Code == "SendAttendEndDayShift").FirstOrDefault().Value;

                if (!string.IsNullOrEmpty(str))
                {
                    endDayShift = Int32.Parse(str);
                }
            }
            catch { }

            //出勤異常通知：測試郵件地址
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "SendAttendTestMail").Any())
                    str = configs.Where(p => p.Code == "SendAttendTestMail").FirstOrDefault().Value;

                if (!string.IsNullOrEmpty(str))
                {
                    TestMail = str;
                }
            }
            catch { }

            //出勤異常通知：稽催模式開關
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "SendAttendRangeMode").Any())
                    str = configs.Where(p => p.Code == "SendAttendRangeMode").FirstOrDefault().Value;

                if (!string.IsNullOrEmpty(str))
                {
                    RangeMode = bool.Parse(str);
                }
                else
                {
                    RangeMode = false;
                }
            }
            catch { }


            if (RangeMode)
            {
                //出勤異常通知：出勤結算日
                try
                {
                    string str = string.Empty;
                    if (configs.Where(p => p.Code == "SendAttendAttendCheckDay").Any())
                        str = configs.Where(p => p.Code == "SendAttendAttendCheckDay").FirstOrDefault().Value;

                    if (!string.IsNullOrEmpty(str))
                    {
                        AttendCheckDay = int.Parse(str);
                    }

                    //判斷起算日是否在上個月
                    if (RunDate.Day > AttendCheckDay)
                    {
                        beginDate = DateTime.Parse(RunDate.Year.ToString() + "/" + RunDate.Month.ToString() + "/" + AttendCheckDay.ToString());
                    }
                    else if (RunDate.Day <= AttendCheckDay && AttendCheckDay != 0)
                    {
                        beginDate = DateTime.Parse((RunDate.AddMonths(-1)).Year.ToString() + "/" + (RunDate.AddMonths(-1)).Month.ToString() + "/" + AttendCheckDay.ToString());
                    }
                    else
                    {
                        //防止錯誤：
                        beginDate = RunDate.AddDays(beginDayShift);
                        endDate = RunDate.AddDays(endDayShift);
                    }
                    endDate = RunDate.AddDays(-1);
                }
                catch { }
            }
            else
            {
                beginDate = RunDate.AddDays(beginDayShift);
                endDate = RunDate.AddDays(endDayShift);
            }

            if (beginDate > endDate)
            {
                beginDate = DateTime.Today;
                endDate = DateTime.Today;
            }

            ErrorUtility.WriteLog("開始程式");
            SendAttend.DoSend(beginDate, endDate, TestMode, TestMail);    //出勤異常通知個人
            SendAttend2.DoSend(beginDate, endDate, TestMode, TestMail);   //出勤異常通知主管
            ErrorUtility.WriteLog("結束程式");           
        }
    }
}
