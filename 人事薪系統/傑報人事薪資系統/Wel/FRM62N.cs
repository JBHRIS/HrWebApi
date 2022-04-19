using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
    public partial class FRM62N : JBControls.JBForm
    {
        public FRM62N()
        {
            InitializeComponent();
        }

        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM62N", MainForm.COMPANY);
        private void FRM62N_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            acg.CheckParameterAndSetDefault("Note1Enable", "啟用Note1控制項", "False", "開啟Note1控制項，提供使用者輸入", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            acg.CheckParameterAndSetDefault("Note1Label", "Note1的標題", "Note1", "設定顯示在Note1控制項前的標題", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("Note1Type", "Note1的型態", "String", "設定Note1的型態提供簡易檢核", "ComboBox", "select CODE,CODE+'-'+NAME from MTCODE where CATEGORY = 'ValidType'", "String");
            acg.CheckParameterAndSetDefault("Note1DefaultBinding", "Note1的預設值來源", "", "設定Note1預設值的資料來源(只接受單一值回傳:select top(1) value from table where IDcolumn = @nobr)", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("Note1DataSource", "Note1的資料來源", "", "設定Note1下拉選單的資料來源(需符合:select code,code + '-' +name,code_disp,name from table)", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("Note2Enable", "啟用Note2控制項", "False", "開啟Note2控制項，提供使用者輸入", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            acg.CheckParameterAndSetDefault("Note2Label", "Note2的標題", "Note2", "設定顯示在Note2控制項前的標題", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("Note2Type", "Note2的型態", "String", "設定Note2的型態提供簡易檢核", "ComboBox", "select CODE,CODE+'-'+NAME from MTCODE where CATEGORY = 'ValidType'", "String");
            acg.CheckParameterAndSetDefault("Note2DefaultBinding", "Note2的預設值來源", "", "設定Note2預設值的資料來源(只接受單一值回傳:select top(1) value from table where IDcolumn = @nobr)", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("Note2DataSource", "Note2的資料來源", "", "設定Note2下拉選單的資料來源(需符合:select code,code + '-' +name,code_disp,name from table)", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("FRM62N_ADD_CloseOnSave", "存檔後是否關閉頁面", "True", "FRM62N_ADD當存檔後是否要關閉視窗", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
        }
        private void jqWelf_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM62N_ADD frm = new FRM62N_ADD();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "FRM62N-新增";
            frm.ShowDialog();
        }

        private void jqWelf_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM62N_ADD frm = new FRM62N_ADD();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "FRM62N-修改";
            frm.Welf_ID = Convert.ToInt32(e.PrimaryKey);
            frm.ShowDialog();
        }

        private void jqWelf_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var instance = db.WELF.SingleOrDefault(p => p.AUTO == Convert.ToInt32(e.PrimaryKey));
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AUTO);
            db.ExecuteCommand("DELETE WELF WHERE AUTO={0}", e.PrimaryKey);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            string Note1Label = acg.GetConfig("Note1Label").Value;
            string Note2Label = acg.GetConfig("Note2Label").Value;
            string Note1Type = acg.GetConfig("Note1Type").Value.ToUpper();
            string Note2Type = acg.GetConfig("Note2Type").Value.ToUpper();
            string Note1DataSource = acg.GetConfig("Note1DataSource").GetString("");
            string Note2DataSource = acg.GetConfig("Note2DataSource").GetString("");

            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            //frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.Text = "福利金批次匯入";
            frm.Allow_MatchField = true;
            frm.TemplateButtonVisible = true;
            //frm.AutoMatchMode = true;

            frm.FieldForm = new FRM62N_IMPORT();
            frm.DataTransfer = new WelfImport
            {
                CheckData = new Dictionary<string, List<JBControls.CheckImportData>>(),
                bASETTs = (from bts in db.BASETTS
                           where db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                           select bts).ToList(),
            };

            frm.DataTransfer.CheckData.Add("員工編號", db.TBASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("所得格式", db.YRFORMAT.Select(p => new JBControls.CheckImportData { DisplayCode = p.M_FORMAT, RealCode = p.M_FORMAT, DisplayName = p.M_FMT_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("福利金代號", db.WCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.W_CODE, RealCode = p.W_CODE, DisplayName = p.W_NAME }).ToList());
            if (Note1Enable && Note1Type == "COMBOBOX" && !string.IsNullOrEmpty(Note1DataSource))
                frm.DataTransfer.CheckData.Add(Note1Label, (Med.FRM71N1.GetDataSource(db, Note1DataSource, true) as DataTable).AsEnumerable().Select(p => new JBControls.CheckImportData { DisplayCode = p.Field<string>(2), RealCode = p.Field<string>(0), DisplayName = p.Field<string>(3) }).ToList());
            if (Note2Enable && Note2Type == "COMBOBOX" && !string.IsNullOrEmpty(Note2DataSource))
                frm.DataTransfer.CheckData.Add(Note2Label, (Med.FRM71N1.GetDataSource(db, Note2DataSource, true) as DataTable).AsEnumerable().Select(p => new JBControls.CheckImportData { DisplayCode = p.Field<string>(2), RealCode = p.Field<string>(0), DisplayName = p.Field<string>(3) }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            //frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得格式", typeof(string));
            frm.DataTransfer.ColumnList.Add("福利金代號", typeof(string));
            frm.DataTransfer.ColumnList.Add("給付總額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扣繳稅額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("福利金代號");
            if (Note1Enable)
            {
                frm.DataTransfer.ColumnList.Add(Note1Label, CodeFunction.GetTypeByValidType(Note1Type));
                frm.DataTransfer.UnMustColumnList.Add(Note1Label);
            }

            if (Note2Enable)
            {
                frm.DataTransfer.ColumnList.Add(Note2Label, CodeFunction.GetTypeByValidType(Note2Type));
                frm.DataTransfer.UnMustColumnList.Add(Note2Label);
            }

            frm.ShowDialog();
        }
    }
}
