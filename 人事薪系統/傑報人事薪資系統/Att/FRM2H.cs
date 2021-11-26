using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
namespace JBHR.Att
{
    public partial class FRM2H : JBControls.JBForm
    {
        public FRM2H()
        {
            InitializeComponent();
        }
        bool isBreak = false;
        private void FRM2H_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            //bASETableAdapter.Fill(this.dsBas.BASE);
            ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
            ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            //ptxDeptB.Text = this.dsBas.DEPT.First().D_NO;
            //ptxDeptE.Text = this.dsBas.DEPT.Last().D_NO;
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            //SalaryDate sd = new SalaryDate(DateTime.Now.Date);
            txtYearB.Text = DateTime.Now.Date.Year.ToString();
            txtMonthB.Text = DateTime.Now.Date.Month.ToString();
            txtYearE.Text = DateTime.Now.Date.Year.ToString();
            txtMonthE.Text = DateTime.Now.Date.Month.ToString();
            //txtDDate.Text = Function.GetDate(DateTime.Now);
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string nobr_b, nobr_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            string dept_b, dept_e;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            string yymm_b, yymm_e;
            int y1, m1, y2, m2;
            //y1 = Convert.ToInt32(txtYearB.Text);
            //m1 = Convert.ToInt32(txtMonthB.Text);
            //y2 = Convert.ToInt32(txtYearE.Text);
            //m2 = Convert.ToInt32(txtMonthE.Text);
            //SalaryDate sd1 = new SalaryDate(y1, m1);
            //SalaryDate sd2 = new SalaryDate(y2, m2);
            yymm_b = new DateTime(int.Parse(txtYearB.Text),int.Parse( txtMonthB.Text),1).ToString("yyyyMM");//sd1.YYMM;
            yymm_e = new DateTime(int.Parse(txtYearE.Text), int.Parse(txtMonthE.Text), 1).ToString("yyyyMM");//sd2.YYMM;
            object[] PARMS = new object[] { nobr_b, nobr_e, dept_b, dept_e, yymm_b, yymm_e };
            //JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //var lockCheck = from a in db.DATA_PASS where a.DATA_PASS1 >= sd0.FirstDayOfAttend && a.DATA_PASS1 <= sd0.LastDayOfAttend select a;
            //if (lockCheck.Any() && MessageBox.Show(Resources.Att.ContainAttLock + "," + Resources.Att.ToBeContinue, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
            //{
            //    return;
            //}

