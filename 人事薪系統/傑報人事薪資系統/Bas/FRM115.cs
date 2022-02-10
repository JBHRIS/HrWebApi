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
	public partial class FRM115 : JBControls.JBForm
	{
		public FRM115()
		{
			InitializeComponent();
		}

		private void FRM115_Load(object sender, EventArgs e)
		{

            SystemFunction.SetComboBoxItems(cbStJobl, CodeFunction.GetJobl(), true, false, true);      //開始職等
            SystemFunction.SetComboBoxItems(cbEnJobl, CodeFunction.GetJobl(), true, false, true);      //結束職等
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**           
            this.jOBLTableAdapter.Fill(this.basDS.JOBL, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

			fullDataCtrl1.DataAdapter = jOBTableAdapter;

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
            fullDataCtrl1.CodeColumn = "JOB.JOB";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "JOB";//**代碼權限設定**
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
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
                {
                    e.Values["JOB"] = Guid.NewGuid().ToString();
                }
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                if (CheckRepeat(e.Values["JOB"].ToString(), e.Values["JOB_DISP"].ToString()))//**代碼權限設定**20121017
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
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

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (jOBBindingSource.Current == null) return;
                BasDS.JOBRow r = ((jOBBindingSource.Current as DataRowView).Row as BasDS.JOBRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "JOB";
                    frm.Code = r.JOB;
                    frm.Text += "(" + r.JOB_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.JOB
                      where a.JOB1 != Code && a.JOB_DISP == Disp
                     && db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                var db = new JBModule.Data.Linq.HrDBDataContext();
                if  ( db.BASETTS.Where(p=>p.JOB == e.Values["JOB"].ToString()).Any())
                {
                    MessageBox.Show("已使用中的代碼無法刪除", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}