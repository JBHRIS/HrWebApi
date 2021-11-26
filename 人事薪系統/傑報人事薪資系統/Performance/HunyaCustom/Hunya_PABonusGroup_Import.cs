using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PABonusGroup_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_PABonusGroup_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxEmployeeID);
            BindingControls.Add(cbxEmployeeName);
            BindingControls.Add(cbxYYMM_B);
            BindingControls.Add(cbxYYMM_E);
            BindingControls.Add(cbxPAGroupCode);
        }

        private void Hunya_PABonusGroup_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEmployeeID);
            cc.AddControl(cbxYYMM_B);
            cc.AddControl(cbxYYMM_E);
            cc.AddControl(cbxPAGroupCode);
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

        public class Hunya_PABonusGroup_ImportData : JBControls.ImportTransfer
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

                if (ColumnValidate(TargetRow, "績效獎金群組", TransferCheckDataField.DisplayCode, out Msg))
                {
                    TargetRow["績效獎金群組"] = Msg;
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
                    string YYMM_B = TransferRow["考核年月起"].ToString();
                    string YYMM_E = TransferRow["考核年月迄"].ToString();
                    //string PAGroupCode = string.Empty;
                    ColumnValidate(TransferRow, "績效獎金群組", TransferCheckDataField.RealCode, out string PAGroupCode);
                    Guid GID = Guid.NewGuid();

                    Repository.Hunya_PABonusGroupDto Hunya_PABonusGroupDto = new Repository.Hunya_PABonusGroupDto
                    {
                        EmployeeID = EmployeeID,
                        YYMM_B = YYMM_B,
                        YYMM_E = YYMM_E,
                        PAGroupCode = PAGroupCode,
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_PABonusGroupRepo Hunya_PABonusGroupRepo = new Repository.Hunya_PABonusGroupRepo();
                    var OverlapHunya_PABonusGroup = Hunya_PABonusGroupRepo.GetOverlapHunya_PABonusGroup(Hunya_PABonusGroupDto);
                    if (OverlapHunya_PABonusGroup.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Hunya_PABonusGroupRepo.DeleteHunya_PABonusGroup(Hunya_PABonusGroupDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Hunya_PABonusGroupRepo.UpdateHunya_PABonusGroup(Hunya_PABonusGroupDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的績效獎金群組資料.";
                            return false;
                        }
                    }
                    else
                        Hunya_PABonusGroupRepo.InsertHunya_PABonusGroup(Hunya_PABonusGroupDto, out ErrorMsg);
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
