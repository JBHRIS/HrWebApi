using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2M_Group : JBControls.JBForm
    {
        public FRM2M_Group()
        {
            InitializeComponent();
        }

        private void FRM2M_Group_Load(object sender, EventArgs e)
        {
            txtNOTE.Enabled = false;
            this.mealGroupTableAdapter.Fill(this.dsAtt.MealGroup, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = mealGroupTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "MealGroup.MEALGROUP_CODE";//**代碼權限設定**20200709
            fdc.CodeSource = "MealGroup";//**代碼權限設定**20200709
            fdc.Init_Ctrls();
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtCODE_DISP.Focus();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
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

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20200709
                {
                    e.Values["MEALGROUP_CODE"] = Guid.NewGuid().ToString();
                }
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;

                if (CheckRepeat(e.Values["MEALGROUP_CODE"].ToString(), e.Values["MEALGROUP_DISP"].ToString()))//**代碼權限設定**20200709
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
        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (mEALGROUPBindingSource.Current == null) return;
                dsAtt.MealGroupRow r = ((mEALGROUPBindingSource.Current as DataRowView).Row as dsAtt.MealGroupRow);
                if (r != null)//**代碼權限設定**20200709
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "MealGroup";
                    frm.Code = r.MealGroup_Code;
                    frm.Text += "(" + r.MealGroup_Name + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20200709
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MealGroup
                      where a.MealGroup_Code != Code && a.MealGroup_DISP == Disp
                     && db.GetCodeFilter("MealGroup", a.MealGroup_Code, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (mEALGROUPBindingSource.Current == null) return;
                dsAtt.MealGroupRow r = ((mEALGROUPBindingSource.Current as DataRowView).Row as dsAtt.MealGroupRow);
                if (r != null)//**代碼權限設定**20200709
                {
                    FRM2M_CaseSetting frm = new FRM2M_CaseSetting();
                    frm.Icon = this.Icon;
                    frm.MealGroup = r.MealGroup_Code;
                    frm.Text += "(" + r.MealGroup_Name + ")";
                    frm.ShowDialog();
                    dgv_SelectionChanged(sender, e);
                }
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (mEALGROUPBindingSource.Current == null) return;
            dsAtt.MealGroupRow r = ((mEALGROUPBindingSource.Current as DataRowView).Row as dsAtt.MealGroupRow);
            if (r != null)//**代碼權限設定**20200709
            {
                this.dsAtt.MealCaseSetting.Clear();
                this.mealCaseSettingTableAdapter.FillByMealGroup(this.dsAtt.MealCaseSetting, r.MealGroup_Code);
            }
        }

        private void btnMealType_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (mEALGROUPBindingSource.Current == null) return;
                dsAtt.MealGroupRow r = ((mEALGROUPBindingSource.Current as DataRowView).Row as dsAtt.MealGroupRow);
                if (r != null)
                {
                    FRM2M_Type frm = new FRM2M_Type();
                    frm.Icon = this.Icon;
                    frm.MealGroup = r.MealGroup_Code;
                    frm.Text += "(" + r.MealGroup_Name + ")";
                    frm.ShowDialog();
                    dgv_SelectionChanged(sender, e);
                }
            }
        }
    }
}
