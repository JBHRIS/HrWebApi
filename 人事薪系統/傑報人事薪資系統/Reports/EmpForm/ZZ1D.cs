/* ======================================================================================================
 * 功能名稱：服務證明
 * 功能代號：ZZ1D
 * 功能路徑：報表列印 > 人事 > 服務證明
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1D.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/10    Daniel Chih    Ver 1.0.01     1. 新增報表選項：非自願離職證明
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/10
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ1D : JBControls.JBForm
    {
        ZZ1D_Report zz1d_report;
        public ZZ1D()
        {
            InitializeComponent();
        }

        private void ZZ1D_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;

            dept_b.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.DataSource = JBHR.Reports.ReportClass.GetDept(MainForm.COMPANY);
            dept_e.SelectedIndex = dept_e.Items.Count - 1;

            comp_b.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.DataSource = JBHR.Reports.ReportClass.GetComp(MainForm.COMPANY);
            comp_e.SelectedIndex = comp_e.Items.Count - 1;

            date_b.Text = DateTime.Now.ToString("yyyyMMdd");
            note2.Text = DateTime.Now.ToString("yyyyMMdd")+"01";

            SystemFunction.CheckAppConfigRule(btnConfig);
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ1D", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("CompTitleDisplay", "顯示公司抬頭", "True", "設定是否顯示公司抬頭", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
        }

        private void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (zz1d_report != null)
                {
                    zz1d_report.Dispose();
                    zz1d_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;
                string dateb = date_b.Text;
                string deptb = (dept_b.SelectedIndex == -1) ? "" : dept_b.SelectedValue.ToString();
                string depte = (dept_e.SelectedIndex == -1) ? "" : dept_e.SelectedValue.ToString();
                string compb = (comp_b.SelectedIndex == -1) ? "" : comp_b.SelectedValue.ToString();
                string compe = (comp_e.SelectedIndex == -1) ? "" : comp_e.SelectedValue.ToString();
                bool _reporttype1 = report_type1.Checked;
                bool _reporttype2 = report_type2.Checked;
                //非自願離職證明 - Added By Daniel Chih - 2021/03/10
                bool _nonself_resign_report_type = NonSelf_Resign_Report_Type.Checked; 
                //string _note = note.Text;
                //string _note1 = note1.Text;
                string type_indt = "";
                if (type_indt1.Checked) type_indt = "B.INDT";
                if (type_indt2.Checked) type_indt = "B.CINDT AS INDT";
                string data_type = " AND " + Sal.Function.GetFilterCmdByDataGroup("b.saladr");
                
                zz1d_report = new ZZ1D_Report(nobrb, nobre, dateb, deptb, depte, compb, compe, _reporttype1, _reporttype2, _nonself_resign_report_type, type_indt, data_type, note2.Text,note1.Text,MainForm.COMPANY_NAME);
                zz1d_report.Show();
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
