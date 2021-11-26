using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace JBHR.EXA
{
    public partial class FRM83IN : JBControls.U_FIELD
    {
        public FRM83IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxEFFLVL);
            BindingControls.Add(cbxEFFSCORE);
            BindingControls.Add(cbxEFFTYPE);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxYYMM);
        }

        private void FRM83IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxEFFLVL);
            cc.AddControl(cbxEFFSCORE);
            cc.AddControl(cbxEFFTYPE);
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxYYMM);
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


    public class ImportExamineData : JBControls.ImportTransfer
    {
        #region ImportExamineData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.ExamineDto examineDto = new JBModule.Data.Dto.ExamineDto
                {
                    EFFLVL = TransferRow["考核等級"].ToString(),
                    EFFSCORE = Convert.ToDecimal(TransferRow["考核分數"].ToString()),
                    EFFTYPE = TransferRow["考核種類"].ToString(),
                    NOBR = TransferRow["員工編號"].ToString(),
                    YYMM = TransferRow["績效年度"].ToString(),
                    IMPORT = true,
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.ExamineRepo examineRepo = new JBModule.Data.Repo.ExamineRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapExamine = examineRepo.GetOverlapExamine(examineDto);
                if (OverlapExamine != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        examineRepo.DeleteExamine(examineDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        examineRepo.UpdateExamine(examineDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的考核資料";
                        return false;
                    }
                }
                else
                {
                    examineRepo.InsertExamine(examineDto, out ErrMsg);
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

            if (ColumnValidate(TargetRow, "考核種類", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["考核種類"] = Msg;
            }
            else
            { 
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "考核等級", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["考核等級"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            JBModule.Data.Dto.ExamineDto examineDto = new JBModule.Data.Dto.ExamineDto
            {
                EFFLVL = TargetRow["考核等級"].ToString(),
                EFFTYPE = TargetRow["考核種類"].ToString(),
                NOBR = TargetRow["員工編號"].ToString(),
                YYMM = TargetRow["績效年度"].ToString(),
            };
            JBModule.Data.Repo.ExamineRepo examineRepo = new JBModule.Data.Repo.ExamineRepo();

            var OverlapExamine = examineRepo.GetOverlapExamine(examineDto);
            if (OverlapExamine != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
                {
                    TargetRow["警告"] = "重複的資料";
                }
            }

            if (!SourceRow.IsNull("績效年度") && !check_YYMM(SourceRow["績效年度"].ToString(), out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
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
            if (YYMM.Length == 4)
            {
                try
                {
                    var yy = int.Parse(YYMM.Substring(0, 4), CultureInfo.InvariantCulture);
                    //msg = msg;
                    return true;
                }
                catch { }
            }
            msg = errorMsg("請輸入年度(YYYY)");
            return false;
        }
        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
