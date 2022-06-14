using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4Z_Import : JBControls.U_FIELD
    {
        CheckControl cc;//必填欄位
        public FRM4Z_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbxYYYY);
            BindingControls.Add(cbxMinSalary);
            BindingControls.Add(cbxMaxSalary);
            BindingControls.Add(cbxDependant00);
            BindingControls.Add(cbxDependant01);
            BindingControls.Add(cbxDependant02);
            BindingControls.Add(cbxDependant03);
            BindingControls.Add(cbxDependant04);
            BindingControls.Add(cbxDependant05);
            BindingControls.Add(cbxDependant06);
            BindingControls.Add(cbxDependant07);
            BindingControls.Add(cbxDependant08);
            BindingControls.Add(cbxDependant09);
            BindingControls.Add(cbxDependant10);
            BindingControls.Add(cbxDependant11);
        }

        private void FRM4Z_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxYYYY);
            cc.AddControl(cbxMinSalary);
            cc.AddControl(cbxMaxSalary);
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

        public class FRM4Z_ImportData : JBControls.ImportTransfer
        {
            public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                if (!(int.TryParse(TargetRow["年度"].ToString(), out int YEAR) || (YEAR >= 1753 && YEAR <= 9999)))
                {
                    TargetRow["錯誤註記"] += "考績年度非正確西元年格式(1753-9999).";
                }
                TargetRow["扶養人數00"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數00"].ToString()) ? "0" : TargetRow["扶養人數00"].ToString();
                TargetRow["扶養人數01"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數01"].ToString()) ? "0" : TargetRow["扶養人數01"].ToString();
                TargetRow["扶養人數02"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數02"].ToString()) ? "0" : TargetRow["扶養人數02"].ToString();
                TargetRow["扶養人數03"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數03"].ToString()) ? "0" : TargetRow["扶養人數03"].ToString();
                TargetRow["扶養人數04"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數04"].ToString()) ? "0" : TargetRow["扶養人數04"].ToString();
                TargetRow["扶養人數05"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數05"].ToString()) ? "0" : TargetRow["扶養人數05"].ToString();
                TargetRow["扶養人數06"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數06"].ToString()) ? "0" : TargetRow["扶養人數06"].ToString();
                TargetRow["扶養人數07"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數07"].ToString()) ? "0" : TargetRow["扶養人數07"].ToString();
                TargetRow["扶養人數08"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數08"].ToString()) ? "0" : TargetRow["扶養人數08"].ToString();
                TargetRow["扶養人數09"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數09"].ToString()) ? "0" : TargetRow["扶養人數09"].ToString();
                TargetRow["扶養人數10"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數10"].ToString()) ? "0" : TargetRow["扶養人數10"].ToString();
                TargetRow["扶養人數11"] = string.IsNullOrWhiteSpace(TargetRow["扶養人數11"].ToString()) ? "0" : TargetRow["扶養人數11"].ToString();

                if (string.IsNullOrWhiteSpace(TargetRow["錯誤註記"].ToString()))
                {
                    //JBModule.Data.Dto.TaxLevelDto Dto = new JBModule.Data.Dto.TaxLevelDto
                    //{
                    //    YEAR = YEAR.ToString(),
                    //    AMT_H = decimal.Parse(TargetRow["薪資上限"].ToString()),
                    //    AMT_L = decimal.Parse(TargetRow["薪資下限"].ToString()),
                    //    PER0 = decimal.Parse(TargetRow["扶養人數00"].ToString()),
                    //    PER1 = decimal.Parse(TargetRow["扶養人數01"].ToString()),
                    //    PER2 = decimal.Parse(TargetRow["扶養人數02"].ToString()),
                    //    PER3 = decimal.Parse(TargetRow["扶養人數03"].ToString()),
                    //    PER4 = decimal.Parse(TargetRow["扶養人數04"].ToString()),
                    //    PER5 = decimal.Parse(TargetRow["扶養人數05"].ToString()),
                    //    PER6 = decimal.Parse(TargetRow["扶養人數06"].ToString()),
                    //    PER7 = decimal.Parse(TargetRow["扶養人數07"].ToString()),
                    //    PER8 = decimal.Parse(TargetRow["扶養人數08"].ToString()),
                    //    PER9 = decimal.Parse(TargetRow["扶養人數09"].ToString()),
                    //    PER10 = decimal.Parse(TargetRow["扶養人數10"].ToString()),
                    //    PER11 = decimal.Parse(TargetRow["扶養人數11"].ToString()),
                    //    KEY_DATE = DateTime.Now,
                    //    KEY_MAN = MainForm.USER_NAME,
                    //};
                    var Overlap = db.TAXLVL.Where(p => p.YEAR == YEAR.ToString() && p.AMT_H == decimal.Parse(TargetRow["薪資上限"].ToString()));
                    if (Overlap.Any())
                    {
                        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                        {
                            TargetRow["警告註記"] = "重複的資料";
                        }
                    }

                    return true;
                }
                else
                    return false;
            }

            public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
            {
                ErrorMsg = "";
                try
                {
                    JBModule.Data.Dto.TaxLevelDto Dto = new JBModule.Data.Dto.TaxLevelDto
                    {
                        YEAR = TransferRow["年度"].ToString(),
                        AMT_H = decimal.Parse(TransferRow["薪資上限"].ToString()),
                        AMT_L = decimal.Parse(TransferRow["薪資下限"].ToString()),
                        PER0 = decimal.Parse(TransferRow["扶養人數00"].ToString()),
                        PER1 = decimal.Parse(TransferRow["扶養人數01"].ToString()),
                        PER2 = decimal.Parse(TransferRow["扶養人數02"].ToString()),
                        PER3 = decimal.Parse(TransferRow["扶養人數03"].ToString()),
                        PER4 = decimal.Parse(TransferRow["扶養人數04"].ToString()),
                        PER5 = decimal.Parse(TransferRow["扶養人數05"].ToString()),
                        PER6 = decimal.Parse(TransferRow["扶養人數06"].ToString()),
                        PER7 = decimal.Parse(TransferRow["扶養人數07"].ToString()),
                        PER8 = decimal.Parse(TransferRow["扶養人數08"].ToString()),
                        PER9 = decimal.Parse(TransferRow["扶養人數09"].ToString()),
                        PER10 = decimal.Parse(TransferRow["扶養人數10"].ToString()),
                        PER11 = decimal.Parse(TransferRow["扶養人數11"].ToString()),
                        KEY_DATE = DateTime.Now,
                        KEY_MAN = MainForm.USER_NAME,
                    };
                    JBModule.Data.Repo.TaxLevelRepo Repo = new JBModule.Data.Repo.TaxLevelRepo();
                    var Overlap= Repo.GetOverlap(Dto);
                    if (Overlap.Count > 0)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                            Repo.Delete(Dto, out ErrorMsg);
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                            Repo.Update(Dto, out ErrorMsg);
                        else
                        {
                            ErrorMsg += "已存在相同的所得級距(年度,薪資上限).";
                            return false;
                        }
                    }
                    else
                        Repo.Insert(Dto, out ErrorMsg);

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
