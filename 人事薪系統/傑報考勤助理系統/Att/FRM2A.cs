using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2A : JBControls.JBForm
    {
        public FRM2A()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        private void FRM2A_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true);
            cbxRote.Enabled = false;
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.rOTECHGTableAdapter.FillByInit(this.dsAtt.ROTECHG);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("rotechg");

            fullDataCtrl1.DataAdapter = rOTECHGTableAdapter; ;
            fullDataCtrl1.Init_Ctrls();

            chkNoTran.Enabled = false;
            chkNoTran.Checked = false;
            txtEdate.Enabled = false;
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            chkNoTran.Enabled = true;
            txtEdate.Enabled = true;
            txtBdate.Text = Sal.Core.SalaryDate.DateString();
            txtEdate.Text = Sal.Core.SalaryDate.DateString();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                chkNoTran.Enabled = false;
                chkNoTran.Checked = false;
                txtEdate.Enabled = false;
                string keyman = e.Values["KEY_MAN"].ToString();
                DateTime keydate = Convert.ToDateTime(e.Values["KEY_DATE"]);
                DateTime d1 = Convert.ToDateTime(txtBdate.Text).Date;
                DateTime d2 = Convert.ToDateTime(txtEdate.Text).Date;
                for (DateTime dd = d1.AddDays(1); dd <= d2; dd = dd.AddDays(1))
                {
                    dsAtt.ROTECHGRow r = dsAtt.ROTECHG.NewROTECHGRow();
                    r.ADATE = dd;
                    r.CODE = "";
                    r.KEY_DATE = keydate;
                    r.KEY_MAN = keyman;
                    r.NOBR = e.Values["nobr"].ToString();
                    r.ROTE = e.Values["rote"].ToString();
                    this.dsAtt.ROTECHG.AddROTECHGRow(r);
                }
                this.rOTECHGTableAdapter.Update(dsAtt.ROTECHG);

            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (cbxRote.SelectedItem == null || cbxRote.SelectedValue == null || cbxRote.SelectedValue.ToString().Trim().Length == 0)
            {
                e.Cancel = true;
                MessageBox.Show("班別代碼未指定", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cbxRote.Focus();
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) chkNoTran.Focus();
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            chkNoTran.Enabled = false;
            chkNoTran.Checked= false;
            txtEdate.Enabled = false;
            txtEdate.Text = "";
        }

        private void txtBdate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime d1, d2;
                d1 = Convert.ToDateTime(txtBdate.Text);
                d2 = Convert.ToDateTime(txtEdate.Text);
                if (d2 < d1) txtEdate.Text = Sal.Core.SalaryDate.DateString();
            }
            catch { }
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            CheckExists();
        }
        void CheckExists()
        {
            var sql = from r in db.ROTECHG where r.NOBR == ptxNobr.Text && r.ADATE >= Convert.ToDateTime(txtBdate.Text) && r.ADATE <= Convert.ToDateTime(txtEdate.Text) select r;
            if (sql.Any())
            {
                string msg = string.Format(Resources.Att.RotechgExists, sql.Count());
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtEdate_Validated(object sender, EventArgs e)
        {
            CheckExists();
        }
        void ReGenRote(string nobr,DateTime date)
        {
            var sql = from r in db.ROTECHG
                      where r.NOBR == ptxNobr.Text && r.ADATE >= Convert.ToDateTime(txtBdate.Text)
                      && r.ADATE <= Convert.ToDateTime(txtEdate.Text) select r;
        }

        //private void btnRoteChg_Click(object sender, EventArgs e)
        //{
        //    FRM2AI fRM2AI = new FRM2AI();
        //    fRM2AI.ShowDialog();
        //}
    }
}
