using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PAPersonalAssessment_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_PAPersonalAssessment_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxEmployeeID);
            BindingControls.Add(cbxEmployeeName);
            BindingControls.Add(cbxYYMM);
            BindingControls.Add(cbxPALevelCode);
        }

        private void Hunya_PAPersonalAssessment_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEmployeeID);
            cc.AddControl(cbxYYMM);
            cc.AddControl(cbxPALevelCode);
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

        public class Hunya_PAPersonalAssessment_ImportData : JBControls.ImportTransfer
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

                if (ColumnValidate(TargetRow, "考核等級", TransferCheckDataField.DisplayCode, out Msg))
                {
                    TargetRow["考核等級"] = Msg;
                }
                //else
                //{
                //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                //    {
                //        TargetRow["錯誤註記"] += Msg;
                //    }
                //}

                return true;
            }

            public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
            {
                ErrorMsg = "";
                try
                {
                    string EmployeeID = TransferRow["員工編號"].ToString();
                    string YYMM = TransferRow["考核年月"].ToString();
                    //string PALevelCode = string.Empty;
                    ColumnValidate(TransferRow, "考核等級", TransferCheckDataField.RealCode, out string PALevelCode);
                    Guid GID = Guid.NewGuid();

                    Repository.Hunya_PAPersonalAssessmentDto Hunya_PAPersonalAssessmentDto = new Repository.Hunya_PAPersonalAssessmentDto
                    {
                        EmployeeID = EmployeeID,
                        YYMM = YYMM,
                        PALevelCode = PALevelCode,
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_PAPersonalAssessmentRepo Hunya_PAPersonalAssessmentRepo = new Repository.Hunya_PAPersonalAssessmentRepo();
                    var OverlapHunya_PAPersonalAssessment = Hunya_PAPersonalAssessmentRepo.GetOverlapHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto);
                    if (OverlapHunya_PAPersonalAssessment.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Hunya_PAPersonalAssessmentRepo.DeleteHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Hunya_PAPersonalAssessmentRepo.UpdateHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的個人績效考核資料.";
                            return false;
                        }
                    }
                    else
                        Hunya_PAPersonalAssessmentRepo.InsertHunya_PAPersonalAssessment(Hunya_PAPersonalAssessmentDto, out ErrorMsg);
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
