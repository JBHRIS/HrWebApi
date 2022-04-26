using JBHR.Sal.Core;
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
    public partial class FRM63N1_ADD : JBControls.JBForm
    {
        public FRM63N1_ADD()
        {
            InitializeComponent();
        }
        int RowIndex = 6;//動態欄位的Row Index
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        CheckControl cc;//必填欄位
        public int TW_TAX_ITEM_AUTO = -1;
        public int TW_TAX_AUTO = -1;
        JBModule.Data.Linq.TW_TAX_ITEM instance = new JBModule.Data.Linq.TW_TAX_ITEM();
        JBModule.Data.Linq.TW_TAX_ITEM instanceCopy = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM63N1", MainForm.COMPANY);
        bool Note1Enable = false;
        bool Note2Enable = false;
        string Note1Label = "Note1";
        string Note2Label = "Note2";
        string Note1Type = "String";
        string Note2Type = "String";
        string Note1DefaultBinding = string.Empty;
        string Note2DefaultBinding = string.Empty;
        string Note1DataSource = string.Empty;
        string Note2DataSource = string.Empty;
        JBControls.TextBox txtNote1 = new JBControls.TextBox();
        ComboBox cbxNote1 = new ComboBox();
        JBControls.TextBox txtNote2 = new JBControls.TextBox();
        ComboBox cbxNote2 = new ComboBox();
        bool CloseOnSave = true;

        private void FRM63N1_ADD_Load(object sender, EventArgs e)
        {
            this.tBASETableAdapter.Fill(this.medDS.TBASE);
            SystemFunction.SetComboBoxItems(cbxComp, CodeFunction.GetComp(), false, true);
            SystemFunction.SetComboBoxItems(cbxFormat, CodeFunction.GetFormat(), false, true);

            initialNoteControls();

            CYYMMFC.AddControl(txtYYMM, true);
            cc = new CheckControl();
            cc.AddControl(ptxNobr);
            cc.AddControl(txtSeq);
            cc.AddControl(cbxComp);
            cc.AddControl(cbxFormat);

            if (TW_TAX_ITEM_AUTO == -1)
            {
                SalaryDate sd = new SalaryDate(DateTime.Today);
                instance = new JBModule.Data.Linq.TW_TAX_ITEM
                {
                    NOBR = string.Empty,
                    YYMM = sd.YYMM,
                    SEQ = "2",
                    COMP = string.Empty,
                    FORMAT = "50",
                    SUBCODE = 0,
                    SAL_CODE = string.Empty,
                    FORSUB = string.Empty,
                    AMT = 0,
                    D_AMT = 0,
                    RET_AMT = 0,
                    MEMO = string.Empty,
                    IMPORT = false,
                    SUP_AMT = 0,
                    TAXNO = string.Empty,
                    TR_TYPE = string.Empty,
                    INA_ID = string.Empty,
                    IS_FILE = false,
                    Note1 = string.Empty,
                    Note2 = string.Empty,
                    KEY_DATE = DateTime.Now,
                    KEY_MAN = MainForm.USER_NAME,
                    PID = TW_TAX_AUTO,
                };
            }
            else
            {
                instance = db.TW_TAX_ITEM.SingleOrDefault(p => p.AUTO == TW_TAX_ITEM_AUTO);
                ptxNobr.Enabled = false;
            }


            if (instance == null)
            {
                MessageBox.Show("查無資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            ptxNobr.Text = instance.NOBR;
            txtYYMM.Text = instance.YYMM;
            txtSeq.Text = instance.SEQ;
            cbxComp.SelectedValue = instance.COMP;
            cbxFormat.SelectedValue = instance.FORMAT;
            cbxForsub.SelectedValue = instance.SUBCODE == 0 ? "" : instance.SUBCODE.ToString();
            txtAMT.Text = JBModule.Data.CDecryp.Number(instance.AMT).ToString();
            txtD_AMT.Text = JBModule.Data.CDecryp.Number(instance.D_AMT).ToString();
            txtSUP_AMT.Text = JBModule.Data.CDecryp.Number(instance.SUP_AMT).ToString();
            txtRET_AMT.Text = JBModule.Data.CDecryp.Number(instance.RET_AMT).ToString();
            chkIS_FILE.Checked = instance.IS_FILE;
            txtMemo.Text = instance.MEMO;
            txtTAXNO.Text = instance.TAXNO;
            txtNote1.Text = instance.Note1;
            txtNote2.Text = instance.Note2;
            cbxNote1.SelectedValue = instance.Note1;
            cbxNote2.SelectedValue = instance.Note2;
            btnCopy.Visible = !CloseOnSave;
        }

        private void initialNoteControls()
        {
            CloseOnSave = acg.GetConfig("FRM63N1_ADD_CloseOnSave").Value.ToUpper() == "FALSE" ? false : true;
            Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            Note1Label = acg.GetConfig("Note1Label").Value;
            Note2Label = acg.GetConfig("Note2Label").Value;
            Note1Type = acg.GetConfig("Note1Type").Value.ToUpper();
            Note2Type = acg.GetConfig("Note2Type").Value.ToUpper();
            Note1DefaultBinding = acg.GetConfig("Note1DefaultBinding").GetString(string.Empty);
            Note2DefaultBinding = acg.GetConfig("Note2DefaultBinding").GetString(string.Empty);
            Note1DataSource = acg.GetConfig("Note1DataSource").GetString(string.Empty);
            if (!string.IsNullOrEmpty(Note1DataSource))
                SystemFunction.SetComboBoxItems(cbxNote1, (FRM63N1.GetDataSource(db, Note1DataSource) as Dictionary<string, string>), true, true, true);
            Note2DataSource = acg.GetConfig("Note2DataSource").GetString(string.Empty);
            if (!string.IsNullOrEmpty(Note2DataSource))
                SystemFunction.SetComboBoxItems(cbxNote2, (FRM63N1.GetDataSource(db, Note2DataSource) as Dictionary<string, string>), true, true, true);
            lbNote1.Text = Note1Label;
            lbNote2.Text = Note2Label;
            lbNote1.Visible = Note1Enable;
            txtNote1.Visible = Note1Enable;
            lbNote2.Visible = Note2Enable;
            txtNote2.Visible = Note2Enable;
            txtNote1.ValidType = StringConvertToVailType(Note1Type);
            txtNote2.ValidType = StringConvertToVailType(Note2Type);
            cbxNote1.Visible = Note1Enable;
            cbxNote2.Visible = Note2Enable;
            txtNote1.TabIndex = 14;
            cbxNote1.TabIndex = 14;
            txtNote2.TabIndex = 15;
            cbxNote2.TabIndex = 15;
            if (!(Note1Enable || Note2Enable))
            {
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
                if (Note1Type == "COMBOBOX")
                {
                    cbxNote1.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(cbxNote1, 1, 6);
                    tableLayoutPanel1.SetColumnSpan(cbxNote1, 2);
                }
                else
                {
                    txtNote1.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(txtNote1, 1, 6);
                    tableLayoutPanel1.SetColumnSpan(txtNote1, 2);
                }
                if (Note2Type == "COMBOBOX")
                {
                    cbxNote2.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(cbxNote2, 4, 6);
                    tableLayoutPanel1.SetColumnSpan(cbxNote2, 3);
                }
                else
                {
                    txtNote2.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(txtNote2, 4, 6);
                    tableLayoutPanel1.SetColumnSpan(txtNote2, 3);

                }
            }
        }
        private JBControls.TextBox.EValidType StringConvertToVailType(string value)
        {
            JBControls.TextBox.EValidType eValidType = JBControls.TextBox.EValidType.String;
            switch (value)
            {
                case "DATETIME":
                    eValidType = JBControls.TextBox.EValidType.DateTime;
                    break;
                case "DATE":
                    eValidType = JBControls.TextBox.EValidType.Date;
                    break;
                case "TIME":
                    eValidType = JBControls.TextBox.EValidType.Time;
                    break;
                case "INTERGER":
                    eValidType = JBControls.TextBox.EValidType.Integer;
                    break;
                case "DECIMAL":
                    eValidType = JBControls.TextBox.EValidType.Decimal;
                    break;
                case "BOOLEAN":
                    eValidType = JBControls.TextBox.EValidType.Boolean;
                    break;
            }
            return eValidType;
        }
        private void cbxFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            var source = CodeFunction.GetForsub(cbxFormat.SelectedValue.ToString());
            SystemFunction.SetComboBoxItems(cbxForsub, source, source.Count > 0 ? false : true);
            cbxForsub.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            var control = CYYMMFC.CheckRequiredFields();
            if (control != null)
            {
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                control.Focus();
                return;
            }
            string Nobr = ptxNobr.Text;
            string YYMM = txtYYMM.Text;
            string SEQ = txtSeq.Text;
            string COMP = cbxComp.SelectedValue.ToString();
            string FORMAT = cbxFormat.SelectedValue.ToString();
            var subcode = db.TW_TAX_SUBCODE.Where(p => p.AUTO == instance.SUBCODE).FirstOrDefault();
            string M_FORSUB = string.Empty;
            if (subcode != null)
                M_FORSUB = subcode.M_FORSUB;
            int subcodekey = Convert.ToInt32(string.IsNullOrEmpty(cbxForsub.SelectedValue.ToString()) ? "0" : cbxForsub.SelectedValue.ToString());
            decimal AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAMT.Text));
            decimal D_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtD_AMT.Text));
            decimal SUP_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtSUP_AMT.Text));
            decimal RET_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtRET_AMT.Text));
            bool IS_FILE = chkIS_FILE.Checked;
            string TAXNO = txtTAXNO.Text;
            string MEMO = txtMemo.Text;
            string Note1 = Note1Type == "COMBOBOX" ? cbxNote1.SelectedValue.ToString() : txtNote1.Text;
            string Note2 = Note2Type == "COMBOBOX" ? cbxNote2.SelectedValue.ToString() : txtNote2.Text;
            string action = "Insert";

            bool changed = false;
            if (TW_TAX_ITEM_AUTO != -1)
            {
                changed = instance.NOBR != Nobr || changed;
                changed = instance.YYMM != YYMM || changed;
                changed = instance.SEQ != SEQ || changed;
                changed = instance.FORMAT != FORMAT || changed;
                changed = instance.SUBCODE != subcodekey || changed;
            }
            else
                changed = true;

            var re_instance = db.TW_TAX_ITEM.Where(p => p.PID == TW_TAX_AUTO && p.AUTO != TW_TAX_ITEM_AUTO && p.NOBR == Nobr && p.YYMM == YYMM && p.SEQ == SEQ && p.FORMAT == FORMAT && p.SUBCODE == subcodekey);
            if (changed && re_instance.Any())
            {
                string re_string1 = string.Format("員工編號{0}已有計薪年月{1}期別{2}所得格式{3}", Nobr, YYMM, SEQ, FORMAT);
                string re_string2 = instance.SUBCODE != 0 ? string.Format("所得註記{0}", M_FORSUB) : string.Empty;
                string re_string3 = string.Format("的資料,是否要進行覆蓋.");
                if (MessageBox.Show(re_string1 + re_string2 + re_string3, "資料重覆", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                instance = re_instance.FirstOrDefault();
                action = "Update";
            }
            else if (TW_TAX_ITEM_AUTO == -1)
                db.TW_TAX_ITEM.InsertOnSubmit(instance);

            instance.NOBR = Nobr;
            instance.YYMM = YYMM;
            instance.SEQ = SEQ;
            instance.COMP = COMP;
            instance.FORMAT = FORMAT;
            instance.SUBCODE = subcodekey;
            instance.FORSUB = M_FORSUB;
            instance.AMT = AMT;
            instance.D_AMT = D_AMT;
            instance.SUP_AMT = SUP_AMT;
            instance.RET_AMT = RET_AMT;
            instance.IS_FILE = IS_FILE;
            instance.TAXNO = TAXNO;
            instance.MEMO = MEMO;
            instance.Note1 = Note1;
            instance.Note2 = Note2;
            instance.KEY_MAN = MainForm.USER_NAME;
            instance.KEY_DATE = DateTime.Now;
            instanceCopy = instance.Clone();
            db.SubmitChanges();
            JBModule.Message.DbLog.WriteLog(action, instance, this.Name, instance.AUTO);
            if (CloseOnSave || TW_TAX_ITEM_AUTO != -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lbMessage.Text = "存檔完成!";
                SalaryDate sd = new SalaryDate(DateTime.Today);
                instance = new JBModule.Data.Linq.TW_TAX_ITEM
                {
                    NOBR = string.Empty,
                    YYMM = sd.YYMM,
                    SEQ = "2",
                    COMP = string.Empty,
                    FORMAT = "50",
                    SUBCODE = 0,
                    SAL_CODE = string.Empty,
                    FORSUB = string.Empty,
                    AMT = 0,
                    D_AMT = 0,
                    RET_AMT = 0,
                    MEMO = string.Empty,
                    IMPORT = false,
                    SUP_AMT = 0,
                    TAXNO = string.Empty,
                    TR_TYPE = string.Empty,
                    INA_ID = string.Empty,
                    IS_FILE = false,
                    Note1 = string.Empty,
                    Note2 = string.Empty,
                    KEY_DATE = DateTime.Now,
                    KEY_MAN = MainForm.USER_NAME,
                    PID = TW_TAX_AUTO,
                };
                ptxNobr.Text = instance.NOBR;
                txtYYMM.Text = instance.YYMM;
                txtSeq.Text = instance.SEQ;
                cbxComp.SelectedValue = instance.COMP;
                cbxFormat.SelectedValue = instance.FORMAT;
                cbxForsub.SelectedValue = instance.SUBCODE == 0 ? "" : instance.SUBCODE.ToString();
                txtAMT.Text = JBModule.Data.CDecryp.Number(instance.AMT).ToString();
                txtD_AMT.Text = JBModule.Data.CDecryp.Number(instance.D_AMT).ToString();
                txtSUP_AMT.Text = JBModule.Data.CDecryp.Number(instance.SUP_AMT).ToString();
                txtRET_AMT.Text = JBModule.Data.CDecryp.Number(instance.RET_AMT).ToString();
                chkIS_FILE.Checked = instance.IS_FILE;
                txtMemo.Text = instance.MEMO;
                txtTAXNO.Text = instance.TAXNO;
                txtNote1.Text = instance.Note1;
                txtNote2.Text = instance.Note2;
                cbxNote1.SelectedValue = instance.Note1;
                cbxNote2.SelectedValue = instance.Note2;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            lbMessage.Text = string.Empty;
            if (TW_TAX_ITEM_AUTO == -1 && Note1Enable)
            {
                if (Note1Type == "COMBOBOX")
                    cbxNote1.SelectedValue = FRM63N1.GetDefaultBinding(db, Note1DefaultBinding, ptxNobr.Text);
                else
                    txtNote1.Text = FRM63N1.GetDefaultBinding(db, Note1DefaultBinding, ptxNobr.Text);
            }
            if (TW_TAX_ITEM_AUTO == -1 && Note2Enable)
            {
                if (Note2Type == "COMBOBOX")
                    cbxNote2.SelectedValue = FRM63N1.GetDefaultBinding(db, Note2DefaultBinding, ptxNobr.Text);
                else
                    txtNote2.Text = FRM63N1.GetDefaultBinding(db, Note2DefaultBinding, ptxNobr.Text);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (instanceCopy != null)
            {
                //ptxNobr.Text = instanceCopy.NOBR;
                txtYYMM.Text = instanceCopy.YYMM;
                txtSeq.Text = instanceCopy.SEQ;
                cbxComp.SelectedValue = instanceCopy.COMP;
                cbxFormat.SelectedValue = instanceCopy.FORMAT;
                cbxForsub.SelectedValue = instanceCopy.SUBCODE == 0 ? "" : instanceCopy.SUBCODE.ToString();
                txtAMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.AMT).ToString();
                txtD_AMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.D_AMT).ToString();
                txtSUP_AMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.SUP_AMT).ToString();
                txtRET_AMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.RET_AMT).ToString();
                chkIS_FILE.Checked = instanceCopy.IS_FILE;
                txtMemo.Text = instanceCopy.MEMO;
                txtTAXNO.Text = instanceCopy.TAXNO;
                txtNote1.Text = instanceCopy.Note1;
                txtNote2.Text = instanceCopy.Note2;
                cbxNote1.SelectedValue = instanceCopy.Note1;
                cbxNote2.SelectedValue = instanceCopy.Note2;
                ptxNobr.Focus();
            }
            else
            {
                MessageBox.Show("尚未有存檔資料可以複製.");
            }
        }
    }
}
