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
	public partial class FRM11Y : JBControls.JBForm
	{
        public string sAcccd;
		public FRM11Y(string Acccd)
		{
			InitializeComponent();
            sAcccd = Acccd;
		}

		private void FRM11D_Load(object sender, EventArgs e)
		{
            // TODO:  這行程式碼會將資料載入 'basDS.CostType' 資料表。您可以視需要進行移動或移除。
            this.costTypeTableAdapter.Fill(this.basDS.CostType);
			SystemFunction.SetComboBoxItems(cbACCTYPE, CodeFunction.GetCostType(), true, false, true);
            this.aCCCDTableAdapter.Fill(this.basDS.ACCCD);
            this.aCCSALTableAdapter.FillByAccCd(this.basDS.ACCSAL, sAcccd);

            fullDataCtrl1.DataAdapter = aCCSALTableAdapter;
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**
			BasDataClassesDataContext db = new BasDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
			}
            //fullDataCtrl1.CodeColumn = "ACCSAL.D_NO";//**代碼權限設定**
            //fullDataCtrl1.CodeSource = "ACCSAL";//**代碼權限設定**
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
                e.Values["acccd"] = sAcccd;
			}
            //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            //{
            //    e.Values["D_NO"] = Guid.NewGuid().ToString();
            //}
            if (CheckRepeat(cbACCTYPE.SelectedValue.ToString(), sAcccd))//**代碼權限設定**20121017
            {
                MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
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

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ACCSAL
                      where a.D_NO == Code && a.ACCCD == Disp
                     && db.GetCodeFilter("ACCSAL", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (this.aCCSALBindingSource.Current == null) return;
                BasDS.ACCSALRow r = ((aCCSALBindingSource.Current as DataRowView).Row as BasDS.ACCSALRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "ACCSAL";
                    frm.Code = r.D_NO;
                    frm.Text += "(" + r.ACCCD + ")";
                    frm.ShowDialog();
                }
            }
        }
	}
}
