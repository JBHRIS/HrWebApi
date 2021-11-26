using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;

namespace JBHR.Sal
{
    public partial class FRM4IA : JBControls.JBForm
    {
        public FRM4IA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string NOBR_B, NOBR_E, DEPT_B, DEPT_E;

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (txtYymmB.Text != txtYymmE.Text)
            {
                DEPT_B = "0000000";
                DEPT_E = "ZZZZZZZ";
            }
            if (MessageBox.Show("是否要執行補充保費重算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            JBTools.Stopwatch sw = new JBTools.Stopwatch();
            sw.Start();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                      && c.D_NO.CompareTo(DEPT_B) >= 0 && c.D_NO.CompareTo(DEPT_E) <= 0
                      && a.YYMM.CompareTo(txtYymmB.Text) >= 0 && a.YYMM.CompareTo(txtYymmE.Text) <= 0
                      && a.SEQ.CompareTo(textBoxSeqB.Text) >= 0 && a.SEQ.CompareTo(textBoxSeqE.Text) <= 0
                      //&& (MainForm.PROCSUPER || MainForm.WORKADR == a.SALADR)
                       && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      group new { a.NOBR, a.YYMM, a.SEQ, a.ADATE, a.FORMAT } by new { a.YYMM, a.SEQ, a.ADATE };
            string nobr_b = NOBR_B;
            string nobr_e = NOBR_E;
            string dept_b = DEPT_B;
            string dept_e = DEPT_E;
            foreach (var it in sql.OrderBy(p => p.Key.ADATE))
            {
                string seq = it.Key.SEQ;
                string yymm = it.Key.YYMM;
                string type = it.First().FORMAT;
                SalaryDate sd = new SalaryDate(yymm);
                DateTime d1 = sd.FirstDayOfSalary;
                DateTime d2 = sd.LastDayOfSalary;
                DateTime a1 = sd.FirstDayOfAttend;
                DateTime a2 = sd.LastDayOfAttend;
                DateTime transDate = it.First().ADATE;
                DateTime inEdate = sd.LastDayOfMonth;
                bool Prev = false;

                SalaryCalculation sc = new SalaryCalculation
                      (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, " MainForm.WORKADR", false, false, type, Prev, inEdate);
                sc.isReExpsup = true;
                sc.ReLoadWaged();
                sc.DeleteExpSup();
                sc.CreateExpSup();
            }
            sw.Stop();
            sw.ShowMessage();
        }

        private void FRM4IA_Load(object sender, EventArgs e)
        {
            SalaryDate sd = new SalaryDate((DateTime.Now.Date), true);
            txtYymmB.Text = sd.YYMM;
            txtYymmE.Text = sd.YYMM;
            textBoxSeqB.Text = "2";
            textBoxSeqE.Text = "Z";
        }
    }
}
