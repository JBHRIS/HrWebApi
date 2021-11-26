using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM214 : JBControls.JBForm
    {
        public FRM214()
        {
            InitializeComponent();
        }

        private void FRM214_Load(object sender, EventArgs e)
        {
            this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALCODETableAdapter.Fill(this.dsSal.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = oTRCDTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "OTRCD.OTRCD";//**代碼權限設定**
            fdc.CodeSource = "OTRCD";//**代碼權限設定**
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121114
                {
                    e.Values["OTRCD"] = Guid.NewGuid().ToString();
                }
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
                if (CheckRepeat(e.Values["OTRCD"].ToString(), e.Values["OTRCD_DISP"].ToString()))//**代碼權限設定**20121114
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
			DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
			dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

			JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
			System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
		}

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (oTRCDBindingSource.Current == null) return;
                dsAtt.OTRCDRow r = ((oTRCDBindingSource.Current as DataRowView).Row as dsAtt.OTRCDRow);
                if (r != null)//**代碼權限設定**20121114
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "OTRCD";
                    frm.Code = r.OTRCD;
                    frm.Text += "(" + r.OTRNAME + ")";
                    frm.ShowDialog();
                }
            }
        }

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121114
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OTRCD
                      where a.OTRCD1!= Code && a.OTRCD_DISP == Disp
                     && db.GetCodeFilter("OTRCD", a.OTRCD1, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }
    }
}