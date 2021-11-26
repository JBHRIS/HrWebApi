using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1MD : JBControls.JBForm
    {
        CheckControl cc;
        public FRM1MD()
        {
            InitializeComponent();
        }
        public string CompID = "";
        private void FRM1M_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbDATAGROUP);      //資料群組
            #endregion

            SystemFunction.SetComboBoxItems(cbDATAGROUP, CodeFunction.GetDatagroupAll(), true, false,true);  //資料群組
            //this.dATAGROUPTableAdapter.Fill(this.sysDS.DATAGROUP);
            this.cOMP_DATAGROUPTableAdapter.FillByComp(this.sysDS.COMP_DATAGROUP,CompID);
            fullDataCtrl1.DataAdapter = cOMP_DATAGROUPTableAdapter;

			BasDataClassesDataContext db = new BasDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;				
			}

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
            #region 必要欄位檢察
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            #endregion

			if (!e.Cancel)
			{
				e.Values["key_man"] = MainForm.USER_NAME;
				e.Values["key_date"] = DateTime.Now;
                e.Values["comp"] = CompID;
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

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbDATAGROUP.Focus();
        }
    }
}
