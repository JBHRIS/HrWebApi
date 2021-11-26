using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Wel;

namespace JBHR.EXA
{
	public partial class FRM85 : JBControls.JBForm
	{
        CheckControl cc;
		public FRM85()
		{
            this.InitializeComponent();
		}

		private void FRM82_Load(object sender, EventArgs e)
		{
            // TODO: 這行程式碼會將資料載入 'exa.Assess' 資料表。您可以視需要進行移動或移除。
            this.assessTableAdapter.Fill(this.exa.Assess);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetAssessCat(), true, false, true);
            fullDataCtrl1.DataAdapter = assessTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            //#region 必要欄位檢察
            //cc = new CheckControl();
            //cc.AddControl(txtEFFTYPE_DISP);     //考核種類代碼
            //cc.AddControl(txtEFFTYPE_NAME);     //考核種類名稱
            //#endregion
            ////fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("EFFLVL");
            
            //WelDataClassesDataContext db = new WelDataClassesDataContext();
            //var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            //if (u_prg != null)
            //{
            //    fullDataCtrl1.bnAddEnable = u_prg.ADD_;
            //    fullDataCtrl1.bnEditEnable = u_prg.EDIT;
            //    fullDataCtrl1.bnDelEnable = u_prg.DELE;
            //    fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            //}
		}

		private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //if (!e.Error)
            //{
            //    CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            //}
		}

		private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
		{
            #region 必要欄位檢察
            //var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            //if (ctrl != null)//必要欄位檢察
            //{
            //    MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ctrl.Focus();
            //    e.Cancel = true;
            //    return;
            //}
            #endregion
            //if (!MainForm.PROCSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();
            //    var data = (from c in db.V_BASE where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //    if (data == null)
            //    {
            //        e.Cancel = true;
            //        MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //if (!Sal.Function.CanModify(txtEFFLVL_DISP.Text))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //if (!e.Cancel)
            //{
            //    if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            //    {
            //        e.Values["EFFTYPE"] = Guid.NewGuid().ToString();
            //    }
            //    e.Values["key_man"] = MainForm.USER_NAME;
            //    e.Values["key_date"] = DateTime.Now;
            //}

            e.Values["sKeyMan"] = MainForm.USER_NAME;
            e.Values["dKeyDate"] = DateTime.Now;

		}

		private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //if (!e.Error)
            //{
            //    CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            //}
		}

		private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            //dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            //JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
		}

		private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //filterData();
		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            //filterData();
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
            //if (!Sal.Function.CanModify(txtEFFTYPE_DISP.Text))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //txtEFFTYPE_DISP.Focus();
        }
	}
}
