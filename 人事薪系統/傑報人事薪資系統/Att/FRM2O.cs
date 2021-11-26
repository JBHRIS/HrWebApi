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
    public partial class FRM2O : JBControls.JBForm
    {
        public FRM2O()
        {
            InitializeComponent();
        }

        private void FRM2O_Load(object sender, EventArgs e)
        {
            var roteData = CodeFunction.GetRoteDisp();
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote());//實際代碼寫入
            SystemFunction.SetComboBoxItems(cbxRoteB, roteData);
            SystemFunction.SetComboBoxItems(cbxRoteE, roteData);
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(cbxDeptB, deptData);
            SystemFunction.SetComboBoxItems(cbxDeptE, deptData);
            var jobData = CodeFunction.GetJobDisp();
            SystemFunction.SetComboBoxItems(cbxJobB, jobData);
            SystemFunction.SetComboBoxItems(cbxJobE, jobData);
            var joblData = CodeFunction.GetJoblDisp();
            SystemFunction.SetComboBoxItems(cbxJoblB, joblData);
            SystemFunction.SetComboBoxItems(cbxJoblE, joblData);
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBLTableAdapter.Fill(this.dsBas.JOBL);
            this.jOBTableAdapter.Fill(this.dsBas.JOB);
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            txtYear.Text = sd.strYear;
            txtMonth.Text = sd.strMonth;
            this.txtBday.Text = "1";
            this.txtEDay.Text = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString();
            this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            this.cbxDeptB.SelectedValue = deptData.First().Key;
            this.cbxDeptE.SelectedValue = deptData.Last().Key;
            this.cbxJobB.SelectedValue = jobData.First().Key;
            this.cbxJobE.SelectedValue = jobData.Last().Key;
            this.cbxJoblB.SelectedValue = joblData.First().Key;
            this.cbxJoblE.SelectedValue = joblData.Last().Key;
            this.cbxRoteB.SelectedValue = roteData.First().Key;
            this.cbxRoteE.SelectedValue = roteData.Last().Key;
            //label4.Text = cbxRote.SelectedValue.ToString();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認要執行置換班別?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                DateTime t1, t2;
                t1 = DateTime.Now;

                int yyyy, MM, dd1 = 0, dd2 = 0;
                yyyy = Convert.ToInt32(txtYear.Text);
                MM = Convert.ToInt32(txtMonth.Text);
                DateTime d1, d2;
                try
                {
                    dd1 = Convert.ToInt32(txtBday.Text);
                    dd2 = Convert.ToInt32(txtEDay.Text);

                    d1 = new DateTime(yyyy, MM, dd1);
                    d2 = new DateTime(yyyy, MM, dd2);
                }
                catch
                {
                    MessageBox.Show("[" + label1.Text + "]" + Resources.Att.InputFormatNotCorrect, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                string nobr_b, nobr_e, dept_b, dept_e, job_b, job_e, jobl_b, jobl_e, rote_b, rote_e;
                nobr_b = ptxNobrB.Text;
                nobr_e = ptxNobrE.Text;
                dept_b = cbxDeptB.SelectedValue.ToString();
                dept_e = cbxDeptE.SelectedValue.ToString();
                job_b = cbxJobB.SelectedValue.ToString();
                job_e = cbxJobE.SelectedValue.ToString();
                jobl_b = cbxJoblB.SelectedValue.ToString();
                jobl_e = cbxJoblE.SelectedValue.ToString();
                rote_b = cbxRoteB.SelectedValue.ToString();
                rote_e = cbxRoteE.SelectedValue.ToString();
                var sql = from att in db.ATTEND
                          join bts in db.BASETTS on att.NOBR equals bts.NOBR
                          join dept in db.DEPT on bts.DEPT equals dept.D_NO
                          join job in db.JOB on bts.JOB equals job.JOB1
                          join jobl in db.JOBL on bts.JOBL equals jobl.JOBL1
                          join rote in db.ROTE on att.ROTE equals rote.ROTE1
                          where att.ADATE >= bts.ADATE && att.ADATE <= bts.DDATE
                          //&& db.GetFilterByNobr(att.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          && att.NOBR.CompareTo(nobr_b) >= 0 && att.NOBR.CompareTo(nobr_e) <= 0
                          && dept.D_NO_DISP.CompareTo(dept_b) >= 0 && dept.D_NO_DISP.CompareTo(dept_e) <= 0
                          && job.JOB_DISP.CompareTo(job_b) >= 0 && job.JOB_DISP.CompareTo(job_e) <= 0
                          && jobl.JOBL_DISP.CompareTo(jobl_b) >= 0 && jobl.JOBL_DISP.CompareTo(jobl_e) <= 0
                          && rote.ROTE_DISP.CompareTo(rote_b) >= 0 && rote.ROTE_DISP.CompareTo(rote_e) <= 0
                          && att.ADATE >= d1 && att.ADATE <= d2
                          select att;
                var sqlRoteChg = (from a in db.ROTECHG
                                  join bts in db.BASETTS on a.NOBR equals bts.NOBR
                                  join dept in db.DEPT on bts.DEPT equals dept.D_NO
                                  join job in db.JOB on bts.JOB equals job.JOB1
                                  join jobl in db.JOBL on bts.JOBL equals jobl.JOBL1
                                  join rote in db.ROTE on a.ROTE equals rote.ROTE1
                                  where a.ADATE >= bts.ADATE && a.ADATE <= bts.DDATE
                                  //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                  && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                                  && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                                  && dept.D_NO_DISP.CompareTo(dept_b) >= 0 && dept.D_NO_DISP.CompareTo(dept_e) <= 0
                                  && job.JOB_DISP.CompareTo(job_b) >= 0 && job.JOB_DISP.CompareTo(job_e) <= 0
                                  && jobl.JOBL_DISP.CompareTo(jobl_b) >= 0 && jobl.JOBL_DISP.CompareTo(jobl_e) <= 0
                                  && rote.ROTE_DISP.CompareTo(rote_b) >= 0 && rote.ROTE_DISP.CompareTo(rote_e) <= 0
                                  && a.ADATE >= d1 && a.ADATE <= d2
                                  select a).ToList();
                if (rdb1.Checked)
                {
                    foreach (var itm in sql)
                    {
                        itm.ROTE = cbxRote.SelectedValue.ToString();
                        var rotechgData = sqlRoteChg.Where(p => p.NOBR == itm.NOBR && p.ADATE == itm.ADATE);
                        if (rotechgData.Any())
                        {
                            var rotechgRow = rotechgData.First();
                            rotechgRow.ROTE = itm.ROTE;
                            rotechgRow.KEY_DATE = DateTime.Now;
                            rotechgRow.KEY_MAN = MainForm.USER_NAME;
                        }
                        else
                        {
                            JBModule.Data.Linq.ROTECHG r = new JBModule.Data.Linq.ROTECHG();
                            r.KEY_DATE = DateTime.Now;
                            r.KEY_MAN = MainForm.USER_NAME;
                            r.ADATE = itm.ADATE;
                            r.CODE = "";
                            r.NOBR = itm.NOBR;
                            r.ROTE = itm.ROTE;
                            db.ROTECHG.InsertOnSubmit(r);
                        }
                    }
                }
                else
                {
                    int rote_day = Convert.ToInt32(txtRote.Text);
                    DateTime rote_date = new DateTime(yyyy, MM, rote_day);
                    var sql1 = from att in sql join att1 in db.ATTEND on att.NOBR equals att1.NOBR where att1.ADATE == rote_date && att.ADATE != rote_date select new { att, chg_rote = att1.ROTE };
                    foreach (var itm in sql1)
                    {
                        itm.att.ROTE = itm.chg_rote;
                        var rotechgData = sqlRoteChg.Where(p => p.NOBR == itm.att.NOBR && p.ADATE == itm.att.ADATE);
                        if (rotechgData.Any())
                        {
                            var rotechgRow = rotechgData.First();
                            rotechgRow.ROTE = itm.att.ROTE;
                            rotechgRow.KEY_DATE = DateTime.Now;
                            rotechgRow.KEY_MAN = MainForm.USER_NAME;
                        }
                        else
                        {
                            JBModule.Data.Linq.ROTECHG r = new JBModule.Data.Linq.ROTECHG();
                            r.KEY_DATE = DateTime.Now;
                            r.KEY_MAN = MainForm.USER_NAME;
                            r.ADATE = itm.att.ADATE;
                            r.CODE = "";
                            r.NOBR = itm.att.NOBR;
                            r.ROTE = itm.att.ROTE;
                            db.ROTECHG.InsertOnSubmit(r);
                        }
                    }
                }
                db.SubmitChanges();
                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxRote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRote.SelectedValue != null)
                label4.Text = cbxRote.SelectedValue.ToString();
            else label4.Text = "";
        }

    }
}
