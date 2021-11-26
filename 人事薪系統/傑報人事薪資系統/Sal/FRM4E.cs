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
    public partial class FRM4E : JBControls.JBForm
    {
        public FRM4E()
        {
            InitializeComponent();
        }
        string inscd = "3";
        string salcode = MainForm.GroupInsConfig.GROUPSALCD;//建議值

        int yy, mm;
        private void FRM4E_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            txtYear.Text = SalaryDate.YearString();
            txtMonth.Text = SalaryDate.MonthString();
            ptxNobrB.Text = this.salaryDS.BASE.First().NOBR;
            ptxNobrE.Text = this.salaryDS.BASE.Last().NOBR;
            ptxDeptB.SelectedValue = deptData.First().Key;
            ptxDeptE.SelectedValue = deptData.Last().Key;
            salcode = MainForm.GroupInsConfig.GROUPSALCD;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行團保計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);

            string nobr_b, nobr_e, dept_b, dept_e, yymm;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            yymm = yy.ToString("0000") + mm.ToString("00");
            if (Function.IsSalaryLocked(yymm, "2", MainForm.WORKADR))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string[] parms = new string[] { nobr_b, nobr_e, dept_b, dept_e, yymm };
            BW.RunWorkerAsync(parms);
            this.panel1.Enabled = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;


            string nobr_b, nobr_e, dept_b, dept_e, yymm;
            string[] pms = e.Argument as string[];
            nobr_b = pms[0];
            nobr_e = pms[1];
            dept_b = pms[2];
            dept_e = pms[3];
            yymm = pms[4];

            SalaryDate sd = new SalaryDate(yy, mm);

            SalaryMDDataContext db = new SalaryMDDataContext();

            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            DateTime d1, d2;
            d1 = sd.FirstDayOfMonth;
            d2 = sd.LastDayOfMonth;
            JBTools.Intersection itsMonth = new JBTools.Intersection();
            itsMonth.Inert(d1, d2);
            int MonthDays = itsMonth.GetDays();
            var sql = from a in db.INSGRP
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      let TtsData = (from d in db.BASETTS where d.NOBR == a.NOBR && d.ADATE <= d2 && d.DDATE.Value >= d1 && ttscodeList.Contains(d.TTSCODE) select new { d.NOBR, d.ADATE, DDATE = d.DDATE.Value })
                      where sd.LastDayOfMonth >= b.ADATE && sd.FirstDayOfMonth <= b.DDATE.Value
                      && ttscodeList.Contains(b.TTSCODE)
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                      && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                      && a.IN_DATE <= sd.LastDayOfAttend && a.OUT_DATE >= sd.FirstDayOfAttend
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      group new { INSGRP = a, TtsData } by a.NOBR;



            //string deleteCmd = "DELETE EXPLAB WHERE YYMM={0} AND NOBR BETWEEN {1} AND {2}" +
            //    " AND EXISTS(SELECT * FROM BASETTS WHERE BASETTS.NOBR=EXPLAB.NOBR" +
            //    " AND {5} BETWEEN BASETTS.ADATE AND BASETTS.DDATE AND BASETTS.DEPT BETWEEN {3} AND {4}) AND SAL_CODE={6}" + " AND dbo.GetFilterByNobr(EXPLAB.NOBR,{7},{8},{9})=1";
            //object[] parms = new object[] { sd.YYMM, nobr_b, nobr_e, dept_b, dept_e, sd.LastDayOfMonth, salcode, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            //db.ExecuteCommand(deleteCmd, parms);
            Delete(yymm, nobr_b, nobr_e, dept_b, dept_e);
            int counts = sql.Count();
            int i = 0;
            foreach (var gp in sql)
            {
                int workDays = 0;

                foreach (var it in gp.First().TtsData)
                {
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(d1, d2);
                    its.Inert(it.ADATE, it.DDATE);
                    workDays += its.GetDays();
                }
                var itm = gp.First();//只取一筆
                i++;
                BW.ReportProgress((i * 100 / counts), Resources.Sal.StatusComputing + gp.Key);
                EXPLAB exp = new EXPLAB();
                exp.ADATE = sd.LastDayOfMonth;
                exp.COMP = JBModule.Data.CEncrypt.Number(itm.INSGRP.COPEXP);
                exp.DAYS = 1;
                exp.EXP = JBModule.Data.CEncrypt.Number(itm.INSGRP.TOTEXP);
                if (MonthDays > workDays)
                {
                    decimal comp = Math.Round(itm.INSGRP.COPEXP * workDays / 30M, MidpointRounding.AwayFromZero);
                    decimal self = Math.Round(itm.INSGRP.TOTEXP * workDays / 30M, MidpointRounding.AwayFromZero);
                    exp.COMP = JBModule.Data.CEncrypt.Number(comp);
                    exp.EXP = JBModule.Data.CEncrypt.Number(self);
                }
                exp.FA_IDNO = "";
                exp.FUNDAMT = 0;
                exp.INSCD = 0;
                exp.INSUR_TYPE = inscd;
                exp.JOBAMT = 0;
                exp.KEY_DATE = DateTime.Now;
                exp.KEY_MAN = MainForm.USER_NAME;
                exp.NOBR = itm.INSGRP.NOBR;
                exp.NOTEDIT = true;
                exp.RATE_CODE = "";
                exp.S_NO = "";
                exp.SAL_CODE = salcode;
                exp.YYMM = sd.YYMM;
                exp.SAL_YYMM = exp.YYMM;
                if (exp.EXP == 10 && exp.COMP == 10) continue;//0不入資料
                db.EXPLAB.InsertOnSubmit(exp);
            }
            BW.ReportProgress(100, Resources.Sal.StatusWriteToDB);
            db.SubmitChanges();
            BW.ReportProgress(100, Resources.Sal.StatusFinish);
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.panel1.Enabled = true;
        }
        void Delete(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e)
        {
            SalaryMDDataContext smd = new SalaryMDDataContext();
            SalaryDate sd = new SalaryDate(yymm);
            object[] parms = new object[] { yymm, nobr_b, nobr_e, dept_b, dept_e, sd.FirstDayOfMonth, sd.LastDayOfMonth, MainForm.GroupInsConfig.GROUPSALCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            smd.ExecuteCommand("DELETE FROM EXPLAB"
                                + " WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN A.ADATE AND A.DDATE "
                                + " AND A.NOBR BETWEEN {1} AND {2} AND B.D_NO_DISP BETWEEN {3} AND {4} AND EXPLAB.NOBR=A.NOBR)"
                                //+ " AND dbo.GetFilterByNobr(EXPLAB.NOBR,{8},{9},{10})=1"
                                + " AND exists(select 1 from BASETTS x where x.NOBR=EXPLAB.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({8},{9},{10})))"
                                + " AND (EXPLAB.SAL_YYMM = {0}) AND SAL_CODE={7}", parms);
        }
    }
}
