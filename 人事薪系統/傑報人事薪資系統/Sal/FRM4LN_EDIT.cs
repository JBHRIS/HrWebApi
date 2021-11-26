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
    public partial class FRM4LN_EDIT : Form
    {
        public FRM4LN_EDIT()
        {
            InitializeComponent();
        }
        public int ID = -1;
        public JBModule.Data.Linq.ENRICH instance;
        private void FRM4LN_ADD_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'basDS.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), true, false, true);
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(""), true, false, true);
            //SystemFunction.SetComboBoxItems(comboBoxContract, CodeFunction.GetContractAll(), true);
            Init();
        }
        void Init()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = db.ENRICH.Where(p => p.AUTOKEY == ID);
            if (sql.Any())
            {
                instance = sql.First();
                ptxNobr.Text = instance.NOBR;
                SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(instance.NOBR), true);
                txtYymm.Text = instance.YYMM;
                txtSeq.Text = instance.SEQ;
                txtMemo.Text = instance.MEMO;
                txtAmt.Text = JBModule.Data.CDecryp.Number(instance.AMT).ToString();
                ptxSalcode.SelectedValue = instance.SAL_CODE;
            }
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(e.code), true, true);
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

            instance.AMT = Convert.ToDecimal(txtAmt.Text);
            instance.FA_IDNO = cbFA_IDNO.SelectedValue != null ? cbFA_IDNO.SelectedValue.ToString() : "";
            instance.IMPORT = false;
            instance.KEY_DATE = DateTime.Now;
            instance.KEY_MAN = MainForm.USER_NAME;
            instance.MEMO = txtMemo.Text;
            instance.NOBR = ptxNobr.Text;
            instance.SAL_CODE = ptxSalcode.SelectedValue.ToString();
            instance.SEQ = txtSeq.Text;
            instance.YYMM = txtYymm.Text;
            JBModule.Data.Repo.EnrichRepo rp = new JBModule.Data.Repo.EnrichRepo();
            string msg = "";
            if (rp.UpdateEnrich(instance, out msg))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("儲存失敗，" + msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
    }
}
