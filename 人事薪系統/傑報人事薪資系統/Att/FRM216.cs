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
    public partial class FRM216 : JBControls.JBForm
    {
        public FRM216()
        {
            InitializeComponent();
        }

        private void FRM216_Load(object sender, EventArgs e)
        {

            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**   
            this.taHOLICD.Fill(this.dsAtt.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = taHOLICD;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "HOLICD.HOLI_CODE";//**代碼權限設定**
            fdc.CodeSource = "HOLICD";//**代碼權限設定**

            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            {
                e.Values["HOLI_CODE"] = Guid.NewGuid().ToString();
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            if (CheckRepeat(e.Values["HOLI_CODE"].ToString(), e.Values["HOLI_CODE_DISP"].ToString()))//**代碼權限設定**20121017
            {
                MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        //private void fdc_BeforeShow(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        //{
        //    taHOLICD.Adapter.Fill(this.dsAtt.HOLICD);
        //}

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
                if (bsHOLICD.Current == null) return;
                dsAtt.HOLICDRow r = ((bsHOLICD.Current as DataRowView).Row as dsAtt.HOLICDRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "HOLICD";
                    frm.Code = r.HOLI_CODE;
                    frm.Text += "(" + r.HOLI_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HOLICD
                      where a.HOLI_CODE != Code && a.HOLI_CODE_DISP == Disp
                     && db.GetCodeFilter("HOLICD", a.HOLI_CODE, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }
    }
}
