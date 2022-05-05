/* ======================================================================================================
 * 功能名稱：年度所得資料列印
 * 功能代號：ZZ51B
 * 功能路徑：報表列印 > 媒體申報 > 年度所得資料列印
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ51B.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/12/15    Daniel Chih    Ver 1.0.01     1. 新增條件篩選項：所得格式
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/12/15
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ51B : JBControls.JBForm
    {
        ZZ51B_Report ZZ51B_report;
        public List<JBModule.Data.Linq.YRTAX> yrtaxList;
        public Dictionary<string, object> yrparameters;
        public ZZ51B()
        {
            InitializeComponent();
        }

        public void ZZ51B_Load(object sender, EventArgs e)
        {
            year.Text = Convert.ToString(DateTime.Now.Year-1);
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            nobr_b.Text = Sal.BaseValue.MinNobr;
            nobr_e.Text = Sal.BaseValue.MaxNobr;


            yrformat_b.DataSource = JBHR.Reports.ReportClass.GetYRFormat();
            yrformat_e.DataSource = JBHR.Reports.ReportClass.GetYRFormat();
            yrformat_e.SelectedIndex = yrformat_e.Items.Count - 1;

            reporttype.SelectedIndex = 0;

            ser_nob.Text = "A000000";
            ser_noe.Text = "Z999999";
        }

        public void Create_Report_Click(object sender, EventArgs e)
        {
            try
            {               
                if (ZZ51B_report != null)
                {
                    ZZ51B_report.Dispose();
                    ZZ51B_report.Close();
                }
                string nobrb = nobr_b.Text;
                string nobre = nobr_e.Text;


                string yrformatb = (yrformat_b.SelectedIndex == -1) ? "" : yrformat_b.SelectedValue.ToString();
                string yrformate = (yrformat_e.SelectedIndex == -1) ? "" : yrformat_e.SelectedValue.ToString();

                string _year = year.Text;
                string sernob = ser_nob.Text;
                string sernoe = ser_noe.Text;
                string typedata = " AND " + Sal.Function.GetFilterCmdByDataGroup("c.saladr");

                
                if (type_tr2.Checked) typedata += " AND C.T_OK=0";
                if (type_tr3.Checked) typedata += " AND C.T_OK=1";


                if (yrparameters != null)
                {
                    yrparameters.Clear();


                    yrparameters.Add("type_tr2", type_tr2.Checked);
                    yrparameters.Add("type_tr3", type_tr3.Checked);


                }

                string report_type = reporttype.SelectedIndex.ToString();
                bool _exportexcel = ExportExcel.Checked;
                ZZ51B_report = new ZZ51B_Report(nobrb, nobre, _year, sernob, sernoe, yrformatb, yrformate, typedata, report_type, _exportexcel, MainForm.USER_NAME, MainForm.COMPANY_NAME, MainForm.COMPANY, yrtaxList, yrparameters);
                ZZ51B_report.Show();
                
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
