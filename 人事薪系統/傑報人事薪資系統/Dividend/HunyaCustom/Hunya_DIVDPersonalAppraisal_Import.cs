using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Dividend.HunyaCustom
{
    public partial class Hunya_DIVDPersonalAppraisal_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_DIVDPersonalAppraisal_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxEmployeeID);
            BindingControls.Add(cbxEmployeeName);
            BindingControls.Add(cbxYYYY);
            BindingControls.Add(cbxDIVDAppraisalCode);
        }

        private void Hunya_DIVDPersonalAppraisal_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEmployeeID);
            cc.AddControl(cbxYYYY);
            cc.AddControl(cbxDIVDAppraisalCode);
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

        public class Hunya_DIVDPersonalAppraisal_ImportData : JBControls.ImportTransfer
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
                    //string DIVDAppraisalCode = string.Empty;
                    ColumnValidate(TransferRow, "考績等第", TransferCheckDataField.RealCode, out string DIVDAppraisalCode);

                    Repository.Hunya_DIVDPersonalAppraisalDto Hunya_DIVDPersonalAppraisalDto = new Repository.Hunya_DIVDPersonalAppraisalDto
                    {
                        EmployeeID = EmployeeID,
                        YYYY = YYYY,
                        DIVDAppraisalCode = DIVDAppraisalCode,
                        GID = Guid.NewGuid(),
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_DIVDPersonalAppraisalRepo Hunya_DIVDPersonalAppraisalRepo = new Repository.Hunya_DIVDPersonalAppraisalRepo();
                    var OverlapHunya_DIVDPersonalAppraisal = Hunya_DIVDPersonalAppraisalRepo.GetOverlapHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto);
                    if (OverlapHunya_DIVDPersonalAppraisal.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Hunya_DIVDPersonalAppraisalRepo.DeleteHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Hunya_DIVDPersonalAppraisalRepo.UpdateHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的個人年度考績資料.";
                            return false;
                        }
                    }
                    else
                        Hunya_DIVDPersonalAppraisalRepo.InsertHunya_DIVDPersonalAppraisal(Hunya_DIVDPersonalAppraisalDto, out ErrorMsg);
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
