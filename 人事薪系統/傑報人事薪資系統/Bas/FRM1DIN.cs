using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1DIN : JBControls.U_FIELD
    {
        public FRM1DIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxDEPTS);
            BindingControls.Add(cbxRATE);
            BindingControls.Add(cbxDATE);
            BindingControls.Add(cbxCADATE);
        }

        private void FRM1DIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxDEPTS);
            cc.AddControl(cbxCADATE);
            cc.AddControl(cbxRATE);
            cc.AddControl(cbxDATE);
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

    public class ImportCOSTData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.CostDto costDto = new JBModule.Data.Dto.CostDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    DEPTS = TransferRow["成本部門"].ToString(),
                    RATE = TransferRow["分攤比率"].ToString() != "" ? Convert.ToDecimal(TransferRow["分攤比率"].ToString()) : 0,
                    CADATE = TransferRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["生效日期"].ToString()) : DateTime.Today,
                    CDDATE = TransferRow["失效日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["失效日期"].ToString()) : DateTime.Today,
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.CostRepo costRepo = new JBModule.Data.Repo.CostRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapSCHL = costRepo.GetOverlapCOST(costDto);
                if (OverlapSCHL != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        costRepo.DeleteCOST(costDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        costRepo.UpdateCOST(costDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的費用分攤資料";
                        return false;
                    }
                }
                else
                {
                    costRepo.InsertCOST(costDto, out ErrMsg);
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

            if (ColumnValidate(TargetRow, "成本部門", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["成本部門"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (SourceRow["生效日期"].ToString() != "" && !check_DateTime(SourceRow["生效日期"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "生效日期格式錯誤";
                }
            }
            if (SourceRow["失效日期"].ToString() != "" && !check_DateTime(SourceRow["失效日期"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "失效日期格式錯誤";
                }
            }
            JBModule.Data.Dto.CostDto costDto = new JBModule.Data.Dto.CostDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                DEPTS = TargetRow["成本部門"].ToString(),
                //RATE = TargetRow["分攤比率"].ToString() != "" ? Convert.ToDecimal(TargetRow["分攤比率"].ToString()) : 0,
                CADATE = TargetRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["生效日期"].ToString()) : DateTime.Today,
                //CDDATE = TargetRow["失效日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["失效日期"].ToString()) : DateTime.Today,
                //KEY_MAN = MainForm.USER_NAME,
                //KEY_DATE = DateTime.Now
            };
            JBModule.Data.Repo.CostRepo costRepo = new JBModule.Data.Repo.CostRepo();

            var OverlapSCHL = costRepo.GetOverlapCOST(costDto);
            if (OverlapSCHL != null)
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
