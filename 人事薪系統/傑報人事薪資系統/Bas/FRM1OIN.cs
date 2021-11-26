using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Bas
{
    public partial class FRM1OIN : JBControls.U_FIELD
    {
        public FRM1OIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxContractType);
            BindingControls.Add(cbxAdate);
            BindingControls.Add(cbxWorkAdr);
            BindingControls.Add(cbxDdate);
        }

        private void FRM1OIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxContractType);
            cc.AddControl(cbxWorkAdr);
            cc.AddControl(cbxAdate);
            cc.AddControl(cbxDdate);
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

    public class ImportContractData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("Contract", MainForm.COMPANY);
                acg = new JBModule.Data.ApplicationConfigSettings("Contract", MainForm.COMPANY);
                var cfg = acg.GetConfig("AlertDay");
                JBModule.Data.Dto.ContractDto contractDto = new JBModule.Data.Dto.ContractDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    ContractType = TransferRow["合同種類"].ToString(),
                    WorkAdr = TransferRow["派駐區"].ToString(),
                    Adate = TransferRow["起始日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["起始日期"].ToString()) : DateTime.Today,
                    Ddate = TransferRow["到期日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["到期日期"].ToString()) : DateTime.Today.AddDays(1),
                    AlertDay = int.Parse(cfg.GetString("0")),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.ContractRepo contractRepo = new JBModule.Data.Repo.ContractRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapContract = contractRepo.GetOverlapContract(contractDto);
                if (OverlapContract != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        contractRepo.DeleteContract(contractDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        contractRepo.UpdateContract(contractDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的合同資料";
                        return false;
                    }
                }
                else
                {
                    contractRepo.InsertContract(contractDto, out ErrMsg);
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

            if (ColumnValidate(TargetRow, "合同種類", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["合同種類"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "派駐區", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["派駐區"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (CheckRepeat(TargetRow["員工編號"].ToString(), TargetRow["合同種類"].ToString(), Convert.ToDateTime(TargetRow["起始日期"].ToString()), Convert.ToDateTime(TargetRow["到期日期"].ToString())))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "合同的有效期間重複，請檢查輸入的資料是否正確";
                }
            }

            if (Sal.Function.CheckLeaveForbid(TargetRow["員工編號"].ToString(), Convert.ToDateTime(TargetRow["起始日期"].ToString())))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "離職人員不可新增合同";
                }
            }

            JBModule.Data.Dto.ContractDto contractDto = new JBModule.Data.Dto.ContractDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                //ContractType = TargetRow["合同種類"].ToString(),
                //WorkAdr = TargetRow["派駐區"].ToString(),
                Adate = TargetRow["起始日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["起始日期"].ToString()) : DateTime.Today,
                Ddate = TargetRow["到期日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["到期日期"].ToString()) : DateTime.Today.AddDays(1),
                //KEY_MAN = MainForm.USER_NAME,
                //KEY_DATE = DateTime.Now
            };
            JBModule.Data.Repo.ContractRepo contractRepo = new JBModule.Data.Repo.ContractRepo();

            var OverlapContract = contractRepo.GetOverlapContract(contractDto);
            if (OverlapContract != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                {
                    TargetRow["警告註記"] = "重複的資料";
                }
            }
            return true;
        }


        bool CheckRepeat(string Nobr, string ContractType, DateTime Adate, DateTime Ddate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Contract where a.Nobr == Nobr && a.ContractType == ContractType && a.Adate <= Ddate && a.Ddate >= Adate select a;
            return sql.Any();
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
