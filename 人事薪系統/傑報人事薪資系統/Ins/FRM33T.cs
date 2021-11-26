using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM33T : JBControls.JBForm
    {
        public FRM33T()
        {
            InitializeComponent();
        }
        public string Nobr = "";
        private void FRM31_Load(object sender, EventArgs e)
        {

            this.fAMILYTableAdapter.FillByNobr(this.basDS.FAMILY, Nobr);
            Sal.Function.SetAvaliableBase(this.mainDS.V_BASE);
            this.iNSGRFTableAdapter.FillByNobr(this.insDS.INSGRF, Nobr);

            fullDataCtrl1.DataAdapter = iNSGRFTableAdapter;
            fullDataCtrl1.Init_Ctrls();
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
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
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

        private void popupTextBox1_Validated(object sender, EventArgs e)
        {
            this.fAMILYTableAdapter.FillByNobr(this.basDS.FAMILY, ptxNobr.Text);
            //fAMILYBindingSource.Clear();
            fAMILYBindingSource.ResetBindings(true);
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Function.GetDate();
            txtDdate.Text = Sal.Function.GetDate(DateTime.MaxValue.Date);
        }
    }
}