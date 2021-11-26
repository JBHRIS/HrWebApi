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
    public partial class FRM2IA : JBControls.JBForm
    {
        public FRM2IA()
        {
            InitializeComponent();
        }
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        //string year_hcode = "W2", ext_year_hcode = "W6", expire_year_hcode = "W5";//, expire_ext_year_hcode = "W3";
        private void FRM2O_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2IA", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("ExtCode1", "特休延休代碼", "", "設定特休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExpireCode1", "特休失效代碼", "", "設定特休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExtCode2", "補休延休代碼", "", "設定補休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExpireCode2", "補休失效代碼", "", "設定補休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExtCode3", "彈休延休代碼", "", "設定彈休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExpireCode3", "彈休失效代碼", "", "設定彈休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(cbxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(cbxDeptE, deptData, false);
            var joblData = CodeFunction.GetJoblDisp();
            SystemFunction.SetComboBoxItems(cbxJoblB, joblData, false);
            SystemFunction.SetComboBoxItems(cbxJoblE, joblData, false);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
            this.ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            this.cbxDeptB.SelectedValue = deptData.First().Key;
            this.cbxDeptE.SelectedValue = deptData.Last().Key;
            this.cbxJoblB.SelectedValue = joblData.First().Key;
            this.cbxJoblE.SelectedValue = joblData.Last().Key;
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
            if (MessageBox.Show("確定要執行延休作業?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                string ExtCode, ExpireCode;
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2IA", MainForm.COMPANY);//reload
                DateTime t1, t2;
                t1 = DateTime.Now;
                if (rdbType1.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode1").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode1").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定特休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定特休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    CalcLeaveExtend("1", "2", ExtCode, ExpireCode);
                }
                if (rdbType2.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode2").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode2").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定補休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定補休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    CalcComposeLeaveExtend("3", "4", ExtCode, ExpireCode);
                }
                if (rdbType3.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode3").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode3").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定彈休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定彈休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    CalcOptionalLeaveExtend("5", "6", ExtCode, ExpireCode);
                }

                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        void CalcLeaveExtend(string GetYearRest, string UseYearRest, string ExtCode, string ExpireCode)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = cbxDeptB.SelectedValue.ToString();
            dept_e = cbxDeptE.SelectedValue.ToString();
            jobl_b = cbxJoblB.SelectedValue.ToString();
            jobl_e = cbxJoblE.SelectedValue.ToString();
            DateTime date_b, date_e, date_t, date_expire;
            date_t = Convert.ToDateTime(txtEdate.Text);
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            date_expire = Convert.ToDateTime(txtExpireDate.Text);

            object[] ttscodes = new object[] { 1, 4, 6 };
            var sql = from r in db.BASETTS
                      join d in db.DEPT on r.DEPT equals d.D_NO
                      join f in db.JOBL on r.JOBL equals f.JOBL1
                      where ttscodes.Contains(r.TTSCODE)
                      && date_t >= r.ADATE && date_t <= r.DDATE
                      && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                      && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && f.JOBL_DISP.CompareTo(jobl_b) >= 0 && f.JOBL_DISP.CompareTo(jobl_e) <= 0
                      select r;

            if (rdb2.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "D" && !b.COUNT_MA select r;
            else if (rdb3.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "I" && !b.COUNT_MA select r;
            else if (rdb4.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where b.COUNT_MA select r;
            string hcode = "";
            string expire_hcode = "";
            //if (rdbHcode1.Checked)
            //{
            hcode = ExtCode;
            expire_hcode = ExpireCode;
            //}
            //else if (rdbHcode2.Checked)
            //{
            //    hcode = ext_year_hcode;
            //    expire_hcode = expire_ext_year_hcode;
            //}

            DeleteLeaveExtend(GetYearRest, UseYearRest, ExtCode, ExpireCode);

            var absSQLAll = from r in db.ABS
                            join b in db.HCODE on r.H_CODE equals b.H_CODE
                            join c in sql on r.NOBR equals c.NOBR
                            where r.BDATE >= date_b && r.BDATE <= date_e
                            && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                            && new string[] { GetYearRest, UseYearRest }.Contains(b.YEAR_REST)
                            orderby r.BDATE
                            group new { ABS = r, HCODE = b } by r.NOBR;
            foreach (var itm in absSQLAll)
            {
                var absSQL = itm;
                var plus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == GetYearRest select r;
                //if (rdbHcode2.Checked)
                //plus = from r in plus where r.HCODE.H_CODE == hcode select r;
                var ext = from a in absSQL where a.HCODE.H_CODE == ExtCode select a;//延休
                var minus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == UseYearRest select r;

                var plusDesc = plus.GroupBy(p => p.ABS.EDATE).OrderByDescending(p => p.Key);


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

                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.A_NAME = "";
                    abs.BDATE = date_e.AddDays(1);//延休生效日期=服務截止日+1天
                    abs.BTIME = "";
                    abs.EDATE = new DateTime(abs.BDATE.Year, 12, 31);//延休失效日期
                    abs.ETIME = "";
                    abs.H_CODE = hcode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOBR = itm.Key;
                    abs.NOTE = "";
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = totalValue;
                    abs.YYMM = "";
                    db.ABS.InsertOnSubmit(abs);

                }
                JBModule.Data.Linq.ABS abs1 = new JBModule.Data.Linq.ABS();
                abs1.A_NAME = "";
                abs1.BDATE = date_e;
                abs1.BTIME = "";
                abs1.EDATE = date_e;
                abs1.ETIME = "";
                abs1.H_CODE = ExpireCode;
                abs1.KEY_DATE = DateTime.Now;
                abs1.KEY_MAN = MainForm.USER_NAME;
                abs1.NOBR = itm.Key;
                abs1.NOTE = "";
                abs1.NOTEDIT = false;
                abs1.SERNO = "";
                abs1.SYSCREATE = true;
                abs1.TOL_DAY = 0;
                abs1.TOL_HOURS = totalValue;//全部失效
                abs1.YYMM = "";
                db.ABS.InsertOnSubmit(abs1);
            }

            db.SubmitChanges();
        }
        void CalcComposeLeaveExtend(string GetYearRest, string UseYearRest, string ExtCode, string ExpireCode)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = cbxDeptB.SelectedValue.ToString();
            dept_e = cbxDeptE.SelectedValue.ToString();
            jobl_b = cbxJoblB.SelectedValue.ToString();
            jobl_e = cbxJoblE.SelectedValue.ToString();
            DateTime date_b, date_e, date_t, date_expire;
            date_t = Convert.ToDateTime(txtEdate.Text);
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            date_expire = Convert.ToDateTime(txtExpireDate.Text);

            object[] ttscodes = new object[] { 1, 4, 6 };
            var sql = from r in db.BASETTS
                      join d in db.DEPT on r.DEPT equals d.D_NO
                      join f in db.JOBL on r.JOBL equals f.JOBL1
                      where ttscodes.Contains(r.TTSCODE)
                      && date_t >= r.ADATE && date_t <= r.DDATE
                      && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                      && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && f.JOBL_DISP.CompareTo(jobl_b) >= 0 && f.JOBL_DISP.CompareTo(jobl_e) <= 0
                      select r;

            if (rdb2.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "D" && !b.COUNT_MA select r;
            else if (rdb3.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "I" && !b.COUNT_MA select r;
            else if (rdb4.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where b.COUNT_MA select r;
            string hcode = "";
            string expire_hcode = "";
            //if (rdbHcode1.Checked)
            //{
            hcode = ExtCode;
            expire_hcode = ExpireCode;
            //}
            //else if (rdbHcode2.Checked)
            //{
            //    hcode = ext_year_hcode;
            //    expire_hcode = expire_ext_year_hcode;
            //}

            DeleteLeaveExtend(GetYearRest, UseYearRest, ExtCode, ExpireCode);

            var absSQLAll = from r in db.ABS
                            join b in db.HCODE on r.H_CODE equals b.H_CODE
                            join c in sql on r.NOBR equals c.NOBR
                            where r.BDATE >= date_b && r.BDATE <= date_e
                            && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                            && new string[] { GetYearRest, UseYearRest }.Contains(b.YEAR_REST)
                            orderby r.BDATE
                            group new { ABS = r, HCODE = b } by r.NOBR;
            foreach (var itm in absSQLAll)
            {
                var absSQL = itm;
                var plus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == GetYearRest select r;
                //if (rdbHcode2.Checked)
                //plus = from r in plus where r.HCODE.H_CODE == hcode select r;
                var ext = from a in absSQL where a.HCODE.H_CODE == ExtCode select a;//延休
                var minus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == UseYearRest select r;

                var plusDesc = plus.GroupBy(p => p.ABS.EDATE).OrderByDescending(p => p.Key);


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
                    decimal ExtHrsTmp = totalValue;
                    decimal ExpireHrs = totalValue;
                    decimal ExtHrs = 0;
                    //decimal ExpireHrs = totalValue - ExtHrs;//三分之一失效
                    int i = 0;
                    foreach (var gr in plusDesc)
                    {
                        i++;
                        if (ExtHrsTmp > 0)
                        {
                            var hrs = gr.Sum(p => p.ABS.TOL_HOURS);
                            if (hrs >= ExtHrsTmp)
                            {
                                ExtHrs = ExtHrsTmp;
                                ExtHrsTmp = 0;
                            }
                            else
                            {
                                ExtHrs = hrs;
                                ExtHrsTmp -= hrs;
                            }
                            JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                            abs.A_NAME = "";
                            abs.BDATE = date_e.AddDays(1);//延休生效日期=服務截止日+1天
                            abs.BTIME = i.ToString("0000");
                            abs.EDATE = gr.Key;//延休失效日期
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
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

                        }
                    }
                    JBModule.Data.Linq.ABS abs1 = new JBModule.Data.Linq.ABS();
                    abs1.A_NAME = "";
                    abs1.BDATE = date_e;
                    abs1.BTIME = "";
                    abs1.EDATE = date_e;
                    abs1.ETIME = "";
                    abs1.H_CODE = ExpireCode;
                    abs1.KEY_DATE = DateTime.Now;
                    abs1.KEY_MAN = MainForm.USER_NAME;
                    abs1.NOBR = itm.Key;
                    abs1.NOTE = "";
                    abs1.NOTEDIT = false;
                    abs1.SERNO = "";
                    abs1.SYSCREATE = true;
                    abs1.TOL_DAY = 0;
                    abs1.TOL_HOURS = ExpireHrs;//全部失效
                    abs1.YYMM = "";
                    db.ABS.InsertOnSubmit(abs1);
                }
            }
            db.SubmitChanges();
        }
        void CalcOptionalLeaveExtend(string GetYearRest, string UseYearRest, string ExtCode, string ExpireCode)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = cbxDeptB.SelectedValue.ToString();
            dept_e = cbxDeptE.SelectedValue.ToString();
            jobl_b = cbxJoblB.SelectedValue.ToString();
            jobl_e = cbxJoblE.SelectedValue.ToString();
            DateTime date_b, date_e, date_t, date_expire;
            date_t = Convert.ToDateTime(txtEdate.Text);
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            date_expire = Convert.ToDateTime(txtExpireDate.Text);

            object[] ttscodes = new object[] { 1, 4, 6 };
            var sql = from r in db.BASETTS
                      join d in db.DEPT on r.DEPT equals d.D_NO
                      join f in db.JOBL on r.JOBL equals f.JOBL1
                      where ttscodes.Contains(r.TTSCODE)
                      && date_t >= r.ADATE && date_t <= r.DDATE
                      && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                      && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && f.JOBL_DISP.CompareTo(jobl_b) >= 0 && f.JOBL_DISP.CompareTo(jobl_e) <= 0
                      select r;

            if (rdb2.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "D" && !b.COUNT_MA select r;
            else if (rdb3.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where r.DI == "I" && !b.COUNT_MA select r;
            else if (rdb4.Checked) sql = from r in sql join b in db.BASE on r.NOBR equals b.NOBR where b.COUNT_MA select r;
            string hcode = "";
            string expire_hcode = "";
            //if (rdbHcode1.Checked)
            //{
            hcode = ExtCode;
            expire_hcode = ExpireCode;
            //}
            //else if (rdbHcode2.Checked)
            //{
            //    hcode = ext_year_hcode;
            //    expire_hcode = expire_ext_year_hcode;
            //}

            DeleteLeaveExtend(GetYearRest, UseYearRest, ExtCode, ExpireCode);

            var absSQLAll = from r in db.ABS
                            join b in db.HCODE on r.H_CODE equals b.H_CODE
                            join c in sql on r.NOBR equals c.NOBR
                            where r.BDATE >= date_b && r.BDATE <= date_e
                            && r.NOBR.CompareTo(nobr_b) >= 0 && r.NOBR.CompareTo(nobr_e) <= 0
                            && new string[] { GetYearRest, UseYearRest }.Contains(b.YEAR_REST)
                            orderby r.BDATE
                            group new { ABS = r, HCODE = b } by r.NOBR;
            foreach (var itm in absSQLAll)
            {
                var absSQL = itm;
                var plus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == GetYearRest select r;
                //if (rdbHcode2.Checked)
                //plus = from r in plus where r.HCODE.H_CODE == hcode select r;
                var ext = from a in absSQL where a.HCODE.H_CODE == ExtCode select a;//延休
                var minus = from r in absSQL where r.HCODE.YEAR_REST.Trim() == UseYearRest select r;

                var plusDesc = plus.GroupBy(p => p.ABS.EDATE).OrderByDescending(p => p.Key);


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
                    decimal ExtHrsTmp = totalValue;
                    decimal ExpireHrs = totalValue;
                    decimal ExtHrs = 0;
                    //decimal ExpireHrs = totalValue - ExtHrs;//三分之一失效
                    int i = 0;
                    foreach (var gr in plusDesc)
                    {
                        i++;
                        if (ExtHrsTmp > 0)
                        {
                            var hrs = gr.Sum(p => p.ABS.TOL_HOURS);
                            if (hrs >= ExtHrsTmp)
                            {
                                ExtHrs = ExtHrsTmp;
                                ExtHrsTmp = 0;
                            }
                            else
                            {
                                ExtHrs = hrs;
                                ExtHrsTmp -= hrs;
                            }
                            JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                            abs.A_NAME = "";
                            abs.BDATE = date_e.AddDays(1);//延休生效日期=服務截止日+1天
                            abs.BTIME = i.ToString("0000");
                            abs.EDATE = gr.Key;//延休失效日期
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
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

                        }
                    }
                    JBModule.Data.Linq.ABS abs1 = new JBModule.Data.Linq.ABS();
                    abs1.A_NAME = "";
                    abs1.BDATE = date_e;
                    abs1.BTIME = "";
                    abs1.EDATE = date_e;
                    abs1.ETIME = "";
                    abs1.H_CODE = ExpireCode;
                    abs1.KEY_DATE = DateTime.Now;
                    abs1.KEY_MAN = MainForm.USER_NAME;
                    abs1.NOBR = itm.Key;
                    abs1.NOTE = "";
                    abs1.NOTEDIT = false;
                    abs1.SERNO = "";
                    abs1.SYSCREATE = true;
                    abs1.TOL_DAY = 0;
                    abs1.TOL_HOURS = ExpireHrs;//全部失效
                    abs1.YYMM = "";
                    db.ABS.InsertOnSubmit(abs1);
                }
            }
            db.SubmitChanges();
        }

        void DeleteLeaveExtend(string GetYearRest, string UseYearRest, string ExtCode, string ExpireCode)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = cbxDeptB.SelectedValue.ToString();
            dept_e = cbxDeptE.SelectedValue.ToString();
            jobl_b = cbxJoblB.SelectedValue.ToString();
            jobl_e = cbxJoblE.SelectedValue.ToString();
            DateTime date_b, date_e, date_t, date_expire;
            date_t = Convert.ToDateTime(txtEdate.Text);
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            date_expire = date_e.AddYears(1);
            string hcode = "";
            string expire_hcode = "";
            hcode = ExtCode;
            expire_hcode = ExpireCode;

            string cmd = "DELETE FROM ABS WHERE SYSCREATE=1"
                        //+ " AND dbo.GetFilterByNobr(ABS.NOBR,{8},{9},{10})=1"
                        + " AND exists(select 1 from BASETTS x where x.NOBR = ABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({8},{9},{10})))"
                        + " AND BDATE BETWEEN {0} AND {1}"
                        + " AND H_CODE='" + hcode + "' "
                        + " AND NOBR IN (SELECT A.NOBR FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO JOIN JOBL C ON A.JOBL=C.JOBL"
                        + " WHERE A.TTSCODE IN('1','4','6')"
                        + " AND A.NOBR BETWEEN {2} AND {3}"
                        + " AND B.D_NO_DISP BETWEEN {4} AND {5}"
                        + " AND C.JOBL_DISP BETWEEN {6} AND {7}"
                        + " GROUP BY A.NOBR)";
            object[] parameters = new object[] { date_e.AddDays(1), date_expire, nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, parameters);//先刪延休

            cmd = "DELETE FROM ABS WHERE SYSCREATE=1"
                //+ " AND dbo.GetFilterByNobr(ABS.NOBR,{8},{9},{10})=1"
                + " AND exists(select 1 from BASETTS x where x.NOBR = ABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({8},{9},{10})))"
                + " AND BDATE BETWEEN {0} AND {1}"
                + " AND H_CODE='" + ExpireCode + "' "
                + " AND NOBR IN (SELECT A.NOBR FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO JOIN JOBL C ON A.JOBL=C.JOBL"
                + " WHERE A.TTSCODE IN('1','4','6')"
                + " AND A.NOBR BETWEEN {2} AND {3}"
                + " AND B.D_NO_DISP BETWEEN {4} AND {5}"
                + " AND C.JOBL_DISP BETWEEN {6} AND {7}"
                + " GROUP BY A.NOBR)";
            parameters = new object[] { date_e, date_e, nobr_b, nobr_e, dept_b, dept_e, jobl_b, jobl_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(cmd, parameters);//再刪失效

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要刪除延休及失效?請確認設定條件是否正確!!", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                DateTime t1, t2;
                t1 = DateTime.Now;
                string ExtCode = "", ExpireCode = "";

                if (rdbType1.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode1").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode1").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定特休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定特休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (rdbType2.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode2").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode2").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定補休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定補休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (rdbType3.Checked)
                {
                    ExtCode = AppConfig.GetConfig("ExtCode3").GetString();
                    ExpireCode = AppConfig.GetConfig("ExpireCode3").GetString();
                    if (ExtCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定彈休延休代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (ExpireCode.Trim().Length == 0)
                    {
                        MessageBox.Show("請先設定彈休失效代碼", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                DeleteLeaveExtend("5", "6", ExtCode, ExpireCode);
                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
