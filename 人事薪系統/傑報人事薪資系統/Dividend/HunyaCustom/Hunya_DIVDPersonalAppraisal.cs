using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Dividend.HunyaCustom
{
    public partial class Hunya_DIVDPersonalAppraisal : JBControls.JBForm
    {
        public Hunya_DIVDPersonalAppraisal()
        {
            InitializeComponent();
        }

        private void Hunya_DIVDPersonalAppraisal_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_Dividend.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.hunya_Dividend.V_BASE);
            this.hunya_DIVDAppraisalCodeTableAdapter.Fill(this.hunya_Dividend.Hunya_DIVDAppraisalCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
        }

        private void JQDIVDPersonalAppraisal_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            Hunya_DIVDPersonalAppraisal_ADD frm = new Hunya_DIVDPersonalAppraisal_ADD();
            frm.ShowDialog();
        }

        private void JQDIVDPersonalAppraisal_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            Hunya_DIVDPersonalAppraisal_ADD frm = new Hunya_DIVDPersonalAppraisal_ADD();
            Dictionary<string, object> values = JQDIVDPersonalAppraisal.SelectedKey as Dictionary<string, object>;
            frm.Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            frm.EmployeeID = values["員工編號"] == System.DBNull.Value ? string.Empty : values["員工編號"].ToString();
            frm.ShowDialog();
        }

        private void JQDIVDPersonalAppraisal_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = e.PrimaryKey as Dictionary<string, object>;
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_DIVDPersonalAppraisal.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            if (instance != null)
            {
                if (!Sal.Function.CanModify(instance.EmployeeID))
                {
                    MessageBox.Show(string.Format("你沒有刪除{0}資料的權限", instance.EmployeeID), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_DIVDPersonalAppraisal.DeleteOnSubmit(instance);
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

            frm.Text = "個人績效考核資料批次匯入";
            frm.FieldForm = new Hunya_DIVDPersonalAppraisal_Import();
            Hunya_DIVDPersonalAppraisal_Import.Hunya_DIVDPersonalAppraisal_ImportData HPBG_ImportData = new Hunya_DIVDPersonalAppraisal_Import.Hunya_DIVDPersonalAppraisal_ImportData();
            frm.DataTransfer = HPBG_ImportData;

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.hunya_Dividend.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("考績等第", this.hunya_Dividend.Hunya_DIVDAppraisalCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.DIVDAppraisalCode_Disp, RealCode = p.DIVDAppraisalCode, DisplayName = p.DIVDAppraisalCode_Name }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("考績年度", typeof(string));
            frm.DataTransfer.ColumnList.Add("考績等第", typeof(string));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("員工姓名");
            frm.ShowDialog();
        }
    }
}
