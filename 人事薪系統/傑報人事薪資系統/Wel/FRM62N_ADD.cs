﻿using JBHR.Sal.Core;
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
    public partial class FRM62N_ADD : JBControls.JBForm
    {
        public FRM62N_ADD()
        {
            InitializeComponent();
        }
        int RowIndex = 3;//動態欄位的Row Index
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        CheckControl cc;//必填欄位
        public int Welf_ID = -1;
        public JBModule.Data.Linq.WELF instance = new JBModule.Data.Linq.WELF();
        JBModule.Data.Linq.WELF instanceCopy = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM62N", MainForm.COMPANY);
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

        private void FRM62N_ADD_Load(object sender, EventArgs e)
        {
            this.tBASETableAdapter.Fill(this.medDS.TBASE);
            //SystemFunction.SetComboBoxItems(cbxFormat, CodeFunction.GetFormat(), false, true);
            Dictionary<string, string> formatList = new Dictionary<string, string>
            {
                { "91", "91-競技競賽及機會中獎獎金" },
                { "92", "92 8A-職工福利金" }
            };
            SystemFunction.SetComboBoxItems(cbxFormat, formatList, false, true);
            SystemFunction.SetComboBoxItems(cbxWCode, CodeFunction.GetWcode(), true, true);

            initialNoteControls();

            CYYMMFC.AddControl(txtYYMM, true);
            cc = new CheckControl();
            cc.AddControl(ptxNobr);
            cc.AddControl(txtSeq);
            cc.AddControl(cbxFormat);

            if (Welf_ID == -1)
            {
                SalaryDate sd = new SalaryDate(DateTime.Today);
                instance = new JBModule.Data.Linq.WELF
                {
                    NOBR = string.Empty,
                    YYMM = sd.YYMM,
                    SEQ = "2",
                    FORMAT = "92",
                    SAL_CODE = string.Empty,
                    AMT = 0,
                    D_AMT = 0,
                    TR_TYPE = string.Empty,
                    Note1 = string.Empty,
                    Note2 = string.Empty,
                    KEY_DATE = DateTime.Now,
                    KEY_MAN = MainForm.USER_NAME,
                    SALADR = String.Empty,
                    COMP = String.Empty,
                    DATE_B = new DateTime(1900, 1, 1),
                    DATE_E = new DateTime(1900, 1, 1),
                };
            }
            else
            {
                instance = db.WELF.SingleOrDefault(p => p.AUTO == Welf_ID);
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
            cbxFormat.SelectedValue = instance.FORMAT;
            txtAMT.Text = JBModule.Data.CDecryp.Number(instance.AMT).ToString();
            txtD_AMT.Text = JBModule.Data.CDecryp.Number(instance.D_AMT).ToString();
            cbxWCode.SelectedValue = instance.SAL_CODE;
            txtNote1.Text = instance.Note1;
            txtNote2.Text = instance.Note2;
            cbxNote1.SelectedValue = instance.Note1;
            cbxNote2.SelectedValue = instance.Note2;
            btnCopy.Visible = !CloseOnSave;
        }
        //動態Note initial Function
        private void initialNoteControls()
        {
            CloseOnSave = acg.GetConfig("FRM62N_ADD_CloseOnSave").Value.ToUpper() == "FALSE" ? false : true;
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
                SystemFunction.SetComboBoxItems(cbxNote1, (Med.FRM71N1.GetDataSource(db, Note1DataSource) as Dictionary<string, string>), true, true, true);
            Note2DataSource = acg.GetConfig("Note2DataSource").GetString(string.Empty);
            if (!string.IsNullOrEmpty(Note2DataSource))
                SystemFunction.SetComboBoxItems(cbxNote2, (Med.FRM71N1.GetDataSource(db, Note2DataSource) as Dictionary<string, string>), true, true, true);
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
                    tableLayoutPanel1.Controls.Add(cbxNote1, 1, RowIndex);
                    tableLayoutPanel1.SetColumnSpan(cbxNote1, 2);
                }
                else
                {
                    txtNote1.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(txtNote1, 1, RowIndex);
                    tableLayoutPanel1.SetColumnSpan(txtNote1, 2);
                }
                if (Note2Type == "COMBOBOX")
                {
                    cbxNote2.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(cbxNote2, 4, RowIndex);
                    tableLayoutPanel1.SetColumnSpan(cbxNote2, 3);
                }
                else
                {
                    txtNote2.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(txtNote2, 4, RowIndex);
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
            int YYYY = int.Parse(YYMM.Substring(0, 4));
            int MM = int.Parse(YYMM.Substring(4,2));
            string SEQ = txtSeq.Text;
            string FORMAT = cbxFormat.SelectedValue.ToString();
            string SAL_CODE = cbxWCode.SelectedValue.ToString();
            SalaryDate sd = new SalaryDate(YYMM);
            //DateTime CheckDate = new DateTime(YYYY, MM, 1).AddMonths(1).AddDays(-1);
            DateTime CheckDate = sd.LastDayOfSalary;
            decimal AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAMT.Text));
            decimal D_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtD_AMT.Text));
            string Note1 = Note1Type == "COMBOBOX" ? cbxNote1.SelectedValue.ToString() : txtNote1.Text;
            string Note2 = Note2Type == "COMBOBOX" ? cbxNote2.SelectedValue.ToString() : txtNote2.Text;
            string SALADR = string.Empty;
            var sql = from a in db.BASETTS where a.NOBR == Nobr && CheckDate >= a.ADATE && CheckDate <= a.DDATE.Value select a;
            string COMP = MainForm.COMPANY;
            if (sql.Any())
            {
                SALADR = sql.First().SALADR;
                COMP = sql.First().COMP;
            }
            if (!MainForm.WriteDataGroups.Contains(SALADR.ToString()))
                SALADR = MainForm.WriteDataGroups.First();
            string action = "Update";
            DateTime DATE_B = sd.FirstDayOfSalary;
            DateTime DATE_E = sd.LastDayOfSalary;
            //bool changed = false;
            //if (Welf_ID != -1)
            //{
            //    changed = instance.NOBR != Nobr || changed;
            //    changed = instance.YYMM != YYMM || changed;
            //    changed = instance.SEQ != SEQ || changed;
            //    changed = instance.FORMAT != FORMAT || changed;
            //}
            //else
            //    changed = true;
            //var re_instance = db.WELF.Where(p => p.AUTO != Welf_ID && p.NOBR == Nobr && p.YYMM == YYMM && p.SEQ == SEQ && p.FORMAT == FORMAT);
            //if (changed && re_instance.Any())
            //{
            //    //string re_string1 = string.Format("員工編號{0}已有計薪年月{1}期別{2}所得格式{3}", Nobr, YYMM, SEQ, FORMAT);
            //    ////string re_string2 = instance.SUBCODE != 0 ? string.Format("所得註記{0}", M_FORSUB) : string.Empty;
            //    //string re_string3 = string.Format("的資料,是否要進行覆蓋.");
            //    //if (MessageBox.Show(re_string1 + re_string3, "資料重覆", MessageBoxButtons.YesNo) == DialogResult.No)
            //    //    return;
            //    instance = re_instance.FirstOrDefault();
            //    action = "Update";
            //}
            //else 
            if (Welf_ID == -1)
            {
                db.WELF.InsertOnSubmit(instance);
                action = "Insert";
            }

            instance.NOBR = Nobr;
            instance.YYMM = YYMM;
            instance.SEQ = SEQ;
            instance.FORMAT = FORMAT;
            instance.AMT = AMT;
            instance.D_AMT = D_AMT;
            instance.SAL_CODE = SAL_CODE;
            instance.Note1 = Note1;
            instance.Note2 = Note2;
            instance.KEY_MAN = MainForm.USER_NAME;
            instance.KEY_DATE = DateTime.Now;
            instance.SALADR = SALADR;
            instance.COMP = COMP;
            instance.DATE_B = DATE_B;
            instance.DATE_E = DATE_E;
            instanceCopy = instance.Clone();
            db.SubmitChanges();
            JBModule.Message.DbLog.WriteLog(action, instance, this.Name, instance.AUTO);
            if (CloseOnSave || Welf_ID != -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lbMessage.Text = "存檔完成!";
                sd = new SalaryDate(DateTime.Today);
                instance = new JBModule.Data.Linq.WELF
                {
                    NOBR = string.Empty,
                    YYMM = sd.YYMM,
                    SEQ = "2",
                    FORMAT = "92",
                    SAL_CODE = string.Empty,
                    AMT = 0,
                    D_AMT = 0,
                    TR_TYPE = "1",
                    Note1 = string.Empty,
                    Note2 = string.Empty,
                    KEY_DATE = DateTime.Now,
                    KEY_MAN = MainForm.USER_NAME,
                    SALADR = String.Empty,
                    AUTO = Welf_ID,
                    COMP = String.Empty,
                    DATE_B = new DateTime(1900, 1, 1),
                    DATE_E = new DateTime(1900, 1, 1),
                };
                ptxNobr.Text = instance.NOBR;
                txtYYMM.Text = instance.YYMM;
                txtSeq.Text = instance.SEQ;
                txtAMT.Text = JBModule.Data.CDecryp.Number(instance.AMT).ToString();
                txtD_AMT.Text = JBModule.Data.CDecryp.Number(instance.D_AMT).ToString();
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
            if (Welf_ID == -1 && Note1Enable)
            {
                if (Note1Type == "COMBOBOX")
                    cbxNote1.SelectedValue = Med.FRM71N1.GetDefaultBinding(db, Note1DefaultBinding, ptxNobr.Text);
                else
                    txtNote1.Text = Med.FRM71N1.GetDefaultBinding(db, Note1DefaultBinding, ptxNobr.Text);
            }
            if (Welf_ID == -1 && Note2Enable)
            {
                if (Note2Type == "COMBOBOX")
                    cbxNote2.SelectedValue = Med.FRM71N1.GetDefaultBinding(db, Note2DefaultBinding, ptxNobr.Text);
                else
                    txtNote2.Text = Med.FRM71N1.GetDefaultBinding(db, Note2DefaultBinding, ptxNobr.Text);
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (instanceCopy != null)
            {
                //ptxNobr.Text = instanceCopy.NOBR;
                txtYYMM.Text = instanceCopy.YYMM;
                txtSeq.Text = instanceCopy.SEQ;
                cbxFormat.SelectedValue = instanceCopy.FORMAT;
                txtAMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.AMT).ToString();
                txtD_AMT.Text = JBModule.Data.CDecryp.Number(instanceCopy.D_AMT).ToString();
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
