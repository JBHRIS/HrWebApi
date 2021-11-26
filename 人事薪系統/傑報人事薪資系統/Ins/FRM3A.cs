using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace JBHR.Ins
{
    public partial class FRM3A : JBControls.JBForm
    {
        InsDataClassesDataContext db = new InsDataClassesDataContext();

        class param
        {
            public string YYMM1, YYMM2, SEQ1, SEQ2, NOBR1, NOBR2;
            public string INSCOMP1, INSCOMP2;
            public DateTime DDATE = new DateTime();
            public DateTime INDATE = new DateTime();
        }

        public FRM3A()
        {
            InitializeComponent();
            var InsCompData = CodeFunction.GetInsCompDisp();
            SystemFunction.SetComboBoxItems(cbxInsCompB, InsCompData, false, true, true);
            SystemFunction.SetComboBoxItems(cbxInsCompE, InsCompData, false, true, true);
            cbxInsCompB.SelectedValue = InsCompData.First().Key;
            cbxInsCompE.SelectedValue = InsCompData.Last().Key;
            Sal.Function.SetAvaliableVBase(this.insDS.V_BASE);
            string minNobr = this.insDS.V_BASE.First().NOBR.Trim();
            string minName_c = (from c in db.BASE where c.NOBR.Trim() == minNobr select c).First().NAME_C.Trim();

            string maxNobr = this.insDS.V_BASE.Last().NOBR.Trim();
            string maxName_c = (from c in db.BASE where c.NOBR.Trim() == maxNobr select c).First().NAME_C.Trim();

            txtMinNobr.Text = minNobr;
            txtMaxNobr.Text = maxNobr;
            lbMinName_C.Text = minName_c;
            lbMaxName_C.Text = maxName_c;
            txtSeq1.Text = "0";
            txtSeq2.Text = "Z";
            DateTime date = DateTime.Now.AddMonths(1);
            date = new DateTime(date.Year, date.Month, 1);
            txtChDate.Text = date.ToString("yyyyMMdd");
            txtInDate.Text = date.AddMonths(-4).ToString("yyyyMMdd");
            txtChDate_Validated(null, null);
        }

        private void txtMinNobr_Leave(object sender, EventArgs e)
        {
            var BASE = (from c in db.BASE where c.NOBR.Trim() == txtMinNobr.Text && db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value select c).FirstOrDefault();
            if (BASE != null)
            {
                lbMinName_C.Text = BASE.NAME_C.Trim();
            }
            else
            {
                lbMinName_C.Text = "";
                MessageBox.Show(Resources.Ins.NobrNotFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMaxNobr_Leave(object sender, EventArgs e)
        {
            var BASE = (from c in db.BASE where c.NOBR.Trim() == txtMaxNobr.Text && db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value select c).FirstOrDefault();
            if (BASE != null)
            {
                lbMaxName_C.Text = BASE.NAME_C.Trim();
            }
            else
            {
                lbMaxName_C.Text = "";
                MessageBox.Show(Resources.Ins.NobrNotFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fRM3AZBindingSource.Count; i++)
            {
                (fRM3AZBindingSource[i] as DataRowView).BeginEdit();
                (fRM3AZBindingSource[i] as DataRowView)["NOTTRAN"] = true;
                (fRM3AZBindingSource[i] as DataRowView).EndEdit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fRM3AZBindingSource.Count; i++)
            {
                (fRM3AZBindingSource[i] as DataRowView).BeginEdit();
                (fRM3AZBindingSource[i] as DataRowView)["NOTTRAN"] = false;
                (fRM3AZBindingSource[i] as DataRowView).EndEdit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            progressBar1.Value = 0;

            param p = new param();
            p.NOBR1 = txtMinNobr.Text;
            p.NOBR2 = txtMaxNobr.Text;
            p.YYMM1 = txtYYMM1.Text;
            p.YYMM2 = txtYYMM2.Text;
            p.SEQ1 = txtSeq1.Text;
            p.SEQ2 = txtSeq2.Text;
            p.DDATE = Convert.ToDateTime(txtChDate.Text);
            p.INDATE = Convert.ToDateTime(txtInDate.Text);
            p.INSCOMP1 = cbxInsCompB.SelectedValue.ToString();
            p.INSCOMP2 = cbxInsCompE.SelectedValue.ToString();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            if (ckBASIC.Checked)
                backgroundWorkerBasic.RunWorkerAsync(p);
            else
                backgroundWorker1.RunWorkerAsync(p);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.insDS.FRM3AZ.Clear();

            param p = e.Argument as param;

            //以最後一個月份做為基準日期
            string yy2, mm2;

            yy2 = p.YYMM2.Trim().Substring(0, 4);
            mm2 = p.YYMM2.Trim().Substring(4, 2);

            string date2 = yy2 + "/" + mm2 + "/" + DateTime.DaysInMonth(Convert.ToInt32(yy2), Convert.ToInt32(mm2)).ToString();

            //以基準日期挑出有效的級距
            INSURLV[] L_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(date2) >= c.EFF_DATEL && Convert.ToDateTime(date2) <= c.LFF_DATEL select c).ToArray();
            INSURLV[] H_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(date2) >= c.EFF_DATEH && Convert.ToDateTime(date2) <= c.LFF_DATEH select c).ToArray();
            INSURLV[] R_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(date2) >= c.EFF_DATER && Convert.ToDateTime(date2) <= c.LFF_DATER select c).ToArray();

            InsDataClassesDataContext db1 = new InsDataClassesDataContext();
            InsDataClassesDataContext db2 = new InsDataClassesDataContext();

            WAGED[] tbWaged_INS = null;
            WAGED[] tbWaged_RET = null;
            //全部
            if (radioButton1.Checked)
            {
                if (ckBASIC.Checked)
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
                else
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
            }
            //間接
            if (radioButton2.Checked)
            {
                if (ckBASIC.Checked)
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "I") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "I") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
                else
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "I") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "I") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
            }
            //直接
            if (radioButton3.Checked)
            {
                if (ckBASIC.Checked)
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "D") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "D") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
                else
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "D") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.BASE.COUNT_MA == false &&
                                   c.BASE.BASETTS.Any(rBaseTTS => Convert.ToDateTime(date2) >= rBaseTTS.ADATE && Convert.ToDateTime(date2) <= rBaseTTS.DDATE && rBaseTTS.DI.Trim().ToUpper() == "D") &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
            }
            //外勞
            if (radioButton4.Checked)
            {
                if (ckBASIC.Checked)
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
                else
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
            }
            //本勞
            if (radioButton5.Checked)
            {
                if (ckBASIC.Checked)
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && !c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE && c.SALCODE.SALATTR.BASIC &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && !c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
                else
                {
                    tbWaged_INS = (from c in db1.WAGED
                                   where c.SALCODE.INSLAB &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && !c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db1.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db1.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db1.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                    tbWaged_RET = (from c in db2.WAGED
                                   where c.SALCODE.RETIRE &&
                                   c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0 && !c.BASE.COUNT_MA &&
                                   c.BASE.BASETTS.Any(basetts => DateTime.Now.Date >= basetts.ADATE && DateTime.Now.Date <= basetts.DDATE && new string[] { "1", "4", "6" }.Contains(basetts.TTSCODE.Trim())) &&
                                   c.YYMM.Trim().CompareTo(p.YYMM1.Trim()) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM2.Trim()) <= 0 &&
                                   c.SEQ.Trim().CompareTo(p.SEQ1.Trim()) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ2.Trim()) <= 0
                                   //&& db2.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && (from bts in db2.BASETTS
                                       where bts.NOBR == c.NOBR
                                       && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                       && (from urdg in db2.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                       select 1).Any()
                                   select c).ToArray();
                }
            }

            backgroundWorker1.ReportProgress(10);

            //若有取得期間薪資的話
            if (tbWaged_INS != null || tbWaged_RET != null)
            {
                //將勞健保相關薪資解密
                foreach (var waged in tbWaged_INS)
                {
                    if (waged.AMT != 0)
                    {
                        waged.AMT = JBModule.Data.CDecryp.Number(waged.AMT);
                        if (waged.SALCODE.SALATTR.FLAG.Trim() == "-") waged.AMT *= -1;
                    }
                }
                backgroundWorker1.ReportProgress(20);

                //將勞退相關薪資解密
                foreach (var waged in tbWaged_RET)
                {
                    if (waged.AMT != 0)
                    {
                        waged.AMT = JBModule.Data.CDecryp.Number(waged.AMT);
                        if (waged.SALCODE.SALATTR.FLAG.Trim() == "-") waged.AMT *= -1;
                    }
                }
                backgroundWorker1.ReportProgress(30);

                //以計薪年月為群組，將勞健保相關的科目相加起來
                var group1 = from c in tbWaged_INS
                             group c by new { YYMM = c.YYMM.Trim(), NOBR = c.NOBR.Trim() } into g1
                             orderby g1.Key.NOBR, g1.Key.YYMM
                             select new
                             {
                                 YYMM = g1.Key.YYMM,
                                 NOBR = g1.Key.NOBR,
                                 AMT = g1.Sum(r => r.AMT)
                             };
                //以計薪年月為群組，將勞退相關的科目相加起來
                var group2 = from c in tbWaged_RET
                             group c by new { YYMM = c.YYMM.Trim(), NOBR = c.NOBR.Trim() } into g1
                             orderby g1.Key.NOBR, g1.Key.YYMM
                             select new
                             {
                                 YYMM = g1.Key.YYMM,
                                 NOBR = g1.Key.NOBR,
                                 AMT = g1.Sum(r => r.AMT)
                             };
                backgroundWorker1.ReportProgress(40);

                //取得勞健保相關的平均薪資
                var group3 = from c in group1
                             group c by c.NOBR into g1
                             select new
                             {
                                 NOBR = g1.Key,
                                 AMT = Decimal.Round(g1.Sum(r => r.AMT) / g1.Count(), 0)
                             };
                //取得勞退相關的平均薪資
                var group4 = from c in group2
                             group c by c.NOBR into g1
                             select new
                             {
                                 NOBR = g1.Key,
                                 AMT = Decimal.Round(g1.Sum(r => r.AMT) / g1.Count(), 0)
                             };
                backgroundWorker1.ReportProgress(50);

                //將勞健保與勞退合併
                var t1 = from c1 in group3
                         join c2 in group4 on c1.NOBR.Trim() equals c2.NOBR.Trim()
                         select new
                         {
                             NOBR = c1.NOBR,
                             SALARY = c1.AMT,
                             SALARYA = c2.AMT
                         };
                //group by 後，就不會有重覆資料
                var t2 = from c in t1
                         group c by new { NOBR = c.NOBR, SALARY = c.SALARY, SALARYA = c.SALARYA } into g1
                         select new
                         {
                             NOBR = g1.Key.NOBR,
                             SALARY = g1.Key.SALARY,
                             SALARYA = g1.Key.SALARYA
                         };

                var sql = (from bs in db.BASE
                           join bt in db.BASETTS on bs.NOBR equals bt.NOBR
                           where p.DDATE >= bt.ADATE && p.DDATE <= bt.DDATE && bt.INDT <= p.INDATE && (bt.STINDT == null || bt.STINDT.Value < p.INDATE)
                            && bs.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && bs.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0
                           select new { Base = bs, BaseTTS = bt }).ToList();

                 //加入 NAME_C, RETCHOO 的欄位
                 var t3 = from c1 in t2
                         join c2 in sql on c1.NOBR equals c2.Base.NOBR
                         //where c2.BASETTS.Where(pp => p.DDATE >= pp.ADATE && p.DDATE <= pp.DDATE.Value && (pp.INDT <= p.INDATE && (pp.STINDT == null || pp.STINDT.Value < p.INDATE))).Any()
                         where Convert.ToDateTime(date2) >= c2.BaseTTS.ADATE && Convert.ToDateTime(date2) <= c2.BaseTTS.DDATE
                         select new
                         {
                             NOBR = c1.NOBR,
                             NAME_C = c2.Base.NAME_C.Trim(),
                             RETCHOO = c2.BaseTTS.RETCHOO,
                             SALARY = c1.SALARY,
                             SALARYA = c1.SALARYA
                         };
                //加入每個人目前的投保資料
                var t4 = from c1 in t3
                         join c2 in db.INSLAB.ToList() on c1.NOBR.Trim() equals c2.NOBR.Trim()
                         join c3 in db.INSCOMP.ToList() on c2.S_NO.Trim() equals c3.S_NO.Trim()
                         where Convert.ToDateTime(date2) >= c2.IN_DATE && Convert.ToDateTime(date2) <= c2.OUT_DATE && new string[] { "1", "2" }.Contains(c2.CODE.Trim()) && c2.FA_IDNO.Trim().Length == 0
                         && c3.S_NO_DISP.Trim().CompareTo(p.INSCOMP1) >= 0 && c3.S_NO_DISP.Trim().CompareTo(p.INSCOMP2) <= 0
                         && (c2.H_AMT > 10 || c2.L_AMT > 10 || c2.R_AMT > 10)//排除都是0的，表示未實際加保，只是作為補充保費減免的參考
                         select new
                         {
                             NOBR = c1.NOBR,
                             NAME_C = c1.NAME_C,
                             RETCHOO = c1.RETCHOO,
                             SALARY = c1.SALARY,
                             SALARYA = c1.SALARYA,
                             L_AMT = (c2.L_AMT != 0) ? JBModule.Data.CDecryp.Number(c2.L_AMT) : 0,
                             H_AMT = (c2.H_AMT != 0) ? JBModule.Data.CDecryp.Number(c2.H_AMT) : 0,
                             R_AMT = (c2.R_AMT != 0) ? JBModule.Data.CDecryp.Number(c2.R_AMT) : 0,
                             INSCOMP = c3.INSNAME,
                         };

                backgroundWorker1.ReportProgress(60);

                decimal L_MAX = L_INSLV_ARRAY.Max(r => r.AMT);
                decimal H_MAX = H_INSLV_ARRAY.Max(r => r.AMT);
                decimal R_MAX = R_INSLV_ARRAY.Max(r => r.AMT);

                decimal i = 1;
                decimal t = t4.Count();

                foreach (var dd in t4)
                {
                    InsDS.FRM3AZRow row = insDS.FRM3AZ.NewFRM3AZRow();
                    row.NOTTRAN = false;
                    row.NOBR = dd.NOBR;
                    row.NAME_C = dd.NAME_C;
                    row.RETCHOO = dd.RETCHOO;
                    row.SALARY = dd.SALARY;
                    row.SALARYA = dd.SALARYA;
                    row.L_AMT = dd.L_AMT;
                    row.H_AMT = dd.H_AMT;
                    row.R_AMT = dd.R_AMT;
                    row.InsComp = dd.INSCOMP;
                    row.REMARK = "";
                    //取得建議的投保級距
                    if (dd.SALARY >= L_MAX) row.L_AMT1 = L_MAX;
                    else
                    {
                        row.L_AMT1 = (from c in L_INSLV_ARRAY
                                      where c.AMT >= dd.SALARY
                                      select c).Min(r => r.AMT);
                    }
                    //取得建議的投保級距
                    if (dd.SALARY >= H_MAX) row.H_AMT1 = H_MAX;
                    else
                    {
                        row.H_AMT1 = (from c in H_INSLV_ARRAY
                                      where c.AMT >= dd.SALARY
                                      select c).Min(r => r.AMT);
                    }

                    //取得建議的投保級距
                    if (dd.SALARY >= R_MAX) row.R_AMT1 = R_MAX;
                    else
                    {
                        row.R_AMT1 = (from c in R_INSLV_ARRAY
                                      where c.AMT >= dd.SALARYA
                                      select c).Min(r => r.AMT);
                    }

                    //取得期間內的薪資
                    var d1 = (from c in group1 where c.NOBR == row.NOBR orderby c.YYMM select c).ToArray();
                    row.AMT1 = (d1.Count() >= 1) ? d1[0].AMT : 0;
                    row.AMT2 = (d1.Count() >= 2) ? d1[1].AMT : 0;
                    row.AMT3 = (d1.Count() >= 3) ? d1[2].AMT : 0;
                    //取得期間內的薪資
                    var d2 = (from c in group2 where c.NOBR == row.NOBR orderby c.YYMM select c).ToArray();
                    row.AMTA = (d2.Count() >= 1) ? d2[0].AMT : 0;
                    row.AMTB = (d2.Count() >= 2) ? d2[1].AMT : 0;
                    row.AMTC = (d2.Count() >= 3) ? d2[2].AMT : 0;

                    if (row.RETCHOO.Trim() == "0" || row.RETCHOO.Trim() == "1")
                    {
                        row.SALARYA = 0;
                        row.R_AMT = 0;
                        row.R_AMT1 = 0;
                        row.AMTA = 0;
                        row.AMTB = 0;
                        row.AMTC = 0;
                    }

                    var EMPBASE = (from c in db.BASE
                                   where c.NOBR.Trim().ToLower() == row.NOBR.Trim().ToLower()
                                   select c).FirstOrDefault();
                    //if (EMPBASE != null && EMPBASE.COUNT_MA)
                    //{
                    //    row.SALARYA = 0;
                    //    row.R_AMT = 0;
                    //    row.R_AMT1 = 0;
                    //    row.AMTA = 0;
                    //    row.AMTB = 0;
                    //    row.AMTC = 0;
                    //}


                    insDS.FRM3AZ.AddFRM3AZRow(row);

                    int rr = Convert.ToInt32(decimal.Floor(Convert.ToDecimal(i / t * 40)));
                    if (rr > 0 && rr % 2 == 0)
                    {
                        backgroundWorker1.ReportProgress(60 + rr);
                    }

                    i++;
                }
            }

            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = fRM3AZBindingSource;
            button1.Enabled = true;

            if (fRM3AZBindingSource.Count > 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            progressBar1.Value = 0;
            backgroundWorker2.RunWorkerAsync(txtChDate.Text);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            InsDataClassesDataContext myDB1 = new InsDataClassesDataContext();
            var INSLAB = from c in myDB1.INSLAB
                         where DateTime.Now.Date >= c.IN_DATE && DateTime.Now.Date <= c.OUT_DATE && new string[] { "1", "2" }.Contains(c.CODE.Trim())
                         && (c.H_AMT > 10 || c.L_AMT > 10 || c.R_AMT > 10)//排除都是0的，表示未實際加保，只是作為補充保費減免的參考
                         orderby c.NOBR, c.FA_IDNO, c.IN_DATE descending
                         select c;

            var INSLABGROUP = from c in INSLAB
                              group c by c.NOBR.Trim().ToLower() into g1
                              select g1;

            decimal i = 0;
            decimal t = this.insDS.FRM3AZ.Count;
            foreach (var rowFRM3AZ in this.insDS.FRM3AZ.AsEnumerable())
            {
                i++;
                int rr = Convert.ToInt32(decimal.Ceiling(Convert.ToDecimal(i / t * 75)));
                if (rr > 0 && rr % 2 == 0)
                {
                    backgroundWorker2.ReportProgress(rr);
                }

                if (rowFRM3AZ.NOTTRAN) continue;

                var FAMILYINS = (from c in INSLABGROUP where c.Key == rowFRM3AZ.NOBR.Trim().ToLower() select c).FirstOrDefault();
                if (FAMILYINS != null)
                {
                    var selfIns = (from c in FAMILYINS where c.FA_IDNO.Trim().Length == 0 select c).FirstOrDefault();
                    if (selfIns != null)
                    {
                        decimal lAmt = JBModule.Data.CDecryp.Number(selfIns.L_AMT);
                        decimal hAmt = JBModule.Data.CDecryp.Number(selfIns.H_AMT);
                        decimal rAmt = JBModule.Data.CDecryp.Number(selfIns.R_AMT);

                        if (lAmt == rowFRM3AZ.L_AMT1 && hAmt == rowFRM3AZ.H_AMT1 && rAmt == rowFRM3AZ.R_AMT1)
                        {
                            continue;
                        }
                    }
                    else continue;
                    string FA_IDNO = null;
                    foreach (var rowIns in FAMILYINS)
                    {
                        DateTime OUT_DATE_Bak = rowIns.OUT_DATE;
                        DateTime ROUT_DATE_Bak = rowIns.ROUT_DATE.Value;
                        rowIns.OUT_DATE = Convert.ToDateTime(txtChDate.Text).AddDays(-1);
                        rowIns.ROUT_DATE = Convert.ToDateTime(txtChDate.Text).AddDays(-1);

                        INSLAB newINS = new INSLAB();
                        newINS.NOBR = rowIns.NOBR;
                        newINS.CODE = "2";
                        newINS.IN_DATE = Convert.ToDateTime(e.Argument);
                        newINS.OUT_DATE = Convert.ToDateTime("9999/12/31");
                        newINS.ROUT_DATE = Convert.ToDateTime("9999/12/31");
                        newINS.SEQ = rowIns.SEQ;
                        newINS.CODE1 = rowIns.CODE1;
                        newINS.NOTE = "";
                        newINS.S_NO = rowIns.S_NO;
                        newINS.SPTYP = rowIns.SPTYP;
                        newINS.WBSPTYP = rowIns.WBSPTYP;
                        newINS.KEY_MAN = MainForm.USER_NAME;
                        newINS.KEY_DATE = DateTime.Now;
                        //if (rowIns.ROUT_DATE.HasValue)
                        //{
                        //    newINS.ROUT_DATE = rowIns.ROUT_DATE.Value;
                        //}

                        if (rowIns.FA_IDNO.Trim().Length == 0)
                        {
                            newINS.FA_IDNO = "";
                            newINS.LRATE_CODE = rowIns.LRATE_CODE;
                            newINS.L_AMT = JBModule.Data.CEncrypt.Number(rowFRM3AZ.L_AMT1);
                            newINS.HRATE_CODE = rowIns.HRATE_CODE;
                            newINS.H_AMT = JBModule.Data.CEncrypt.Number(rowFRM3AZ.H_AMT1);
                            newINS.R_AMT = JBModule.Data.CEncrypt.Number(rowFRM3AZ.R_AMT1);
                        }
                        else
                        {
                            newINS.FA_IDNO = rowIns.FA_IDNO.Trim();
                            newINS.LRATE_CODE = "";
                            newINS.L_AMT = JBModule.Data.CEncrypt.Number(0);
                            newINS.HRATE_CODE = rowIns.HRATE_CODE;
                            newINS.H_AMT = JBModule.Data.CEncrypt.Number(rowFRM3AZ.H_AMT1);
                            newINS.R_AMT = JBModule.Data.CEncrypt.Number(0);
                        }

                        var OldinsLab = db.INSLAB.Where(p => p.NOBR == newINS.NOBR && p.FA_IDNO == newINS.FA_IDNO && p.IN_DATE == newINS.IN_DATE);
                        if (OldinsLab.Any())
                        {
                            rowIns.OUT_DATE = OUT_DATE_Bak;
                            rowIns.ROUT_DATE = ROUT_DATE_Bak;
                            rowFRM3AZ.REMARK += string.Format("員工編號:{0}眷屬證號:{1}，在{2}有重複的調整資料. ", newINS.NOBR, newINS.FA_IDNO, newINS.IN_DATE.ToShortDateString());
                        }
                        else if (FA_IDNO != rowIns.FA_IDNO.Trim())
                            myDB1.INSLAB.InsertOnSubmit(newINS);
                        FA_IDNO = rowIns.FA_IDNO.Trim();
                    }
                }
            }

            backgroundWorker2.ReportProgress(75);
            System.Data.Common.DbConnection DbConnection = myDB1.Connection;
            try
            {
                if (DbConnection.State == ConnectionState.Closed) DbConnection.Open();
                System.Data.Common.DbTransaction DbTransaction = DbConnection.BeginTransaction();

                try
                {
                    myDB1.Transaction = DbTransaction;
                    myDB1.SubmitChanges();

                    DbTransaction.Commit();
                    backgroundWorker2.ReportProgress(100);
                }
                catch (Exception ex)
                {
                    backgroundWorker2.ReportProgress(0);
                    MessageBox.Show(ex.Message);
                    DbTransaction.Rollback();
                }
            }
            finally
            {
                DbConnection.Close();
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Resources.Ins.WorkCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dt = ExportGridToDataTable(dataGridView1);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            JBModule.Data.CNPOI.SaveDataSetToExcel(ds, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        DataTable ExportGridToDataTable(DataGridView dgv)
        {
            if (dgv != null)
            {
                DataTable tbl = new DataTable();
                List<string> comboboxList = new List<string>();
                foreach (DataGridViewColumn dc in dgv.Columns)
                {
                    int count = 0;
                    string col_name = dc.HeaderText;
                    while (tbl.Columns.Contains(col_name))
                    {
                        count++;
                        col_name = dc.HeaderText + "(" + count.ToString() + ")";
                    }
                    if (dc.ValueType != null)
                        tbl.Columns.Add(new DataColumn(col_name, dc.ValueType));
                }
                DateTime t1, t2;
                t1 = DateTime.Now;
                foreach (DataGridViewRow dr in dgv.Rows)
                {

                    DataRow row = tbl.NewRow();
                    foreach (DataGridViewCell dcc in dr.Cells)
                    {
                        string column_name = dgv.Columns[dcc.ColumnIndex].HeaderText;
                        if (!tbl.Columns.Contains(column_name)) continue;
                        DataGridViewComboBoxCell combobox = dcc as DataGridViewComboBoxCell;
                        if (combobox != null)
                        {
                            var data = combobox.DataSource as BindingSource;
                            var table = (data.DataSource as DataSet).Tables[data.DataMember] as DataTable;
                            if (table != null)
                            {
                                var rows = table.Select(combobox.ValueMember + "='" + dcc.Value + "'");
                                if (rows.Any())
                                    row[column_name] = rows[0][combobox.DisplayMember];
                            }
                        }
                        else
                        {
                            string string_value = dcc.FormattedValue.ToString();
                            if (dcc.ValueType == typeof(decimal))
                            {
                                decimal value = 0;
                                if (!decimal.TryParse(string_value, out value))
                                    row[column_name] = DBNull.Value;
                                else row[column_name] = value;
                            }
                            else if (dcc.ValueType == typeof(DateTime))
                            {
                                DateTime value = new DateTime();
                                if (!DateTime.TryParse(string_value, out value))
                                    row[column_name] = DBNull.Value;
                                else row[column_name] = value;
                            }
                            else if (dcc.ValueType == typeof(int))
                            {
                                int value = 0;
                                if (!int.TryParse(string_value, out value))
                                    row[column_name] = DBNull.Value;
                                else row[column_name] = value;
                            }
                            else if (dcc.ValueType == typeof(bool))
                            {
                                bool value = true;
                                if (!bool.TryParse(string_value, out value))
                                    row[column_name] = DBNull.Value;
                                else row[column_name] = value;
                            }
                            else//其餘都當作是字串處理
                            {
                                row[column_name] = string_value;
                            }
                        }
                    }
                    tbl.Rows.Add(row);
                }
                t2 = DateTime.Now;
                var ts = t2 - t1;
                return tbl;
            }

            return null;
        }
        private void FRM3A_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void backgroundWorkerBasic_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime tt1, tt2;
            tt1 = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //db1 = new JBModule.Data.Linq.HrDBDataContext();
            this.insDS.FRM3AZ.Clear();

            param p = e.Argument as param;

            //以最後一個月份做為基準日期
            string yy2, mm2;
            //Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(p.DDATE);


            //以基準日期挑出有效的級距
            var L_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(p.DDATE) >= c.EFF_DATEL && Convert.ToDateTime(p.DDATE) <= c.LFF_DATEL select c).ToArray();
            var H_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(p.DDATE) >= c.EFF_DATEH && Convert.ToDateTime(p.DDATE) <= c.LFF_DATEH select c).ToArray();
            var R_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(p.DDATE) >= c.EFF_DATER && Convert.ToDateTime(p.DDATE) <= c.LFF_DATER select c).ToArray();

            var salbasdSQL = (from c in db.SALBASD
                              join d in db.SALCODE on c.SAL_CODE equals d.SAL_CODE
                              join f in db.SALATTR on d.SAL_ATTR equals f.SALATTR1
                              join a in db.BASE on c.NOBR equals a.NOBR
                              join b in db.BASETTS on c.NOBR equals b.NOBR
                              where (d.INSLAB || d.RETIRE)
                              //&& db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(q => q.DATAGROUP).Contains(b.SALADR)
                              && c.NOBR.Trim().CompareTo(p.NOBR1.Trim()) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR2.Trim()) <= 0
                              && p.DDATE >= c.ADATE && p.DDATE <= c.DDATE
                              && p.DDATE >= b.ADATE && p.DDATE <= b.DDATE
                              && b.INDT <= p.INDATE && (b.STINDT == null || b.STINDT.Value < p.INDATE)
                              select new
                              {
                                  SALBASD = c,
                                  SALCODE = d,
                                  SALATTR = f,
                                  BASE = a,
                                  BASETTS = b
                              });


            backgroundWorkerBasic.ReportProgress(10);


            backgroundWorkerBasic.ReportProgress(20);


            backgroundWorkerBasic.ReportProgress(30);


            var inslabSQL = from a in db.INSLAB
                            join b in db.BASE on a.NOBR equals b.NOBR
                            join c in db.BASETTS on a.NOBR equals c.NOBR
                            join d in db.INSCOMP on a.S_NO equals d.S_NO
                            where p.DDATE >= a.IN_DATE && p.DDATE <= a.OUT_DATE
                            && p.DDATE >= c.ADATE && p.DDATE <= c.DDATE.Value
                            && a.FA_IDNO.Trim().Length == 0
                            && b.NOBR.CompareTo(p.NOBR1) >= 0 && b.NOBR.CompareTo(p.NOBR2) <= 0
                            //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(q => q.DATAGROUP).Contains(c.SALADR)
                             && d.S_NO_DISP.CompareTo(p.INSCOMP1) >= 0 && d.S_NO_DISP.CompareTo(p.INSCOMP2) <= 0
                            select new { INSLAB = a, BASE = b, BASETTS = c ,INSCOMP = d};

            if (radioButton2.Checked)
            {
                inslabSQL = from a in inslabSQL where a.BASETTS.DI == "I" select a;
            }
            else if (radioButton3.Checked)
            {
                inslabSQL = from a in inslabSQL where a.BASETTS.DI == "D" select a;
            }
            else if (radioButton4.Checked)
            {
                inslabSQL = from a in inslabSQL where a.BASE.COUNT_MA select a;
            }
            else if (radioButton5.Checked)
            {
                inslabSQL = from a in inslabSQL where !a.BASE.COUNT_MA select a;
            }




            backgroundWorkerBasic.ReportProgress(60);

            decimal L_MAX = L_INSLV_ARRAY.Max(r => r.AMT);
            decimal H_MAX = H_INSLV_ARRAY.Max(r => r.AMT);
            decimal R_MAX = R_INSLV_ARRAY.Max(r => r.AMT);
            var salbasdList = salbasdSQL.ToList();

            foreach (var r in inslabSQL.ToList())
            {
                var salbasdOfNobr = from a in salbasdList where a.BASE.NOBR == r.INSLAB.NOBR select a;
                InsDS.FRM3AZRow row = insDS.FRM3AZ.NewFRM3AZRow();
                row.NOTTRAN = false;
                row.NOBR = r.BASE.NOBR;
                row.NAME_C = r.BASE.NAME_C;
                row.RETCHOO = r.BASETTS.RETCHOO;
                var qq1 = salbasdOfNobr.Where(q => q.SALCODE.INSLAB);
                row.SALARY = qq1.Any() ? qq1.Sum(q => q.SALATTR.FLAG != "-" ? JBModule.Data.CDecryp.Number(q.SALBASD.AMT) : JBModule.Data.CDecryp.Number(q.SALBASD.AMT) * -1) : 0;
                var qq2 = salbasdOfNobr.Where(q => q.SALCODE.RETIRE);
                row.SALARYA = qq2.Any() ? qq2.Sum(q => q.SALATTR.FLAG != "-" ? JBModule.Data.CDecryp.Number(q.SALBASD.AMT) : JBModule.Data.CDecryp.Number(q.SALBASD.AMT) * -1) : 0;
                row.L_AMT = JBModule.Data.CDecryp.Number(r.INSLAB.L_AMT);
                row.H_AMT = JBModule.Data.CDecryp.Number(r.INSLAB.H_AMT);
                row.R_AMT = JBModule.Data.CDecryp.Number(r.INSLAB.R_AMT);
                row.InsComp = r.INSCOMP.INSNAME;
                //取得建議的投保級距
                //if (p.isLab)
                //{
                if (row.SALARY >= L_MAX) row.L_AMT1 = L_MAX;
                else
                {
                    row.L_AMT1 = (from c in L_INSLV_ARRAY
                                  where c.AMT >= row.SALARY
                                  select c).Min(q => q.AMT);
                }
                //}
                //else
                //{
                //    row.L_AMT1 = row.L_AMT;//如果不調整，就跟原本一樣
                //}

                //取得建議的投保級距
                //if (p.isHea)
                //{
                if (row.SALARY >= H_MAX) row.H_AMT1 = H_MAX;
                else
                {
                    row.H_AMT1 = (from c in H_INSLV_ARRAY
                                  where c.AMT >= row.SALARY
                                  select c).Min(q => q.AMT);
                }
                //}
                //else
                //{
                //    row.H_AMT1 = row.H_AMT;
                //}

                //取得建議的投保級距
                //if (p.isRet)
                //{
                if (row.SALARYA >= R_MAX) row.R_AMT1 = R_MAX;
                else
                {
                    row.R_AMT1 = (from c in R_INSLV_ARRAY
                                  where c.AMT >= row.SALARYA
                                  select c).Min(q => q.AMT);
                }
                //}
                //else
                //{
                //    row.R_AMT1 = row.R_AMT;
                //}

                if (row.RETCHOO.Trim() == "0" || row.RETCHOO.Trim() == "1")
                {
                    row.SALARYA = 0;
                    row.R_AMT = 0;
                    row.R_AMT1 = 0;
                    row.AMTA = 0;
                    row.AMTB = 0;
                    row.AMTC = 0;
                }

                //if (r.BASE.COUNT_MA)
                //{
                //    row.SALARYA = 0;
                //    row.R_AMT = 0;
                //    row.R_AMT1 = 0;
                //    row.AMTA = 0;
                //    row.AMTB = 0;
                //    row.AMTC = 0;
                //}


                insDS.FRM3AZ.AddFRM3AZRow(row);
            }

            tt2 = DateTime.Now;
            var ts = tt2 - tt1;
            backgroundWorkerBasic.ReportProgress(100);
        }

        private void txtChDate_Validated(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(txtChDate.Text);
                DateTime date1 = date.AddMonths(-4);
                DateTime date2 = date.AddMonths(-2);
                txtYYMM1.Text = date1.ToString("yyyyMM");
                txtYYMM2.Text = date2.ToString("yyyyMM");
            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
            }
        }

        private void txtYYMM1_Validated(object sender, EventArgs e)
        {
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(txtYYMM1.Text);
            var ym = sd.FirstDayOfMonth.AddMonths(2);
            txtYYMM2.Text = ym.ToString("yyyyMM");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            JBHR.Sal.FRM3AA frm = new Sal.FRM3AA();
            frm.ShowDialog();
            if (frm.dtImport != null && frm.dtImport.Rows.Count > 0)//有資料
            {
                txtChDate.Text = frm.TransDate.ToString("yyyy/MM/dd");
                panel2.Enabled = false;
                //button1.Text = "取消";
                this.insDS.FRM3AZ.Clear();
                foreach (DataRow r in frm.dtImport)
                {
                    var newRow = this.insDS.FRM3AZ.NewFRM3AZRow();
                    for (int i = 0; i < frm.dtImport.Columns.Count; i++)
                    {
                        newRow[i] = r[i];
                    }
                    this.insDS.FRM3AZ.AddFRM3AZRow(newRow);
                }
                checkRange();
                setState(true);
            }
        }
        void checkRange()
        {
            DateTime ddate = Convert.ToDateTime(txtChDate.Text);
            var L_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(ddate) >= c.EFF_DATEL && Convert.ToDateTime(ddate) <= c.LFF_DATEL select c).ToList();
            var H_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(ddate) >= c.EFF_DATEH && Convert.ToDateTime(ddate) <= c.LFF_DATEH select c).ToList();
            var R_INSLV_ARRAY = (from c in db.INSURLV where Convert.ToDateTime(ddate) >= c.EFF_DATER && Convert.ToDateTime(ddate) <= c.LFF_DATER select c).ToList();
            int error = 0;
            foreach (var r in this.insDS.FRM3AZ)
            {
                var lablv = from a in L_INSLV_ARRAY where a.AMT == r.L_AMT1 select a;
                if (!lablv.Any()) r.NOTTRAN = true;

                var healv = from a in H_INSLV_ARRAY where a.AMT == r.H_AMT1 select a;
                if (!healv.Any()) r.NOTTRAN = true;

                var retlv = from a in R_INSLV_ARRAY where a.AMT == r.R_AMT1 select a;
                if (!retlv.Any()) r.NOTTRAN = true;

                if (r.NOTTRAN) error++;
            }
            if (error > 0)
            {
                MessageBox.Show("有" + error.ToString() + "筆資料金額未在投保金額級距內，請檢察有勾選的不新增的資料並修正", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void setState(bool state)
        {
            button2.Enabled = state;
            button3.Enabled = state;
            button4.Enabled = state;
            button5.Enabled = state;
            tableLayoutPanel1.Enabled = state;
            splitContainer2.Panel2.Enabled = state;
        }
    }
}
