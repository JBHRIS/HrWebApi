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
    public partial class FRM63N1 : JBControls.JBForm
    {
        public FRM63N1()
        {
            InitializeComponent();
        }
        public int TW_TAX_Auto = -1;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM63N1", MainForm.COMPANY);
        private void buttonImportFromPayRoll_Click(object sender, EventArgs e)
        {
            FRM63N1_T frm = new FRM63N1_T();
            frm.TW_TAX_Auto = TW_TAX_Auto;
            frm.ShowDialog();
        }
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

        private void buttonImportFromFile_Click(object sender, EventArgs e)
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
            frm.Text = "各類所得批次匯入";
            frm.Allow_MatchField = true;
            frm.TemplateButtonVisible = true;
            //frm.AutoMatchMode = true;

            frm.FieldForm = new FRM63N1_IMPORT();
            var import = new TwYearTaxImport();
            import.TW_TAX_AUTO = this.TW_TAX_Auto;
            frm.DataTransfer = import;
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();

            frm.DataTransfer.CheckData.Add("員工編號", db.TBASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("所得格式", db.YRFORMAT.Where(p => new string[] { "91", "92" }.Contains(p.M_FORMAT)).Select(p => new JBControls.CheckImportData { DisplayCode = p.M_FORMAT, RealCode = p.M_FORMAT, DisplayName = p.M_FMT_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("公司", db.COMP.Select(p => new JBControls.CheckImportData { DisplayCode = p.COMP1, RealCode = p.COMP1, DisplayName = p.COMPNAME }).ToList());
            frm.DataTransfer.CheckData.Add("所得註記FULL", db.TW_TAX_SUBCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.M_FORSUB, RealCode = p.AUTO.ToString(), DisplayName = p.M_SUB_NAME, CheckValue1 = p.M_FORMAT }).ToList());
            if (Note1Enable && Note1Type == "COMBOBOX" && !string.IsNullOrEmpty(Note1DataSource))
                frm.DataTransfer.CheckData.Add(Note1Label, (GetDataSource(db, Note1DataSource, true) as DataTable).AsEnumerable().Select(p => new JBControls.CheckImportData { DisplayCode = p.Field<string>(2), RealCode = p.Field<string>(0), DisplayName = p.Field<string>(3) }).ToList());
            if (Note2Enable && Note2Type == "COMBOBOX" && !string.IsNullOrEmpty(Note2DataSource))
                frm.DataTransfer.CheckData.Add(Note2Label, (GetDataSource(db, Note2DataSource, true) as DataTable).AsEnumerable().Select(p => new JBControls.CheckImportData { DisplayCode = p.Field<string>(2), RealCode = p.Field<string>(0), DisplayName = p.Field<string>(3) }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("公司", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            //frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得格式", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("給付總額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扣繳稅額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("補充保費", typeof(decimal?));
            frm.DataTransfer.ColumnList.Add("自提退休金", typeof(decimal?));
            frm.DataTransfer.ColumnList.Add("已申報", typeof(string));
            frm.DataTransfer.ColumnList.Add("稅籍編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("所得註記");
            frm.DataTransfer.UnMustColumnList.Add("備註");

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

        private void buttonIsFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否要將所選擇的{0}筆所得資料設定為已申報", jbQuery1.SelectKeys.Count()), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var it in jbQuery1.SelectKeys)
                {
                    try
                    {
                        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                        var instance = db.TW_TAX_ITEM.Where(p => p.AUTO == Convert.ToInt32(it)).FirstOrDefault();
                        if (instance != null)
                            instance.IS_FILE = true;
                        db.SubmitChanges();
                    }
                    catch { }
                }
                MessageBox.Show("完成");
                jbQuery1.Query();
            }
        }

        private void buttonIsNotFile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否要將所選擇的{0}筆所得資料設定為未申報", jbQuery1.SelectKeys.Count()), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var it in jbQuery1.SelectKeys)
                {
                    try
                    {
                        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                        var instance = db.TW_TAX_ITEM.SingleOrDefault(p => p.AUTO == Convert.ToInt32(it));
                        if (instance != null)
                            instance.IS_FILE = false;
                        db.SubmitChanges();
                    }
                    catch { }
                }
                MessageBox.Show("完成");
                jbQuery1.Query();
            }
        }

        private void FRM63N1_Load(object sender, EventArgs e)
        {
            jbQuery1.Parameters.Add("TW_TAX_AUTO", TW_TAX_Auto.ToString());

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
            acg.CheckParameterAndSetDefault("FRM63N1_ADD_CloseOnSave", "存檔後是否關閉頁面", "True", "FRM63N1_ADD當存檔後是否要關閉視窗", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");


            Sys.SysDS.U_USERDataTable u_loignDataTable = new JBHR.Sys.SysDS.U_USERDataTable();
            Sys.SysDS.U_PRGIDDataTable U_PRGIDDataTable = new JBHR.Sys.SysDS.U_PRGIDDataTable();
            string USERID = MainForm.USER_ID;
            bool ADMIN = MainForm.ADMIN;
            bool SUPER = u_loignDataTable.Count > 0 ? u_loignDataTable[0].SUPER : false;
            bool SYSTEMRULE = MainForm.SYSTEMRULE;
            DataRow row = U_PRGIDDataTable.FindByUSER_IDPROGSYSTEM(USERID, "FRM4I", "JBHR");
            buttonImportFromPayRoll.Visible = false;
            if (row != null)
                buttonImportFromPayRoll.Visible = true;
            if (USERID == "JBADMIN" || ADMIN || SUPER || SYSTEMRULE)
                buttonImportFromPayRoll.Visible = true;
        }

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM63N1_ADD frm = new FRM63N1_ADD();
            frm.TW_TAX_AUTO = TW_TAX_Auto;
            frm.Text = "FRM63N1-新增";
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK)
            //    jbQuery1.Query();
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM63N1_ADD frm = new FRM63N1_ADD();
            frm.TW_TAX_AUTO = TW_TAX_Auto;
            frm.Text = "FRM63N1-修改";
            frm.TW_TAX_ITEM_AUTO = Convert.ToInt32(jbQuery1.SelectedKey);
            frm.ShowDialog();
            //if (frm.ShowDialog() == DialogResult.OK)
            //    jbQuery1.Query();
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            var instance = db.TW_TAX_ITEM.SingleOrDefault(p => p.AUTO == Convert.ToInt32(e.PrimaryKey));
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AUTO);
            db.ExecuteCommand("DELETE TW_TAX_ITEM WHERE AUTO={0}", e.PrimaryKey);
        }
        public static string GetDefaultBinding(JBModule.Data.Linq.HrDBDataContext db, string conf, string nobr) //Dictionary<string, string>
        {
            var cmd = db.Connection.CreateCommand();
            string outstring = string.Empty;
            if (!string.IsNullOrEmpty(conf))
            {
                cmd.CommandText = conf;
                System.Data.SqlClient.SqlParameter sp = new System.Data.SqlClient.SqlParameter();
                sp.ParameterName = "userid";
                sp.Value = MainForm.USER_ID;
                cmd.Parameters.Add(sp);
                sp = new System.Data.SqlClient.SqlParameter();
                sp.ParameterName = "comp";
                sp.Value = MainForm.COMPANY;
                cmd.Parameters.Add(sp);
                sp = new System.Data.SqlClient.SqlParameter();
                sp.ParameterName = "admin";
                sp.Value = MainForm.ADMIN;
                cmd.Parameters.Add(sp);
                sp = new System.Data.SqlClient.SqlParameter();
                sp.ParameterName = "nobr";
                sp.Value = nobr;
                cmd.Parameters.Add(sp);
                if (string.IsNullOrEmpty(nobr))
                    return outstring;

                if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                db.Connection.Close();
                outstring = dt.AsEnumerable().Select(p => p.Field<string>(0)).FirstOrDefault();
                if (outstring == null)
                    outstring = string.Empty;
            }
            return outstring;
        }
        public static object GetDataSource(JBModule.Data.Linq.HrDBDataContext db, string conf, bool import = false) //Dictionary<string, string>
        {
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = conf;
            System.Data.SqlClient.SqlParameter sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "userid";
            sp.Value = MainForm.USER_ID;
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "comp";
            sp.Value = MainForm.COMPANY;
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "admin";
            sp.Value = MainForm.ADMIN;
            cmd.Parameters.Add(sp);
            if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            db.Connection.Close();
            if (import)
                return dt;
            else
                return dt.AsEnumerable().ToDictionary(p => p.Field<string>(0), p => p.Field<string>(1));
        }
    }
    public class TwYearTaxImport : JBControls.ImportTransfer
    {
        public int TW_TAX_AUTO = -1;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM63N1", MainForm.COMPANY);
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";

            foreach (DataColumn dc in TargetRow.Table.Columns)
            {
                if (SourceRow.Table.Columns.Contains(dc.ColumnName))
                    TargetRow[dc.ColumnName] = SourceRow[dc.ColumnName];
            }

            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            string Note1Label = acg.GetConfig("Note1Label").Value;
            string Note2Label = acg.GetConfig("Note2Label").Value;
            string Note1Type = acg.GetConfig("Note1Type").Value.ToUpper();
            string Note2Type = acg.GetConfig("Note2Type").Value.ToUpper();

            if (Note1Enable && Note1Type == "COMBOBOX" && CheckData.ContainsKey(Note1Label) && CheckData[Note1Label].Count > 0)
            {
                if (ColumnValidate(TargetRow, Note1Label, TransferCheckDataField.RealCode, out Msg))
                {
                    TargetRow[Note1Label] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += Msg;
                    }
                }
            }
            if (Note2Enable && Note2Type == "COMBOBOX" && CheckData.ContainsKey(Note2Label) && CheckData[Note2Label].Count > 0)
            {
                if (ColumnValidate(TargetRow, Note2Label, TransferCheckDataField.RealCode, out Msg))
                {
                    TargetRow[Note2Label] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += Msg;
                    }
                }
            }

            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["員工編號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            if (ColumnValidate(TargetRow, "所得格式", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["所得格式"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            if (ColumnValidate(TargetRow, "公司", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["公司"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            var CheckFormatSub = CheckData["所得註記FULL"].Where(p => p.CheckValue1.Trim() == TargetRow["所得格式"].ToString().Trim());
            if (CheckFormatSub.Any())//完全沒有就不檢查
            {
                var CheckError = CheckFormatSub.Where(p => p.DisplayCode.Trim() == TargetRow["所得註記"].ToString().Trim());
                if (!CheckError.Any())
                {
                    CheckError = CheckFormatSub.Where(p => p.DisplayName.Trim() == TargetRow["所得註記"].ToString().Trim());
                    if (!CheckError.Any())
                        SetError(TargetRow, "錯誤的所得註記(" + TargetRow["所得註記"].ToString() + ")");
                }
            }
            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            return InsertTwYearTax(TransferRow, RepeatSelectionString, out ErrorMsg);
        }

        private bool InsertTwYearTax(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            try
            {
                JBModule.Data.Linq.TW_TAX_ITEM item = new JBModule.Data.Linq.TW_TAX_ITEM();

                bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
                bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
                string Note1Label = acg.GetConfig("Note1Label").Value;
                string Note2Label = acg.GetConfig("Note2Label").Value;
                if (Note1Enable)
                    item.Note1 = TransferRow.Table.Columns.Contains(Note1Label) ? TransferRow[Note1Label].ToString() : string.Empty;
                if (Note2Enable)
                    item.Note2 = TransferRow.Table.Columns.Contains(Note2Label) ? TransferRow[Note2Label].ToString() : string.Empty;

                item.NOBR = TransferRow["員工編號"].ToString();
                item.YYMM = TransferRow["所得年月"].ToString();
                item.SEQ = TransferRow["期別"].ToString();
                item.FORMAT = TransferRow["所得格式"].ToString();
                item.AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["給付總額"]));
                item.D_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["扣繳稅額"]));
                if (TransferRow.Table.Columns.Contains("補充保費") && TransferRow["補充保費"] != DBNull.Value)
                    item.SUP_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["補充保費"]));
                else item.SUP_AMT = 10;
                if (TransferRow.Table.Columns.Contains("自提退休金") && TransferRow["自提退休金"] != DBNull.Value)
                    item.RET_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["自提退休金"]));
                else item.RET_AMT = 10;
                item.SAL_CODE = "檔案匯入";
                var CheckFormatSub = CheckData["所得註記FULL"].Where(p => p.CheckValue1.Trim() == TransferRow["所得格式"].ToString().Trim());
                if (CheckFormatSub.Any())//完全沒有就不檢查
                {
                    var CheckError = CheckFormatSub.Where(p => p.DisplayCode.Trim() == TransferRow["所得註記"].ToString().Trim());
                    if (!CheckError.Any())
                    {
                        CheckError = CheckFormatSub.Where(p => p.DisplayName.Trim() == TransferRow["所得註記"].ToString().Trim());
                        if (!CheckError.Any())
                        {
                            SetError(TransferRow, "錯誤的所得註記(" + TransferRow["所得註記"].ToString() + ")");
                            return false;
                        }
                        else item.SUBCODE = Convert.ToInt32(CheckError.First().RealCode);
                    }
                    else item.SUBCODE = Convert.ToInt32(CheckError.First().RealCode);
                }
                else
                    item.SUBCODE = 0;
                item.TAXNO = TransferRow["稅籍編號"].ToString();
                item.TR_TYPE = "";
                item.COMP = TransferRow["公司"].ToString();
                item.INA_ID = "";
                item.FORSUB = "";
                item.IMPORT = true;
                item.IS_FILE = TransferRow["已申報"].ToString().Trim() == "Y";
                item.KEY_DATE = DateTime.Now;
                item.KEY_MAN = MainForm.USER_NAME;
                item.MEMO = TransferRow["備註"].ToString();
                item.PID = TW_TAX_AUTO;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                db.TW_TAX_ITEM.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }
}
