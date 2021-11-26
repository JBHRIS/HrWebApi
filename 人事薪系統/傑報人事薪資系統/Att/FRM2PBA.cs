using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
namespace JBHR.Att
{
    public partial class FRM2PBA : JBControls.JBForm
    {
        public FRM2PBA()
        {
            InitializeComponent();
        }
        private void FRM2O_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            var roteData = CodeFunction.GetRoteDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            SystemFunction.SetComboBoxItems(ptxRoteB, roteData, false);
            SystemFunction.SetComboBoxItems(ptxRoteE, roteData, false);
            var hcodeData = CodeFunction.GetHcode();
            SystemFunction.SetComboBoxItems(comboBox1, hcodeData, true);
            SystemFunction.SetComboBoxItems(comboBox2, hcodeData, true);
            SystemFunction.SetComboBoxItems(comboBox3, hcodeData, true);
            //this.hCODETableAdapter.FillByDiscount(this.dsAtt.HCODE);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
            this.ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;
            this.ptxRoteB.SelectedValue = roteData.Where(p =>!CodeFunction.GetHolidayRoteList().Contains( p.Key)).First().Key;
            this.ptxRoteE.SelectedValue = roteData.Last().Key;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1;
            d1 = DateTime.Now.Date;
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtChkDateB.Text = txtBdate.Text;
            txtChkDateE.Text = txtEdate.Text;
            txtChkTimeB.Text = "0000";
            txtChkTimeE.Text = "2400";

            txtChkDateB.Enabled = chkCheck.Checked;
            txtChkDateE.Enabled = chkCheck.Checked;
            txtChkTimeB.Enabled = chkCheck.Checked;
            txtChkTimeE.Enabled = chkCheck.Checked;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime t1, t2;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            rote_b = ptxRoteB.SelectedValue.ToString();
            rote_e = ptxRoteE.SelectedValue.ToString();

            object[] ttscodes = new object[] { 1, 4, 6 };

            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtBdate.Text);
            d2 = Convert.ToDateTime(txtEdate.Text);

            DateTime D1, D2;
            D1 = Convert.ToDateTime(txtChkDateB.Text);
            D2 = Convert.ToDateTime(txtChkDateE.Text);
            string T1, T2;
            T1 = txtChkTimeB.Text;
            T2 = txtChkTimeE.Text;
            D1 = D1.AddHours(GetHour(T1)).AddMinutes(GetMinute(T1));
            D2 = D2.AddHours(GetHour(T2)).AddMinutes(GetMinute(T2));

