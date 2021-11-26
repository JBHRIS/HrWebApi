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
    public partial class FRM21A : JBControls.JBForm
    {
        public FRM21A()
        {
            InitializeComponent();
        }

        private void FRM21A_Load(object sender, EventArgs e)
        {
            this.taOTHCODE.Fill(this.dsAtt.OTHCODE);
            SystemFunction.SetComboBoxItems(comboBoxRote, CodeFunction.GetRote(), true, false, true);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.DataAdapter = taOTHCODE;
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            e.Values["OTHCOLOR"] = e.Values["OTHCOLOR"].ToString().Trim().Length == 0 ? Color.Black.ToArgb() : Convert.ToInt32(e.Values["OTHCOLOR"]);
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

        private void bsOTHCODE_CurrentChanged(object sender, EventArgs e)
        {
            if (bsOTHCODE.Current != null)
            {
                dsAtt.OTHCODERow r = (bsOTHCODE.Current as DataRowView).Row as dsAtt.OTHCODERow;
                try
                {
                    txtOthColor.BackColor = Color.FromArgb(Convert.ToInt32(r.OTHCOLOR));
                }
                catch
                {
                    txtOthColor.BackColor = Color.Black;
                }
            }
        }

        private void txtOthColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                txtOthColor.Text = cd.Color.ToArgb().ToString();
                txtOthColor.BackColor = Color.FromArgb(Convert.ToInt32(txtOthColor.Text));
            }
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }
    }
}
