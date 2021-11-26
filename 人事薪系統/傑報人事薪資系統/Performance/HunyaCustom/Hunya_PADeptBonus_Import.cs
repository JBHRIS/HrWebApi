using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PADeptBonus_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public Hunya_PADeptBonus_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxPADept);
            BindingControls.Add(cbxPADeptName);
            BindingControls.Add(cbxYYMM_B);
            BindingControls.Add(cbxYYMM_E);
            BindingControls.Add(cbxPABasicBonus);
        }

        private void Hunya_PADeptBonus_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxPADept);
            cc.AddControl(cbxYYMM_B);
            cc.AddControl(cbxYYMM_E);
            cc.AddControl(cbxPABasicBonus);
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

        public class Hunya_PADeptBonus_ImportData : JBControls.ImportTransfer
        {
            public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
            {
                if (ColumnValidate(TargetRow, "部門代碼", TransferCheckDataField.DisplayCode, out string Msg))
                {
                    TargetRow["部門代碼"] = Msg;
                    ColumnValidate(TargetRow, "部門代碼", TransferCheckDataField.DisplayName, out Msg);
                    if (!string.IsNullOrEmpty(TargetRow["部門名稱"].ToString()) && TargetRow["部門名稱"].ToString() != Msg)
                        TargetRow["警告註記"] += "匯入名稱與部門代碼名稱不符.";
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
                    //string PADept = string.Empty;
                    ColumnValidate(TransferRow, "部門代碼", TransferCheckDataField.RealCode, out string PADept);
                    string YYMM_B = TransferRow["考核年月起"].ToString();
                    string YYMM_E = TransferRow["考核年月迄"].ToString();
                    Decimal PABasicBonus = JBModule.Data.CEncrypt.Number(decimal.Parse(TransferRow["基本獎金"].ToString()));
                    Guid GID = Guid.NewGuid();

                    Repository.Hunya_PADeptBonusDto Hunya_PADeptBonusDto = new Repository.Hunya_PADeptBonusDto
                    {
                        PADept = PADept,
                        YYMM_B = YYMM_B,
                        YYMM_E = YYMM_E,
                        PABasicBonus = PABasicBonus,
                        KeyDate = DateTime.Now,
                        KeyMan = MainForm.USER_NAME,
                    };
                    Repository.Hunya_PADeptBonusRepo Hunya_PADeptBonusRepo = new Repository.Hunya_PADeptBonusRepo();
                    var OverlapHunya_PADeptBonus = Hunya_PADeptBonusRepo.GetOverlapHunya_PADeptBonus(Hunya_PADeptBonusDto);
                    if (OverlapHunya_PADeptBonus.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Hunya_PADeptBonusRepo.DeleteHunya_PADeptBonus(Hunya_PADeptBonusDto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Hunya_PADeptBonusRepo.UpdateHunya_PADeptBonus(Hunya_PADeptBonusDto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的部門獎金分配權數.";
                            return false;
                        }
                    }
                    else
                        Hunya_PADeptBonusRepo.InsertHunya_PADeptBonus(Hunya_PADeptBonusDto, out ErrorMsg);
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