            List<string> hcodeList = new List<string>();
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox1.SelectedValue.ToString());
            if (comboBox2.SelectedValue != null && comboBox2.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox2.SelectedValue.ToString());
            if (comboBox3.SelectedValue != null && comboBox3.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox3.SelectedValue.ToString());

            List<JBModule.Data.Linq.ABSPRE> abspreList = new List<JBModule.Data.Linq.ABSPRE>();
            while (d1 <= d2)
            {
                var sql = from r in db.BASETTS
                          join a in db.ATTEND on r.NOBR equals a.NOBR
                          join ro in db.ROTE on a.ROTE equals ro.ROTE1
                          join b in db.DEPT on r.DEPT equals b.D_NO
                          where ttscodes.Contains(r.TTSCODE)
                          && d1 >= r.ADATE && d1 <= r.DDATE
                          && a.ADATE >= r.ADATE && a.ADATE <= r.DDATE
                          && a.ADATE == d1//每個迴圈檢察一天的資料，沒有當天出勤就略過
                              //查詢條件
                          && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                          && b.D_NO_DISP.CompareTo(dept_b) >= 0 && b.D_NO_DISP.CompareTo(dept_e) <= 0
                          && ro.ROTE_DISP.CompareTo(rote_b) >= 0 && ro.ROTE_DISP.CompareTo(rote_e) <= 0
                          && r.CALABS == false//未選取不計算請假
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(r.SALADR)
                          select new { a.NOBR, a.ROTE, ro.ON_TIME, ro.OFF_TIME };
                DeleteAbsPre(d1);
                foreach (var itm in sql)
                {
                    JBHR.BLL.AbsenseFactory af = new BLL.AbsenseFactory();
                    var apply = af.CreateAbsApply();
                    var condition = new JBModule.Data.Dto.AbsenceApply();
                    string BTIME = itm.ON_TIME;
                    string ETIME = itm.OFF_TIME;
                    if (BTIME.Trim().Length == 0 || ETIME.Trim().Length == 0) continue;//沒有時間就略過
                    if (chkCheck.Checked)
                    {
                        DateTime RD1, RD2;
                        RD1 = d1;
                        RD2 = d2;
                        RD1 = RD1.AddHours(GetHour(BTIME)).AddMinutes(GetMinute(BTIME));
                        RD2 = RD2.AddHours(GetHour(ETIME)).AddMinutes(GetMinute(ETIME));
                        DateTime DD1, DD2;
                        DD1 = D1 > RD1 ? D1 : RD1;//交集取最大開始時間
                        DD2 = D2 < RD2 ? D2 : RD2;//交集取最小結束時間

                        if (DD1 >= DD2)//代表無交集,表示該班別不影響
                            continue;
                        string TT1, TT2;
                        TT1 = DD1.ToString("HHmm");
                        TT2 = DD2.ToString("HHmm");
                        if (DD1.Date > d1)//跨夜48小時顯示
                            TT1 = AddHour(TT1, 24);
                        if (DD2.Date > d1)//跨夜48小時顯示
                            TT2 = AddHour(TT2, 24);
                        BTIME = TT1;
                        ETIME = TT2;
                    }
                    condition.ApplyBeginDate = d1.AddTime(BTIME);
                    condition.ApplyEndDate = d1.AddTime(ETIME);
                    condition.EmployeeID = itm.NOBR;
                    condition.Hcode = hcodeList[0];
                    var absApply = apply.GenerateABS(condition);
                    decimal sugHrs = absApply.Sum(p => p.TOL_HOURS);
                    foreach (var hcode in hcodeList)
                    {
                        condition.Hcode = hcode;
                        absApply = apply.GenerateABS(condition);
                      
                        if (sugHrs <= 0) continue;
                        JBModule.Data.Linq.ABSPRE ae = new JBModule.Data.Linq.ABSPRE();
                        ae.ABS1_HRS = 0;
                        ae.ABS2_HRS = 0;
                        ae.ADATE = d1;
                        ae.BTIME = BTIME;
                        ae.ETIME = ETIME;

                        ae.H_CODE = hcode;
                        ae.KEY_DATE = DateTime.Now;
                        ae.KEY_MAN = MainForm.USER_NAME;
                        ae.NOBR = itm.NOBR;
                        //var abs_calc = Dll.Att.AbsCal.AbsCalculation(itm.NOBR, ae.H_CODE, ae.ADATE, ae.ADATE, ae.BTIME, ae.ETIME, "");
                        //if (abs_calc.sHcodeUnit == "小時")
                        //    ae.SUG_HRS = abs_calc.iTotalHour;
                        //else ae.SUG_HRS = abs_calc.iTotalDay;



                        var aif = new JBHR.BLL.AbsInfoFactory();
                        decimal LeaveHours = 0;
                        var infoCond = new BLL.AbsInfoQueryCondition();
                        infoCond.Adate = ae.ADATE;
                        infoCond.EmployeeID = ae.NOBR;
                        infoCond.HolidayCode = ae.H_CODE;
                        
                        var absValidate = af.CreateAbsValidate();
                        var checkValidate = absValidate.Validate(absApply);
                        decimal CurrentApplyHours = 0;
                        var abspreData = from a in abspreList where a.NOBR == ae.NOBR && a.H_CODE == hcode select a;
                        if (abspreData.Any()) CurrentApplyHours = abspreData.Sum(p => p.ABS_HRS);

                        decimal AbsHrs = sugHrs;
                        if (!checkValidate && absValidate.RejectCode == 201002)
                        {
                            var absInfo = aif.getInfo(infoCond);
                            LeaveHours = absInfo.totalHours;
                            AbsHrs = LeaveHours - CurrentApplyHours;//如果剩餘時數不足，就只產生剩餘時數
                        }

                        ae.SUG_HRS = AbsHrs;
                        if (ae.SUG_HRS <= 0) continue;//略過沒有時數的記錄
                        ae.ABS_HRS = ae.SUG_HRS;
                        ae.TRANS = false;
                        ae.DDATE = d1;
                        SalaryDate sd = new SalaryDate(d1);
                        ae.YYMM = sd.YYMM;
                        db.ABSPRE.InsertOnSubmit(ae);
                        abspreList.Add(ae);
                        sugHrs -= AbsHrs;
                    }
                }
                d1 = d1.AddDays(1);
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
        void DeleteAbsPre(DateTime dd)
        {
            string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            DateTime date_b, date_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            rote_b = ptxRoteB.SelectedValue.ToString();
            rote_e = ptxRoteE.SelectedValue.ToString();
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            dcAttDataContext db = new dcAttDataContext();
            string cmd = "DELETE ABSPRE WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND A.NOBR=ABSPRE.NOBR AND {6} BETWEEN A.ADATE AND A.DDATE) AND ADATE = {6} AND EXISTS(SELECT * FROM ATTEND JOIN ROTE ON ATTEND.ROTE=ROTE.ROTE WHERE  ROTE_DISP BETWEEN {4} AND {5} AND ATTEND.NOBR=ABSPRE.NOBR AND ATTEND.ADATE=ABSPRE.ADATE)" + " and " + Sal.Function.GetFilterCmdByNobrOfWrite("ABSPRE.NOBR");
            object[] PARA = new object[] { nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e, dd };
            db.ExecuteCommand(cmd, PARA);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DateTime date_b, date_e;
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);

            DateTime t1, t2;
            t1 = DateTime.Now;

            for (DateTime dd = date_b; dd <= date_e; dd = dd.AddDays(1))
                DeleteAbsPre(dd);

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        int GetHour(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(0, 2));
        }
        int GetMinute(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(2, 2));
        }
        string AddHour(string HHmm, decimal hour)
        {
            var HH = GetHour(HHmm) + Math.Ceiling(hour);
            var mm = GetMinute(HHmm) + (hour % 1M) * 60M;
            if (mm >= 60)
            {
                HH++;
                mm -= 60;
            }
            return HH.ToString("00") + mm.ToString("00");
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            txtChkDateB.Text = txtBdate.Text;
        }

        private void txtEdate_Validated(object sender, EventArgs e)
        {
            txtChkDateE.Text = txtEdate.Text;
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtChkDateB.Enabled = chkCheck.Checked;
            txtChkDateE.Enabled = chkCheck.Checked;
            txtChkTimeB.Enabled = chkCheck.Checked;
            txtChkTimeE.Enabled = chkCheck.Checked;
        }
    }
}
