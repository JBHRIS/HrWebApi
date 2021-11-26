using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.Att
{
    public partial class FRM25IN : JBControls.U_FIELD
    {
        public FRM25IN()
        {
            InitializeComponent();
            //cbAmt.Tag = "AMT";
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxADATE);
            BindingControls.Add(cbxONTIME);
            BindingControls.Add(cbxMENO);
            BindingControls.Add(cbxREASON);
            BindingControls.Add(rbLOS_TRUE);

        }
        private void FRM25IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxADATE);
            cc.AddControl(cbxONTIME);
            cc.AddControl(cbxNOBR);
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

    }
    public class ImportTransferToCard : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.CardDto cardDto = new JBModule.Data.Dto.CardDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    ADATE = Convert.ToDateTime(TransferRow["刷卡日期"].ToString()),
                    ONTIME = TransferRow["刷卡時間"].ToString(),
                    REASON = TransferRow["原因代碼"].ToString(),
                    MENO = TransferRow["備註"].ToString(),
                    LOS = Convert.ToBoolean(TransferRow["是否為遺忘刷卡"].ToString()),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.CardRepo cardRepo = new JBModule.Data.Repo.CardRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapCard = cardRepo.GetOverlapCard(cardDto);
                if (OverlapCard != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        cardRepo.DeleteCard(cardDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        cardRepo.UpdateCard(cardDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同時段的刷卡資料";
                        return false;
                    }
                }
                else
                {
                    cardRepo.InsertCard(cardDto, out ErrMsg);
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

            if (!string.IsNullOrWhiteSpace(TargetRow["原因代碼"].ToString()))
            {
                if (ColumnValidate(TargetRow, "原因代碼", TransferCheckDataField.DisplayName, out Msg))
                {
                    TargetRow["原因名稱"] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = Msg;
                    }
                }
            }

            var AdateTemp = new DateTime(1900,1,1);
            if (!check_DateTime(TargetRow["刷卡日期"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = errorMsg("刷卡日期");
                }
            }
            else 
                AdateTemp = Convert.ToDateTime(TargetRow["刷卡日期"].ToString());

            if (!check_Btime(TargetRow["刷卡時間"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = errorMsg("刷卡時間");
                }
            }

            JBModule.Data.Dto.CardDto cardDto = new JBModule.Data.Dto.CardDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                ADATE = AdateTemp,
                ONTIME = TargetRow["刷卡時間"].ToString(),
            };
            JBModule.Data.Repo.CardRepo cardRepo = new JBModule.Data.Repo.CardRepo();

            var OverlapCard = cardRepo.GetOverlapCard(cardDto);
            if (OverlapCard != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
                {
                    TargetRow["警告"] = "重複的資料";
                }
            }

            return true;
        }
        bool check_DateTime(string sDate)
        {
            var d = DateTime.MaxValue;
            return DateTime.TryParse(sDate, out d);
        }
        bool check_Btime(string Btime)
        {
            if (Btime.Trim().Length == 4)
            {
                try
                {
                    int h = int.Parse(Btime.Trim().Substring(0, 2));
                    int m = int.Parse(Btime.Trim().Substring(2));
                    return (h <= 24 && m < 60);
                }
                catch { }
            }
            return false;
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