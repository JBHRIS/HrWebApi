using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
namespace JBHR.Att
{
    public partial class FRM24A : JBControls.JBForm
    {
        public FRM24A()
        {
            InitializeComponent();
        }

        private void FRM25A_Load(object sender, EventArgs e)
        {
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            this.dEPTTableAdapter1.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

            if (this.dsBas.BASE.Rows.Count > 0)
            {
                ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
                ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            }

            if (this.basDS.DEPT.Rows.Count > 0)
            {
                ptxDeptB.Text = this.basDS.DEPT.First().D_NO_DISP;
                ptxDeptE.Text = this.basDS.DEPT.Last().D_NO_DISP;
            }

            if (this.dsAtt.ROTE.Rows.Count > 0)
            {
                ptxRoteB.Text = this.dsAtt.ROTE.First().ROTE_DISP;
                ptxRoteE.Text = this.dsAtt.ROTE.Last().ROTE_DISP;
            }
            txtDateB.Text = Sal.Function.GetDate();
            txtDateE.Text = Sal.Function.GetDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            DateTime date_b, date_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.Text;
            dept_e = ptxDeptE.Text;
            rote_b = ptxRoteB.Text;
            rote_e = ptxRoteE.Text;
            date_b = Convert.ToDateTime(txtDateB.Text);
            date_e = Convert.ToDateTime(txtDateE.Text);

            DateTime t1, t2;
            t1 = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ATTEND
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.ROTE on a.ROTE equals c.ROTE1
                      join d in db.CARDAPP on a.NOBR equals d.NOBR into ad
                      from cardapp in ad.DefaultIfEmpty()
                      join f in db.DEPT on b.DEPT equals f.D_NO
                      where a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && f.D_NO_DISP.CompareTo(dept_b) >= 0 && f.D_NO_DISP.CompareTo(dept_e) <= 0
                      && c.ROTE_DISP.CompareTo(rote_b) >= 0 && c.ROTE_DISP.CompareTo(rote_e) <= 0
                      && a.ADATE >= date_b && a.ADATE <= date_e
                      && c.ON_TIME.Trim().Length > 0 && c.OFF_TIME.Trim().Length > 0
                      && db.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID,MainForm.COMPANY, MainForm.ADMIN).Value
                      select new { ATTEND = a, ROTE = c, CARDAPP = cardapp };
            var CardSQL = from a in db.CARD
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join f in db.DEPT on b.DEPT equals f.D_NO
                          where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                          && f.D_NO_DISP.CompareTo(dept_b) >= 0 && f.D_NO_DISP.CompareTo(dept_e) <= 0
                          && a.ADATE >= date_b && a.ADATE <= date_e.AddDays(1)//可能跨天
                          && db.GetFilterByNobrAssist(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          select a;
            var roteList = (from a in db.ROTE select a).ToList();
            foreach (var itm in sql)
            {
                JBModule.Data.Linq.CARD card = null;
                if (itm.ATTEND.ROTE == "00") continue;//如果遇到假日就略過
                if (rdb21.Checked || rdb22.Checked)//如果是選全部或是上班卡
                {
                    DateTime adate = itm.ATTEND.ADATE;
                    string ontime = itm.ROTE.ON_TIME;
                    if (ontime.CompareTo("2400") >= 0)
                    {
                        int hh, mm;
                        hh = Convert.ToInt32(ontime.Substring(0, 2));
                        mm = Convert.ToInt32(ontime.Substring(2));
                        hh -= 24;
                        ontime = hh.ToString("00") + mm.ToString("00");
                        adate = adate.AddDays(1);
                    }
                    var CardSQLofNobrAdateOntime = from a in CardSQL
                                                   where a.NOBR == itm.ATTEND.NOBR
                                                   && a.ADATE == adate
                                                   && a.ONTIME == ontime//上班時段
                                                   select a;
                    if (!CardSQLofNobrAdateOntime.Any())//不存在
                    {
                        card = new JBModule.Data.Linq.CARD();
                        card.ADATE = adate;
                        card.NOBR = itm.ATTEND.NOBR;
                        card.CARDNO = itm.CARDAPP != null ? itm.CARDAPP.CARDNO : itm.ATTEND.NOBR;
                        card.CODE = "FRM24A";
                        card.DAYS = 1;
                        card.IPADD = "";
                        card.KEY_DATE = DateTime.Now;
                        card.KEY_MAN = MainForm.USER_NAME;
                        card.LOS = false;
                        card.MENO = "";
                        card.NOT_TRAN = false;
                        card.ONTIME = ontime;//上班時間
                        card.REASON = "";
                        card.SERNO = "";
                        db.CARD.InsertOnSubmit(card);
                    }
                }
                if (rdb21.Checked || rdb23.Checked)//如果是選全部或是下班卡
                {
                    DateTime adate = itm.ATTEND.ADATE;
                    string offtime = itm.ROTE.OFF_TIME;
                    if (offtime.CompareTo("2400") >= 0)
                    {
                        int hh, mm;
                        hh = Convert.ToInt32(offtime.Substring(0, 2));
                        mm = Convert.ToInt32(offtime.Substring(2));
                        hh -= 24;
                        offtime = hh.ToString("00") + mm.ToString("00");
                        adate = adate.AddDays(1);
                    }
                    var CardSQLofNobrAdateOntime = from a in CardSQL
                                                   where a.NOBR == itm.ATTEND.NOBR
                                                   && a.ADATE == adate
                                                   && a.ONTIME == offtime
                                                   select a;
                    var dtRote = from a in roteList where a.ROTE1 == itm.ATTEND.ROTE select a;
                    JBModule.Data.Linq.ROTE rote = new JBModule.Data.Linq.ROTE();
                    if (dtRote.Any())
                        rote = dtRote.First();
                    else new Exception("找不到班別" + rote.ROTE1);

                    if (!CardSQLofNobrAdateOntime.Any())//不存在
                    {
                        if (rote.ALLLATES1 > 0)
                        {
                            int hh, mm;
                            hh = Convert.ToInt32(offtime.Substring(0, 2));
                            mm = Convert.ToInt32(offtime.Substring(2));
                            mm += Convert.ToInt32(rote.ALLLATES1);
                            if (mm >= 60)
                            {
                                mm -= 60;
                                hh++;
                                if (hh >= 24)
                                {
                                    hh -= 24;
                                    adate = adate.AddDays(1);
                                }
                            }
                            offtime = hh.ToString("00") + mm.ToString("00");
                        }
                        card = new JBModule.Data.Linq.CARD();
                        card.ADATE = adate;
                        card.NOBR = itm.ATTEND.NOBR;
                        card.CARDNO = itm.CARDAPP != null ? itm.CARDAPP.CARDNO : itm.ATTEND.NOBR;
                        card.CODE = "FRM24A";
                        card.DAYS = 1;
                        card.IPADD = "";
                        card.KEY_DATE = DateTime.Now;
                        card.KEY_MAN = MainForm.USER_NAME;
                        card.LOS = true;
                        card.MENO = "";
                        card.NOT_TRAN = false;
                        card.ONTIME = offtime;//下班時間
                        card.REASON = "";
                        card.SERNO = "";
                        db.CARD.InsertOnSubmit(card);
                    }
                }
                //db.SubmitChanges();
            }
            try
            {
                db.SubmitChanges();
            }
            catch (System.Data.Linq.DuplicateKeyException ex)
            {
                var data = ex.Data;
            }
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
