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
    public partial class Hunya_ABPersonalBonus_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_ABPersonalBonus_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxEmployeeID);
            BindingControls.Add(cbxEmployeeName);
            BindingControls.Add(cbxYYYY);
            BindingControls.Add(cbxABScore);
            BindingControls.Add(cbxABLevelCode);
            BindingControls.Add(cbxABRealLevel);
        }

        private void Hunya_ABPersonalBonus_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEmployeeID);
            cc.AddControl(cbxYYYY);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        public class Hunya_ABPersonalBonus_ImportData : JBControls.ImportTransfer
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            public List<JBModule.Data.Linq.Hunya_ABLevelCode> hunya_ABLevelCodes = new List<JBModule.Data.Linq.Hunya_ABLevelCode>();
            public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
            {
                if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.RealCode, out string Msg))
                {
                    TargetRow["員工編號"] = Msg;
                    ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg);
                    if (!string.IsNullOrEmpty(TargetRow["員工姓名"].ToString()) && TargetRow["員工姓名"].ToString() != Msg)
                        TargetRow["警告註記"] += "匯入姓名與員工編號姓名不符.";
                }
                //else
                //{
                //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                //    {
                //        TargetRow["錯誤註記"] += Msg;
                //    }
                //}
                string EmployeeID = TargetRow["員工編號"].ToString();
                List<JBModule.Data.Linq.Hunya_ABYearEndAppraisal> HAYAList = new List<JBModule.Data.Linq.Hunya_ABYearEndAppraisal>(); 
                if (!int.TryParse(TargetRow["考績年度"].ToString(), out int YYYY) && !(YYYY >= 1753 && YYYY <=9998))
                    TargetRow["錯誤註記"] += "考績年度非正確西元年格式(1753-9998).";
                else
                    HAYAList = db.Hunya_ABYearEndAppraisal.Where(p => p.EmployeeID == EmployeeID && p.YYYY == YYYY).ToList();

                if (TargetRow["年度考績"] != null)
                {
                    if (!decimal.TryParse(TargetRow["年度考績"].ToString(), out decimal ABSocre))
                        TargetRow["錯誤註記"] += "年度考績非正確數字格式.";
                }
                else
                {
                    decimal ABSocre = 0;
                    ABSocre = HAYAList.Sum(p => p.ABScore) / HAYAList.Count;
                    TargetRow["年度考績"] = ABSocre;
                    TargetRow["警告註記"] += string.Format("年度考績由系統產生."); 
                }
                if (TargetRow["年度評等"] != null)
                {
                    if (ColumnValidate(TargetRow, "年度評等", TransferCheckDataField.DisplayCode, out Msg))
                        TargetRow["年度評等"] = Msg;
                    else
                        TargetRow["錯誤註記"] += string.Format("{0}.", Msg);
                }
                else
                {
                    if (hunya_ABLevelCodes.FirstOrDefault(p => p.ABLevelBonusRate <= 1.0M) != null)
                        TargetRow["年度評等"] = hunya_ABLevelCodes.First(p => p.ABLevelBonusRate <= 1.0M).ABLevelCode_DISP;
                    else if (hunya_ABLevelCodes.Count != 0)
                        TargetRow["年度評等"] = hunya_ABLevelCodes.First().ABLevelCode_DISP;
                    else
                        TargetRow["錯誤註記"] += string.Format("沒有考績等第設定.");
                }

                if (TargetRow["實際評等"] != null)
                {
                    if (ColumnValidate(TargetRow, "實際評等", TransferCheckDataField.DisplayCode, out Msg))
                        TargetRow["實際評等"] = Msg;
                    else
                        TargetRow["錯誤註記"] += string.Format("{0}.", Msg);
                }
                else
                    TargetRow["實際評等"] = TargetRow["年度評等"];

                if (string.IsNullOrWhiteSpace(TargetRow["錯誤註記"].ToString()))
                    return true;
                else
                    return false;
            }

            public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
            {
                ErrorMsg = "";
                try
                {
                    string EmployeeID = TransferRow["員工編號"].ToString();
                    int YYYY = int.Parse(TransferRow["考績年度"].ToString());
                    //string ABAppraisalCode = string.Empty;
                    ColumnValidate(TransferRow, "年度評等", TransferCheckDataField.RealCode, out string ABLevelCode);
                    decimal ABSocre = decimal.Parse(TransferRow["年度考績"].ToString());
                    ColumnValidate(TransferRow, "實際評等", TransferCheckDataField.RealCode, out string RealLevelCode);
                    Guid GID = Guid.NewGuid();

                    Repository.Hunya_ABYearEndAppraisalDto Hunya_ABYearEndAppraisalDto = new Repository.Hunya_ABYearEndAppraisalDto
                    {
                        EmployeeID = EmployeeID,
                        YYYY = YYYY,
                        ABSocre = ABSocre,
                        ABLevelCode = ABLevelCode,
                        RealLevelCode = RealLevelCode,
                        GID = Guid.NewGuid(),
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_ABYearEndAppraisalRepo Hunya_ABYearEndAppraisalRepo = new Repository.Hunya_ABYearEndAppraisalRepo();
                    var OverlapHunya_ABYearEndAppraisal = Hunya_ABYearEndAppraisalRepo.GetOverlapHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto);
                    if (OverlapHunya_ABYearEndAppraisal.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Hunya_ABYearEndAppraisalRepo.DeleteHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Hunya_ABYearEndAppraisalRepo.UpdateHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的年度平均考績資料.";
                            return false;
                        }
                    }
                    else
                        Hunya_ABYearEndAppraisalRepo.InsertHunya_ABYearEndAppraisal(Hunya_ABYearEndAppraisalDto, out ErrorMsg);
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
}
