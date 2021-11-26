using JBTools.Extend;
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
    public partial class FRM2TA : Form
    {
        public FRM2TA()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog htypeSelection = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void FRM2TA_Load(object sender, EventArgs e)
        {
            htypeSelection.SetControl(button3, Repo.AttRepo.GetHcodeType(), "_HTYPE");
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            db = new JBModule.Data.Linq.HrDBDataContext();
            var empList = GetEmployeeList(htypeSelection.SelectedValues, Convert.ToDateTime(textBoxBeginDate.Text), Convert.ToDateTime(textBoxEndDate.Text));
            empSelection.SetControl(buttonEmp, Repo.EmpRepo.GetEmpData(empList, Convert.ToDateTime(textBoxEndDate.Text)), "員工編號");
        }

        List<string> GetEmployeeList(List<string> HcodeTypeList, DateTime DateBegin, DateTime DateEnd)
        {
            var data = from a in db.ABS
                       join b in db.HCODE on a.H_CODE equals b.H_CODE
                       //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                       where HcodeTypeList.Contains(b.HTYPE) && a.BDATE <= DateEnd && a.EDATE >= DateBegin
                       && (from bts in db.BASETTS
                           where bts.NOBR == a.NOBR
                           && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                           && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                           select 1).Any()
                       select a.NOBR;
            return data.Distinct().ToList();
        }
        List<AbsentEntitle> GetAbsentEntitles(List<string> EmployeeList, List<string> HcodeTypeList, DateTime DateBegin, DateTime DateEnd)
        {
            List<AbsentEntitle> data = new List<AbsentEntitle>();
            foreach (var item in EmployeeList.Split(1000))
            {
                var sql = from a in db.ABS
                           join b in db.HCODE on a.H_CODE equals b.H_CODE
                           //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                           where HcodeTypeList.Contains(b.HTYPE) && b.FLAG == "+"
                           && item.Contains(a.NOBR) //EmployeeList已作驗證
                           && a.BDATE <= DateEnd && a.EDATE >= DateBegin
                           select new AbsentEntitle
                           {
                               Guid = a.Guid,
                               Balance = a.Balance.GetValueOrDefault(0),
                               DateBegin = a.BDATE,
                               DateEnd = a.EDATE,
                               EmployeeId = a.NOBR,
                               Entitle = a.TOL_HOURS,
                               Hcode = a.H_CODE,
                               Taken = a.LeaveHours.GetValueOrDefault(0)
                           };
                data.AddRange(sql.ToList());
            }
            return data.ToList();
        }
        List<AbsentTaken> GetAbsentTakens(List<string> EmployeeList, List<string> HcodeTypeList, DateTime DateBegin, DateTime DateEnd)
        {
            List<AbsentTaken> data = new List<AbsentTaken>();
            foreach (var item in EmployeeList.Split(1000))
            {
                var sql = from a in db.ABS
                           join b in db.HCODE on a.H_CODE equals b.H_CODE
                           //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                           where HcodeTypeList.Contains(b.HTYPE) && b.FLAG == "-"
                           && item.Contains(a.NOBR) //EmployeeList已作驗證
                           && a.BDATE <= DateEnd && a.EDATE >= DateBegin
                           select new AbsentTaken
                           {
                               Guid = a.Guid,
                               EmployeeId = a.NOBR,
                               Hcode = a.H_CODE,
                               DateAbsent = a.BDATE,
                               Taken = a.TOL_HOURS
                           };
                data.AddRange(sql.ToList());
            }
            return data.ToList();
        }
        void RemoveAbsdAddByGuid(string guid)
        {
            db.ExecuteCommand("DELETE ABSD WHERE ABSADD='{0}'", guid);
        }
        void RemoveAbsdSubtractByGuid(string guid)
        {
            //restore balance
            string updatestr = string.Format("UPDATE ABS SET LeaveHours=LeaveHours-(SELECT USEHOUR FROM ABSD WHERE ABSD.ABSSUBTRACT='{0}' AND ABS.Guid=ABSD.ABSADD),Balance=Balance+(SELECT USEHOUR FROM ABSD WHERE ABSD.ABSSUBTRACT='{0}' AND ABS.Guid=ABSD.ABSADD) WHERE EXISTS(SELECT * FROM ABSD WHERE ABSD.ABSSUBTRACT='{0}' AND ABS.Guid=ABSD.ABSADD)", guid);
            var result1 = db.ExecuteCommand(updatestr);
            //remove absd
            string deletestr = string.Format("DELETE ABSD WHERE ABSSUBTRACT='{0}'", guid);
            var result2 = db.ExecuteCommand(deletestr);
        }
        void FixEntitleBalance(string guid)
        {
            string updatestr = string.Format("UPDATE ABS SET LeaveHours=ISNULL((SELECT SUM(USEHOUR) FROM ABSD WHERE ABSD.ABSADD=ABS.Guid),0) ,Balance=ABS.TOL_HOURS-ISNULL((SELECT SUM(USEHOUR) FROM ABSD WHERE ABSD.ABSADD=ABS.Guid),0) WHERE ABS.Guid='{0}'", guid);
            var result = db.ExecuteCommand(updatestr);
        }
        void FixNullGuid()
        {
            var result = db.ExecuteCommand("update ABS set Guid=NEWID() where Guid is null or Guid=''");
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            SetEnable(false);
            backgroundWorker1.RunWorkerAsync();
        }

        private void SetEnable(bool IsEnable)
        {
            groupBox1.Enabled = IsEnable;
            groupBox2.Enabled = IsEnable;
            buttonExit.Enabled = IsEnable;
            buttonRun.Enabled = IsEnable;
        }

        //public bool AutoABSD(string Nobr, string Hcode, DateTime dDate, string guid, decimal AbsHours, bool OverWrite = false)
        //{
        //    var hcodeCheck = from a in db.HCODE where a.CHE && a.HTYPE.Trim().Length > 0 && a.H_CODE == Hcode select 1;

        //    if (guid.Trim().Length == 0) return false;
        //    //取出已存在的ABSD
        //    var absdSQL = from a in db.ABSD where a.ABSSUBTRACT == guid select a;
        //    if (!OverWrite)
        //        if (absdSQL.Any()) return true;//有資料就跳出
        //    //取出與ABSD有關的ABS(得)
        //    var abstList = (from a in db.ABS where (from b in absdSQL where b.ABSADD == a.Guid select 1).Any() select a).ToList();
        //    foreach (var it in absdSQL)//先清掉舊時數
        //    {
        //        var abst = from a in abstList where a.Guid == it.ABSADD select a;
        //        foreach (var itm in abst)
        //        {
        //            itm.LeaveHours -= it.USEHOUR;
        //            itm.Balance = itm.TOL_HOURS - itm.LeaveHours;
        //        }
        //    }
        //    db.ABSD.DeleteAllOnSubmit(absdSQL);

        //    if (hcodeCheck.Any())
        //    {
        //        //取出有效得假
        //        var sql = from a in db.ABS
        //                  join b in db.HCODE on a.H_CODE equals b.H_CODE
        //                  where b.FLAG == "+"
        //                  && a.NOBR == Nobr
        //                  && dDate >= a.BDATE && dDate <= a.EDATE
        //                  && (from c in db.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any()
        //                  orderby a.EDATE, b.SORT
        //                  select a;
        //        decimal Hrs = AbsHours;
        //        foreach (var it in sql)
        //        {
        //            //var absdOfEntitle = from a in absdSQL where a.ABSADD == it.Guid select a;
        //            //decimal current = 0;
        //            //if (absdOfEntitle.Any()) current = absdOfEntitle.Sum(pp => pp.USEHOUR);
        //            //if (Hrs <= 0) break;
        //            //it.LeaveHours -= current;//扣掉原本的
        //            decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
        //            decimal Balance = it.TOL_HOURS - useHrs;

        //            if (Balance > 0 && Hrs > 0)//還有剩餘
        //            {
        //                decimal absHrs = Hrs;
        //                if (Hrs > Balance)//請假大於剩餘
        //                    absHrs = Balance;
        //                if (absHrs == 0) continue;
        //                JBModule.Data.Linq.ABSD absd = new JBModule.Data.Linq.ABSD();
        //                absd.ABSADD = it.Guid;
        //                absd.ABSSUBTRACT = guid;
        //                absd.KEY_DATE = DateTime.Now;
        //                absd.KEY_MAN = MainForm.USER_NAME;
        //                absd.USEHOUR = absHrs;
        //                db.ABSD.InsertOnSubmit(absd);
        //                Hrs -= absHrs;
        //                it.LeaveHours += absHrs;
        //            }
        //            it.Balance = it.TOL_HOURS - it.LeaveHours;
        //        }
        //        if (Hrs > 0)
        //            return false;//時數不足
        //    }
        //    //myDB.ExecuteCommand("DELETE ABSD WHERE ABSSUBTRACT={0}", guid);
        //    db.SubmitChanges();
        //    return true;
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //toolStrpProgressbar.Value = 0;
            backgroundWorker1.ReportProgress(0, "開始執行");
            db = new JBModule.Data.Linq.HrDBDataContext();
            int total = empSelection.SelectedValues.Count;
            int current = 0;
            #region 移除異常沖假
            if (checkBoxInvalid.Checked)
            {
                backgroundWorker1.ReportProgress(current * 100 / total, "正在執行" + "移除異常沖假");
                RemoveInvalidAbsd();
            }
            #endregion
            #region 修正空白編號
            if (checkBoxNullGuid.Checked)
            {
                backgroundWorker1.ReportProgress(current * 100 / total, "正在執行" + "修正空白編號");
                FixNullGuid();
            }
            #endregion

            foreach (var emp in empSelection.SelectedValues)
            {
                current++;

                if (checkBoxFixBalance.Checked)
                {
                    backgroundWorker1.ReportProgress(current * 100 / total, "正在執行" + "修正剩餘時數" + "：" + emp);
                    var entitles = GetAbsentEntitles(new List<string> { emp }, htypeSelection.SelectedValues, Convert.ToDateTime(textBoxBeginDate.Text), Convert.ToDateTime(textBoxEndDate.Text));
                    foreach (var entitle in entitles)
                    {
                        FixEntitleBalance(entitle.Guid);
                    }
                }
                if (checkBoxReset.Checked)
                {
                    backgroundWorker1.ReportProgress(current * 100 / total, "正在執行" + "重新沖假" + "：" + emp);
                    var takens = GetAbsentTakens(new List<string> { emp }, htypeSelection.SelectedValues, Convert.ToDateTime(textBoxBeginDate.Text), Convert.ToDateTime(textBoxEndDate.Text));
                    //if (db.Connection.State != ConnectionState.Open)
                    //    db.Connection.Open();
                    //var trans = db.Connection.BeginTransaction();
                    //db.Transaction = trans;
                    try
                    {
                        //using (trans)
                        //{
                        foreach (var abs in takens)
                        {
                            RemoveAbsdSubtractByGuid(abs.Guid);
                        }
                        foreach (var abs in takens)
                        {
                            var result = FRM28.AutoABSD(abs.EmployeeId, abs.Hcode, abs.DateAbsent, abs.Guid, abs.Taken, false);
                        }
                        //    trans.Commit();
                        //}
                    }
                    catch (Exception ex)
                    {
                        JBModule.Message.TextLog.WriteLog(ex);
                    }
                }
            }

        }

        private void RemoveInvalidAbsd()
        {
            var result1 = db.ExecuteCommand(@"DELETE ABSD WHERE NOT EXISTS(SELECT 1 FROM ABS WHERE EXISTS(SELECT 1 FROM HCODE WHERE HCODE.H_CODE=ABS.H_CODE AND HCODE.FLAG='+') AND GUID=ABSD.ABSADD)");
            var result2 = db.ExecuteCommand(@"DELETE ABSD WHERE NOT EXISTS(SELECT 1 FROM ABS WHERE EXISTS(SELECT 1 FROM HCODE WHERE HCODE.H_CODE=ABS.H_CODE AND HCODE.FLAG in ( '-' , 'X' )) AND GUID=ABSD.ABSSUBTRACT)");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatus.Text = e.UserState.ToString();
            toolStrpProgressbar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetEnable(true);
            MessageBox.Show("完成");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
