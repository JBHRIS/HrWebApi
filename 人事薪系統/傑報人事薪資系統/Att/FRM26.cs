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
    public partial class FRM26 : JBControls.JBForm
    {
        public FRM26()
        {
            InitializeComponent();
        }

        private void FRM26_Load(object sender, EventArgs e)
        {
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true, false, true);
            this.aTTCARDTableAdapter.FillByInit(this.dsAtt.ATTCARD);


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
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = this.aTTCARDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (txtT1.Text.CompareTo(txtT2.Text) >= 0 && !string.IsNullOrWhiteSpace(txtT2.Text))
            {
                string msg = label3.Text + " " + Resources.Att.NotAllowLargerThan + " " + label4.Text;
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }

            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }

        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //    txtAdate.Focus();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtT1_Validating(object sender, CancelEventArgs e)
        {
            if (txtT1.Text.Length == 0)
                return;
            if (!Sal.Function.ValidateTimeStringFormat(txtT1.Text, 48))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
                txtT1.Focus();
                return;
            }
        }

        private void txtTT1_Validating(object sender, CancelEventArgs e)
        {
            if (txtTT1.Text.Length == 0)
                return;
            if (!Sal.Function.ValidateTimeStringFormat(txtTT1.Text, 24))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
                txtTT1.Focus();
                return;
            }
        }

        private void txtT2_Validating(object sender, CancelEventArgs e)
        {
            if (txtT2.Text.Length == 0)
                return;
            if (!Sal.Function.ValidateTimeStringFormat(txtT2.Text, 48))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
                txtT2.Focus();
                return;
            }
        }

        private void txtTT2_Validating(object sender, CancelEventArgs e)
        {
            if (txtTT2.Text.Length == 0)
                return;
            if (!Sal.Function.ValidateTimeStringFormat(txtTT2.Text, 24))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
                txtTT2.Focus();
                return;
            }
        }

        private void txtT1_Validated(object sender, EventArgs e)
        {
            if (txtT1.Text.Length == 4)
            {
                var iH = Convert.ToInt32(txtT1.Text.Substring(0, 2));
                var h = iH < 24 ? txtT1.Text.Substring(0, 2) : (iH - 24).ToString();
                var m = txtT1.Text.Substring(2, 2);
                var txt = h + m;
                if (txt.Length < 4) txt = "0" + txt;
                txtTT1.Text = txt;
            }
        }

        private void txtT2_Validated(object sender, EventArgs e)
        {
            if (txtT2.Text.Length == 4)
            {
                var iH = Convert.ToInt32(txtT2.Text.Substring(0, 2));
                var h = iH < 24 ? txtT2.Text.Substring(0, 2) : (iH - 24).ToString();
                var m = txtT2.Text.Substring(2, 2);
                var txt = h + m;
                if (txt.Length < 4) txt = "0" + txt;
                txtTT2.Text = txt;
            }
        }
    }
}
