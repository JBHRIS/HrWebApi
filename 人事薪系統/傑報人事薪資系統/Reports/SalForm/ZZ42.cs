/* ======================================================================================================
 * 功能名稱：發放薪資報表
 * 功能代號：ZZ42
 * 功能路徑：報表列印 > 薪資 > 發放薪資報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ42.cs
 * 功能用途：
 *  用於產出發放薪資報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/13    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：公司
 * 2021/07/07    Daniel Chih    Ver 1.0.02     1. 修改特休代碼與補休代碼的參考來源
 * 2021/08/04    Daniel Chih    Ver 1.0.03     1. 特休、補休代碼參考來源Config的Code校正
 * 2021/09/01    Daniel Chih    Ver 1.0.04     1. 整理功能版面控制項位置
 * 2021/11/10    Daniel Chih    Ver 1.0.05     1. 修改【臨時人數】撈取規則，代碼讀自Appconfig，報表結果增加【公司名稱】欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/11/10
 */

using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ42 : JBControls.JBForm
    {
        ZZ42_Report zz42_report;
        public string saladrsql;

        public ZZ42()
        {
            InitializeComponent();
        }


        private void ZZ42_Load(object sender, EventArgs e)
        {

            saladrsql = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            SystemFunction.SetComboBoxItems(comp_b, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(comp_e, ReportClass.SourceConvert(ReportClass.GetComp(MainForm.COMPANY)), false, true, true);
            //comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            //comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(dept_b, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(dept_e, ReportClass.SourceConvert(ReportClass.GetDept(MainForm.COMPANY)), false, true, true);
            //dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            //dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(depts_b, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(depts_e, ReportClass.SourceConvert(ReportClass.GetDepts(MainForm.COMPANY)), false, true, true);
            //depts_b.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            //depts_e.DataSource = JBHR.Reports.ReportClass.GetDepts(MainForm.COMPANY);
            depts_e.SelectedIndex = depts_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(empcd_b, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            SystemFunction.SetComboBoxItems(empcd_e, ReportClass.SourceConvert(ReportClass.GetEmpcd()), false, true, true);
            //empcd_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            //empcd_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            empcd_e.SelectedIndex = empcd_e.Items.Count - 1;

            SystemFunction.SetComboBoxItems(saladr_b, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            SystemFunction.SetComboBoxItems(saladr_e, ReportClass.SourceConvert(ReportClass.GetSaladr(MainForm.COMPANY)), false, true, true);
            //saladr_b.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            //saladr_e.DataSource = JBHR.Reports.ReportClass.GetSaladr(MainForm.COMPANY);
            saladr_e.SelectedIndex = saladr_e.Items.Count - 1;
                       
            date_t.Text = "";  
            report_type.SelectedIndex = 0;

            //判斷當前公司是否為清展
            if ((MainForm.COMPANY_NAME.ToString().Trim() == "清展科技有限公司" || MainForm.COMPANY_NAME.ToString().Trim() == "清展科技股份有限公司") && MainForm.COMPANY.ToString().Trim() == "A")
            {
                report_type.Items.Add(new ListItem("【清展】轉帳明細表", "HISS_Report_5"));
            }


            salary_pa1.Enabled = false;
            A3_BigCharacter.Enabled = true;

            year.Text = Convert.ToString(DateTime.Now.Year);
            month.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            seq.Text = "2";

            date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
            attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
            attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);

            date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate(year.Text + month.Text, seq.Text, saladrsql);

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("BankID", "銀行客戶代碼", "", "銀行客戶代碼", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Bank013", "國泰世華客戶代碼", "", "臨櫃申請的客戶代號", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Bank018", "匯豐銀行客戶代號", "", "HSBC Connect Customer ID", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankEmail", "匯豐銀行通知Eamil", "", "HSBC通知Eamil", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Bank018NET", "匯豐銀行NET客戶代號", "", "HSBCnet Customer ID", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankBaseSal", "本薪代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankFoodSal", "伙食津貼代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankOTSal", "加班費代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankLaborSal", "勞保費代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankHealthSal", "健保費代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankRetSal", "勞退自提代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("BankTaxSal", "所得稅代碼", "", "國泰世華電子薪資單如有多個科目請用逗號半形(,)區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Upload", "上傳類別", "", "1.臨櫃,2.網路,3.銀行應用程式", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("SalaryNOte", "薪資單備註", "請同仁遵循薪資保密之公司政策，若有任何對薪資方面的疑問，請逕洽人事單位。", "薪資單備註", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("SalaryNOte_EN", "外籍薪資單備註", "", "外籍薪資單備註", "TextBox", "", "String");
            //AppConfig.CheckParameterAndSetDefault("Remain_AnnualType", "特休請假類別代碼", "1", "計算特休請餘剩時數", "ComboBox", "select HTYPE,HTYPE_DISP +'-'+ TYPE_NAME from HcodeType where dbo.getcodefilter('HcodeType',HTYPE,@userid,@comp,@admin)=1", "String");
            //AppConfig.CheckParameterAndSetDefault("Remain_RestType", "補休請假類別代碼", "2", "計算補休請餘剩時數", "ComboBox", "select HTYPE,HTYPE_DISP +'-'+ TYPE_NAME from HcodeType where dbo.getcodefilter('HcodeType',HTYPE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("Bank017Branch", "兆豐商銀扣帳分行3位代號", "", "扣帳分行3位代號", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("SalaryIns", "薪資單顯示勞健勞退投保金額", "0", "薪資單顯示勞健勞退投保金額0不顯示,1為顯示", "TextBox", "", "Boolean");
            AppConfig.CheckParameterAndSetDefault("SalaryDetailsA3", "明細/彙總/會計匯款表A3紙張顯示二列", "0", "明細/彙總/會計匯款表A3紙張顯示二列0不顯示,1為顯示", "TextBox", "", "Boolean");
            AppConfig.CheckParameterAndSetDefault("CHBMemo", "彰銀轉帳摘要", "050", "彰銀轉帳存摺摘要", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("SendMailBWSW", "是否在背景執行寄送薪資單", "N", "是否啟用背景程式執行寄送薪資單的工作", "TextBox", "", "String");

            //測試模式開關
            AppConfig.CheckParameterAndSetDefault("SalaryTransferMode", "自訂格式轉帳磁片 - 開關", "False"
                , "是否使用【自訂格式轉帳磁片】", "ComboBox"
                , "SELECT CODE, RESULT FROM (SELECT CAST('True' AS NVARCHAR) AS True, CAST('False' AS NVARCHAR) AS False) AS TF UNPIVOT(CODE FOR RESULT IN(TF.TRUE,TF.FALSE)) AS PV"
                , "String");

            //臨時人員員別
            AppConfig.CheckParameterAndSetDefault("TemporaryEmpcd", "臨時人員員別代碼", "", "指定臨時人員員別代碼", "ComboBox", "select EMPCD,EMPCD + ' - ' + EMPDESCR from empcd", "String");

            note.Text = AppConfig.GetConfig("SalaryNOte").Value;
        }

        private void month_Validated(object sender, EventArgs e)
        {
            try
            {
                month.Text = month.Text.PadLeft(2, '0');

                date_t.SelectedIndex = -1;
                date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate(year.Text + month.Text, seq.Text, saladrsql);
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
                attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
                attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);
                seq.Focus();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void seq_Validated(object sender, EventArgs e)
        {
            try
            {
                date_t.SelectedIndex = -1;
                date_t.DataSource = JBHR.Reports.ReportClass.GetTranDate(year.Text + month.Text, seq.Text, saladrsql);
                //if (string.IsNullOrEmpty(seqmerge.Text))
                //    LABCHECK.Checked = true;
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void year_Validated(object sender, EventArgs e)
        {
            try
            {
                date_b.Text = JBHR.Reports.ReportClass.GetSalEDate(year.Text, month.Text);
                attdate_b.Text = JBHR.Reports.ReportClass.GetAttBDate(year.Text, month.Text);
                attdate_e.Text = JBHR.Reports.ReportClass.GetAttEDate(year.Text, month.Text);
                month.Focus();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.YearError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void attdate_b_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime dtab = DateTime.Parse(attdate_b.Text);
            //    attdate_e.Text = DateTime.Parse(attdate_b.Text).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}
            //catch (Exception Ex)
            //{
            //    return;
            //}
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                HrDBDataContext dcHr = new HrDBDataContext();

                #region 特休
                JBModule.Data.ApplicationConfigSettings AnnualLeaveSettingConfigs = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
                //若未設置Config則讀預設代碼 "1"
                string AnnualLeaveType = AnnualLeaveSettingConfigs.GetConfig("AnnualLeaveTypeCode").GetString("1").Trim();
                #endregion

                #region 補休
                JBModule.Data.ApplicationConfigSettings CompensatoryLeaveSettingConfigs = new JBModule.Data.ApplicationConfigSettings("FRM4P", MainForm.COMPANY);
                //若未設置Config則讀預設代碼 "2"
                string CompensatoryLeaveType = CompensatoryLeaveSettingConfigs.GetConfig("LeaveTypeCode").GetString("2").Trim();
                #endregion

                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);

                //臨時員工員別代碼，若未設置Config則預設帶 "2"
                string _temporary_empcd = AppConfig.GetConfig("TemporaryEmpcd").GetString("2").Trim();

                string note_en = AppConfig.GetConfig("SalaryNOte_EN").Value;
                note.Text = AppConfig.GetConfig("SalaryNOte").Value;

                bool SalaryTransferMode = false;
                if (AppConfig.GetConfig("SalaryTransferMode").Value.ToString() == "True")
                {
                    SalaryTransferMode = true;
                }

                DateTime dtb = DateTime.Parse(date_b.Text);
                DateTime dtae = DateTime.Parse(attdate_e.Text);
                if (zz42_report != null)
                {
                    zz42_report.Dispose();
                    zz42_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string deptsb = (depts_b.SelectedIndex == -1) ? "" : depts_b.SelectedValue.ToString();
                string deptse = (depts_e.SelectedIndex == -1) ? "" : depts_e.SelectedValue.ToString();
                string saladrb = (saladr_b.SelectedIndex == -1) ? "" : saladr_b.SelectedValue.ToString();
                string saladre = (saladr_e.SelectedIndex == -1) ? "" : saladr_e.SelectedValue.ToString();
                string empb = (empcd_b.SelectedIndex == -1) ? "" : empcd_b.SelectedValue.ToString();
                string empe = (empcd_e.SelectedIndex == -1) ? "" : empcd_e.SelectedValue.ToString();
                string _year = year.Text;
                string _month = month.Text;
                string _seq = seq.Text;
                string _seqmerge = seqmerge.Text;
                string dateb = date_b.Text;                
                string datet = "";
                if (date_t.SelectedIndex == -1)
                    datet = "";
                else
                    datet = date_t.SelectedValue.ToString();
                string attdateb = attdate_b.Text;
                string attdatee = attdate_e.Text;
                string _note = note.Text;
                string _note1 = note1.Text;               
                string _note3 = note3.Text;
                string _loginuser = "";
                string _loginpwd = "";
                bool _pa = pa.Checked;
                bool _pa1 = pa1.Checked;
                bool _pa2 = pa2.Checked;
                bool _pa3 = pa3.Checked;
                bool _order1 = order1.Checked;
                bool _order2 = order2.Checked;
                bool _order3 = order3.Checked;
                bool _A3_BigCharacter = A3_BigCharacter.Checked;
                bool noupwage = no_upwage.Checked;
                bool noname = no_name.Checked;
                bool prnnoemail = prn_noemail.Checked;
                bool prnpaa = prn_paa.Checked;
                bool trancount = tran_count.Checked;
                bool salarypa1 = salary_pa1.Checked;
                bool _exportexcel = ExportExcel.Checked;
                bool nocomp = no_comp.Checked;
                bool nodeptcount = no_deptcount.Checked;
                bool _TwoRows = TwoRows.Checked;
                string type_data = ""; 
                if (type_data1.Checked) type_data = "1";
                if (type_data2.Checked) type_data = "2";
                if (type_data3.Checked) type_data = "3";
                if (type_data4.Checked) type_data = "4";
                if (type_data5.Checked) type_data = "5";
                string reponame = report_type.Text;
                string reporttype = Convert.ToString(report_type.SelectedIndex + 1);

                string report_type_item = (report_type is null) ? "" : report_type.SelectedItem.ToString().Trim();

                string _username = MainForm.USER_NAME;
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("saladr");
                string workadr1 = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool _noout = noout.Checked;
                bool _sumdi = sumdi.Checked;
                bool _noret = noret.Checked;
                bool _sendsalary = sendsalary.Checked;
                bool _labchedk = LABCHECK.Checked;
                bool nodispot = NoDispOt.Checked;

                //ITCT-F01-220118-酷碼-20220316：Added By Daniel Chih - 2022/03/16
                string dd = FreezeDatePicker.Value.ToString("yyyy/MM/dd");
                int hrs = FreezeTimePicker.Value.Hour;
                int mins = FreezeTimePicker.Value.Minute;

                DateTime senddate = DateTime.Parse(dd).AddHours(hrs).AddMinutes(mins);
                if (Convert.ToString(report_type.SelectedIndex + 1) == "5"
                    || Convert.ToString(report_type.SelectedIndex + 1) == "6"
                    || Convert.ToString(report_type.SelectedIndex + 1) == "7"
                    || Convert.ToString(report_type.SelectedIndex + 1) == "9"
                    || Convert.ToString(report_type.SelectedIndex + 1) == "18")
                {
                    if (Convert.ToInt32(DateTime.Parse(dd).ToString("yyyyMMdd")) < Convert.ToInt32(DateTime.Parse(datet).ToString("yyyyMMdd")) && _sendsalary)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        //MessageBox.Show("提醒發送日期小於轉帳日期", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        DialogResult result;
                        result = MessageBox.Show("提醒發送日期小於轉帳日期\n\n按是繼續發送,按否取消發送", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                    }
                }

                zz42_report = new ZZ42_Report(_temporary_empcd, SalaryTransferMode, AnnualLeaveType, CompensatoryLeaveType
                    , nobrb, nobre, compb, compe, deptb, depte, deptsb, deptse, saladrb, saladre, empb, empe, attdateb, attdatee
                    , dateb, datet, reporttype, report_type_item, _year, _month, _seq, type_data, _note, _note1, _note3, note_en
                    , _loginuser, _loginpwd, _username, _exportexcel, _pa, _pa1, _pa2, _pa3, _order1, _order2, _order3, noupwage
                    , noname, prnnoemail, prnpaa, trancount, salarypa1, nodeptcount, nocomp, workadr, workadr1, reponame, _sumdi
                    , MainForm.COMPANY_NAME, MainForm.COMPANY, print_pdf.Checked, _noout, _noret, _sendsalary, _seqmerge
                    , _labchedk, nodispot, _A3_BigCharacter, senddate);
                zz42_report.Show();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void report_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((report_type.SelectedIndex + 1).ToString() == "9" 
                || (report_type.SelectedIndex + 1).ToString() == "18" 
                || (report_type.SelectedIndex + 1).ToString() == "20")
            {
                salary_pa1.Enabled = true;
            }
            else
            {
                salary_pa1.Checked = false;

                salary_pa1.Enabled = false;
            }

            if ((report_type.SelectedIndex + 1).ToString() == "1"
                || (report_type.SelectedIndex + 1).ToString() == "2"
                || (report_type.SelectedIndex + 1).ToString() == "3"
                || (report_type.SelectedIndex + 1).ToString() == "4")
            {
                A3_BigCharacter.Enabled = true;
            }
            else
            {
                A3_BigCharacter.Checked = false;

                A3_BigCharacter.Enabled = false;
            }

        }
    }
}
