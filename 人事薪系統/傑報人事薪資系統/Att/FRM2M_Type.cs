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
    public partial class FRM2M_Type : JBControls.JBForm
    {
        public FRM2M_Type()
        {
            InitializeComponent();
        }
        CheckTimeFormatControl CTFC = new CheckTimeFormatControl();
        public string MealGroup { set; get; } = string.Empty;
        List<Control> controlList = new List<Control>();
        List<string> pklist = new List<string>();
        string MealType = string.Empty;
        private void FRM2M_Type_Load(object sender, EventArgs e)
        {
            CTFC.AddControl(txtBTime, true, true, false);
            CTFC.AddControl(txtETime, true, true, false);
            txtNOTE.Enabled = false;
            this.mealTypeTableAdapter.FillByMealGroup(this.dsAtt.MealType, MealGroup);
            fdc.DataAdapter = mealTypeTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.Init_Ctrls();
            //繪製自定義欄位
            controlList = SystemFunction.UserDefineLayoutSetFrmLayout(this, MainForm.COMPANY);
            pklist.Add("mEALTYPEDISPDataGridViewTextBoxColumn");
            pklist.Add("MEALGROUP");
            SystemFunction.updateUserDefineValue(dgv, controlList, pklist);
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtCODE.Focus();
            SystemFunction.SetUserDefineEnable(controlList, true);
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                string DeleteSystemCreateCmd = @" IF (EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'KCR_MealApplySetting'))
                                                    BEGIN
                                                          delete KCR_MealApplySetting
                                                          where MealGroup = {0} and MealType = {1}
                                                    END ";
                db.ExecuteCommand(DeleteSystemCreateCmd, new object[] { MealGroup, MealType });
            }
            SystemFunction.SetUserDefineEnable(controlList, false);
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
            var control = CTFC.CheckRequiredFields();
            if (control != null)
            {
                e.Cancel = true;
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return;
            }
            if (txtBTime.Text.CompareTo(txtETime.Text) > 0)
            {
                e.Cancel = true;
                MessageBox.Show("開始時間不得大於結束時間,跨夜請輸入48小時制.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var OverLapAdd = db.MealType.Where(p => p.MealGroup == MealGroup && p.MealType_Code == txtCODE.Text);
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add && OverLapAdd.Any())
            {
                e.Cancel = true;
                MessageBox.Show("已存在相同代碼.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCODE.Focus();
                return;
            }
            var OverLapEdit = db.MealType.Where(p => p.MealGroup == MealGroup && p.BTime.CompareTo(txtETime.Text) < 0 && p.ETime.CompareTo(txtBTime.Text) > 0 && p.MealType_Code != e.Values["MealType_Code"].ToString());
            if (OverLapEdit.Any())
            {
                e.Cancel = true;
                MessageBox.Show("指定時段與其他設定重疊.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!e.Cancel)
            {
                e.Values["MealGroup"] = MealGroup;
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }
        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
                SystemFunction.submitchangesUserDefineValue(dgv, controlList, pklist);
            }
            SystemFunction.SetUserDefineEnable(controlList, false);
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SystemFunction.SetUserDefineEnable(controlList, true);
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
                SystemFunction.updateUserDefineValue(dgv, controlList, pklist);
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string DeleteSystemCreateCmd = @" IF (EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'KCR_MealApplySetting'))
                                                    BEGIN
                                                          SELECT count(*) as c from KCR_MealApplySetting
                                                          where MealGroup = {0} and MealType = {1} and ApplyFlag = 1
                                                    END ";
            MealType = txtCODE.Text;
            if (db.ExecuteQuery<int>(DeleteSystemCreateCmd, new object[] { MealGroup, MealType }).Single() > 0)
            {
                MessageBox.Show("使用中的代碼不能刪除.", "警告",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }    
        }
    }
}
