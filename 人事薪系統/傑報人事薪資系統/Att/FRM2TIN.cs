using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JBControls;

namespace JBHR.Att
{
    public partial class FRM2TIN : JBControls.U_FIELD
    {
        public FRM2TIN()
        {
            InitializeComponent();
            //cbAmt.Tag = "AMT";
            BindingControls.Add(cbxBDATE);
            //BindingControls.Add(cbxBTIME);
            BindingControls.Add(cbxNOTE);
            //BindingControls.Add(cbxETIME);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxH_CODE);
            BindingControls.Add(cbxTOL_HOURS);
            BindingControls.Add(cbxDdate);


        }
        private void FRM2TIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxBDATE);
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxTOL_HOURS);
            cc.AddControl(cbxDdate);
            cc.AddControl(cbxH_CODE);
        }
        CheckControl cc;//必填欄位
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
             foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbxDdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
    public class ImportTransferToABST : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = string.Empty;
            string Msg = string.Empty;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                string H_CODE = string.Empty;
                if (ColumnValidate(TransferRow, "假別代碼", TransferCheckDataField.RealCode, out Msg))
                    H_CODE = Msg;
                else
                {
                    if (TransferRow.Table != null && TransferRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TransferRow["錯誤註記"] = Msg;
                        return false;
                    }
                }

                //string H_CODE = TransferRow["假別代碼"].ToString();
                JBModule.Data.Repo.AbsRepo absRepo = new JBModule.Data.Repo.AbsRepo();
                var absTaken = new JBModule.Data.Dto.AbsEntitleDto()
                {
                    EmployeeID = TransferRow["員工編號"].ToString(),
                    Taken = Convert.ToDecimal(TransferRow["得假時數/天數"]),
                    BeginDate = Convert.ToDateTime(TransferRow["生效日期"].ToString()),
                    EndDate = Convert.ToDateTime(TransferRow["失效日期"].ToString()),
                    Hcode = H_CODE,
                    Remark = TransferRow["備註"].ToString(),
                    Serno = Guid.NewGuid().ToString(),
                    YYMM = Convert.ToDateTime(TransferRow["生效日期"].ToString()).ToString("yyyyMM"),
                    CreateMan = MainForm.USER_ID,
                };
                //var ConfilctData = absRepo.GetAbsEntitle(absRepo.ConvertAbsEntitleDtoToAbs(absTaken, out ErrMsg));
                //if (!ConfilctData.Any())
                //{
                absRepo.InsertAbsEntitle(absRepo.ConvertAbsEntitleDtoToAbs(absTaken, out ErrMsg), out ErrMsg);
                //}
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
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            //if (ColumnValidate(TargetRow, "檢核時數", TransferCheckDataField.DisplayName, out Msg))
            //{
            //    TargetRow["檢核時數"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] = Msg;
            //    }
            //}
            //if (ColumnValidate(TargetRow, "失效日期", TransferCheckDataField.DisplayName, out Msg))
            //{
            //    TargetRow["失效日期"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] = Msg;
            //    }
            //}
            //if (check_YYMM(TargetRow["計薪年月"].ToString(), out Msg))
            //{

            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] = Msg;
            //    }
            //}
            if (ColumnValidate(TargetRow, "假別代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["假別名稱"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            //if (ColumnValidate(TargetRow, "假別代碼", TransferCheckDataField.RealCode, out Msg))
            //{
            //    TargetRow["假別代碼"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] = Msg;
            //    }
            //}

            if (TargetRow["得假時數/天數"].ToString() == "")
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = errorMsg("得假時數/天數");
                }
            }
            else
            {
                var tol_hours = Convert.ToDecimal(TargetRow["得假時數/天數"].ToString());
                if (tol_hours <= 0)
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = errorMsg("得假時數/天數");
                    }
                }
            }
            //JBModule.Data.Repo.AbsRepo absRepo = new JBModule.Data.Repo.AbsRepo();
            //var absTaken = new JBModule.Data.Linq.ABS()
            //{
            //    BDATE = Convert.ToDateTime(TargetRow["生效日期"].ToString()),
            //    EDATE = Convert.ToDateTime(TargetRow["失效日期"].ToString()),
            //    NOBR = TargetRow["員工編號"].ToString(),
            //    H_CODE = TargetRow["假別代碼"].ToString(),
            //};
            //var ConfilctData = absRepo.GetAbsEntitle(absTaken);
            //if (ConfilctData.Any())
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
            //    {
            //        TargetRow["警告"] = "重複的資料";
            //    }
            //}
            return true;
        }

        bool check_YYMM(string YYMM, out string msg)
        {
            msg = "";
            if (YYMM.Length == 6)
            {
                try
                {
                    var yy = int.Parse(YYMM.Substring(0, 4));
                    var mm = int.Parse(YYMM.Substring(4));

                    var d = new DateTime(yy, mm, 1);
                    //msg = msg;
                    return true;
                }
                catch { }
            }
            msg = errorMsg("計薪年月");
            return false;
        }
        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }
}