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
    public partial class FRM2IC : JBControls.JBForm
    {
        public FRM2IC()
        {
            InitializeComponent();
        }
        string year_hcode = "W", ext_year_hcode = "W1", expire_year_hcode = "W3", expire_ext_year_hcode = "W3";
        private void FRM2O_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false, true, true);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false, true, true);
            var joblData = CodeFunction.GetJoblDisp();
            SystemFunction.SetComboBoxItems(ptxJoblB, joblData, false, true, true);
            SystemFunction.SetComboBoxItems(ptxJoblE, joblData, false, true, true);
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.jOBLTableAdapter.Fill(this.dsBas.JOBL);
            this.jOBTableAdapter.Fill(this.dsBas.JOB);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
            this.ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;
            this.ptxJoblB.SelectedValue = joblData.First().Key;
            this.ptxJoblE.SelectedValue = joblData.Last().Key;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1, d2;
            d1 = new DateTime(yy, 1, 1);
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            SetDate(d1);
            ptxNobrB.Focus();
        }
        void SetDate(DateTime d1)
        {
            DateTime d2;
            d2 = new DateTime(d1.Year, 12, 31);
            //txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtDdate.Text = Sal.Core.SalaryDate.DateString(d2);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d2);
            txtExpireDate.Text = Sal.Core.SalaryDate.DateString(d2.AddYears(1));
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime t1, t2;
            t1 = DateTime.Now;
            string nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            jobl_b = ptxJoblB.SelectedValue.ToString();
            jobl_e = ptxJoblE.SelectedValue.ToString();
            DateTime date_b, date_e, date_t, date_expire;
            date_t = Convert.ToDateTime(txtEdate.Text);
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            date_expire = Convert.ToDateTime(txtExpireDate.Text);

            object[] ttscodes = new object[] { 1, 4, 6 };
            var sql = from r in db.BASETTS
                      join b in db.DEPT on r.DEPT equals b.D_NO
                      join c in db.JOBL on r.JOBL equals c.JOBL1
                      where ttscodes.Contains(r.TTSCODE)
                      && date_t >= r.ADATE && date_t <= r.DDATE
                      && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                      && b.D_NO_DISP.CompareTo(dept_b) >= 0 && b.D_NO_DISP.CompareTo(dept_e) <= 0
                      && c.JOBL_DISP.CompareTo(jobl_b) >= 0 && c.JOBL_DISP.CompareTo(jobl_e) <= 0
                      //&& db.GetFilterByNobr(r.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                     && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(r.SALADR)
                      select r;

            if (rdb2.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "D" && !b.COUNT_MA select r;
            else if (rdb3.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "I" && !b.COUNT_MA select r;
            else if (rdb4.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where b.COUNT_MA select r;
            string hcode = "";
            string expire_hcode = "";
            //if (rdbHcode1.Checked)
            //{
            hcode = year_hcode;
            expire_hcode = expire_year_hcode;
            //}
            //else if (rdbHcode2.Checked)
            //{
            //    hcode = ext_year_hcode;
            //    expire_hcode = expire_ext_year_hcode;
            //}

            string cmd = "DELETE FROM ABS WHERE SYSCREATE=1"
                        //+ " AND dbo.GetFilterByNobr(ABS.NOBR,{6},{7},{8})=1"
                        + " AND exists(select 1 from BASETTS x where x.NOBR = ABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({6},{7},{8})))"
                        + " AND BDATE BETWEEN {0} AND {1}"
                        + " AND H_CODE='" + ext_year_hcode + "' "
                        + " AND EXISTS(SELECT NOBR FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO "
                        + " WHERE TTSCODE IN('1','4','6')"
                        + " AND A.NOBR BETWEEN {2} AND {3} AND A.NOBR=ABS.NOBR"
                        + " AND B.D_NO_DISP BETWEEN {4} AND {5}"
                        + " )";
            object[] parameters = new object[] { date_e.AddDays(1), date_expire, nobr_b, nobr_e, dept_b, dept_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, parameters);//先刪延休

            cmd = "DELETE FROM ABS WHERE SYSCREATE=1"
                      //+ " AND dbo.GetFilterByNobr(ABS.NOBR,{6},{7},{8})=1"
                      + " AND exists(select 1 from BASETTS x where x.NOBR = ABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({6},{7},{8})))"
                      + " AND BDATE BETWEEN {0} AND {1}"
                      + " AND H_CODE='W3' "
                       + " AND EXISTS(SELECT NOBR FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO "
                      + " WHERE TTSCODE IN('1','4','6')"
                      + " AND A.NOBR BETWEEN {2} AND {3} AND A.NOBR=ABS.NOBR"
                      + " AND B.D_NO_DISP BETWEEN {4} AND {5}"
                      + " )";
            parameters = new object[] { date_e, date_e, nobr_b, nobr_e, dept_b, dept_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, parameters);//再刪失效

            var absSQLAll = from r in db.ABS
                            join b in db.HCODE on r.H_CODE equals b.H_CODE
                            join c in sql on r.NOBR equals c.NOBR
                            where r.BDATE >= date_b && r.BDATE <= date_e
                            && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                            //&& db.GetFilterByNobr(r.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in db.BASETTS
                                where bts.NOBR == r.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            group new { ABS = r, HCODE = b } by r.NOBR;
            foreach (var itm in absSQLAll)
            {
                var absSQL = itm;
                var plus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == "1" select r;
                //if (rdbHcode2.Checked)
                //plus = from r in plus where r.HCODE.H_CODE == hcode select r;
                var ext = from a in absSQL where a.HCODE.H_CODE == ext_year_hcode select a;//延休
                var minus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == "2" select r;

                decimal plusValue = plus.Any() ? plus.Sum(p => p.ABS.TOL_HOURS) : 0;
                decimal extValue = ext.Any() ? ext.Sum(p => p.ABS.TOL_HOURS) : 0;
                decimal minusValue = minus.Any() ? minus.Sum(p => p.ABS.TOL_HOURS) : 0;
                decimal totalValue = 0;
                if (extValue >= minusValue)//如果延休時數大於扣假時數，代表延休還沒休完(先扣延休)，所以整年度的特休都未使用
                    totalValue = plusValue - extValue;
                else//扣完延休，所以可以直接加項扣掉減項
                    totalValue = plusValue - minusValue;
                if (totalValue != 0)//也可能有負數
                {
                    decimal ExtHrs = totalValue;

                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.A_NAME = "";
                    abs.BDATE = date_e.AddDays(1);//延休生效日期=服務截止日+1天
                    abs.BTIME = "";
                    abs.EDATE = date_expire;//延休失效日期
                    abs.ETIME = "";
                    abs.H_CODE = ext_year_hcode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOBR = itm.Key;
                    abs.NOTE = "";
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = ExtHrs;
                    abs.YYMM = "";
                    db.ABS.InsertOnSubmit(abs);

                    abs = new JBModule.Data.Linq.ABS();
                    abs.A_NAME = "";
                    abs.BDATE = date_e;
                    abs.BTIME = "";
                    abs.EDATE = date_e;
                    abs.ETIME = "";
                    abs.H_CODE = expire_hcode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOBR = itm.Key;
                    abs.NOTE = "";
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = totalValue;//全部失效
                    abs.YYMM = "";
                    db.ABS.InsertOnSubmit(abs);
                }
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

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            var d1 = Convert.ToDateTime(txtBdate.Text);
            SetDate(d1);
        }
    }
}
