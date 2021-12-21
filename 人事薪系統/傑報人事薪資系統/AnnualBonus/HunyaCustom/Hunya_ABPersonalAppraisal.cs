using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.AnnualBonus.HunyaCustom
{
    public partial class Hunya_ABPersonalAppraisal : JBControls.JBForm
    {
        public Hunya_ABPersonalAppraisal()
        {
            InitializeComponent();
        }
        private void Hunya_ABPersonalAppraisal_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_AnnualBonus.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.hunya_AnnualBonus.V_BASE);
            this.hunya_ABLevelCodeTableAdapter.Fill(this.hunya_AnnualBonus.Hunya_ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
        }

        private void JQABPersonalAppraisal_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            Hunya_ABPersonalAppraisal_ADD frm = new Hunya_ABPersonalAppraisal_ADD();
            frm.ShowDialog();
        }

        private void JQABPersonalAppraisal_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            Hunya_ABPersonalAppraisal_ADD frm = new Hunya_ABPersonalAppraisal_ADD();
            Dictionary<string, object> values = JQABPersonalAppraisal.SelectedKey as Dictionary<string, object>;
            frm.Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            frm.EmployeeID = values["員工編號"] == System.DBNull.Value ? string.Empty : values["員工編號"].ToString();
            frm.ShowDialog();
        }

        private void JQABPersonalAppraisal_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = e.PrimaryKey as Dictionary<string, object>;
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_ABPersonalAppraisal.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            if (instance != null)
            {
                if (!Sal.Function.CanModify(instance.EmployeeID))
                {
                    MessageBox.Show(string.Format("你沒有刪除{0}資料的權限", instance.EmployeeID), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_ABPersonalAppraisal.DeleteOnSubmit(instance);
                db.SubmitChanges();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.Text = "個人年度考績資料批次匯入";
            frm.FieldForm = new Hunya_ABPersonalAppraisal_Import();
            Hunya_ABPersonalAppraisal_Import.Hunya_ABPersonalAppraisal_ImportData HAPA_ImportData = new Hunya_ABPersonalAppraisal_Import.Hunya_ABPersonalAppraisal_ImportData();
            frm.DataTransfer = HAPA_ImportData;

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.hunya_AnnualBonus.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("考績種類", CodeFunction.GetHunya_ABTypeCode(false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());
            frm.DataTransfer.CheckData.Add("考績等第", this.hunya_AnnualBonus.Hunya_ABLevelCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.ABLevelCode_DISP, RealCode = p.ABLevelCode, DisplayName = p.ABLevelCode_Name }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("考績年度", typeof(int));
            frm.DataTransfer.ColumnList.Add("考績種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("考績分數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("考績等第", typeof(string));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("員工姓名");
            frm.ShowDialog();
        }
    }
}
