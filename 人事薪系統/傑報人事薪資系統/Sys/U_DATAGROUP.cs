using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_DATAGROUP : JBControls.JBForm
    {
        public U_DATAGROUP()
        {
            InitializeComponent();
        }
        public string UserID = "";
        public string CompID = "";
        private void U_USER_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetDatagroup(CompID));
            this.dATAGROUPTableAdapter.Fill(this.sysDS.DATAGROUP);
            this.u_DATAGROUPTableAdapter.FillByUserComp(this.sysDS.U_DATAGROUP, UserID, CompID);
            fullDataCtrl1.DataAdapter = u_DATAGROUPTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            string saladr = "";
            if (comboBox2.SelectedValue != null)
                saladr = comboBox2.SelectedValue.ToString();
            if (!MainForm.ADMIN && !MainForm.WriteRules.Where(p => p.DATAGROUP == saladr).Any())
            {
                MessageBox.Show("你沒有權限刪除該群組的資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            string saladr = "";
            if (comboBox2.SelectedValue != null)
                saladr = comboBox2.SelectedValue.ToString();
            if (!MainForm.ADMIN && !MainForm.WriteRules.Where(p => p.DATAGROUP == saladr).Any())
            {
                MessageBox.Show("你沒有權限刪除該群組的資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            e.Values["user_id"] = UserID;
            e.Values["company"] = CompID;
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (this.sysDS.U_USER.Count > 0)
            {
                foreach (var row in this.sysDS.U_USER)
                {
                    row.PASSWORD = JBModule.Data.CDecryp.Text(row.PASSWORD);
                }
            }
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (this.sysDS.U_USER.Count > 0)
            {
                foreach (var row in this.sysDS.U_USER)
                {
                    row.PASSWORD = JBModule.Data.CDecryp.Text(row.PASSWORD);
                }
            }
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox2.Enabled = false;//不可變換資料群組(僅可刪除後重建)
        }
    }

}
