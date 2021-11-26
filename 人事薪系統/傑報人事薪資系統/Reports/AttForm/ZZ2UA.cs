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
        public partial class ZZ2UA : JBControls.JBForm
    {
        ZZ2UA_Report zz2ua_report;
        public ZZ2UA()
        {
            InitializeComponent();
        }

        private void ZZ2UA_Load(object sender, EventArgs e)
        {
            bASETableAdapter.Fill(salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            //var deptsData = CodeFunction.GetDeptsDisp();
            //SystemFunction.SetComboBoxItems(depts_b, deptsData, false);
            //SystemFunction.SetComboBoxItems(depts_e, deptsData, false);
            //depts_b.SelectedValue = deptsData.First().Key;
            //depts_e.SelectedValue = deptsData.Last().Key;

            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(dept_b, deptData, false);
            SystemFunction.SetComboBoxItems(dept_e, deptData, false);
            dept_b.SelectedValue = deptData.First().Key;
            dept_e.SelectedValue = deptData.Last().Key;

            emp_b.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            emp_e.DataSource = JBHR.Reports.ReportClass.GetEmpcd();
            emp_e.SelectedIndex = emp_e.Items.Count - 1;

            //yymm_b.Text = Convert.ToString(DateTime.Now.Year);
            //yymm_e.Text = Convert.ToString(DateTime.Now.Year);
            //month_b.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            //month_e.Text = Convert.ToString(DateTime.Now.Month).PadLeft(2, '0');
            string _yy = DateTime.Now.Year.ToString();
            string _mm = DateTime.Now.Month.ToString().PadLeft(2, '0'); ;
            date_b.Text = JBHR.Reports.ReportClass.GetAttBDate(_yy, _mm);
            date_e.Text = JBHR.Reports.ReportClass.GetAttEDate(_yy, _mm);
            report_type.SelectedIndex = 0;

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("CN2UA", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("student_NightRote", "夜班代碼", "", "計算學生夜班人數請用半形分號區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Disinclude_Hcode", "公出相關假別代碼", "", "不扣除出勤時數請用半形分號區隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("Student_Othrs", "學生加班時數", "", "統計大於加班時數人數", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("UserID", "使用者帳號", "", "請用半形分號區隔", "TextBox", "", "String");
            string dd1 = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek)).ToShortDateString();
            string dd2 = DateTime.Today.AddDays(-((int)DateTime.Parse(DateTime.Now.ToString("yyyy/01/01")).DayOfWeek)).ToShortDateString();
            DateTime lastyear = Convert.ToDateTime(DateTime.Now.AddYears(-1).ToString("yyyy/12/31"));
            date_b.Text = lastyear.AddDays(-((int)lastyear.DayOfWeek)).AddDays(8).ToShortDateString();
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz2ua_report != null)
                {
                    zz2ua_report.Dispose();
                    zz2ua_report.Close();
                }
                string _nobrb = nobr_b.Text;
                string _nobre = nobr_e.Text;
                string _deptb = dept_b.SelectedValue.ToString();
                string _depte = dept_e.SelectedValue.ToString();

                string _empb = emp_b.SelectedValue.ToString();
                string _empe = emp_e.SelectedValue.ToString();

                string _dateb = date_b.Text;
                string _datee = date_e.Text;
                //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("CN2UA", MainForm.COMPANY);
                //string userid = AppConfig.GetConfig("UserID").Value.ToUpper();
                //if (!string.IsNullOrEmpty(userid))
                //{
                //    if (userid.Contains(MainForm.USER_ID.ToUpper()))
                //        checkB.Checked = true;
                //}

                string _typedata = "";

                if (type_data2.Checked) _typedata = " AND B.DI='I'  AND A.COUNT_MA=0  ";
                if (type_data3.Checked) _typedata = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                string workadr = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                bool _exportexcel = ExportExcel.Checked;
                bool _checkB = checkB.Checked;
                string _reporttype = report_type.SelectedIndex.ToString();
                zz2ua_report = new ZZ2UA_Report(_nobrb, _nobre, _deptb, _depte, _empb, _empe, _dateb, _datee, _reporttype, _typedata, _exportexcel, MainForm.USER_NAME, workadr, MainForm.COMPANY_NAME, MainForm.COMPANY, _checkB);
                zz2ua_report.Show();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void LeaveForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
