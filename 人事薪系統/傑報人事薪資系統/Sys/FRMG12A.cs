using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class FRMG12A : JBControls.JBForm
    {
        public FRMG12A()
        {
            InitializeComponent();
        }

        private void FRMG12A_Load(object sender, EventArgs e)
        {
            var lst = CodeFunction.GetDatagroup();
            SystemFunction.SetComboBoxItems(comboBox1, lst);
            SystemFunction.SetComboBoxItems(comboBox2, lst);
            comboBox1.SelectedValue = lst.First().Key;
            comboBox2.SelectedValue = lst.Last().Key;
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Today, true);
            textBox1.Text = sd.YYMM;
            maskedTextBox2.Text = "2";
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var lst = from a in MainForm.WriteRules where a.DATAGROUP.CompareTo(comboBox1.SelectedValue.ToString()) >= 0 && a.DATAGROUP.CompareTo(comboBox2.SelectedValue.ToString()) <= 0 select a;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var qq = (from a in db.LOCK_WAGE where a.YYMM == textBox1.Text && a.SEQ == maskedTextBox2.Text select a.SALADR).ToList();
            foreach (var it in lst)
            {
                if (!qq.Contains(it.DATAGROUP))
                {
                    JBModule.Data.Linq.LOCK_WAGE lw = new JBModule.Data.Linq.LOCK_WAGE();
                    lw.KEY_DATE = DateTime.Now;
                    lw.KEY_MAN = MainForm.USER_NAME;
                    lw.MENO = MEMOTextBox.Text;
                    lw.SALADR = it.DATAGROUP;
                    lw.SEQ = maskedTextBox2.Text;
                    lw.YYMM = textBox1.Text;
                    db.LOCK_WAGE.InsertOnSubmit(lw);
                }
            }
            db.SubmitChanges();
            MessageBox.Show("鎖檔完成!!", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
