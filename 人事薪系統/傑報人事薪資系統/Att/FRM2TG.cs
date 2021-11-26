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
    public partial class FRM2TG : JBControls.JBForm
    {
        public FRM2TG()
        {
            InitializeComponent();
        }

        private void FRM2TG_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            textBoxYear.Text = DateTime.Today.Year.ToString();
            ptxNobrB.Text = this.mainDS.V_BASE.First().NOBR;
            ptxNobrE.Text = this.mainDS.V_BASE.Last().NOBR;
            SystemFunction.SetComboBoxItems(comboBoxHcode, CodeFunction.GetHcode(true), true, true);
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBTools.Stopwatch sw = new JBTools.Stopwatch();
            sw.Start();
            DateTime ddate = Convert.ToDateTime(textBoxDDATE.Text);
            string hcode = comboBoxHcode.SelectedValue.ToString();
            var hcoeData = from a in db.HCODE where a.H_CODE == hcode select a;
            if (!hcoeData.Any())
            {
                MessageBox.Show("找不到假別代碼的設定" + comboBoxHcode.SelectedValue.ToString());
                return;
            }
            JBModule.Data.Linq.HCODE hcodeRow = hcoeData.First();
            int year = Convert.ToInt32(textBoxYear.Text);
            string msg = string.Format("是否要產生{0}年的{1}{2}", year, hcodeRow.H_NAME, checkBoxOverride.Checked ? "並覆蓋已存在的資料" : "");
            if (MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                return;
            var sql = from a in db.BASETTS
                      //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                      where ddate >= a.ADATE && ddate <= a.DDATE.Value
                      && a.NOBR.CompareTo(ptxNobrB.Text) >= 0 && a.NOBR.CompareTo(ptxNobrE.Text) <= 0
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new { a.NOBR, a.INDT };
            var absSQL = (from a in db.ABS
                          //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                          where a.H_CODE == hcode
                          && a.NOBR.CompareTo(ptxNobrB.Text) >= 0 && a.NOBR.CompareTo(ptxNobrE.Text) <= 0
                          && a.BDATE.Year == year
                          && (from bts in db.BASETTS
                              where bts.NOBR == a.NOBR
                              && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                              && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                              select 1).Any()
                          //&& a.SYSCREATE//系統產生
                          select a).ToList();

            foreach (var it in sql)
            {
                var absSQLofNobr = from a in absSQL where a.NOBR == it.NOBR select a;
                if (absSQLofNobr.Any())
                {
                    if (checkBoxOverride.Checked)
                    {
                        var absRow = absSQLofNobr.First();
                        absRow.TOL_HOURS = hcodeRow.MAX_NUM;
                        absRow.Balance = absRow.TOL_HOURS - absRow.LeaveHours;
                        absRow.KEY_DATE = DateTime.Now;
                        absRow.KEY_MAN = MainForm.USER_NAME;
                    }
                }
                else
                {
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = new DateTime(year, 1, 1);
                    abs.EDATE = new DateTime(year, 12, 31);
                    abs.BTIME = "";
                    abs.ETIME = "";
                    abs.Guid = Guid.NewGuid().ToString();
                    abs.H_CODE = hcode;
                    abs.nocalc = false;
                    abs.NOTE = "";
                    abs.NOTEDIT = false;
                    abs.SERNO = Guid.NewGuid().ToString();
                    abs.SYSCREATE = true;
                    abs.SYSCREATE1 = false;
                    abs.TOL_DAY = 0;
                    abs.YYMM = year.ToString();
                    abs.TOL_HOURS = hcodeRow.MAX_NUM;
                    abs.LeaveHours = 0;
                    abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    db.ABS.InsertOnSubmit(abs);
                }
            }
            db.SubmitChanges();
            sw.Stop();
            sw.ShowMessage();
        }
        public static void GenerateAbsEntitle(List<string> EmployeeList, DateTime Adate, DateTime Ddate, List<string> HtypeList)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            DateTime ddate = Adate;
            var sqlHtype = from a in db.HcodeType where HtypeList.Contains(a.HTYPE) select a;
            foreach (var tt in sqlHtype)
            {
                string hcode = tt.GetCode;
                var hcoeData = from a in db.HCODE where a.H_CODE == hcode select a;
                if (!hcoeData.Any())
                {
                    MessageBox.Show(string.Format("'{0}'的請假類別代碼,找不到得假代碼的設定", tt.TYPE_NAME));
                    continue;
                }
                JBModule.Data.Linq.HCODE hcodeRow = hcoeData.First();
                int year = Adate.Year;
                //string msg = string.Format("是否要產生{0}年的{1}{2}", year, hcodeRow.H_NAME, checkBoxOverride.Checked ? "並覆蓋已存在的資料" : "");
                //if (MessageBox.Show(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                //    return;
                var sql = from a in db.BASETTS
                          //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                          where ddate >= a.ADATE && ddate <= a.DDATE.Value
                          && EmployeeList.Contains(a.NOBR)
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                          select new { a.NOBR, a.INDT };
                var absSQL = (from a in db.ABS
                              //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                              where a.H_CODE == hcode
                              && EmployeeList.Contains(a.NOBR)
                              && a.YYMM == year.ToString()
                              && a.SYSCREATE//系統產生
                              && (from bts in db.BASETTS
                                  where bts.NOBR == a.NOBR
                                  && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                  && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                  select 1).Any()
                              select a).ToList();

                foreach (var it in sql)
                {
                    var absSQLofNobr = from a in absSQL where a.NOBR == it.NOBR select a;
                    if (absSQLofNobr.Any())
                    {
                        if (true)
                        {
                            var absRow = absSQLofNobr.First();
                            absRow.TOL_HOURS = hcodeRow.MAX_NUM;
                            absRow.Balance = absRow.TOL_HOURS - absRow.LeaveHours;
                            absRow.KEY_DATE = DateTime.Now;
                            absRow.KEY_MAN = MainForm.USER_NAME;
                        }
                    }
                    else
                    {
                        JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                        abs.NOBR = it.NOBR;
                        abs.A_NAME = "";
                        abs.BDATE = new DateTime(Adate.Year, 1, 1);
                        abs.EDATE = new DateTime(Adate.Year, 12, 31);
                        abs.BTIME = "";
                        abs.ETIME = "";
                        abs.Guid = Guid.NewGuid().ToString();
                        abs.H_CODE = hcode;
                        abs.nocalc = false;
                        abs.NOTE = "";
                        abs.NOTEDIT = false;
                        abs.SERNO = Guid.NewGuid().ToString();
                        abs.SYSCREATE = true;
                        abs.SYSCREATE1 = false;
                        abs.TOL_DAY = 0;
                        abs.YYMM = year.ToString();
                        abs.TOL_HOURS = hcodeRow.MAX_NUM;
                        abs.LeaveHours = 0;
                        abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
                        abs.KEY_DATE = DateTime.Now;
                        abs.KEY_MAN = MainForm.USER_NAME;
                        db.ABS.InsertOnSubmit(abs);
                    }
                }
                db.SubmitChanges();
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
