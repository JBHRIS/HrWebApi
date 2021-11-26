/* ======================================================================================================
 * 功能名稱：早來晚走通知
 * 功能代號：
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\工具程式\SendEarlyLate\Program.cs
 * 功能用途：
 *  用於發送早來晚走通知到員工個人信箱、主管信箱和HR信箱
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
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Linq;
using JBModule.Message;

using JBModule.Data.Linq;

namespace SendEarlyLate
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

            string TestMail = "";
            bool TestMode = false;

            //早來晚走通知：測試模式開關
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "EarlyLateTestMode").Any())
                    str = configs.Where(p => p.Code == "EarlyLateTestMode").FirstOrDefault().Value;

                if (str != null)
                {
                    TestMode = bool.Parse(str);
                }
                else
                {
                    TestMode = false;
                }
            }
            catch { }

            //早來晚走通知：起日回推天數
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "EarlyLateBeginDayShift").Any())
                    str = configs.Where(p => p.Code == "EarlyLateBeginDayShift").FirstOrDefault().Value;

                if (str != null)
                {
                    beginDayShift = Int32.Parse(str);
                }
            }
            catch { }

            //早來晚走通知：迄日回推天數
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "EarlyLateEndDayShift").Any())
                    str = configs.Where(p => p.Code == "EarlyLateEndDayShift").FirstOrDefault().Value;

                if (str != null)
                {
                    endDayShift = Int32.Parse(str);
                }
            }
            catch { }

            //早來晚走通知：測試郵件地址
            try
            {
                string str = string.Empty;
                if (configs.Where(p => p.Code == "EarlyLateTestMail").Any())
                    str = configs.Where(p => p.Code == "EarlyLateTestMail").FirstOrDefault().Value;

                if (str != null)
                {
                    TestMail = str;
                }
            }
            catch { }

            beginDate = RunDate.AddDays(beginDayShift);
            endDate = RunDate.AddDays(endDayShift);

            if (beginDate > endDate)
            {
                beginDate = DateTime.Today;
                endDate = DateTime.Today;
            }

            ErrorUtility.WriteLog("開始程式");
            Employee.DoSend(beginDate, endDate, TestMode, TestMail);  //個人通知
            Mang.DoSend(beginDate, endDate, TestMode, TestMail);  //主管及HR人員
        }
    }
}
