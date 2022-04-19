using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
    public partial class FRM62N_IMPORT : JBControls.U_FIELD
    {
        int RowIndex = 4;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM62N", MainForm.COMPANY);
        CheckControl cc;//必填欄位
        public FRM62N_IMPORT()
        {
            InitializeComponent();
            BindingControls.Add(cbAmt);
            BindingControls.Add(cbxNobr);
            BindingControls.Add(cbxFormat);
            BindingControls.Add(cbxWCode);
            BindingControls.Add(cbxD_Amt);
            BindingControls.Add(cbxYymm);
            BindingControls.Add(cbxSeq);
            BindingControls.Add(cbxNote1);
            BindingControls.Add(cbxNote2);

            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            if (!(Note1Enable || Note2Enable))
            {
                lbNote1.Visible = Note1Enable;
                lbNote2.Visible = Note2Enable;
                cbxNote1.Visible = Note1Enable;
                cbxNote1.Enabled = Note1Enable;
                cbxNote2.Visible = Note2Enable;
                cbxNote2.Enabled = Note2Enable;
                float percent = 100f / tableLayoutPanel1.RowStyles.Count;
                for (int i = 0; i < tableLayoutPanel1.RowStyles.Count; i++)
                {
                    if (i != RowIndex)
                        tableLayoutPanel1.RowStyles[i].Height = percent;
                    else
                        tableLayoutPanel1.RowStyles[i].Height = 0;
                }
                this.Size = new Size(this.Size.Width, tableLayoutPanel1.Size.Height + 20);
            }
            else
            {
                if (Note1Enable)
                {
                    string Note1Label = acg.GetConfig("Note1Label").Value;
                    lbNote1.Text = Note1Label;
                    cbxNote1.Tag = Note1Label;
                }
                if (Note2Enable)
                {
                    string Note2Label = acg.GetConfig("Note2Label").Value;
                    lbNote2.Text = Note2Label;
                    cbxNote2.Tag = Note2Label;
                }
            }
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

        private void FRM62N_IMPORT_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxNobr);
            cc.AddControl(cbxYymm);
            cc.AddControl(cbxSeq);
            cc.AddControl(cbxFormat);
            //cc.AddControl(cbxWCode);
            cc.AddControl(cbxD_Amt);
            cc.AddControl(cbAmt);
        }
    }
    public class WelfImport : JBControls.ImportTransfer
    {
        //public int TW_TAX_AUTO = -1;
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM62N", MainForm.COMPANY);
        public List<JBModule.Data.Linq.BASETTS> bASETTs = new List<JBModule.Data.Linq.BASETTS>();
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";

            foreach (DataColumn dc in TargetRow.Table.Columns)
            {
                if (SourceRow.Table.Columns.Contains(dc.ColumnName))
                    TargetRow[dc.ColumnName] = SourceRow[dc.ColumnName];
            }

            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            string Note1Label = acg.GetConfig("Note1Label").Value;
            string Note2Label = acg.GetConfig("Note2Label").Value;
            string Note1Type = acg.GetConfig("Note1Type").Value.ToUpper();
            string Note2Type = acg.GetConfig("Note2Type").Value.ToUpper();

            if (Note1Enable && Note1Type == "COMBOBOX" && CheckData.ContainsKey(Note1Label) && CheckData[Note1Label].Count > 0)
            {
                if (ColumnValidate(TargetRow, Note1Label, TransferCheckDataField.RealCode, out Msg))
                {
                    TargetRow[Note1Label] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += Msg;
                    }
                }
            }
            if (Note2Enable && Note2Type == "COMBOBOX" && CheckData.ContainsKey(Note2Label) && CheckData[Note2Label].Count > 0)
            {
                if (ColumnValidate(TargetRow, Note2Label, TransferCheckDataField.RealCode, out Msg))
                {
                    TargetRow[Note2Label] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] += Msg;
                    }
                }
            }

            //if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.RealCode, out Msg))
            //{
            //    TargetRow["員工編號"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] += Msg;
            //    }
            //}
            //if (ColumnValidate(TargetRow, "所得格式", TransferCheckDataField.RealCode, out Msg))
            //{
            //    TargetRow["所得格式"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] += Msg;
            //    }
            //}
            //if (ColumnValidate(TargetRow, "福利金代號", TransferCheckDataField.RealCode, out Msg))
            //{
            //    TargetRow["公司"] = Msg;
            //}
            //else
            //{
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["錯誤註記"] += Msg;
            //    }
            //}
            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            try
            {
                JBModule.Data.Linq.WELF item = new JBModule.Data.Linq.WELF();
                bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
                bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
                string Note1Label = acg.GetConfig("Note1Label").Value;
                string Note2Label = acg.GetConfig("Note2Label").Value;
                if (Note1Enable)
                    item.Note1 = TransferRow.Table.Columns.Contains(Note1Label) ? TransferRow[Note1Label].ToString() : string.Empty;
                if (Note2Enable)
                    item.Note2 = TransferRow.Table.Columns.Contains(Note2Label) ? TransferRow[Note2Label].ToString() : string.Empty;
                item.NOBR = TransferRow["員工編號"].ToString();
                item.YYMM = TransferRow["所得年月"].ToString();
                int YYYY = int.Parse(item.YYMM.Substring(0, 4));
                int MM = int.Parse(item.YYMM.Substring(4, 2));
                DateTime CheckDate = new DateTime(YYYY, MM, 1).AddMonths(1).AddDays(-1);
                var sql = from a in bASETTs where a.NOBR == item.NOBR && CheckDate >= a.ADATE && CheckDate <= a.DDATE.Value select a;
                if (sql.Any())
                    item.SALADR = sql.First().SALADR;
                if (!MainForm.WriteDataGroups.Contains(item.SALADR.ToString()))
                    item.SALADR = MainForm.WriteDataGroups.First();
                item.SEQ = TransferRow["期別"].ToString();
                item.FORMAT = TransferRow["所得格式"].ToString();
                item.AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["給付總額"]));
                item.D_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["扣繳稅額"]));
                item.SAL_CODE = TransferRow["福利金代號"] != null ? TransferRow["福利金代號"].ToString() : String.Empty;
                item.TR_TYPE = "1";
                item.KEY_DATE = DateTime.Now;
                item.KEY_MAN = MainForm.USER_NAME;
                //item.PID = TW_TAX_AUTO;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                db.WELF.InsertOnSubmit(item);
                db.SubmitChanges();
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
