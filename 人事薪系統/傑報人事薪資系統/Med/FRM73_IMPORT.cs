using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM73_IMPORT : JBControls.U_FIELD
    {
        public FRM73_IMPORT()
        {
            InitializeComponent();
            BindingControls.Add(cbxPostcode);
            BindingControls.Add(cbxNobr);
            BindingControls.Add(cbxTEL);
            BindingControls.Add(cbxEMail);
            BindingControls.Add(cbxIDCODE);
            BindingControls.Add(cbxADDR);
            BindingControls.Add(cbxMobile);
            BindingControls.Add(cbxName_c);
            BindingControls.Add(cbxIDNO);
            BindingControls.Add(cbxTaxno);
            BindingControls.Add(cbxINCOMP);
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

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        private void FRM73_IMPORT_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNobr);
            cc.AddControl(cbxName_c);
            cc.AddControl(cbxIDNO);
            cc.AddControl(cbxIDCODE);
            cc.AddControl(cbxINCOMP);
        }
    }

    public class ImportFRM73Data : JBControls.ImportTransfer
    {
        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            try
            {
                using (JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext())
                {
                    JBModule.Data.Repo.TBaseRepo tbaseRepo = new JBModule.Data.Repo.TBaseRepo();
                    JBModule.Data.Dto.TBaseDto tbaseDto = new JBModule.Data.Dto.TBaseDto
                    {
                        INCOMP = Convert.ToBoolean(TransferRow["是否為內部員工"].ToString()),
                        NOBR = TransferRow["所得人編號"].ToString(),
                        NAME_C = TransferRow["所得人姓名"].ToString(),
                        ADDR = TransferRow["地址"].ToString(),
                        TEL = TransferRow["電話"].ToString(),
                        EMAIL = TransferRow["E-Mail"].ToString(),
                        GSM = TransferRow["行動電話"].ToString(),
                        IDNO = TransferRow["統一編號"].ToString(),
                        IDCODE = TransferRow["證號別"].ToString(),
                        POSTCODE1 = TransferRow["郵遞區號"].ToString(),
                        POSTCODE2 = TransferRow["郵遞區號"].ToString(),
                        SALADR = string.Empty,
                        TAXNO = TransferRow["稅籍編號"].ToString(),
                        KEY_MAN = MainForm.USER_NAME,
                        KEY_DATE = DateTime.Now
                    };
                    var OverlapTBASE = tbaseRepo.GetOverlapTBASE(tbaseDto);
                    if (OverlapTBASE != null)
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                        {
                            tbaseRepo.DeleteTBASE(tbaseDto, out ErrMsg);
                        }
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                        {
                            tbaseRepo.UpdateTBASE(tbaseDto, out ErrMsg);
                        }
                        else
                        {
                            ErrMsg += "已存在相同的所得人資料";
                            return false;
                        }
                    }
                    else
                    {
                        tbaseRepo.InsertTBASE(tbaseDto, out ErrMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            try
            {
                string Msg = "";

                if (Convert.ToBoolean(TargetRow["是否為內部員工"].ToString()))
                {
                    var checkList = CheckData["員工編號"];
                    if (checkList.Where(p => p.RealCode == TargetRow["所得人編號"].ToString()).Any())
                    {
                        if (!checkList.Where(p => p.RealCode == TargetRow["所得人編號"].ToString() && p.DisplayName == TargetRow["所得人姓名"].ToString()).Any())
                        {
                            TargetRow["錯誤註記"] += "此員工姓名與員工編號不符.";
                        }
                    }
                    else
                    {
                        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                        {
                            TargetRow["錯誤註記"] += "此所得人編號非內部員工.";
                        }
                    }
                }
                if (ColumnValidate(TargetRow, "證號別", TransferCheckDataField.RealCode, out Msg))
                {
                    TargetRow["證號別"] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += Msg;
                    }
                }

                JBModule.Data.Repo.TBaseRepo tbaseRepo = new JBModule.Data.Repo.TBaseRepo();
                JBModule.Data.Dto.TBaseDto tbaseDto = new JBModule.Data.Dto.TBaseDto
                {
                    NOBR = TargetRow["所得人編號"].ToString(),
                    INCOMP = Convert.ToBoolean(TargetRow["是否為內部員工"].ToString()),
                };
                var OverlapTBASE = tbaseRepo.GetOverlapTBASE(tbaseDto);
                if (OverlapTBASE != null)
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                    {
                        TargetRow["警告註記"] = "重複的資料";
                    }
                }
            }
            catch (Exception ex)
            {
                TargetRow["錯誤註記"] = ex.Message;
                return false;
            }
            return true;
        }
    }
}
