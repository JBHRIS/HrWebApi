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
    public partial class FRMG12 : JBControls.JBForm
    {
        public FRMG12()
        {
            InitializeComponent();
        }

        private void FRMG12_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetDatagroup());
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroup("lock_wage.saladr");
            fullDataCtrl1.DataAdapter = lOCK_WAGETableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }


        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            Sys.SysDS.LOCK_WAGERow LOCK_WAGERow = (lOCKWAGEBindingSource.Current as DataRowView).Row as Sys.SysDS.LOCK_WAGERow;

            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(LOCK_WAGERow.SALADR))
            {
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
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
            if (!e.Cancel)
            {
                Sys.SysDS.LOCK_WAGERow LOCK_WAGERow = (lOCKWAGEBindingSource.Current as DataRowView).Row as Sys.SysDS.LOCK_WAGERow;
                LOCK_WAGERow.SALADR = comboBox1.SelectedValue.ToString();
                LOCK_WAGERow.KEY_MAN = MainForm.USER_NAME;
                LOCK_WAGERow.KEY_DATE = DateTime.Now;

                if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(LOCK_WAGERow.SALADR))
                {
                    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
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

        private void btnBatch_Click(object sender, EventArgs e)
        {
            FRMG12A frm = new FRMG12A();
            frm.ShowDialog();
        }
    }
}