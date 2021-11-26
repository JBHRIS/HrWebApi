/* ======================================================================================================
 * 功能名稱：出勤異常通知
 * 功能代號：ZZ2S
 * 功能路徑：報表列印 > 出勤 > 出勤異常通知
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ2S.cs
 * 功能用途：
 *  用於產出扣繳稅額繳款書與外籍所得稅報帳
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/20    Daniel Chih    Ver 1.0.01     1. 新增通知選項：早來晚走
 * 2021/02/20    Daniel Chih    Ver 1.0.01     1. 新增出勤異常Config設定：【稽催模式開關】、【出勤結算日】
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/20
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ2S : JBControls.JBForm
    {
        public string dept;
        public ZZ2S()
        {
            InitializeComponent();
        }
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        private void ZZ2S_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ2S", string.Empty);

            AppConfig.CheckParameterAndSetDefault("OnTimeBufferMins", "早到分鐘數", "15"
               , "上班早到檢查分鐘數，預設15分鐘", "TextBox", "", "int");
            AppConfig.CheckParameterAndSetDefault("OffTimeBufferMins", "晚退分鐘數", "15"
               , "下班晚退檢查分鐘數，預設15分鐘", "TextBox", "", "int");
            AppConfig.CheckParameterAndSetDefault("beginDate", "模擬日期起", ""
               , "模擬日期起，模擬執行的時間起迄，需開始到結束皆合法才有作用，優先權高", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("endDate", "模擬日期迄", ""
               , "模擬日期迄，模擬執行的時間起迄，需開始到結束皆合法才有作用，優先權高", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("beginDayShift", "往前推算N日", "-3"
               , "如沒有模擬日期，將以執行日為基準，增減幾天，開始不可大於結束(如不合法則都已今日執行)，優先權低", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("endDayShift", "往後推算N日", "0"
               , "如沒有模擬日期，將以執行日為基準，增減幾天，開始不可大於結束(如不合法則都已今日執行)，優先權低", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("comp", "篩選公司別", ""
               , "篩選公司別，不填為全部，多個請用半形逗號分隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("emp", "篩選員工號", ""
               , "篩選員工號，不填為全部，多個請用半形逗號分隔", "TextBox", "", "String");

            #region 早來晚走通知
            //測試模式開關
            AppConfig.CheckParameterAndSetDefault("EarlyLateTestMode", "自動早來晚走通知排程 - 測試模式開關", "False"
                , "【測試模式開關】是否啟用【早來晚走通知】測試模式", "ComboBox"
                , "SELECT CODE, RESULT FROM (SELECT CAST('True' AS NVARCHAR) AS True, CAST('False' AS NVARCHAR) AS False) AS TF UNPIVOT(CODE FOR RESULT IN(TF.TRUE,TF.FALSE)) AS PV"
                , "String");
            //起日回推天數
            AppConfig.CheckParameterAndSetDefault("EarlyLateBeginDayShift", "自動早來晚走通知排程 - 日期起日", "-3"
               , "【日期起日】自當前日期回推的天數作為起日", "TextBox", "", "String");
            //迄日回推天數
            AppConfig.CheckParameterAndSetDefault("EarlyLateEndDayShift", "自動早來晚走通知排程 - 日期迄日", "0"
               , "【日期迄日】自當前日期回推的天數作為迄日", "TextBox", "", "String");
            //測試郵件地址
            AppConfig.CheckParameterAndSetDefault("EarlyLateTestMail", "自動早來晚走通知排程 - 測試郵件地址", "daniel@jbjob.com.tw"
               , "【測試郵件地址】若開啟測試模式，則出勤異常通知的郵件都會寄送到此測試郵件地址", "TextBox", "", "String");
            #endregion

            #region 出勤異常通知
            //測試模式開關
            AppConfig.CheckParameterAndSetDefault("SendAttendTestMode", "自動出勤異常通知排程 - 測試模式開關", "False"
                , "【測試模式開關】是否啟用【出勤異常通知】測試模式", "ComboBox"
                , "SELECT CODE, RESULT FROM (SELECT CAST('True' AS NVARCHAR) AS True, CAST('False' AS NVARCHAR) AS False) AS TF UNPIVOT(CODE FOR RESULT IN(TF.TRUE,TF.FALSE)) AS PV"
                , "String");

            //起日回推天數
            AppConfig.CheckParameterAndSetDefault("SendAttendBeginDayShift", "自動出勤異常通知排程 - 日期起日", "-3"
               , "【日期起日】自當前日期回推的天數作為起日", "TextBox", "", "String");
            //迄日回推天數
            AppConfig.CheckParameterAndSetDefault("SendAttendEndDayShift", "自動出勤異常通知排程 - 日期迄日", "0"
               , "【日期迄日】自當前日期回推的天數作為迄日", "TextBox", "", "String");

            //測試郵件地址
            AppConfig.CheckParameterAndSetDefault("SendAttendTestMail", "自動出勤異常通知排程 - 測試郵件地址", "daniel@jbjob.com.tw"
               , "【測試郵件地址】若開啟測試模式，則出勤異常通知的郵件都會寄送到此測試郵件地址", "TextBox", "", "String");

            //稽催模式開關
            AppConfig.CheckParameterAndSetDefault("SendAttendRangeMode", "自動出勤異常通知排程 - 稽催模式開關", "False"
                , "【稽催模式開關】是否啟用【出勤異常通知】稽催模式", "ComboBox"
                , "SELECT CODE, RESULT FROM (SELECT CAST('True' AS NVARCHAR) AS True, CAST('False' AS NVARCHAR) AS False) AS TF UNPIVOT(CODE FOR RESULT IN(TF.TRUE,TF.FALSE)) AS PV"
                , "String");
            //出勤結算日
            AppConfig.CheckParameterAndSetDefault("SendAttendAttendCheckDay", "自動出勤異常通知排程 - 出勤結算日", "1"
               , "【出勤結算日】若開啟稽催模式，則會根據出勤結算日寄送月度迄今的異常通知", "TextBox", "", "String");

            #endregion

            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            try
            {


                DataTable rqparameter = SqlConn.GetDataTable("select code,value from Parameter where code in ('JbMail.Department','JbMail.TestAccount','JbMail.Sender')");
                Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
                nobr_b.Text = Sal.BaseValue.MinNobr;
                nobr_e.Text = Sal.BaseValue.MaxNobr;
                date_b.Text = DateTime.Now.ToString("yyyy/MM/dd");
                date_e.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TestSubject.Text = "測試中";
                HRMail.Text = string.Empty;
                HRMail1.Text = string.Empty;
                MailFrom.Text = string.Empty;
                dept = "Dept";
                foreach (DataRow Row in rqparameter.Rows)
                {
                    if (Row["code"].ToString().Trim() == "JbMail.Sender")
                        MailFrom.Text = Row["value"].ToString();
                    else if (Row["code"].ToString().Trim() == "JbMail.TestAccount")
                        HRMail.Text = Row["value"].ToString();
                    else if (Row["code"].ToString().Trim() == "JbMail.Department")
                        dept = Row["value"].ToString().Trim();
                }
                report_type.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string type_data = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool TestSend = send_type1.Checked;

                //發送【出勤異常】的通知
                if (report_type.SelectedIndex == 0)
                {
                    //發送個人出勤異常
                    if (s_person.Checked)
                    {
                        ZZ2SClass_Person.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend, type_data, dept);
                    }
                        
                    //發送編制主管出勤異常
                    if (s_mange.Checked)
                    {
                        ZZ2SClass_Manage.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend, type_data, dept);
                    }
                        
                    MessageBox.Show("異常發送完畢!");
                }

                //發送【早來晚走】的通知
                if (report_type.SelectedIndex == 1)
                {
                    //個人通知
                    if (s_person.Checked)
                    {
                        ZZ2SClass_Early_Late_Employee.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend, type_data, dept);
                    }

                    //主管及HR人員
                    if (s_mange.Checked)
                    {
                        ZZ2SClass_Early_Late_Mang.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend, type_data, dept);
                    }

                    MessageBox.Show("通知發送完畢!");
                }

                #region 此部分內容並未啟用，先以註解折疊起來

                //if (report_type.SelectedIndex == 0 || report_type.SelectedIndex == 1)
                //{
                //    if (s_person.Checked)
                //    {
                //        //發送有mail出勤異常
                //        ZZ2SClass_Person.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend);

                //        //發送未有mail出勤異常給指定人員
                //        ZZ2SClass_Person1.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend);
                //    }
                //    //發送所有出勤異常mail給簽核主管
                //    if (s_mange.Checked) ZZ2SClass_Manage.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend);
                //}

                //if (report_type.SelectedIndex == 0 || report_type.SelectedIndex == 2)
                //{
                //    //發送請假與刷卡時數超過30分鐘
                //    ZZ2SAbsAttCard.DoSend(nobr_b.Text, nobr_e.Text, date_b.Text, date_e.Text, TestSubject.Text, MailFrom.Text, HRMail.Text, HRMail1.Text, HRMail2.Text, TestSend, s_person.Checked, s_mange.Checked);
                //}

                #endregion

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        /// <summary>
        /// 選擇的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dcHr = new JBModule.Data.Linq.HrDBDataContext();

            var configs = dcHr.AppConfig.Where(p => p.Category == "ZZ2S" && p.Comp == string.Empty);

            //測試模式
            if (send_type1.Checked == true)
            {
                //早來晚走
                if (report_type.SelectedIndex == 1)
                {
                    HRMail.Text = configs.Where(p => p.Code == "EarlyLateTestMail").FirstOrDefault().Value;
                }
                //出勤異常
                else
                {
                    HRMail.Text = configs.Where(p => p.Code == "SendAttendTestMail").FirstOrDefault().Value;
                }

            }
        }
    }
}
