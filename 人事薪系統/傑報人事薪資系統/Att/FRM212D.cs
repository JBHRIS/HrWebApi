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
    public partial class FRM212D : JBControls.JBForm
    {
        public string sRote;

        public FRM212D()
        {
            InitializeComponent();
        }

        private void FRM211D_Load(object sender, EventArgs e)
        {
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE,MainForm.USER_ID,MainForm.COMPANY,MainForm.ADMIN);
            this.rOTE_BONUSTableAdapter.FillByRote(this.dsAtt.ROTE_BONUS, sRote);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetSalCode(), false, false);
            SystemFunction.SetComboBoxItems(cbxSALFUNCTION, CodeFunction.GetSalFunction("ATT"), true);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.WhereCmd = " ROTE='" + sRote + "'";
            fdc.DataAdapter = rOTE_BONUSTableAdapter;
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            e.Values["ROTE"] = sRote;
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtBtime.Text = "0000";
            txtEtime.Text = "0000";
            txtBworkHrs.Text = "0";
            txtEworkHrs.Text = "99";
            txtAmt.Text = "0";
            cbxSALFUNCTION.SelectedValue = "";
            comboBox1.Focus();
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (rOTEBONUSBindingSource.Current == null) return;

            dsAtt.ROTE_BONUSRow r = ((rOTEBONUSBindingSource.Current as DataRowView).Row as dsAtt.ROTE_BONUSRow);
            Sys.U_QUERY frm = new Sys.U_QUERY();
            frm.Source = "RoteBonusConditionType";
            frm.Code = r.AUTO.ToString();
            frm.ShowDialog();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var frm = new CopyBonusSetting();
            frm.CurrentRote = sRote;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rOTE_BONUSTableAdapter.FillByRote(this.dsAtt.ROTE_BONUS, sRote);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
