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
	public partial class FRM112 : JBControls.JBForm
	{
		public FRM112()
		{
			InitializeComponent();
		}

		private void FRM112_Load(object sender, EventArgs e)
		{
            // TODO: 這行程式碼會將資料載入 'medDS.MTCODE' 資料表。您可以視需要進行移動或移除。
            this.mTCODETableAdapter.FillBySUBS(this.medDS.MTCODE);
            // TODO: 這行程式碼會將資料載入 'basDS.EXP_DEPT' 資料表。您可以視需要進行移動或移除。
            this.eXP_DEPTTableAdapter.Fill(this.basDS.EXP_DEPT);
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**   
            SystemFunction.CheckMtCodeCodeConfigRule(btnConfigMtCode,"SUBS");
			this.sUBSTableAdapter.Fill(this.basDS.SUBS);
            SystemFunction.SetComboBoxItems(cbSubs, CodeFunction.GetMtCode("SUBS"), true, false, true);      //類別
            SystemFunction.SetComboBoxItems(cbI_CODE, CodeFunction.GetCostType(), true, false, true);      //間接費用
            SystemFunction.SetComboBoxItems(cbD_CODE, CodeFunction.GetCostType(), true, false, true);      //直接費用

            this.dEPTSTableAdapter.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

			fullDataCtrl1.DataAdapter = dEPTSTableAdapter;

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
            fullDataCtrl1.CodeColumn = "DEPTS.D_NO";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "DEPTS";//**代碼權限設定**
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
                    e.Values["D_NO"] = Guid.NewGuid().ToString();
                }
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                if (CheckRepeat(e.Values["D_NO"].ToString(), e.Values["D_NO_DISP"].ToString()))//**代碼權限設定**20121017
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

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                e.Values["adate"] = DateTime.Now.ToString("yyyy/MM/dd");
                e.Values["ddate"] = "9999/12/31";
            }
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (dEPTSBindingSource.Current == null) return;
                BasDS.DEPTSRow r = ((dEPTSBindingSource.Current as DataRowView).Row as BasDS.DEPTSRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "DEPTS";
                    frm.Code = r.D_NO;
                    frm.Text += "(" + r.D_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }

        private void btnConfigMtCode_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                Sys.MTCODE frm = new Sys.MTCODE();
                var btn = sender as System.Windows.Forms.Button;
                if (btn != null)
                {
                    frm.Category = btn.Tag.ToString();
                    frm.ShowDialog();
                }
                SystemFunction.SetComboBoxItems(cbSubs, CodeFunction.GetMtCode("SUBS"), true);      //類別
                this.basDS.DEPTS.RejectChanges();
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTS
                      where a.D_NO != Code && a.D_NO_DISP == Disp
                     && db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }
	}
}
