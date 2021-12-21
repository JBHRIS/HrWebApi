using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.AnnualBonus.HunyaCustom
{
    public partial class Hunya_ABPersonalAppraisal_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_ABPersonalAppraisal_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxEmployeeID);
            BindingControls.Add(cbxEmployeeName);
            BindingControls.Add(cbxYYYY);
            BindingControls.Add(cbxABTypeCode);
            BindingControls.Add(cbxABScore);
            BindingControls.Add(cbxABLevelCode);
        }

        private void Hunya_ABPersonalAppraisal_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEmployeeID);
            cc.AddControl(cbxYYYY);
            cc.AddControl(cbxABTypeCode);
            cc.AddControl(cbxABScore);
            cc.AddControl(cbxABLevelCode);
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

        public class Hunya_ABPersonalAppraisal_ImportData : JBControls.ImportTransfer
        {
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

                if (!int.TryParse(TargetRow["考績年度"].ToString(), out int YYYY) && !(YYYY >= 1753 && YYYY <= 9998))
                    TargetRow["錯誤註記"] += "考績年度非正確西元年格式(1753-9998).";

                if (ColumnValidate(TargetRow, "考績種類", TransferCheckDataField.DisplayName, out Msg))
                    TargetRow["考績種類"] = Msg;

                if (ColumnValidate(TargetRow, "考績等第", TransferCheckDataField.DisplayCode, out Msg))
                    TargetRow["考績等第"] = Msg;

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
                    ColumnValidate(TransferRow, "考績種類", TransferCheckDataField.RealCode, out string ABTypeCode);
                    decimal ABSocre = decimal.Parse(TransferRow["考績分數"].ToString());
                    ColumnValidate(TransferRow, "考績等第", TransferCheckDataField.RealCode, out string ABLevelCode);
                    Guid GID = Guid.NewGuid();

                    Repository.Hunya_ABPersonalAppraisalDto Hunya_ABPersonalAppraisalDto = new Repository.Hunya_ABPersonalAppraisalDto
                    {
                        EmployeeID = EmployeeID,
                        YYYY = YYYY,
                        ABTypeCode = ABTypeCode,
                        ABSocre = ABSocre,
                        ABLevelCode = ABLevelCode,
                        GID = Guid.NewGuid(),
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_ABPersonalAppraisalRepo Hunya_ABPersonalAppraisalRepo = new Repository.Hunya_ABPersonalAppraisalRepo();
                    var OverlapHunya_ABPersonalAppraisal = Hunya_ABPersonalAppraisalRepo.GetOverlapHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto);
                    bool Changed = false;
                    if (OverlapHunya_ABPersonalAppraisal.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Changed = Hunya_ABPersonalAppraisalRepo.DeleteHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Changed = Hunya_ABPersonalAppraisalRepo.UpdateHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的個人年度考績資料.";
                            return false;
                        }
                    }
                    else
                        Changed = Hunya_ABPersonalAppraisalRepo.InsertHunya_ABPersonalAppraisal(Hunya_ABPersonalAppraisalDto, out ErrorMsg);

                    if (Changed)
                    {
                        Repository.Hunya_ABPersonalBonusDto Hunya_ABPersonalBonusDto = new Repository.Hunya_ABPersonalBonusDto
                        {
                            EmployeeID = EmployeeID,
                            YYYY = YYYY,
                        };
                        Repository.Hunya_ABPersonalBonusRepo Hunya_ABPersonalBonusRepo = new Repository.Hunya_ABPersonalBonusRepo();
                        var OverlapHunya_ABPersonalBonus = Hunya_ABPersonalBonusRepo.GetOverlapHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto);
                        if (OverlapHunya_ABPersonalBonus.Count > 0)
                            Hunya_ABPersonalBonusRepo.DeleteHunya_ABPersonalBonus(Hunya_ABPersonalBonusDto, out ErrorMsg);
                    }

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
