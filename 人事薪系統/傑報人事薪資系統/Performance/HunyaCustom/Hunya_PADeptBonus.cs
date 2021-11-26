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
    public partial class Hunya_PADeptBonus : JBControls.JBForm
    {
        public Hunya_PADeptBonus()
        {
            InitializeComponent();
        }

        private void Hunya_PADeptBonus_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_Performance.Dept' 資料表。您可以視需要進行移動或移除。
            this.dEPTTableAdapter.Fill(this.hunya_Performance.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
        }

        private void JQPADeptBonus_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            Hunya_PADeptBonus_ADD frm = new Hunya_PADeptBonus_ADD();
            frm.ShowDialog();
        }

        private void JQPADeptBonus_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            Hunya_PADeptBonus_ADD frm = new Hunya_PADeptBonus_ADD();
            Dictionary<string, object> values = (JQPADeptBonus.SelectedKey as Dictionary<string, object>);
            frm.Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            frm.D_NO = values["部門實際代碼"] == System.DBNull.Value ? string.Empty : values["部門實際代碼"].ToString();
            frm.ShowDialog();
        }

        private void JQPADeptBonus_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = (e.PrimaryKey as Dictionary<string, object>);
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_PADeptBonus.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            //if (!Sal.Function.CanModify(instance.EmployeeId))
            //{
            //    MessageBox.Show("你沒有刪除該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (instance != null)
            {
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_PADeptBonus.DeleteOnSubmit(instance);
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

            frm.Text = "部門獎金分配權數批次匯入";
            frm.FieldForm = new Hunya_PADeptBonus_Import();
            Hunya_PADeptBonus_Import.Hunya_PADeptBonus_ImportData HPBG_ImportData = new Hunya_PADeptBonus_Import.Hunya_PADeptBonus_ImportData();
            frm.DataTransfer = HPBG_ImportData;

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("部門代碼", this.hunya_Performance.DEPT.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("部門代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核年月起", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核年月迄", typeof(string));
            frm.DataTransfer.ColumnList.Add("基本獎金", typeof(string));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("部門名稱");
            frm.ShowDialog();
        }
    }
}
