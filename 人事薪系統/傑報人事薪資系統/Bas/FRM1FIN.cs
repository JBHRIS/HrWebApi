using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1FIN : JBControls.U_FIELD
    {
        public FRM1FIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxDESCS);
            BindingControls.Add(cbxMDATE);
            BindingControls.Add(cbxCOMP);
            BindingControls.Add(cbxLIC_NOTE);
            BindingControls.Add(cbxEDATE);
            BindingControls.Add(cbxOWNER);
            BindingControls.Add(cbxLIC_PASS);
            BindingControls.Add(cbxLIC_NO);
        }

        private void FRM1FIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxDESCS);
            cc.AddControl(cbxCOMP);
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


    public class ImportLICANData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.LICANDto lICANDto = new JBModule.Data.Dto.LICANDto
                {
                    NOBR = TransferRow["員工編號"].ToString(),
                    DESCS = TransferRow["證照內容"].ToString(),
                    COMP = TransferRow["發照單位"].ToString(),
                    MDATE = TransferRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["生效日期"].ToString()) : DateTime.Today,
                    EDATE = TransferRow["有效日期"].ToString() != "" ? Convert.ToDateTime(TransferRow["有效日期"].ToString()) : DateTime.Today,
                    LIC_NO = TransferRow["證照編號"].ToString(),
                    LIC_NOTE = TransferRow["備註欄"].ToString(),
                    OWNER = TransferRow["本公司擁有"].ToString() != "" ? Convert.ToBoolean(TransferRow["本公司擁有"].ToString()) : false,
                    LIC_PASS = TransferRow["國家考試"].ToString() != "" ? Convert.ToBoolean(TransferRow["國家考試"].ToString()) : false,
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };
                JBModule.Data.Repo.LICANRepo lICANRepo = new JBModule.Data.Repo.LICANRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapLICAN = lICANRepo.GetOverlapLICAN(lICANDto);
                if (OverlapLICAN != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        lICANRepo.DeleteLICAN(lICANDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        lICANRepo.UpdateLICAN(lICANDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的證照資料";
                        return false;
                    }
                }
                else
                {
                    lICANRepo.InsertLICAN(lICANDto, out ErrMsg);
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

            JBModule.Data.Dto.LICANDto lICANDto = new JBModule.Data.Dto.LICANDto
            {
                NOBR = TargetRow["員工編號"].ToString(),
                DESCS = TargetRow["證照內容"].ToString(),
                //COMP = TargetRow["發照單位"].ToString(),
                //MDATE = TargetRow["生效日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["生效日期"].ToString()) : DateTime.Today,
                //EDATE = TargetRow["有效日期"].ToString() != "" ? Convert.ToDateTime(TargetRow["有效日期"].ToString()) : DateTime.Today,
                //LIC_NO = TargetRow["證照編號"].ToString(),
                //LIC_NOTE = TargetRow["備註欄"].ToString(),
                //OWNER = TargetRow["本公司擁有"].ToString() != "" ? Convert.ToBoolean(TargetRow["本公司擁有"].ToString()) : false,
                //LIC_PASS = TargetRow["國家考試"].ToString() != "" ? Convert.ToBoolean(TargetRow["國家考試"].ToString()) : false,
                //KEY_MAN = MainForm.USER_NAME,
                //KEY_DATE = DateTime.Now
            };
            JBModule.Data.Repo.LICANRepo lICANRepo = new JBModule.Data.Repo.LICANRepo();

            var OverlapLICAN = lICANRepo.GetOverlapLICAN(lICANDto);
            if (OverlapLICAN != null)
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
