using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM48 : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM48()
        {
            InitializeComponent();
        }

        private void FRM48_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(ptxHcode, CodeFunction.GetHcode(), true, false, true);
            ptxHcode.Enabled = false;
            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), true, false, true);
            ptxSalcode.Enabled = false;
            SystemFunction.SetComboBoxItems(ptxMlssalcode, CodeFunction.GetSalCode(), true, false, true);
            ptxMlssalcode.Enabled = false;
            //this.hCODETableAdapter.Fill(this.attendDS.HCODE);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALABSTableAdapter.FillByInit(this.salaryDS.SALABS);
            this.hCODETableAdapter1.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = this.sALABSTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt"]));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                this.salaryDS.SALABS.AcceptChanges();
            }
        }
        void fdc_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.SALABS)
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            this.salaryDS.SALABS.AcceptChanges();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSum.Text = Function.ColumnsSum(dataGridView1, e.ColumnIndex);
        }

    }
}
