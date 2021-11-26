using System;using System.Collections.Generic;using System.ComponentModel;using System.Data;using System.Drawing;using System.Linq;using System.Text;using System.Windows.Forms;using JBHR.BLL.NotifyMsgLib;namespace JBHR.Bas{    public partial class FRM12D : JBControls.JBForm    {        public FRM12D()        {            InitializeComponent();        }        private void FRM12D_Load(object sender, EventArgs e)        {
            // TODO: 這行程式碼會將資料載入 'basDS1.TABLEATT' 資料表。您可以視需要進行移動或移除。
            this.tABLEATTTableAdapter.Fill(this.basDS1.TABLEATT);            fullDataCtrl1.DataAdapter = tABLEATTTableAdapter;            FRM12DataClassesDataContext dbBas = new FRM12DataClassesDataContext();            BasDataClassesDataContext db = new BasDataClassesDataContext();            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();            if (u_prg != null)            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;            }            //fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("TABLEATT");            fullDataCtrl1.Init_Ctrls();        }        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)        {            if (!e.Error)            {                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);                            }        }        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)        {            if (!e.Cancel)            {
                //if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
                //{
                //    e.Cancel = true;
                //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}

                e.Values["key_man"] = MainForm.USER_NAME;                e.Values["key_date"] = DateTime.Now;

            }        }        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)        {            if (!e.Error)            {                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);            }        }        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)        {            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");        }        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)        {            textBox1.Focus();        }        private void textBox1_Validated(object sender, EventArgs e)        {        }        private void cbxContractType_SelectedIndexChange(object sender, EventArgs e)        {        }        private void txtAdate_Validated(object sender, EventArgs e)        {        }
        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void txtDDate_Validated(object sender, EventArgs e)
        {
        }
        private void txtAlertDay_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtDDate_TextChanged(object sender, EventArgs e)
        {
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (!Sal.Function.CanModify(ptxNobr.Text))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
        }     

    }
}
