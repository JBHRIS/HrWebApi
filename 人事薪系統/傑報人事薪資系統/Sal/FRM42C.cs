using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Sal
{
    public partial class FRM42C : JBControls.JBForm
    {
        public FRM42C()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        public string Source;
        public string Bank_Code;
        public string Bank_Name;

        private void FRM42C_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'salaryTransferDataSet.SalaryTransferBank' 資料表。您可以視需要進行移動或移除。
            this.salaryTransferBankTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransferBank, Bank_Code.ToString());

            fullDataCtrl1.DataAdapter = salaryTransferBankTableAdapter;

            SystemFunction.SetComboBoxItems(comboBox_Comp, CodeFunction.GetComp());

            Dictionary<string, string> DateType = new Dictionary<string, string>();
            DateType.Add("1", "民國 - 年月日");
            DateType.Add("2", "西元 - 年月日");
            DateType.Add("3", "民國 - 年（兩碼）月日");
            SystemFunction.SetComboBoxItems(comboBox_DateType, DateType, false);
            comboBox_DateType.Enabled = false;

            Dictionary<string, string> BankName = new Dictionary<string, string>();
            BankName.Add(Bank_Code.ToString(), Bank_Code.ToString() + " - " + Bank_Name);
            SystemFunction.SetComboBoxItems(comboBox_Bank, BankName, false);
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;

            textBox_CompID.Enabled = false;

            string comp = "";
            if (comboBox_Comp.SelectedValue == null)
            {
                comp = "";
            }
            else
            {
                comp = comboBox_Comp.SelectedValue.ToString();
            }

            var dbcomp = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in dbcomp.COMP
                      where a.COMP1 == comp
                      orderby a.COMP1
                      select new { COMP_ID = a.COMPID };
            //var lst = sql.AsEnumerable().ToDictionary(p => p.COMP_ID);
            var lst = sql.CopyToDataTable();


            if (lst.Rows.Count == 0)
            {
                textBox_CompID.Text = "";
            }
            else
            {
                textBox_CompID.Text = lst.Rows[0]["COMP_ID"].ToString();
            }

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;
            textBox_CompID.Enabled = false;

            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;
            textBox_CompID.Enabled = false;

            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["COMPANY_BANK_NO"] = Bank_Code.ToString();
                e.Values["COMPANY_BANK_NAME"] = Bank_Name.ToString();
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;
            textBox_CompID.Enabled = false;

            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;
            textBox_CompID.Enabled = false;

            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox_Bank.Enabled = false;
            comboBox_Bank.SelectedIndex = 0;
            textBox_CompID.Enabled = false;
        }

        private void comboBox_Comp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comp = "";
            if (comboBox_Comp.SelectedValue == null)
            {
                comp = "";
            }
            else
            {
                comp = comboBox_Comp.SelectedValue.ToString();
            }

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.COMP
                      where a.COMP1 == comp
                      orderby a.COMP1
                      select new { COMP_ID = a.COMPID };
            //var lst = sql.AsEnumerable().ToDictionary(p => p.COMP_ID);
            var lst = sql.CopyToDataTable();


            if (lst.Rows.Count == 0)
            {
                textBox_CompID.Text = "";
            }
            else
            {
                textBox_CompID.Text = lst.Rows[0]["COMP_ID"].ToString();
            }
        }
    }
}
