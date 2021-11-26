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
    public partial class FRM2M_CaseSetting : JBControls.JBForm
    {
        public FRM2M_CaseSetting()
        {
            InitializeComponent();
        }
        public string MealGroup { get; set; }
        CheckControl cc = new CheckControl();
        private void FRM2M_CaseSetting_Load(object sender, EventArgs e)
        {
            cc.AddControl(cbxMealType);
            this.mealCaseSettingTableAdapter.FillByMealGroup(this.dsAtt.MealCaseSetting, MealGroup);
            SystemFunction.SetComboBoxItems(cbxMealType, CodeFunction.GetMealType(MealGroup), true, false, true, true);
            fdc.DataAdapter = mealCaseSettingTableAdapter;

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
            var control = cc.CheckRequiredFields();
            if (control != null )
            {
                e.Cancel = true;
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return;
            }
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var OverLapAdd = db.MealCaseSetting.Where(p => p.MealGroup == MealGroup && p.MealSettingCode == txtCODE_DISP.Text);
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add && OverLapAdd.Any())
            {
                e.Cancel = true;
                MessageBox.Show("已存在相同代碼.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCODE_DISP.Focus();
                return;
            }
            string MealType = cbxMealType.SelectedValue.ToString();
            bool SwAttend = chkATTEND.Checked , SwApply = chkApply.Checked, SwOT = chKOT.Checked, SwEat = chKEAT.Checked;
            var OverLap = db.MealCaseSetting.Where(p => p.MealGroup == MealGroup && p.MealType == MealType && p.Attend == SwAttend && p.Apply == SwApply
                                                          && p.OT == SwOT && p.Eat == SwEat && p.MealSettingCode != e.Values["MealSettingCode"].ToString());
            if (OverLap.Any())
            {
                e.Cancel = true;
                MessageBox.Show("已有相同案例設定.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                e.Values["MealGroup"] = MealGroup;
            }
        }
        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void cbxMealType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.MealType
                      where a.MealType_Code == cbxMealType.SelectedValue.ToString() && a.MealGroup == MealGroup
                      select a;
            if (sql.Any())
            {
                txtBTime.Text = sql.First().BTime;
                txtETime.Text = sql.First().ETime;
            }
        }
    }
}
