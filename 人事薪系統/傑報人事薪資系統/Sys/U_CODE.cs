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
	public partial class U_CODE : JBControls.JBForm
	{
		public U_CODE()
		{
			InitializeComponent();
		}

		private void U_CODE_Load(object sender, EventArgs e)
		{
            this.u_PRGTableAdapter.Fill(this.sysDS.U_PRG);
            this.u_CODETableAdapter.Fill(this.sysDS.U_CODE);

            //if (!MainForm.MANGSUPER) uCODEBindingSource.Filter = "workadr = '" + MainForm.WORKADR + "'";

            Dictionary<string,string> lst=new Dictionary<string,string>();
            lst.Add("C", "文字");
            lst.Add("N","數值");
            lst.Add("D","日期");
            lst.Add("L","布林");
            SystemFunction.SetComboBoxItems(comboBox1, lst);

            fullDataCtrl1.DataAdapter = u_CODETableAdapter;
            fullDataCtrl1.Init_Ctrls();
            comboBox1.Enabled = false;
		}

		private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
		{
			
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
                e.Values["SYSTEM"] = "JBHR";
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
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

		private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxPrg.Focus();
        }
	}
}
