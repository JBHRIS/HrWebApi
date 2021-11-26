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

        object[] PARMS = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

        private void FRM26_Load(object sender, EventArgs e)
        {
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true);
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
            //迅得carol要求只要經修改或新增的資料存檔都要不自動轉換
            //chkNotModi.Checked = true;
            e.Values["nomody"] = true;
            ptxNobr.Focus();

        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //迅得carol要求只要經修改或新增的資料存檔都要不自動轉換
            //chkNotModi.Checked = true;
            e.Values["nomody"] = true;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                //var db = new JBModule.Data.Linq.HrDBDataContext();

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                //tc.TransCard(e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["adate"].ToString()), DateTime.Parse(e.Values["adate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
                tc.TransCard(PARMS[0].ToString().Trim(), PARMS[1].ToString().Trim(), PARMS[2].ToString().Trim(), PARMS[3].ToString().Trim(), DateTime.Parse(PARMS[4].ToString()), DateTime.Parse(PARMS[5].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (txtTT1.Text.CompareTo(txtTT2.Text) >= 0)
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
                //迅得carol要求只要經修改或新增的資料存檔都要不自動轉換
                //e.Values["NOMODY"] = true;
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }

        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                //var db = new JBModule.Data.Linq.HrDBDataContext();
                var DeptSQL = from a in db.BASETTS
                              join b in db.DEPT on a.DEPT equals b.D_NO
                              where DateTime.Parse(e.Values["adate"].ToString()) <= a.DDATE && DateTime.Parse(e.Values["adate"].ToString()) >= a.ADATE
                              && a.NOBR == e.Values["nobr"].ToString().Trim()
                              select new { a.NOBR, b.D_NO_DISP };

                string dept_b = DeptSQL.First().D_NO_DISP;

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                //tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                tc.TransCard(e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["adate"].ToString()), DateTime.Parse(e.Values["adate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            }
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
            var DeptSQL = from a in db.BASETTS
                          join b in db.DEPT on a.DEPT equals b.D_NO
                          where DateTime.Parse(e.Values["adate"].ToString()) <= a.DDATE && DateTime.Parse(e.Values["adate"].ToString()) >= a.ADATE
                          && a.NOBR == e.Values["nobr"].ToString().Trim()
                          select new { a.NOBR, b.D_NO_DISP };

            string dept_b = DeptSQL.First().D_NO_DISP;

            PARMS = new object[] { e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["adate"].ToString()), DateTime.Parse(e.Values["adate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
        }

        private void txtT1_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtT1.Text,24))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
            }
        }

        private void txtTT1_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtTT1.Text))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
                return;
            }
        }

        private void txtT2_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtT2.Text,24))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
            }
        }

        private void txtTT2_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtTT2.Text))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);

            }
        }
    }
}
