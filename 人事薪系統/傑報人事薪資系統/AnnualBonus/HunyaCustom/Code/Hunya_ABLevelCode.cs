using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.AnnualBonus.HunyaCustom.Code
{
    public partial class Hunya_ABLevelCode : JBControls.JBForm
    {
        public Hunya_ABLevelCode()
        {
            InitializeComponent();
        }

        private void Hunya_ABLevelCode_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_AnnualBonus.Hunya_ABLevelCode' 資料表。您可以視需要進行移動或移除。
            this.ABLevelCodeTableAdapter.Fill(this.hunya_AnnualBonus.Hunya_ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = ABLevelCodeTableAdapter;
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.CodeColumn = "Hunya_ABLevelCode.ABLevelCode";//**代碼權限設定**
            fdc.CodeSource = "Hunya_ABLevelCode";//**代碼權限設定**
            fdc.Init_Ctrls();
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtABLevelCode_DISP.Focus();
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
                    e.Values["ABLevelCode"] = Guid.NewGuid().ToString();
                }
                e.Values["KEYMAN"] = MainForm.USER_NAME;
                e.Values["KEYDATE"] = DateTime.Now;
                e.Values["GID"] = Guid.NewGuid();
                if (CheckRepeat(e.Values["ABLevelCode"].ToString(), e.Values["ABLevelCode_DISP"].ToString()))//**代碼權限設定**
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
                if (ABLevelCodeBindingSource.Current == null) return;
                Hunya_AnnualBonus.Hunya_ABLevelCodeRow r = ((ABLevelCodeBindingSource.Current as DataRowView).Row as Hunya_AnnualBonus.Hunya_ABLevelCodeRow);
                if (r != null)//**代碼權限設定**
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "Hunya_ABLevelCode";
                    frm.Code = r.ABLevelCode;
                    frm.Text += "(" + r.ABLevelCode_Name + ")";
                    frm.ShowDialog();
                }
            }
        }

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_ABLevelCode
                      where a.ABLevelCode != Code && a.ABLevelCode_DISP == Disp
                     && db.GetCodeFilter("Hunya_ABLevelCode", a.ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }


    }
}
