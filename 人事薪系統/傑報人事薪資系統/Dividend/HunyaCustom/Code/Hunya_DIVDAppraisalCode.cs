using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Dividend.HunyaCustom.Code
{
    public partial class Hunya_DIVDAppraisalCode : JBControls.JBForm
    {
        public Hunya_DIVDAppraisalCode()
        {
            InitializeComponent();
        }

        private void Hunya_DIVDAppraisalCode_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_Dividend.Hunya_DIVDAppraisalCode' 資料表。您可以視需要進行移動或移除。
            this.DIVDAppraisalCodeTableAdapter.Fill(this.hunya_Dividend.Hunya_DIVDAppraisalCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = DIVDAppraisalCodeTableAdapter;
            BasDataClassesDataContext db = new BasDataClassesDataContext();

            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.CodeColumn = "Hunya_DIVDAppraisalCode.DIVDAppraisalCode";//**代碼權限設定**
            fdc.CodeSource = "Hunya_DIVDAppraisalCode";//**代碼權限設定**
            fdc.Init_Ctrls();
        }


        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtDIVDAppraisalCode_DISP.Focus();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fdc.BackupDataTable);
            }
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**
                {
                    e.Values["DIVDAppraisalCode"] = Guid.NewGuid().ToString();
                }
                e.Values["KEYMAN"] = MainForm.USER_NAME;
                e.Values["KEYDATE"] = DateTime.Now;
                e.Values["GID"] = Guid.NewGuid();
                if (CheckRepeat(e.Values["DIVDAppraisalCode"].ToString(), e.Values["DIVDAppraisalCode_DISP"].ToString()))//**代碼權限設定**
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (DIVDAppraisalCodeBindingSource.Current == null) return;
                Hunya_Dividend.Hunya_DIVDAppraisalCodeRow r = ((DIVDAppraisalCodeBindingSource.Current as DataRowView).Row as Hunya_Dividend.Hunya_DIVDAppraisalCodeRow);
                if (r != null)//**代碼權限設定**
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "Hunya_DIVDAppraisalCode";
                    frm.Code = r.DIVDAppraisalCode;
                    frm.Text += "(" + r.DIVDAppraisalCode_Name + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_DIVDAppraisalCode
                      where a.DIVDAppraisalCode != Code && a.DIVDAppraisalCode == Disp
                     && db.GetCodeFilter("Hunya_DIVDAppraisalCode", a.DIVDAppraisalCode, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }
    }
}
