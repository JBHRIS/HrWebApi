using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.HopaxCustom
{
    public partial class HPX_Point_MGT_IN : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public HPX_Point_MGT_IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxActivity_Name);
            BindingControls.Add(cbxMemo);
            BindingControls.Add(cbxEmployee_Name);
            BindingControls.Add(cbxEmployee_No);
            BindingControls.Add(cbxLeader);
            BindingControls.Add(cbxPerson_Join);
            BindingControls.Add(cbxBook_User);
            BindingControls.Add(cbxRelatives_Count);
            BindingControls.Add(cbxGet_Point);
            BindingControls.Add(cbxUse_Point);
            BindingControls.Add(cbxUse_Date);
            BindingControls.Add(cbxRemaining_Point);
            BindingControls.Add(cbxCreated_By);
            BindingControls.Add(cbxCreation_Date);
            BindingControls.Add(cbxLast_Updated_By);
            BindingControls.Add(cbxLast_Update_Date);
        }

        private void HPX_Point_MGT_IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxActivity_Name);
            cc.AddControl(cbxEmployee_Name);
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
    }

    public class HPXPointMGTImport : JBControls.ImportTransfer
    {
        public HPX_WebService.ServiceClient client = null;
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";
            if (ColumnValidate(TargetRow, "工號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["工號"] = Msg;
                ColumnValidate(TargetRow, "工號", TransferCheckDataField.DisplayName, out Msg);
                if (TargetRow["姓名"].ToString() != Msg)
                    TargetRow["警告註記"] += "匯入姓名與工號姓名不符.";
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            if (ColumnValidate(TargetRow, "團主否", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["團主否"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            if (ColumnValidate(TargetRow, "本人參加否", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["本人參加否"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] += Msg;
                }
            }

            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            try
            {
                string Activity_Name = TransferRow["活動名稱"].ToString();
                string EmployeeName = TransferRow["姓名"].ToString();
                string EmployeeNo = TransferRow["工號"].ToString();
                string Leader = string.IsNullOrWhiteSpace(TransferRow["團主否"].ToString()) ? "N" : TransferRow["團主否"].ToString();
                string PersonJoin = string.IsNullOrWhiteSpace(TransferRow["本人參加否"].ToString()) ? "N" : TransferRow["本人參加否"].ToString();
                int RelativesCount = string.IsNullOrWhiteSpace(TransferRow["親友人數"].ToString()) ?0 : Convert.ToInt32(TransferRow["親友人數"].ToString());
                int GetPoint = string.IsNullOrWhiteSpace(TransferRow["獲得點數"].ToString()) ? 0 : Convert.ToInt32(TransferRow["獲得點數"].ToString());
                int UsePoint = string.IsNullOrWhiteSpace(TransferRow["使用點數"].ToString()) ? 0 : Convert.ToInt32(TransferRow["使用點數"].ToString());
                DateTime? UseDate = string.IsNullOrWhiteSpace(TransferRow["使用時間"].ToString()) ? (DateTime?)null : Convert.ToDateTime(TransferRow["使用時間"].ToString());
                //int RemainingPoint = 10;
                string BookUser = TransferRow["承辦人"].ToString();
                string Remark = TransferRow["備註"].ToString();
                string CreatedBy = string.IsNullOrWhiteSpace(TransferRow["創建人員"].ToString()) ? MainForm.USER_NAME : TransferRow["創建人員"].ToString();
                DateTime CreationDate = string.IsNullOrWhiteSpace(TransferRow["創建日期"].ToString()) ? DateTime.Now.Date : Convert.ToDateTime(TransferRow["創建日期"].ToString());
                string LastUpdatedBy = string.IsNullOrWhiteSpace(TransferRow["最後修改者"].ToString()) ? MainForm.USER_NAME : TransferRow["最後修改者"].ToString();
                DateTime LastUpdateDate = string.IsNullOrWhiteSpace(TransferRow["最後修改日"].ToString()) ? DateTime.Now.Date : Convert.ToDateTime(TransferRow["最後修改日"].ToString());

                HPX_WebService.HPXPointDto hPXPointDto = new HPX_WebService.HPXPointDto()
                {
                    ActivityName = Activity_Name,
                    EmployeeName = EmployeeName,
                    EmployeeNo = EmployeeNo,
                    Leader = Leader,
                    PersonJoin = PersonJoin,
                    RelativesCount = RelativesCount,
                    GetPoint = GetPoint,
                    UsePoint = UsePoint,
                    UseDate = UseDate,
                    //RemainingPoint = RemainingPoint,
                    BookUser = BookUser,
                    Remark = Remark,
                    CreatedBy = CreatedBy,
                    CreationDate = CreationDate,
                    LastUpdatedBy = LastUpdatedBy,
                    LastUpdateDate = LastUpdateDate,
                };
                client.InsertHPXPoint(hPXPointDto);
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
