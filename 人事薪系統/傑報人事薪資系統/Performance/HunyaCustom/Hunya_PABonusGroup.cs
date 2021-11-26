using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PABonusGroup : JBControls.JBForm
    {
        public Hunya_PABonusGroup()
        {
            InitializeComponent();
        }
        private void Hunya_PABonusGroup_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_Performance.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.hunya_Performance.V_BASE);
            this.hunya_PAGroupCodeTableAdapter.Fill(this.hunya_Performance.Hunya_PAGroupCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
        }

        private void JQPABonusData_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            Hunya_PABonusGroup_ADD frm = new Hunya_PABonusGroup_ADD();
            frm.ShowDialog();
        }

        private void JQPABonusGroup_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            Hunya_PABonusGroup_ADD frm = new Hunya_PABonusGroup_ADD();
            Dictionary<string, object> values = JQPABonusGroup.SelectedKey as Dictionary<string, object>;
            frm.Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            frm.EmployeeID = values["員工編號"] == System.DBNull.Value ? string.Empty : values["員工編號"].ToString();
            frm.ShowDialog();
        }

        private void JQPABonusGroup_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = e.PrimaryKey as Dictionary<string, object>;
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_PABonusGroup.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            if (instance != null)
            {
                if (!Sal.Function.CanModify(instance.EmployeeID))
                {
                    MessageBox.Show(string.Format("你沒有刪除{0}資料的權限", instance.EmployeeID), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_PABonusGroup.DeleteOnSubmit(instance);
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

            frm.Text = "績效獎金群組資料批次匯入";
            frm.FieldForm = new Hunya_PABonusGroup_Import();
            Hunya_PABonusGroup_Import.Hunya_PABonusGroup_ImportData HPBG_ImportData = new Hunya_PABonusGroup_Import.Hunya_PABonusGroup_ImportData();
            frm.DataTransfer = HPBG_ImportData;

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.hunya_Performance.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("績效獎金群組", this.hunya_Performance.Hunya_PAGroupCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.PAGroupCode_Disp, RealCode = p.PAGroupCode, DisplayName = p.PAGroupCode_Name }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核年月起", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核年月迄", typeof(string));
            frm.DataTransfer.ColumnList.Add("績效獎金群組", typeof(string));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("員工姓名");
            frm.ShowDialog();
        }
    }
}
