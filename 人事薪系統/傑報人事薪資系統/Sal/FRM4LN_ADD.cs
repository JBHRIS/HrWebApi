using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4LN_ADD : Form
    {
        public FRM4LN_ADD()
        {
            InitializeComponent();
        }

        private void FRM4LN_ADD_Load(object sender, EventArgs e)
        {
            this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), true, true, true);
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(""), true, false, true);
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(e.code), true, true, true);
                cbFA_IDNO.Focus();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ptxNobr.Text.Trim().Length == 0)
            {
                MessageBox.Show("員工工號不可以是空白", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ptxNobr.Focus();
                return;
            }
            if (!JBTools.FormatValidate.CheckYearMonthFormat(txtYymm.Text))
            {
                MessageBox.Show("計薪年月格式不正確", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYymm.Focus();
                return;
            }
            if (ptxSalcode.SelectedValue == null || ptxSalcode.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("請選擇薪資代碼", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ptxSalcode.Focus();
                return;
            }
            JBModule.Data.Linq.ENRICH enrich = new JBModule.Data.Linq.ENRICH();
            enrich.AMT = Convert.ToDecimal(txtAmt.Text);
            enrich.FA_IDNO = cbFA_IDNO.SelectedValue != null ? cbFA_IDNO.SelectedValue.ToString() : "";
            enrich.IMPORT = false;
            enrich.KEY_DATE = DateTime.Now;
            enrich.KEY_MAN = MainForm.USER_NAME;
            enrich.MEMO = txtMemo.Text;
            enrich.NOBR = ptxNobr.Text;
            enrich.SAL_CODE = ptxSalcode.SelectedValue.ToString();
            enrich.SEQ = txtSeq.Text;
            enrich.YYMM = txtYymm.Text;
            JBModule.Data.Repo.EnrichRepo rp = new JBModule.Data.Repo.EnrichRepo();
            string msg = "";
            if (rp.InsertEnrich(enrich, out msg))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("儲存失敗，"+msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
