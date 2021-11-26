using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1AIN : JBControls.U_FIELD
    {
        public FRM1AIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxCOMPANY);
            BindingControls.Add(cbxJOB);
            BindingControls.Add(cbxTITTLE);
            BindingControls.Add(cbxNOTE);
            BindingControls.Add(cbxBDATE);
            BindingControls.Add(cbxEDATE);
        }

        private void FRM1AIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxCOMPANY);
            cc.AddControl(cbxTITTLE);
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

    public class ImportWORKSData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.WorksDto worksDto = new JBModule.Data.Dto.WorksDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    COMPANY = TransferRow["公司"].ToString(),
                    TITLE = TransferRow["職稱"].ToString(),
                    BDATE = TransferRow["開始日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["開始日期"].ToString()) : DateTime.Today,
                    EDATE = TransferRow["結束日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["結束日期"].ToString()) : DateTime.Today,
                    JOB = TransferRow["工作內容"].ToString(),
                    NOTE = TransferRow["備註"].ToString(),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.WorksRepo worksRepo = new JBModule.Data.Repo.WorksRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapWORKS = worksRepo.GetOverlapWORKS(worksDto);
                if (OverlapWORKS != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        worksRepo.DeleteWORKS(worksDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        worksRepo.UpdateWORKS(worksDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的經歷資料";
                        return false;
                    }
                }
                else
                {
                    worksRepo.InsertWORKS(worksDto, out ErrMsg);
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

            JBModule.Data.Dto.WorksDto worksDto = new JBModule.Data.Dto.WorksDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                COMPANY = TargetRow["公司"].ToString(),
                //TITLE = TargetRow["職稱"].ToString(),
                BDATE = TargetRow["開始日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["開始日期"].ToString()) : DateTime.Today,
                //EDATE = TargetRow["結束日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["結束日期"].ToString()) : DateTime.Today,
                //JOB = TargetRow["工作內容"].ToString(),
                //NOTE = TargetRow["備註"].ToString(),
                //KEY_MAN = MainForm.USER_NAME,
                //KEY_DATE = DateTime.Now
            };

            JBModule.Data.Repo.WorksRepo worksRepo = new JBModule.Data.Repo.WorksRepo();

            var OverlapWORKS = worksRepo.GetOverlapWORKS(worksDto);
            if (OverlapWORKS != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                {
                    TargetRow["警告註記"] = "重複的資料";
                }
            }
            return true;
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}
