using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JBModule.Data.Dto;
using JBModule.Data.Linq;
using System.Linq;
using JBModule.Data.Repo;

namespace JBHR.Bas
{
    public partial class FRM18_UserDF_Import : JBControls.U_FIELD
    {
        public FRM18_UserDF_Import()
        {
            InitializeComponent();
        }

        private void FRM18_UserDF_Import_Load(object sender, EventArgs e)
        {

        }
    }


    public class ImportUserDefineData : JBControls.ImportTransfer
    {
        //public UserDefineGroup UDFG { set; get; } = new UserDefineGroup();
        public List<UserDefineLayout> UDFL { set; get; } = new List<UserDefineLayout>();
        //public UserDefineSource UDFS { set; get; } = new UserDefineSource();
        //public UserDefineValue UDFV { set; get; } = new UserDefineValue();

        public Dictionary<string, Guid> ColumnForControlID = new Dictionary<string, Guid>();
        string ErrMsg = string.Empty;
        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            HrDBDataContext db = new HrDBDataContext();

            try
            {
                string Nobr = TransferRow["員工編號"].ToString();
                List<UserDefineDto> userDefineDtoList = new List<UserDefineDto>();
                foreach (var column in ColumnList)
                {
                    if (TransferRow.Table.Columns.Contains(column.Key) && ColumnForControlID.ContainsKey(column.Key))
                    {
                        var control = UDFL.Where(p => p.ControlID.Equals(ColumnForControlID[column.Key])).First();
                        string sourceID = CodeFunction.GetUDFControlTagPropByID(control.ControlID, "SourceID");

                        UserDefineDto userDefineDto = new UserDefineDto()
                        {
                            Code = Nobr,
                            ControlID = control.ControlID,
                            SourceID = !string.IsNullOrEmpty(sourceID) ? Guid.Parse(sourceID) : (Guid?)null,
                            ValueTYPE = control.Type,
                            Value = TransferRow[column.Key].ToString(),
                            Key_Date = DateTime.Now,
                            Key_Man = MainForm.USER_ID
                        };

                        userDefineDtoList.Add(userDefineDto);
                    }
                }
                UserDefineRepo userDefineRepo = new UserDefineRepo();
                var OverlapUserDefine = userDefineRepo.GetOverlapUserDefine(userDefineDtoList);
                if (OverlapUserDefine != null && OverlapUserDefine.Count > 0)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        userDefineRepo.DeleteUserDefine(userDefineDtoList, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        userDefineRepo.UpdateUserDefine(userDefineDtoList, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的自定欄位資料";
                        return false;
                    }
                }
                else
                    userDefineRepo.InsertUserDefine(userDefineDtoList, out ErrMsg);
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            ErrorMsg = ErrMsg;
            return true;
        }

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            //SourceRow.Table.Columns.Add("錯誤註記");
            List<string> diffColumns = new List<string>(); 
            foreach (DataColumn item in TargetRow.Table.Columns)
            {
                if (!SourceRow.Table.Columns.Contains(item.ColumnName))
                    diffColumns.Add(item.ColumnName);
            }

            foreach (string item in diffColumns)
            {
                if (UnMustColumnList.Contains(item))
                    TargetRow.Table.Columns.Remove(item);
            }

            HrDBDataContext db = new HrDBDataContext();
            var decimalList = ColumnList.Where(p=>p.Value.Equals(typeof(decimal)));
            foreach (var item in decimalList)
            {
                Guid controlID = Guid.Parse(ColumnForControlID[item.Key].ToString());
                decimal Maximum = decimal.Parse(CodeFunction.GetUDFControlTagPropByID(controlID, "Maximum"));
                decimal Minimum = decimal.Parse(CodeFunction.GetUDFControlTagPropByID(controlID, "Minimum"));
                decimal value = decimal.TryParse(SourceRow[item.Key].ToString(), out value) ? value : 0;
                if (value > Maximum || value < Minimum)
                {
                    TargetRow["錯誤註記"] = string.Format("{0}超出{1}到{2}的範圍", item.Key, Minimum.ToString(), Maximum.ToString());
                }
            }

            if (string.IsNullOrEmpty(TargetRow["錯誤註記"].ToString()))
                return true;
            else
                return false;
        }
    }
}
