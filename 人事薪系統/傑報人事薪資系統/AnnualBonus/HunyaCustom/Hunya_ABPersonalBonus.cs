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
    public partial class Hunya_ABPersonalBonus : JBControls.JBForm
    {
        public Hunya_ABPersonalBonus()
        {
            InitializeComponent();
        }
        JBModule.Data.ApplicationConfigSettings acg = null;
        private void Hunya_ABPersonalBonus_Load(object sender, EventArgs e)
        {
            this.v_BASETableAdapter.Fill(this.hunya_AnnualBonus.V_BASE);
            this.hunya_ABLevelCodeTableAdapter.Fill(this.hunya_AnnualBonus.Hunya_ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            acg = null; acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("ABFault1", "大過扣發天數", "10"
               , "指定大過年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABFault2", "小過扣發天數", "3"
               , "指定小過年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABFault3", "申誡扣發天數", "1"
               , "指定警告年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABAward1", "大功加發天數", "10"
               , "指定大功年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABAward2", "小功加發天數", "3"
               , "指定小功年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABAward3", "嘉獎加發天數", "1"
               , "指定嘉獎年終獎金扣發天數", "TextBox", "", "Decimal");
            acg.CheckParameterAndSetDefault("ABEMPCD", "正式職代碼", "01"
               , "指定正式職代碼，以「,」做分隔。", "TextBox", "", "String");
            SystemFunction.CheckAppConfigRule(btnConfig);
        }

        private void JQABPersonalBonus_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.Text = "個人年度考績資料批次匯入";
            frm.FieldForm = new Hunya_ABPersonalBonus_Import();
            Hunya_ABPersonalBonus_Import.Hunya_ABPersonalBonus_ImportData HAPA_ImportData = new Hunya_ABPersonalBonus_Import.Hunya_ABPersonalBonus_ImportData();
            HAPA_ImportData.hunya_ABLevelCodes = db.Hunya_ABLevelCode.Where(p => db.GetCodeFilter("Hunya_ABLevelCode", p.ABLevelCode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).OrderByDescending(p => p.ABLevelBonusRate).ToList();
            frm.DataTransfer = HAPA_ImportData;
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.hunya_AnnualBonus.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("年度評等", this.hunya_AnnualBonus.Hunya_ABLevelCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.ABLevelCode_DISP, RealCode = p.ABLevelCode, DisplayName = p.ABLevelCode_Name }).ToList());
            frm.DataTransfer.CheckData.Add("實際評等", this.hunya_AnnualBonus.Hunya_ABLevelCode.Select(p => new JBControls.CheckImportData { DisplayCode = p.ABLevelCode_DISP, RealCode = p.ABLevelCode, DisplayName = p.ABLevelCode_Name }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("考績年度", typeof(int));
            frm.DataTransfer.ColumnList.Add("年度考績", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("年度評等", typeof(string));
            frm.DataTransfer.ColumnList.Add("實際評等", typeof(string));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("員工姓名");
            frm.DataTransfer.UnMustColumnList.Add("年度考績");
            frm.DataTransfer.UnMustColumnList.Add("年度評等");
            frm.DataTransfer.UnMustColumnList.Add("實際評等");
            frm.ShowDialog();
        }

        private void JQABPersonalBonus_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {

        }

        private void JQABPersonalBonus_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Dictionary<string, object> values = e.PrimaryKey as Dictionary<string, object>;
            int Autokey = values["AK"] == System.DBNull.Value ? -1 : int.Parse(values["AK"].ToString());
            var instance = db.Hunya_ABYearEndAppraisal.SingleOrDefault(p => p.AK == Convert.ToInt32(Autokey));
            if (instance != null)
            {
                if (!Sal.Function.CanModify(instance.EmployeeID))
                {
                    MessageBox.Show(string.Format("你沒有刪除{0}資料的權限", instance.EmployeeID), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AK);
                db.Hunya_ABYearEndAppraisal.DeleteOnSubmit(instance);

                var instance1 = db.Hunya_ABPersonalBonus.SingleOrDefault(p => p.EmployeeID == instance.EmployeeID && p.YYYY == instance.YYYY);
                if (instance1 != null)
                {
                    JBModule.Message.DbLog.WriteLog("Delete", instance1, this.Name, instance1.AK);
                    db.Hunya_ABPersonalBonus.DeleteOnSubmit(instance1);
                }

                db.SubmitChanges();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Hunya_ABPersonalBonus_Calculator frm = new Hunya_ABPersonalBonus_Calculator();
            frm.ShowDialog();
        }
    }
}
