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
    public partial class FRM1A : JBControls.JBForm
    {
        public FRM1A()
        {
            InitializeComponent();
        }

        private void FRM1A_Load(object sender, EventArgs e)
        {
            this.wORKSTableAdapter.FillByInit(this.basDS.WORKS);//載入時顯示空白
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            //this.wORKSTableAdapter.FillByInit(this.basDS.WORKS);

			fullDataCtrl1.DataAdapter = wORKSTableAdapter;

			BasDataClassesDataContext db = new BasDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
			}
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("works.nobr");
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
			if (!checkSavePower(e.Values["nobr"].ToString()))
			{
				e.Cancel = true;
				MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

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

		private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
		}

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
		}


		private bool checkSavePower(string nobr)
		{
            return Sal.Function.CanModify(nobr);
		}

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                textBox1.Enabled = true;
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
			frm.TemplateButtonVisible = true;

			frm.FieldForm = new FRM1AIN();
            frm.DataTransfer = new ImportWORKSData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
			frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
			frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
			frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("公司", typeof(string));
            frm.DataTransfer.ColumnList.Add("職稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("開始日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("結束日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("工作內容", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));

			frm.DataTransfer.UnMustColumnList = new List<string>();
			frm.DataTransfer.UnMustColumnList.Add("開始日期");
			frm.DataTransfer.UnMustColumnList.Add("結束日期");
			frm.DataTransfer.UnMustColumnList.Add("工作內容");
			frm.DataTransfer.UnMustColumnList.Add("備註");
			frm.ShowDialog();
        }
    }
}
