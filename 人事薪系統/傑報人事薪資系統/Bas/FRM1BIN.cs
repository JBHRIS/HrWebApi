using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1BIN : JBControls.U_FIELD
    {
        public FRM1BIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxSCHL);
            BindingControls.Add(cbxADATE);
            BindingControls.Add(cbxEDUCCODE);
            BindingControls.Add(cbxMEMO);
            BindingControls.Add(cbxDATE_B);
            BindingControls.Add(cbxDATE_E);
            BindingControls.Add(cbxSUBJ_DETAIL);
            BindingControls.Add(cbxOK);
            BindingControls.Add(cbxGraduated);
            BindingControls.Add(cbxDayOrNight);
            BindingControls.Add(cbxSUBJ);
        }

        private void FRM1BIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxSCHL);
            cc.AddControl(cbxSUBJ);
            cc.AddControl(cbxEDUCCODE);
            cc.AddControl(cbxSUBJ_DETAIL);
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

    public class ImportSCHLData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.SCHLDto sCHLDto = new JBModule.Data.Dto.SCHLDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    SCHL = TransferRow["學校"].ToString(),
                    EDUCCODE = TransferRow["教育程度代號"].ToString(),
                    SUBJ = TransferRow["科系"].ToString(),
                    SUBJ_DETAIL = TransferRow["科系詳細名稱"].ToString(),
                    ADATE = TransferRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["生效日期"].ToString()) : DateTime.Today,
                    DATE_B = TransferRow["入學年月"].ToString(),
                    DATE_E = TransferRow["畢業年月"].ToString(),
                    DayOrNight = TransferRow["日夜"].ToString(),
                    OK = TransferRow["畢業"].ToString() != "" ? Convert.ToBoolean(TransferRow["畢業"].ToString()) : false,
                    Graduated = TransferRow["肄業"].ToString() != "" ? Convert.ToBoolean(TransferRow["肄業"].ToString()) : false,
                    MEMO = TransferRow["備註"].ToString(),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.SCHLRepo sCHLRepo = new JBModule.Data.Repo.SCHLRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapSCHL = sCHLRepo.GetOverlapSCHL(sCHLDto);
                if (OverlapSCHL != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        sCHLRepo.DeleteSCHL(sCHLDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        sCHLRepo.UpdateSCHL(sCHLDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的教育程度資料";
                        return false;
                    }
                }
                else
                {
                    sCHLRepo.InsertSCHL(sCHLDto, out ErrMsg);
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

            if (ColumnValidate(TargetRow, "教育程度代號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["教育程度代號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "科系", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["科系"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (!SourceRow.IsNull("日夜") && !string.IsNullOrWhiteSpace(SourceRow["日夜"].ToString()) && ColumnValidate(TargetRow, "日夜", TransferCheckDataField.RealCode, out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (!SourceRow.IsNull("入學年月") && !string.IsNullOrWhiteSpace(SourceRow["入學年月"].ToString()) && !check_YYMM(SourceRow["入學年月"].ToString(), out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (!SourceRow.IsNull("畢業年月") && !string.IsNullOrWhiteSpace(SourceRow["畢業年月"].ToString()) && !check_YYMM(SourceRow["畢業年月"].ToString(), out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            JBModule.Data.Dto.SCHLDto sCHLDto = new JBModule.Data.Dto.SCHLDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                //SCHL = TargetRow["學校"].ToString(),
                EDUCCODE = TargetRow["教育程度代號"].ToString(),
                //SUBJ = TargetRow["科系"].ToString(),
                //SUBJ_DETAIL = TargetRow["科系詳細名稱"].ToString(),
                ADATE = TargetRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["生效日期"].ToString()) : DateTime.Today,
                //DATE_B = TargetRow["入學年月"].ToString(),
                //DATE_E = TargetRow["畢業年月"].ToString(),
                //DayOrNight = TargetRow["日夜"].ToString(),
                //OK = TargetRow["畢業"].ToString() != "" ? Convert.ToBoolean(TargetRow["畢業"].ToString()) : false,
                //Graduated = TargetRow["肄業"].ToString() != "" ? Convert.ToBoolean(TargetRow["肄業"].ToString()) : false,
                //MEMO = TargetRow["備註"].ToString(),
                //KEY_MAN = MainForm.USER_NAME,
                //KEY_DATE = DateTime.Now
            };
            JBModule.Data.Repo.SCHLRepo sCHLRepo = new JBModule.Data.Repo.SCHLRepo();

            var OverlapSCHL = sCHLRepo.GetOverlapSCHL(sCHLDto);
            if (OverlapSCHL != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                {
                    TargetRow["警告註記"] = "重複的資料";
                }
            }
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
            else if (YYMM.Length == 7)
            {
                try
                {
                    var yy = int.Parse(YYMM.Substring(0, 4));
                    var mm = int.Parse(YYMM.Substring(5));

                    var d = new DateTime(yy, mm, 1);
                    //msg = msg;
                    return true;
                }
                catch { }
            }
            msg = errorMsg("年月格式YYYYMM或YYYY/MM");
            return false;
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
