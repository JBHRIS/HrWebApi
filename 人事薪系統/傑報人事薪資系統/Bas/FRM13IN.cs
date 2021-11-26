using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM13IN : JBControls.U_FIELD
    {
        public FRM13IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxFA_IDNO);
            BindingControls.Add(cbxFA_NAME);
            BindingControls.Add(cbxREL_CODE);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxFA_BIRDT);
            BindingControls.Add(cbxADDR);
        }

        private void FRM13IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            //cc.AddControl(cbxFA_BIRDT);
            cc.AddControl(cbxREL_CODE);
            cc.AddControl(cbxFA_NAME);
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxFA_IDNO);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告註記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }

    public class ImportFamilyData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.FamilyDto familyDto = new JBModule.Data.Dto.FamilyDto
                {
                    FA_IDNO = TransferRow["眷屬身份証號"].ToString(),
                    FA_NAME = TransferRow["眷屬姓名"].ToString(),
                    REL_CODE = TransferRow["眷屬種類"].ToString(),
                    NOBR = TransferRow["員工編號"].ToString(),
                    FA_BIRDT = TransferRow["眷屬生日"].ToString() != "" ? Convert.ToDateTime(TransferRow["眷屬生日"].ToString()) : (DateTime?)null,
                    ADDR = TransferRow["眷屬地址"].ToString(),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };

                JBModule.Data.Repo.FamilyRepo familyRepo = new JBModule.Data.Repo.FamilyRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapFAMILY = familyRepo.GetOverlapFAMILY(familyDto);
                if (OverlapFAMILY != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        familyRepo.DeleteFAMILY(familyDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        familyRepo.UpdateFAMILY(familyDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的眷屬資料";
                        return false;
                    }
                }
                else
                {
                    familyRepo.InsertFAMILY(familyDto, out ErrMsg);
                }

            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }


        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            string Msg = "";
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["員工編號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "眷屬種類", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["眷屬種類"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (SourceRow["眷屬生日"].ToString() != "" && !check_DateTime(SourceRow["眷屬生日"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "眷屬生日格式錯誤";
                }
            }
            JBModule.Data.Dto.FamilyDto familyDto = new JBModule.Data.Dto.FamilyDto
            {
                FA_IDNO = TargetRow["眷屬身份証號"].ToString(),
                //FA_NAME = TargetRow["眷屬姓名"].ToString(),
                //REL_CODE = TargetRow["眷屬種類"].ToString(),
                //FA_BIRDT = Convert.ToDateTime(TargetRow["眷屬生日"].ToString()),
                NOBR = TargetRow["員工編號"].ToString(),
                //ADDR = TargetRow["眷屬地址"].ToString()
            };
            JBModule.Data.Repo.FamilyRepo familyRepo = new JBModule.Data.Repo.FamilyRepo();

            var OverlapFAMILY = familyRepo.GetOverlapFAMILY(familyDto);
            if (OverlapFAMILY != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                {
                    TargetRow["警告註記"] = "重複的資料";
                }
            }
            return true;
        }
        bool check_DateTime(string sDate)
        {
            var d = DateTime.MaxValue;
            return DateTime.TryParse(sDate, out d);
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
