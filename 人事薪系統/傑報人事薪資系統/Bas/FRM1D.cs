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
    public partial class FRM1D : JBControls.JBForm
    {
        public FRM1D()
        {
            InitializeComponent();
        }

        private void FRM1D_Load(object sender, EventArgs e)
        {
            this.cOSTTableAdapter.FillByInit(this.basDS.COST);//載入時顯示空白
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            this.dEPTSTableAdapter.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts_effe(), true, false, true);
            //this.cOSTTableAdapter.Fill(this.basDS.COST);

			fullDataCtrl1.DataAdapter = cOSTTableAdapter;

			BasDataClassesDataContext db = new BasDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
			}
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("cost.nobr");
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
				FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
				var cost = (from c in db.COST
							where c.DEPTS.ToLower().Trim() == e.Values["depts"].ToString().ToLower().Trim()
							select c).FirstOrDefault();
				if (cost != null && cost.DEPTS1 != null) 
				{
					e.Values.Row["dept_name"] = cost.DEPTS1.D_NAME.Trim();					
					dataGridView1.Refresh();
				}
			}
		}

		private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
			dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

			JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
			System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") return;
            if (Convert.ToDecimal(textBox1.Text) > 1)
            {
                MessageBox.Show(Resources.Bas.CostRateMaxLimitErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
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

			frm.FieldForm = new FRM1DIN();
            frm.DataTransfer = new ImportCOSTData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("成本部門", this.basDS.DEPTS.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME, CheckValue1 = p.D_NAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
			frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
			frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
			frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("成本部門", typeof(string));
            frm.DataTransfer.ColumnList.Add("分攤比率", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("生效日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("失效日期", typeof(DateTime));

            //frm.DataTransfer.ColumnList.Add("備註", typeof(string));

            frm.ShowDialog();
        }
    }
}
