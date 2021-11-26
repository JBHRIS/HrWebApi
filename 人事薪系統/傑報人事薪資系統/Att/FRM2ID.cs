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
    public partial class FRM2ID : JBControls.JBForm
    {
        public FRM2ID()
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
            this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            this.ptxDeptB.SelectedValue = Sal.BaseValue.MinDept;
            this.ptxDeptE.SelectedValue = Sal.BaseValue.MaxDept;
            this.ptxJoblB.SelectedValue = Sal.BaseValue.MinJobl;
            this.ptxJoblE.SelectedValue = Sal.BaseValue.MaxJobl;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1, d2;
            d1 = new DateTime(yy, 1, 1);
            d2 = new DateTime(yy, 12, 31);
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtDdate.Text = Sal.Core.SalaryDate.DateString(d2);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d2);
            txtExpireDate.Text = Sal.Core.SalaryDate.DateString();
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
            if (rdbHcode1.Checked)
            {
                hcode = year_hcode;
                expire_hcode = expire_year_hcode;
            }
            else if (rdbHcode2.Checked)
            {
                hcode = ext_year_hcode;
                expire_hcode = expire_ext_year_hcode;
            }

            string cmd = "DELETE FROM ABS WHERE SYSCREATE=1"
                        //+ " AND dbo.GetFilterByNobr(ABS.NOBR,{6},{7},{8})=1"
                        + " AND exists(select 1 from BASETTS x where x.NOBR=ABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList('{6}','{7}',{8})))"
                        + " AND BDATE BETWEEN {0} AND {1}"
                        + " AND H_CODE='W3' "
                        + " AND EXISTS(SELECT NOBR FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO"
                        + " WHERE A.TTSCODE IN('1','4','6')"
                        + " AND A.NOBR BETWEEN {2} AND {3} AND ABS.NOBR=A.NOBR"
                        + " AND B.D_NO_DISP BETWEEN {4} AND {5}"
                        + " )";
            object[] parameters = new object[] { date_b, date_e, nobr_b, nobr_e, dept_b, dept_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, parameters);

            foreach (var itm in sql)
            {
                var absSQL = from r in db.ABS where r.NOBR == itm.NOBR && r.BDATE >= date_b && r.EDATE <= date_e select r;
                var plus = from r in absSQL join h in db.HCODE on r.H_CODE equals h.H_CODE where h.YEAR_REST.Trim() == "1" select r;
                //if (rdbHcode2.Checked)
                plus = from r in plus where r.H_CODE == hcode select r;
                var minus = from r in absSQL join h in db.HCODE on r.H_CODE equals h.H_CODE where h.YEAR_REST.Trim() == "2" select r;
                decimal plusValue = plus.Any() ? plus.Sum(p => p.TOL_HOURS) : 0;
                decimal minusValue = minus.Any() ? minus.Sum(p => p.TOL_HOURS) : 0;
                decimal totalValue = plusValue - minusValue;
                if (totalValue != 0)
                {
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.A_NAME = "";
                    abs.BDATE = date_expire;
                    abs.BTIME = "";
                    abs.EDATE = new DateTime(1900, 1, 1);
                    abs.ETIME = "";
                    abs.H_CODE = expire_hcode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOBR = itm.NOBR;
                    abs.NOTE = "";
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = totalValue;
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
    }
}
