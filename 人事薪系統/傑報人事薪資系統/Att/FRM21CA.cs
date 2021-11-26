using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM21CA : JBControls.JBForm
    {
        public FRM21CA()
        {
            InitializeComponent();
        }
        private void FRM21CA_Load(object sender, EventArgs e)
        {
            //this.oTHCODETableAdapter.Fill(this.dsAtt.OTHCODE);
            //this.oTRATECDTableAdapter.Fill(this.dsAtt.OTRATECD);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.hOLICDTableAdapter.Fill(this.dsAtt.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            var holi = CodeFunction.GetHolicdDisp();
            SystemFunction.SetComboBoxItems(cbxHoliB, holi, false);
            SystemFunction.SetComboBoxItems(cbxHoliE, holi, false);
            var rote = CodeFunction.GetRoteDisp();
            SystemFunction.SetComboBoxItems(cbxRoteB, rote, false);
            SystemFunction.SetComboBoxItems(cbxRoteE, rote, false);
            SystemFunction.SetComboBoxItems(cbxAtype, CodeFunction.GetOthCode(), false);
            SystemFunction.SetComboBoxItems(cbxHoliCode, CodeFunction.GetOtRatecd(), false);

            var rows = this.dsAtt.ROTE.Where(p =>CodeFunction.GetHolidayRoteList().Contains( p.ROTE));
            if (rows.Any())//剔除00
            {
                rows.First().Delete();
                this.dsAtt.ROTE.AcceptChanges();
            }
            textBox1.Text = Sal.Function.GetDate();
            textBox2.Text = Sal.Function.GetDate();
            //var holiSQL = from a in db.HOLICD select new{a.HOLI_CODE,a.HOLI_NAME};
            //if (dsAtt.HOLICD.Rows.Count > 0)
            //{
            cbxHoliB.SelectedValue = holi.First().Key;
            cbxHoliE.SelectedValue = holi.Last().Key;
            //}


            cbxRoteB.SelectedValue = rote.First().Key;
            cbxRoteE.SelectedValue = rote.Last().Key;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (cbxHoliCode.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("加班比率代碼未選擇", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxHoliCode.Focus();
                return;
            }
            if (cbxAtype.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("類別未選擇", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxAtype.Focus();
                return;
            }
            if (MessageBox.Show("確定要執行批次產生?" + Environment.NewLine + "相同區間的資料將被覆蓋", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                return;
            TimeSpan ts;
            DateTime t1, t2;
            t1 = DateTime.Now;
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime d1, d2;
            d1 = Convert.ToDateTime(textBox1.Text);
            d2 = Convert.ToDateTime(textBox2.Text);
            string rote_b, rote_e, holi_b, holi_e;
            rote_b = cbxRoteB.SelectedValue.ToString();
            rote_e = cbxRoteE.SelectedValue.ToString();
            holi_b = cbxHoliB.SelectedValue.ToString();
            holi_e = cbxHoliE.SelectedValue.ToString();
            
            var rote = CodeFunction.GetRote();
            var roteDisp = CodeFunction.GetRoteDisp();
            var roteData = roteDisp.Where(p => p.Key.CompareTo(rote_b) >= 0 && p.Key.CompareTo(rote_e) <= 0);
            var holicd = CodeFunction.GetHolicd();
            var holicdDisp = CodeFunction.GetHolicdDisp();
            var holicdData = holicdDisp.Where(p => p.Key.CompareTo(holi_b) >= 0 && p.Key.CompareTo(holi_e) <= 0);
            string DeleteCommand = "DELETE HOL_DAY WHERE EXISTS(SELECT * FROM ROTE WHERE ROTE.ROTE=HOL_DAY.ROTE AND ROTE.ROTE_DISP BETWEEN {0} AND {1}) AND EXISTS(SELECT * FROM HOLICD WHERE HOLICD.HOLI_CODE=HOL_DAY.HOLI_CODE AND HOLICD.HOLI_CODE_DISP BETWEEN {2} AND {3}) AND ADATE BETWEEN {4} AND {5}";
            var del = db.ExecuteCommand(DeleteCommand, new object[] { rote_b, rote_e, holi_b, holi_e, d1, d2 });
            int cc = 0;
            for (DateTime dd = d1; dd <= d2; dd = dd.AddDays(1))
            {
                foreach (var roteRow in roteData)
                {
                    var RoteList = from a in rote where a.Value == roteRow.Value select a;
                    if (RoteList.Any())
                    {
                        var rRote = RoteList.First();
                        foreach (var holicdRow in holicdData)
                        {
                            var holicdList = from a in holicd where a.Value == holicdRow.Value select a;
                            if (holicdList.Any())
                            {
                                var rHolicd = holicdList.First();
                                JBModule.Data.Linq.HOL_DAY rr = new JBModule.Data.Linq.HOL_DAY();
                                rr.KEY_DATE = DateTime.Now;
                                rr.KEY_MAN = MainForm.USER_NAME;
                                rr.ADATE = dd;
                                rr.ATYPE = cbxAtype.SelectedValue.ToString();
                                rr.HOLI_CODE = rHolicd.Key;
                                rr.OTRATECD = cbxHoliCode.SelectedValue.ToString();
                                rr.ROTE = rRote.Key;
                                db.HOL_DAY.InsertOnSubmit(rr);
                                cc++;
                            }
                        }
                    }
                }
            }
            db.SubmitChanges();
            t2 = DateTime.Now;
            ts = t2 - t1;
            string msg = string.Format("完成共產生" + cc.ToString() + "筆資料" + Environment.NewLine + Resources.Sal.TimeSpan, ts.Minutes.ToString(), ts.Seconds.ToString());
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要執行批次刪除?" + Environment.NewLine + "區間內的資料將被刪除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                return;
            TimeSpan ts;
            DateTime t1, t2;
            t1 = DateTime.Now;
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime d1, d2;
            d1 = Convert.ToDateTime(textBox1.Text);
            d2 = Convert.ToDateTime(textBox2.Text);
            string rote_b, rote_e, holi_b, holi_e;
            rote_b = cbxRoteB.SelectedValue.ToString();
            rote_e = cbxRoteE.SelectedValue.ToString();
            holi_b = cbxHoliB.SelectedValue.ToString();
            holi_e = cbxHoliE.SelectedValue.ToString();

            var rote = CodeFunction.GetRote();
            var roteDisp = CodeFunction.GetRoteDisp();
            var roteData = roteDisp.Where(p => p.Key.CompareTo(rote_b) >= 0 && p.Key.CompareTo(rote_e) <= 0);
            var holicd = CodeFunction.GetHolicd();
            var holicdDisp = CodeFunction.GetHolicdDisp();
            var holicdData = holicdDisp.Where(p => p.Key.CompareTo(holi_b) >= 0 && p.Key.CompareTo(holi_e) <= 0);
            string DeleteCommand = "DELETE HOL_DAY WHERE EXISTS(SELECT * FROM ROTE WHERE ROTE.ROTE=HOL_DAY.ROTE AND ROTE.ROTE_DISP BETWEEN {0} AND {1}) AND EXISTS(SELECT * FROM HOLICD WHERE HOLICD.HOLI_CODE=HOL_DAY.HOLI_CODE AND HOLICD.HOLI_CODE_DISP BETWEEN {2} AND {3}) AND ADATE BETWEEN {4} AND {5}";
            var del = db.ExecuteCommand(DeleteCommand, new object[] { rote_b, rote_e, holi_b, holi_e, d1, d2 });

            t2 = DateTime.Now;
            ts = t2 - t1;
            string msg = string.Format("完成共刪除" + del.ToString() + "筆資料" + Environment.NewLine + Resources.Sal.TimeSpan, ts.Minutes.ToString(), ts.Seconds.ToString());
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
