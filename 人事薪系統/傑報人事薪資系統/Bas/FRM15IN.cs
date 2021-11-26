using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM15IN : JBControls.U_FIELD
    {
        public FRM15IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxADATE);
            BindingControls.Add(cbxAwardcd);
            BindingControls.Add(cbxYYMM);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxAward1);
            BindingControls.Add(cbxAward2);
            BindingControls.Add(cbxAward3);
            BindingControls.Add(cbxAward4);
            BindingControls.Add(cbxFault1);
            BindingControls.Add(cbxFault2);
            BindingControls.Add(cbxFault3);
            BindingControls.Add(cbxFault4);
            BindingControls.Add(cbxNote);
        }

        private void FRM15IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxADATE);
            cc.AddControl(cbxAwardcd);
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



    public class ImportAWARDData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.AwardDto awardDto = new JBModule.Data.Dto.AwardDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    ADATE = Convert.ToDateTime(TransferRow["獎懲日期"].ToString()),
                    AWARD_CODE = TransferRow["獎懲原因"].ToString(),
                    AWARD1 = TransferRow["大功"].ToString() != "" ? Convert.ToDecimal(TransferRow["大功"].ToString()) : 0,
                    AWARD2 = TransferRow["小功"].ToString() != "" ? Convert.ToDecimal(TransferRow["小功"].ToString()) : 0,
                    AWARD3 = TransferRow["嘉獎"].ToString() != "" ? Convert.ToDecimal(TransferRow["嘉獎"].ToString()) : 0,
                    AWARD4 = TransferRow["獎金罰金"].ToString() != "" ? Convert.ToDecimal(TransferRow["獎金罰金"].ToString()) : 0,
                    FAULT1 = TransferRow["大過"].ToString() != "" ? Convert.ToDecimal(TransferRow["大過"].ToString()) : 0,
                    FAULT2 = TransferRow["小過"].ToString() != "" ? Convert.ToDecimal(TransferRow["小過"].ToString()) : 0,
                    FAULT3 = TransferRow["申誡"].ToString() != "" ? Convert.ToDecimal(TransferRow["申誡"].ToString()) : 0,
                    FAULT4 = TransferRow["警告"].ToString() != "" ? Convert.ToDecimal(TransferRow["警告數"].ToString()) : 0,
                    NOTE = TransferRow["備註"].ToString(),
                    YYMM = TransferRow["計薪年月"].ToString(),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.AwardRepo awardRepo = new JBModule.Data.Repo.AwardRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapAWARD = awardRepo.GetOverlapAWARD(awardDto);
                if (OverlapAWARD != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        awardRepo.DeleteAWARD(awardDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        awardRepo.UpdateAWARD(awardDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的獎懲資料";
                        return false;
                    }
                }
                else
                {
                    awardRepo.InsertAWARD(awardDto, out ErrMsg);
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

            if (ColumnValidate(TargetRow, "獎懲原因", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["獎懲原因"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (SourceRow["獎懲日期"].ToString() != "" && !check_DateTime(SourceRow["獎懲日期"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "獎懲日期格式錯誤";
                }
            }

            if (SourceRow["計薪年月"].ToString() != "" && !check_YYMM(SourceRow["計薪年月"].ToString(), out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            JBModule.Data.Dto.AwardDto awardDto = new JBModule.Data.Dto.AwardDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                ADATE = Convert.ToDateTime(TargetRow["獎懲日期"].ToString()),
                //AWARD_CODE = TargetRow["獎懲原因"].ToString(),
                //AWARD1 = TargetRow["大功"].ToString() != "" ? Convert.ToDecimal(TargetRow["大功"].ToString()) : 0,
                //AWARD2 = TargetRow["小功"].ToString() != "" ? Convert.ToDecimal(TargetRow["小功"].ToString()) : 0,
                //AWARD3 = TargetRow["嘉獎"].ToString() != "" ? Convert.ToDecimal(TargetRow["嘉獎"].ToString()) : 0,
                //AWARD4 = TargetRow["獎金罰金"].ToString() != "" ? Convert.ToDecimal(TargetRow["獎金罰金"].ToString()) : 0,
                //FAULT1 = TargetRow["大過"].ToString() != "" ? Convert.ToDecimal(TargetRow["大過"].ToString()) : 0,
                //FAULT2 = TargetRow["小過"].ToString() != "" ? Convert.ToDecimal(TargetRow["小過"].ToString()) : 0,
                //FAULT3 = TargetRow["申誡"].ToString() != "" ? Convert.ToDecimal(TargetRow["申誡"].ToString()) : 0,
                //FAULT4 = TargetRow["警告"].ToString() != "" ? Convert.ToDecimal(TargetRow["警告"].ToString()) : 0,
                //NOTE = TargetRow["備註"].ToString(),
                //YYMM = TargetRow["計薪年月"].ToString(),
            };
            JBModule.Data.Repo.AwardRepo awardRepo = new JBModule.Data.Repo.AwardRepo();

            var OverlapAWARD = awardRepo.GetOverlapAWARD(awardDto);
            if (OverlapAWARD != null)
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
            msg = errorMsg("計薪年月格式YYYYMM");
            return false;
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