            BW.RunWorkerAsync(PARMS);
            panel2.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SetList(List<string> lst, string Value, int count)
        {
            if (Value == null || Value.Trim().Length == 0 || isBreak)
            {
                isBreak = true;
                return;

            }
            for (int i = 0; i < count; i++)
                lst.Add(Value);
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            dcAttDataContext dbAtt = new dcAttDataContext();
            var param = e.Argument as object[];
            DateTime t1, t2;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e, yymm, prevYymm, yymm_b, yymm_e;
            nobr_b = param[0].ToString();
            nobr_e = param[1].ToString();
            dept_b = param[2].ToString();
            dept_e = param[3].ToString();
            yymm_b = param[4].ToString();
            yymm_e = param[5].ToString();
            //ddate = txtDDate.Text;
            int y1, m1;

            for (int x = Convert.ToInt32(yymm_b); x <= Convert.ToInt32(yymm_e); x = SetMonthDate(x))
            {
                y1 = Convert.ToInt32(x.ToString().Substring(0, 4));
                m1 = Convert.ToInt32(x.ToString().Substring(4, 2));
                //SalaryDate sd0 = new SalaryDate(y1, m1);
                //yymm = sd0.YYMM;
                //SalaryDate pd = sd0.GetPrevSalaryDate();
                //prevYymm = pd.YYMM;//上個月的計薪年月
                //SalaryDate sd = new SalaryDate(yymm);
                //DateTime d1, d2;
                //d1 = sd.FirstDayOfMonth;
                //d2 = sd.LastDayOfMonth;
                yymm = x.ToString();
                DateTime d1, d2;
                d1 = new DateTime(y1, m1, 1);
                d2 = d1.AddMonths(1).AddDays(-1);

                object[] parms = new object[] { nobr_b, nobr_e, dept_b, dept_e, yymm, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
                //刪除指定區間內的資料
                //db.ExecuteCommand("delete tmtable where "
                //    + " exists(select * from basetts a join dept b on a.dept=b.d_no"
                //    + " where a.nobr between {0} and {1} and "
                //    + " b.d_no_disp between {2} and {3} and a.nobr=tmtable.nobr)"
                //    + " and yymm={4} and dbo.getfilterbynobr(nobr,{5},{6},{7})=1", parms);
                string deleteTmtable = Sal.Function.DeleteCommand("TMTABLE", nobr_b, nobr_e, dept_b, dept_e)
                    + " AND YYMM={4}";
                db.ExecuteCommand(deleteTmtable, parms);

                //object[] PARMS = new object[] { nobr_b, nobr_e, dept_b, dept_e, d1, d2, MainForm.WORKADR, MainForm.PROCSUPER };
                //if (checkBox1.Checked)
                //    db.ExecuteCommand("DELETE ATTEND WHERE EXISTS(SELECT * FROM BASETTS WHERE BASETTS.NOBR BETWEEN {0} AND {1} AND BASETTS.DEPT BETWEEN {2} AND {3} AND TTSCODE IN('1','4','6') AND BASETTS.NOBR=ATTEND.NOBR AND (SALADR={6} OR {7}=1)) AND ATTEND.ADATE BETWEEN {4} AND {5}", PARMS);

                //db.ExecuteCommand("delete tmtable_TMP where ROTE='{5}' and yymm={4}", parms);
                //產生班表

                dsAtt.TMTABLEDataTable dtTmt = new dsAtt.TMTABLEDataTable();
                var holiList = (from rHoli in dbAtt.HOLI where rHoli.H_DATE >= d1 && rHoli.H_DATE <= d2 select rHoli).ToList();

                var _HoliCode = (from _HoliCodei in dbAtt.OTHCODE select _HoliCodei).ToList();


                List<string> ttscodeList = new List<string>();
                ttscodeList.Add("1");
                ttscodeList.Add("4");
                ttscodeList.Add("6");

                var sql = from rbs in db.BASE
                          join rbt in db.BASETTS on rbs.NOBR equals rbt.NOBR
                          join rotet in db.ROTET on rbt.ROTET equals rotet.ROTET1
                          join a in db.DEPT on rbt.DEPT equals a.D_NO
                          //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on rbs.NOBR equals d.NOBR
                          where rbt.ADATE <= d2 && rbt.DDATE >= d1
                          && rbt.NOBR.CompareTo(nobr_b) >= 0 && rbt.NOBR.CompareTo(nobr_e) <= 0
                          && a.D_NO_DISP.CompareTo(dept_b) >= 0 && a.D_NO_DISP.CompareTo(dept_e) <= 0
                          && ttscodeList.Contains(rbt.TTSCODE)
                          //&& db.GetFilterByNobr(rbs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(rbt.SALADR)
                          select rbs.NOBR;
                var lst = sql.Distinct().ToList();
                int count = 0;
                foreach(var it in lst)
                {
                    BW.ReportProgress(count * 100 / lst.Count, "正在產生員工" + it+"-"+yymm + "班表");
                    JBHR.BLL.Att.TimeTableGenerator tg = new BLL.Att.TimeTableGenerator(it, yymm);
                    tg.KeyMan = MainForm.USER_NAME;
                    tg.Generate(checkBox1.Checked);
                }
            }
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
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            panel2.Enabled = true;
        }

        int SetMonthDate(int yymm)
        {
            string sYear = yymm.ToString().Substring(0, 4);
            string sMonth = yymm.ToString().Substring(4, 2);
            int iYear = int.Parse(sYear);
            int iMonth = int.Parse(sMonth);
            if (iMonth + 1 > 12)
            {
                iYear = iYear + 1;
                iMonth = 1;
            }
            else
            {
                iMonth = iMonth + 1;
            }
            //if (iMonth.ToString().Length < 2)
            //    sMonth = "0" + iMonth.ToString();
            //else
            //    sMonth = iMonth.ToString();
            //sYear = iYear.ToString();
            return iYear * 100 + iMonth;
        }
    }

}
