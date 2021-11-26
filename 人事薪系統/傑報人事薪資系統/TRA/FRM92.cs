using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Wel;

namespace JBHR.TRA
{
	public partial class FRM92 : JBControls.JBForm
	{
        CheckControl cc;
		public FRM92()
		{
			InitializeComponent();
		}

        private void FRM92_Load(object sender, EventArgs e)
		{
            // TODO:  這行程式碼會將資料載入 'traDS1.TRCOMP' 資料表。您可以視需要進行移動或移除。
            this.tRCOMPTableAdapter.Fill(this.traDS1.TRCOMP);
            fullDataCtrl1.DataAdapter = tRCOMPTableAdapter;
            
			WelDataClassesDataContext db = new WelDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
			}
            fullDataCtrl1.CodeColumn = "TRCOMPY.TR_COMP";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "TRCOMPY";//**代碼權限設定**
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
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                if (GetTrCompy(txtTR_COMP_DISP.Text) != null)
                {
                    MessageBox.Show("「承辦單位代碼」已使用，請重新輸入。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTR_COMP_DISP.Focus();
                    e.Cancel = true;
                    return;
                }
            }

			if (!e.Cancel)
			{
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
                {
                    e.Values["TR_COMP"] = Guid.NewGuid().ToString();
                }
				e.Values["key_man"] = MainForm.USER_NAME;
				e.Values["key_date"] = DateTime.Now;
			}
		}
        JBModule.Data.Linq.TRCOMPY GetTrCompy(string TrCompDisp)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRCOMPY
                      where a.TR_COMP_DISP == TrCompDisp
                      select a;
            return sql.FirstOrDefault();
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

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			filterData();
		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			filterData();
		}

		private void filterData()
		{
            //if (!MainForm.MANGSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();

            //    DataTable dt = (wELFBindingSource.DataSource as DataSet).Tables[wELFBindingSource.DataMember];
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();

            //    fullDataCtrl1.Init_Ctrls();
            //}
		}

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (!Sal.Function.CanModify(txtEFFLVL_DISP.Text))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtTR_COMP_DISP.Focus();
        }

        //private void FRM81_Load_1(object sender, EventArgs e)
        //{
        //    // TODO: 這行程式碼會將資料載入 'exa.EFFLVL' 資料表。您可以視需要進行移動或移除。
        //    this.eFFLVLTableAdapter.Fill(this.exa.EFFLVL);
        //    // TODO: 這行程式碼會將資料載入 'exa.EFFLVL' 資料表。您可以視需要進行移動或移除。
        //    this.eFFLVLTableAdapter.Fill(this.exa.EFFLVL);

        //}
	}
}
