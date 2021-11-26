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
    public partial class FRM2JBA : JBControls.JBForm
    {
        public FRM2JBA()
        {
            InitializeComponent();
        }
        
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
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d1);
            if (this.dsAtt.OTRCD.Where(p => p.OTRCD == "19").Any())
                cbxOtrcd.SelectedValue = "19";
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

            dcAttDataContext db = new dcAttDataContext();
            object[] ttscodes = new object[] { 1, 4, 6 };
            var attSQL = from a in db.ATTEND
                         join r in db.ROTE on a.ROTE equals r.ROTE1
                         join b in db.ATT_BASETTS on a.NOBR equals b.NOBR
                         join c in db.ATT_ROTET on b.ROTET equals c.ROTET1
                         join d in db.ATT_BASE on a.NOBR equals d.NOBR
                         where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                         && a.ADATE >= d1 && a.ADATE <= d2
                         && a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                         && ttscodes.Contains(b.TTSCODE)
                         && b.NOOT == false//未選取不產生加班
                         && c.FREQ == "1" && !d.COUNT_MA//判斷為輪班人員
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                         select new
                         {
                             ATTEND = a,
                             //ATTCARD = ac,
                             ROTE = r,
                             BASETTS = b
                         };


            int counts = attSQL.Count();

            foreach (var itm in attSQL)
            {
                string rote = itm.ATTEND.ROTE;
                var roteData = itm.ROTE;
                if (CodeFunction.GetHolidayRoteList().Contains( itm.ATTEND.ROTE))
                {
                    var att = from a in db.ATTEND
                              join b in db.ROTE on a.ROTE equals b.ROTE1
                              where a.NOBR == itm.BASETTS.NOBR && a.ADATE < itm.ATTEND.ADATE && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE)
                              orderby a.ADATE descending
                              select new { ATTEND = a, ROTE = b };
                    if (att.Any())
                    {
                        rote = att.First().ATTEND.ROTE;//前一個非假日班班別
                        roteData = att.First().ROTE;
                    }
                    else
                    {
                        att = from a in db.ATTEND
                              join b in db.ROTE on a.ROTE equals b.ROTE1
                              where a.NOBR == itm.BASETTS.NOBR && a.ADATE > itm.ATTEND.ADATE && !CodeFunction.GetHolidayRoteList().Contains( a.ROTE)
                              orderby a.ADATE
                              select new { ATTEND = a, ROTE = b };
                        if (att.Any())
                        {
                            rote = att.First().ATTEND.ROTE;//往後一個非假日班班別
                            roteData = att.First().ROTE;
                        }
                    }
                }
                OTPRE ae = new OTPRE();
                ae.OT_DEPT = itm.BASETTS.DEPTS;
                ae.ADATE = itm.ATTEND.ADATE;

                //保留給大量列印使用
                //ae.BTIME = itm.ATTCARD.T1;
                //ae.ETIME = itm.ATTCARD.T2;
                //if (rb33.Checked)
                //    ae.BTIME = itm.ATTCARD.T1.CompareTo(itm.ROTE.OT_BEGIN) > 0 ? itm.ATTCARD.T1 : itm.ROTE.OT_BEGIN;
                //else if (rb32.Checked)
                //    ae.ETIME = itm.ATTCARD.T2.CompareTo(itm.ROTE.ON_TIME) > 0 ? itm.ROTE.ON_TIME : itm.ATTCARD.T2;

                ae.BTIME = roteData.ON_TIME;
                ae.ETIME = roteData.OFF_TIME;

                var ot_calc = Dll.Att.OtCal.CalculationOt(itm.BASETTS.NOBR, rote, ae.ADATE, ae.BTIME, ae.ETIME);
                ae.OT_ROTE = rote;
                ae.KEY_DATE = DateTime.Now;
                ae.KEY_MAN = MainForm.USER_NAME;
                ae.NOBR = itm.BASETTS.NOBR;
                SalaryDate sd = new SalaryDate(d1);
                ae.YYMM = sd.YYMM;
                ae.SUG_HRS = ot_calc.iTotalHour;
                if (ae.SUG_HRS < 0) continue;
                ae.OT_HRS = rb22.Checked ? ae.SUG_HRS : 0;
                ae.REST_HRS = rb23.Checked ? ae.SUG_HRS : 0;
                ae.OT1_HRS = 0;
                ae.OT2_HRS = 0;
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
            string cmd = "DELETE OTPRE WHERE EXISTS(SELECT * FROM BASETTS WHERE NOBR BETWEEN {0} AND {1} AND DEPT BETWEEN {2} AND {3} AND ROTET BETWEEN {4} AND {5} AND NOBR=OTPRE.NOBR AND {6} BETWEEN ADATE AND DDATE) AND ADATE between {6} and {7} and otrcd={8}"
                //+ " AND dbo.GetFilterByNobr(OTPRE.NOBR,{9},{10},{11})=1";
                + " AND exists(select 1 from BASETTS x where x.NOBR=OTPRE.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({9},{10},{11})))";
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
    }
}
