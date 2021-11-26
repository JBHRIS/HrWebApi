using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
using System.Data.Linq.SqlClient;
namespace JBHR.Att
{
    public partial class FRM2JBB : JBControls.JBForm
    {
        public FRM2JBB()
        {
            InitializeComponent();
        }
        string holi_code = "00";
        private void FRM2O_Load(object sender, EventArgs e)
        {
            this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

            this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            this.ptxDeptB.Text = Sal.BaseValue.MinDept;
            this.ptxDeptE.Text = Sal.BaseValue.MaxDept;
            this.ptxRoteB.Text = dsAtt.ROTE.First().ROTE;
            this.ptxRoteE.Text = dsAtt.ROTE.Last().ROTE;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1;
            d1 = DateTime.Now.Date;
            DateTime t1, t2;
            SalaryDate sd = new SalaryDate(DateTime.Now.ToString("yyyyMM"));
            t1 = sd.FirstDayOfAttend;
            t2 = sd.LastDayOfAttend;
            txtBdate.Text = Sal.Core.SalaryDate.DateString(t1);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(t2);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            rote_b = ptxRoteB.Text;
            rote_e = ptxRoteE.Text;

            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtBdate.Text);
            d2 = Convert.ToDateTime(txtEdate.Text);
            DeleteOTPre();//先刪除範圍內資料

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            object[] ttscodes = new object[] { 1, 4, 6 };

            var sql = from r in db.BASETTS
                      let holi = (from a in db.HOLI
                                  where a.HOLI_CODE == r.HOLI_CODE
                                  && a.H_DATE >= r.ADATE && a.H_DATE <= r.DDATE.Value
                                  && a.H_DATE >= d1 && a.H_DATE <= d2
                                  select a).Count()
                      let att_date_b = d1 > r.ADATE ? d1 : r.ADATE
                      let att_date_e = d2 < r.DDATE.Value ? d2 : r.DDATE.Value
                      let att = (from a in db.ATTEND
                                 where a.NOBR == r.NOBR
                                 && a.ADATE >= r.ADATE && a.ADATE <= r.DDATE.Value
                                 && a.ADATE >= d1 && a.ADATE <= d2
                                 && a.ROTE == "00"
                                 select a).Count()
                      join b in db.BASE on r.NOBR equals b.NOBR
                      join c in db.DEPT on r.DEPT equals c.D_NO
                      join d in db.ROTET on r.ROTET equals d.ROTET1
                      where ttscodes.Contains(r.TTSCODE)
                      && d2 >= r.ADATE && d1 <= r.DDATE.Value
                      && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                      && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                      && d.ROTET_DISP.CompareTo(rote_b) >= 0 && d.ROTET_DISP.CompareTo(rote_e) <= 0
                      && r.NOOT == false
                      && (b.COUNT_MA == rb33.Checked || rb31.Checked)
                      && db.GetFilterByNobr(r.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      group new { BASETTS = r, holi, att } by r.NOBR into gp
                      select gp;

            int counts = sql.Count();
            int negative = 0;
            foreach (var itm in sql)
            {
                var plusDay = itm.Sum(p => p.holi);
                var minusDay = itm.Sum(p => p.att);
                var totalDay = plusDay - minusDay;

                //if (totalDay == 0) continue;//不寫入0小時

                var gp = itm.Where(p => p.BASETTS.ADATE <= d2 && p.BASETTS.DDATE >= d2);
                var basetts = itm.First().BASETTS;
                if (gp.Any()) basetts = gp.First().BASETTS;

                JBModule.Data.Linq.OTPRE ae = new JBModule.Data.Linq.OTPRE();
                ae.OT_DEPT = basetts.DEPTS;
                ae.ADATE = d1;
                ae.BTIME = "0000";
                ae.ETIME = "0000";
                ae.OT_ROTE = "00";
                ae.KEY_DATE = DateTime.Now;
                ae.KEY_MAN = MainForm.USER_NAME;
                ae.NOBR = itm.Key;
                SalaryDate sd = new SalaryDate(d1);
                ae.YYMM = sd.YYMM;
                ae.SUG_HRS = totalDay * 8;
                ae.OT_HRS = rb22.Checked ? ae.SUG_HRS : 0;
                if (ae.OT_HRS < 0) //continue;
                    negative++;
                ae.REST_HRS = rb23.Checked ? ae.SUG_HRS : 0;
                ae.OT1_HRS = plusDay;
                ae.OT2_HRS = minusDay;
                ae.SYS_OT = chkSysOt.Checked;
                ae.TRANP = rb12.Checked;
                ae.TRANS = false;
                ae.OTRCD = cbxOtrcd.SelectedValue;
                ae.NOTE = txtNote.Text;

                db.OTPRE.InsertOnSubmit(ae);

            }

            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            if (negative > 0) MessageBox.Show("轉換資料中有" + negative.ToString() + "筆負數資料，請檢察出勤資料是否有誤!!", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void DeleteOTPre()
        {
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e, otrcd;
            DateTime date_b, date_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            rote_b = ptxRoteB.Text;
            rote_e = ptxRoteE.Text;
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            otrcd = cbxOtrcd.SelectedValue;
            dcAttDataContext db = new dcAttDataContext();
            string cmd = "DELETE OTPRE WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO JOIN C ON A.ROTET=C.ROTET WHERE A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND C.ROTET_DISP BETWEEN {4} AND {5} AND NOBR=OTPRE.NOBR AND {6} BETWEEN ADATE AND DDATE) AND ADATE between {6} and {7} and otrcd={8}" + " AND dbo.GetFilterByNobr(OTPRE.NOBR,{9},{10},{11})=1";
            object[] PARA = new object[] { nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e, date_b, date_e, otrcd, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, PARA);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DateTime date_b, date_e;
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);


            DateTime t1, t2;
            t1 = DateTime.Now;

            //for (DateTime dd = date_b; dd <= date_e; dd = dd.AddDays(1))
            DeleteOTPre();


            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse(txtBdate.Text);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            txtEdate.Text = Sal.Function.GetDate(d2);
        }
    }
}
