using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace HrDataTransport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        JBTools.Stopwatch sw = new JBTools.Stopwatch();
        private void button1_Click(object sender, EventArgs e)
        {
            sw.Start();
            BW.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS select a;
            var sql1 = from a in sql group a by a.COMP;
            int i = 0;
            int total = sql.Count();
            foreach (var it in sql1)
            {

                var comp = it.Key;
                var deptData = (from a in db.DEPT where db.GetCodeFilter("dept", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                var deptsData = (from a in db.DEPTS where db.GetCodeFilter("depts", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                var deptaData = (from a in db.DEPTA where db.GetCodeFilter("depta", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                var jobData = (from a in db.JOB where db.GetCodeFilter("JOB", a.JOB1, "TONY", comp, true).Value select new { a.JOB1, a.JOB_DISP }).ToList();
                var jobsData = (from a in db.JOBS where db.GetCodeFilter("JOBS", a.JOBS1, "TONY", comp, true).Value select new { a.JOBS1, a.JOBS_DISP }).ToList();
                var joblData = (from a in db.JOBL where db.GetCodeFilter("JOBL", a.JOBL1, "TONY", comp, true).Value select new { a.JOBL1, a.JOBL_DISP }).ToList();
                var stationData = (from a in db.STATION where db.GetCodeFilter("STATION", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                var OutPostData = (from a in db.OutPost where db.GetCodeFilter("OutPost", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                var ROTETData = (from a in db.ROTET where db.GetCodeFilter("ROTET", a.ROTET1, "TONY", comp, true).Value select new { Code = a.ROTET1, Disp = a.ROTET_DISP }).ToList();
                var ttscdData = (from a in db.TTSCD where db.GetCodeFilter("TTSCD", a.TTSCD1, "TONY", comp, true).Value select new { Code = a.TTSCD1, Disp = a.TTSCD_DISP }).ToList();
                var holicdData = (from a in db.HOLICD where db.GetCodeFilter("HOLICD", a.HOLI_CODE, "TONY", comp, true).Value select new { Code = a.HOLI_CODE, Disp = a.HOLI_CODE_DISP }).ToList();

                foreach (var r in it)
                {
                    i++;
                    BW.ReportProgress(i * 100 / total, "正在更新" + r.NOBR);
                    //var deptRow = deptData.Where(p => p.D_NO_DISP == r.DEPT);
                    //var deptRow1 = deptData.Where(p => p.D_NO_DISP == r.DEPT + "z");
                    //if (deptRow.Any())
                    //{
                    //    r.DEPT = deptRow.First().D_NO;
                    //}
                    //else if (deptRow1.Any())
                    //{
                    //    r.DEPT = deptRow1.First().D_NO;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到編制部門代碼" + r.NOBR + ";" + r.DEPT + ";");
                    //}

                    //var deptsRow = deptsData.Where(p => p.D_NO_DISP == r.DEPTS);
                    //if (deptsRow.Any())
                    //{
                    //    r.DEPTS = deptsRow.First().D_NO;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到成本部門代碼" + r.NOBR + ";" + r.DEPTS + ";");
                    //}

                    //var deptaRow = deptaData.Where(p => p.D_NO_DISP == r.DEPTM);
                    //if (deptaRow.Any())
                    //{
                    //    r.DEPTM = deptaRow.First().D_NO;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到簽核部門代碼" + r.NOBR + ";" + r.DEPTM + ";");
                    //}

                    //var jobRow = jobData.Where(p => p.JOB_DISP == r.JOB);
                    //if (jobRow.Any())
                    //{
                    //    r.JOB = jobRow.First().JOB1;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到職稱代碼" + r.NOBR + ";" + r.JOB + ";");
                    //}

                    var jobsRow = jobsData.Where(p => p.JOBS_DISP == r.JOBS);
                    if (jobsRow.Any())
                    {
                        r.JOBS = jobsRow.First().JOBS1;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到職系代碼" + r.NOBR + ";" + r.JOBS + ";");
                    }

                    //var joblRow = joblData.Where(p => p.JOBL_DISP == r.JOBL);
                    //if (joblRow.Any())
                    //{
                    //    r.JOBL = joblRow.First().JOBL1;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到職等代碼" + r.NOBR + ";" + r.JOBL + ";");
                    //}

                    //var stationRow = stationData.Where(p => p.Disp == r.STATION);
                    //if (stationRow.Any())
                    //{
                    //    r.STATION = stationRow.First().Code;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到環境津貼代碼" + r.NOBR + ";" + r.STATION + ";");
                    //}

                    //var OutPostRow = OutPostData.Where(p => p.Disp == r.OutPost);
                    //if (OutPostRow.Any())
                    //{
                    //    r.OutPost = OutPostRow.First().Code;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到外派代碼" + r.NOBR + ";" + r.OutPost + ";");
                    //}

                    //var rotetRow = ROTETData.Where(p => p.Disp == r.ROTET);
                    //if (rotetRow.Any())
                    //{
                    //    r.ROTET = rotetRow.First().Code;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到外派代碼" + r.NOBR + ";" + r.ROTET + ";");
                    //}

                    //var ttscdRow = ttscdData.Where(p => p.Disp == r.TTSCD);
                    //if (ttscdRow.Any())
                    //{
                    //    r.TTSCD = ttscdRow.First().Code;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到外派代碼" + r.NOBR + ";" + r.TTSCD + ";");
                    //}

                    //var holicdRow = holicdData.Where(p => p.Disp == r.HOLI_CODE);
                    //if (holicdRow.Any())
                    //{
                    //    r.HOLI_CODE = holicdRow.First().Code;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到行事曆代碼" + r.NOBR + ";" + r.HOLI_CODE + ";");
                    //}

                }
            }
            db.SubmitChanges();
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sw.Stop();
            sw.ShowMessage();
            this.panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("SELECT * INTO BASETTS_BAK FROM BASETTS");
            MessageBox.Show("備份成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            db.ExecuteCommand("DELETE BASETTS");
            db.ExecuteCommand("INSERT INTO BASETTS SELECT * FROM BASETTS_BAK");
            MessageBox.Show("還原成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("DROP TABLE BASETTS_BAK");
            MessageBox.Show("刪除成功");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sw.Start();
            BW1.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("SELECT * INTO BASE_BAK FROM BASE");
            MessageBox.Show("備份成功");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            db.ExecuteCommand("DELETE BASE");
            db.ExecuteCommand("INSERT INTO BASE SELECT * FROM BASE_BAK");
            MessageBox.Show("還原成功");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("DROP TABLE BASE_BAK");
            MessageBox.Show("刪除成功");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sw.Start();
            BW2.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        private void BW1_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      select new { BASE = a, b.COMP };
            var sql1 = from a in sql group a.BASE by a.COMP;
            int i = 0;
            int total = sql.Count();
            foreach (var it in sql1)
            {

                var comp = it.Key;
                var BankCodeData = (from a in db.BankCode where db.GetCodeFilter("BankCode", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                var giftCodeData = (from a in db.GiftVoucher where db.GetCodeFilter("GiftVoucher", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                foreach (var r in it)
                {
                    i++;
                    BW1.ReportProgress(i * 100 / total, "正在更新" + r.NOBR);

                    var BankCodeRow = BankCodeData.Where(p => p.Disp == r.BANK_CODE);
                    if (BankCodeRow.Any())
                    {
                        r.BANK_CODE = BankCodeRow.First().Code;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到銀行代碼" + r.NOBR + ";" + r.BANK_CODE + ";");
                    }

                    var giftCodeRow = giftCodeData.Where(p => p.Disp == r.Gift);
                    if (giftCodeRow.Any())
                    {
                        r.Gift = giftCodeRow.First().Code;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到禮物代碼" + r.NOBR + ";" + r.Gift + ";");
                    }
                }
            }
            db.SubmitChanges();
        }

        private void BW2_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.OT
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.YYMM == "201303" && a.KEY_MAN == "JB"
                      select new { BASE = a, b.COMP };
            var sql1 = from a in sql group a.BASE by a.COMP;
            int i = 0;
            int total = sql.Count();
            foreach (var it in sql1)
            {

                var comp = it.Key;
                var roteData = (from a in db.ROTE where db.GetCodeFilter("ROTE", a.ROTE1, "TONY", comp, true).Value select new { Code = a.ROTE1, Disp = a.ROTE_DISP }).ToList();
                var otrcdData = (from a in db.OTRCD where db.GetCodeFilter("OTRCD", a.OTRCD1, "TONY", comp, true).Value select new { Code = a.OTRCD1, Disp = a.OTRCD_DISP }).ToList();
                var deptData = (from a in db.DEPTS where db.GetCodeFilter("DEPTS", a.D_NO, "TONY", comp, true).Value select new { Code = a.D_NO, Disp = a.D_NO_DISP }).ToList();
                foreach (var r in it)
                {
                    i++;
                    BW2.ReportProgress(i * 100 / total, "正在更新" + r.NOBR);

                    var roteRow = roteData.Where(p => p.Disp == r.OT_ROTE);
                    if (roteRow.Any())
                    {
                        r.OT_ROTE = roteRow.First().Code;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到班別代碼" + r.NOBR + ";" + r.OT_ROTE + ";");
                    }

                    var otrcdRow = otrcdData.Where(p => p.Disp == r.OTRCD);
                    if (otrcdRow.Any())
                    {
                        r.OTRCD = otrcdRow.First().Code;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到加班原因代碼" + r.NOBR + ";" + r.OTRCD + ";");
                    }

                    var deptRow = deptData.Where(p => p.Disp == r.OT_DEPT);
                    if (deptRow.Any())
                    {
                        r.OT_DEPT = deptRow.First().Code;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到加班部門代碼" + r.NOBR + ";" + r.OT_DEPT + ";");
                    }
                }
            }
            db.SubmitChanges();
        }

        private void BW1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void BW2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void BW3_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ABS
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.BDATE >= new DateTime(2013, 1, 1)
                      select new { BASE = a, b.COMP };
            var sql1 = from a in sql group a.BASE by a.COMP;
            int i = 0;
            int total = sql.Count();
            foreach (var it in sql1)
            {

                var comp = it.Key;
                var hcodeData = (from a in db.HCODE where db.GetCodeFilter("HCODE", a.H_CODE, "TONY", comp, true).Value select new { Code = a.H_CODE, Disp = a.H_CODE_DISP }).ToList();

                foreach (var r in it)
                {
                    i++;
                    BW3.ReportProgress(i * 100 / total, "正在更新" + r.NOBR);

                    var hcodeRow = hcodeData.Where(p => p.Disp == r.H_CODE);
                    if (hcodeRow.Any())
                    {
                        //r.H_CODE = hcodeRow.First().Code;
                        db.ExecuteCommand("UPDATE ABS SET H_CODE={0} WHERE NOBR={1} AND BDATE={2} AND BTIME={3} AND H_CODE={4}", new object[] { hcodeRow.First().Code, r.NOBR, r.BDATE, r.BTIME, r.H_CODE });
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到假別代碼" + r.NOBR + ";" + r.H_CODE + ";");
                    }
                }
            }
            //db.SubmitChanges();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            sw.Start();
            BW3.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("SELECT * INTO OT_BAK FROM OT");
            MessageBox.Show("備份成功");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            db.ExecuteCommand("DELETE OT");
            db.ExecuteCommand("INSERT INTO OT SELECT * FROM OT_BAK");
            MessageBox.Show("還原成功");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("DROP TABLE OT_BAK");
            MessageBox.Show("刪除成功");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("SELECT * INTO ABS_BAK FROM ABS");
            MessageBox.Show("備份成功");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            db.ExecuteCommand("DELETE ABS");
            db.ExecuteCommand("INSERT INTO ABS SELECT * FROM ABS_BAK");
            MessageBox.Show("還原成功");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行?", "INFO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            db.ExecuteCommand("DROP TABLE ABS_BAK");
            MessageBox.Show("刪除成功");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS where a.ADATE == new DateTime(2013, 3, 18) select a;
            var sql1 = from a in sql group a by a.COMP;
            int i = 0;
            int total = sql.Count();
            foreach (var it in sql1)
            {

                var comp = it.Key;
                var deptData = (from a in db.DEPT where db.GetCodeFilter("dept", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                //var deptsData = (from a in db.DEPTS where db.GetCodeFilter("depts", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                var deptaData = (from a in db.DEPTA where db.GetCodeFilter("depta", a.D_NO, "TONY", comp, true).Value select new { a.D_NO, a.D_NO_DISP }).ToList();
                //var jobData = (from a in db.JOB where db.GetCodeFilter("JOB", a.JOB1, "TONY", comp, true).Value select new { a.JOB1, a.JOB_DISP }).ToList();
                //var jobsData = (from a in db.JOBS where db.GetCodeFilter("JOBS", a.JOBS1, "TONY", comp, true).Value select new { a.JOBS1, a.JOBS_DISP }).ToList();
                //var joblData = (from a in db.JOBL where db.GetCodeFilter("JOBL", a.JOBL1, "TONY", comp, true).Value select new { a.JOBL1, a.JOBL_DISP }).ToList();
                //var stationData = (from a in db.STATION where db.GetCodeFilter("STATION", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                //var OutPostData = (from a in db.OutPost where db.GetCodeFilter("OutPost", a.Code, "TONY", comp, true).Value select new { a.Code, Disp = a.CODE_DISP }).ToList();
                //var ROTETData = (from a in db.ROTET where db.GetCodeFilter("ROTET", a.ROTET1, "TONY", comp, true).Value select new { Code = a.ROTET1, Disp = a.ROTET_DISP }).ToList();
                //var ttscdData = (from a in db.TTSCD where db.GetCodeFilter("TTSCD", a.TTSCD1, "TONY", comp, true).Value select new { Code = a.TTSCD1, Disp = a.TTSCD_DISP }).ToList();
                //var holicdData = (from a in db.HOLICD where db.GetCodeFilter("HOLICD", a.HOLI_CODE, "TONY", comp, true).Value select new { Code = a.HOLI_CODE, Disp = a.HOLI_CODE_DISP }).ToList();

                foreach (var r in it)
                {
                    i++;
                    BW.ReportProgress(i * 100 / total, "正在更新" + r.NOBR);
                    var deptRow = deptData.Where(p => p.D_NO_DISP == r.DEPT);
                    if (deptRow.Any())
                    {
                        r.DEPT = deptRow.First().D_NO;
                    }
                    //else if (deptRow1.Any())
                    //{
                    //    r.DEPT = deptRow1.First().D_NO;
                    //}
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到編制部門代碼" + r.NOBR + ";" + r.DEPT + ";");
                    }

                    //var deptsRow = deptsData.Where(p => p.D_NO_DISP == r.DEPTS);
                    //if (deptsRow.Any())
                    //{
                    //    r.DEPTS = deptsRow.First().D_NO;
                    //}
                    //else
                    //{
                    //    JBModule.Message.TextLog.WriteLog("對應不到成本部門代碼" + r.NOBR + ";" + r.DEPTS + ";");
                    //}

                    var deptaRow = deptaData.Where(p => p.D_NO_DISP == r.DEPTM);
                    if (deptaRow.Any())
                    {
                        r.DEPTM = deptaRow.First().D_NO;
                    }
                    else
                    {
                        JBModule.Message.TextLog.WriteLog("對應不到簽核部門代碼" + r.NOBR + ";" + r.DEPTM + ";");
                    }


                }
            }
            db.SubmitChanges();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //JBHR.Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", tol_hours, sno);
            JBHR.BLL.Repo.DataContextPool dc = new JBHR.BLL.Repo.DataContextPool();
            var absRepo = dc.CreateHolidayRepo();
            var sql = from a in absRepo.GetLeaveUse()
                      where a.BDATE >= new DateTime(2013, 1, 1)
                        && a.H_CODE == "MA01"
                      select a;
            foreach (var it in sql)
            {
                //if (it.BDATE < it.EDATE || it.BTIME.CompareTo(it.ETIME) > 0)
                //if (it.TOL_HOURS == 0)
                //{
                dc.dataContext.ExecuteCommand("DELETE ABS WHERE NOBR={0} AND BDATE={1} AND BTIME={2} AND H_CODE={3}", new object[] { it.NOBR, it.BDATE, it.BTIME, it.H_CODE });
                JBHR.Dll.Att.AbsCal.AbsSaveBy24(it.NOBR, it.H_CODE, it.BDATE, it.EDATE, it.BTIME, it.ETIME, "", it.NOTE, it.KEY_MAN, it.A_NAME, 0, it.SERNO);
                //}
            }
            MessageBox.Show("修改成功");
        }

    }
}
