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
    public partial class FRM38 : JBControls.JBForm
    {
        public FRM38()
        {
            InitializeComponent();
        }

        private void FRM38_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**   
            this.iNSCOMPTableAdapter.Fill(this.insDS.INSCOMP, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.CodeColumn = "S_NO";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "INSCOMP";//**代碼權限設定**

			fullDataCtrl1.DataAdapter = iNSCOMPTableAdapter;
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
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121113
            {
                e.Values["S_NO"] = Guid.NewGuid().ToString();
            }
            if (!e.Cancel)
			{
				e.Values["key_man"] = MainForm.USER_NAME;
				e.Values["key_date"] = DateTime.Now;
			}
            if (CheckRepeat(e.Values["S_NO"].ToString(), e.Values["S_NO_DISP"].ToString()))//**代碼權限設定**20121114
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

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (iNSCOMPBindingSource.Current == null) return;
                InsDS.INSCOMPRow r = ((iNSCOMPBindingSource.Current as DataRowView).Row as InsDS.INSCOMPRow);
                if (r != null)//**代碼權限設定**20121113
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "INSCOMP";
                    frm.Code = r.S_NO;
                    frm.Text += "(" + r.INSNAME + ")";
                    frm.ShowDialog();
                }
            }
        }

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121114
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSCOMP
                      where a.S_NO != Code && a.S_NO_DISP == Disp
                     && db.GetCodeFilter("INSCOMP", a.S_NO, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

       
    }
}