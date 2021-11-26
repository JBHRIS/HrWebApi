using JBHR.Att.Attendance;
using JBHR.Att.Attendance.Dto;
using JBHR.BLL.Att;
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
    public partial class FRM2AN_ADD : JBControls.JBForm
    {
        public FRM2AN_ADD()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.ROTECHG instance = new JBModule.Data.Linq.ROTECHG();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        private void FRM2AN_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            SystemFunction.SetComboBoxItems(cbxROTE, CodeFunction.GetRote(), false, true, true);
            EmpInitial();
        }

        private void EmpInitial()
        {
            if (Autokey == -1)
            {
                dtpBDate.Value = DateTime.Today;
                dtpEDate.Value = DateTime.Today;
                //SetEmpList();
            }
            else
            {
                instance = db.ROTECHG.SingleOrDefault(p => p.AUTOKEY == Autokey);
                var emp = (from a in db.BASE
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           where b.NOBR == instance.NOBR
                           orderby b.ADATE descending
                           select new { 员工编号 = a.NOBR, 姓名 = a.NAME_C, 职等 = b.JOBL, 编制部门 = b.DEPT1.D_NAME }).First();
                btnEmp.Text = emp.员工编号 + "-" + emp.姓名;
                dtpBDate.Value = instance.ADATE;
                dtpEDate.Value = instance.ADATE;
                rOTECHGBindingSource.DataSource = instance;
                topic = emp.编制部门 + '-' + btnEmp.Text;
                this.Text = topic;

                dtpBDate.Enabled = false;
                dtpEDate.Enabled = false;
                chkNoTran.Enabled = false;
            }
        }

        void SetEmpList()
        {
            if (Autokey == -1)
            {
                DateTime ndate = DateTime.Today;//Convert.ToDateTime(dtpADATE.Text);
                DateTime bdate = dtpBDate.Value;
                DateTime edate = dtpEDate.Value;
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join ad in (db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p=>p.NOBR)) on a.NOBR equals ad.Key
                          //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                          where ndate >= b.ADATE && ndate <= b.DDATE.Value
                          && new string[] { "1", "4", "6" }.Contains(b.TTSCODE)
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new { 員工編號 = a.NOBR, 姓名 = a.NAME_C, 职等 = b.JOBL, 编制部门 = b.DEPT1.D_NAME };
                mdEmp.SetControl(btnEmp, sql.CopyToDataTable(), "員工編號");
                mdEmp.SelectedValues.Clear();
                btnEmp.Text = "請選擇需調班的人員";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<string> nobrs = mdEmp.SelectedValues;
            DateTime BDate = dtpBDate.Value.Date;
            DateTime Edate = dtpEDate.Value.Date;
            string rote = cbxROTE.SelectedValue.ToString();
            string keyman = MainForm.USER_NAME;
            DateTime keydate = DateTime.Now;
            //bool ReplaceSW = false;
            if (Autokey == -1)
            {
                object[] PARMS = new object[] { nobrs, BDate, Edate, rote, keyman, keydate };
                BW.RunWorkerAsync(PARMS);
                tableLayoutPanel1.Enabled = false;
            }
            else
            {
                List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                string Nobr = instance.NOBR;
                DateTime DT1 = BDate;
                DateTime DT2 = Edate;
                string RT = rote;

                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(Nobr, DT1.AddDays(-7), DT1, DT2.AddDays(7));

                var RoteCHG = db.ROTECHG.Where(p => p.NOBR == Nobr && (p.ADATE >= DT1.AddDays(-7) || p.ADATE <= DT2.AddDays(7))).ToList();
                foreach (var item in RoteCHG)
                {
                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).First().ScheduleType = item.ROTE;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(item.ADATE, RT));
                }

                for (DateTime dd = DT1; dd <= DT2; dd = dd.AddDays(1))
                {
                    if (chkNoTran.Checked)
                    {//假日就跳過
                        var roteSql = (from a in db.ATTEND where a.NOBR == Nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                        if (roteSql != null && holi_codeList.Contains(rote)) continue;
                    }

                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).First().ScheduleType = RT;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(dd, RT));
                }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                var result = WSCG.Check();
                if (result.workScheduleIssues.Count > 0)
                {
                    JBControls.ShowList showList = new JBControls.ShowList(result.workScheduleIssues.Select(p => new { 異常日期 = p.IssueDate, 異常敘述 = p.ErrorMessage }).CopyToDataTable());
                    showList.Text = "異常";
                    showList.StartPosition = FormStartPosition.CenterScreen;
                    showList.Show();
                }
                else
                {
                    //instance.ROTE = rote;不用更新，因為綁定控制項
                    instance.KEY_DATE = keydate;
                    instance.KEY_MAN = keyman;
                    nobrs.Add(instance.NOBR);

                    db.SubmitChanges();
                    AttendanceGenerator ag = new AttendanceGenerator(nobrs, BDate, Edate);
                    ag.Generate();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnEmp_Enter(object sender, EventArgs e)
        {
            SetEmpList();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            var param = e.Argument as object[];
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> nobrs = (List<string>)param[0];
            DateTime BDate = Convert.ToDateTime(param[1].ToString());
            DateTime Edate = Convert.ToDateTime(param[2].ToString());
            string rote = param[3].ToString();
            string keyman = param[4].ToString();
            DateTime keydate = Convert.ToDateTime(param[5].ToString());

            List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
            JBControls.MultiSelectionDialog rpmdEmp = new JBControls.MultiSelectionDialog();
            var rpSql = from a in db.ROTECHG
                        join b in db.BASE on a.NOBR equals b.NOBR
                        join r in db.ROTE on a.ROTE equals r.ROTE1
                        where nobrs.Contains(a.NOBR)
                        && a.ADATE >= BDate && a.ADATE <= Edate
                        select new { 員工編號 = a.NOBR, 姓名 = b.NAME_C, 調班日期 = a.ADATE, 調班班別 = r.ROTE_DISP, 班別名稱 = r.ROTENAME, 索引鍵 = string.Format("{0}-{1}", a.NOBR, a.ADATE) };
            List<string> Rplist = new List<string>();
            if (rpSql.Any())
            {
                Rplist = rpSql.Select(p => p.索引鍵).ToList<string>();
                foreach (var item in rpSql)
                    rpmdEmp.SelectedValues.Add(item.索引鍵);
                if (MessageBox.Show("發現有重複調班資料，是否要覆蓋?", "資料重複.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //ReplaceSW = true;
                    rpmdEmp.Source = rpSql.CopyToDataTable();
                    rpmdEmp.ValueField = "索引鍵";
                    rpmdEmp.Text = "請選擇要覆蓋的資料";
                    rpmdEmp.ShowDialog();
                    foreach (var item in rpmdEmp.SelectedValues)
                        Rplist.Remove(item);
                }
                //else
                //    ReplaceSW = false;
            }

            WorkScheduleCheckResult WSCR = new WorkScheduleCheckResult();
            WSCR.workScheduleIssues = new List<WorkScheduleIssueDto>();
            int count = 0;
            foreach (var nobr in nobrs)
            {
                count++;
                BW.ReportProgress(count * 100 / nobrs.Count, "正在產生員工" + nobr + "- 調班資料");
                var rotechgList = (from a in db.ROTECHG where a.NOBR == nobr && a.ADATE >= BDate && a.ADATE <= Edate select a).ToList();

                string Nobr = nobr;
                DateTime DT1 = BDate;
                DateTime DT2 = Edate;
                string RT = rote;

                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(Nobr, DT1.AddDays(-7), DT1, DT2.AddDays(7));

                var RoteCHG = db.ROTECHG.Where(p => p.NOBR == Nobr && (p.ADATE >= DT1.AddDays(-7) || p.ADATE <= DT2.AddDays(7))).ToList();
                foreach (var item in RoteCHG)
                {
                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).First().ScheduleType = item.ROTE;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(item.ADATE, RT));
                }

                for (DateTime dd = DT1; dd <= DT2; dd = dd.AddDays(1))
                {
                    if (chkNoTran.Checked)
                    {//假日就跳過
                        var roteSql = (from a in db.ATTEND where a.NOBR == Nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                        if (roteSql != null && holi_codeList.Contains(rote)) continue;
                    }

                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).First().ScheduleType = RT;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(dd, RT));
                }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                var result = WSCG.Check();
                if (result.workScheduleIssues.Count > 0)
                {
                    foreach (var item in result.workScheduleIssues)
                    {
                        WorkScheduleIssueDto issueDto = item;
                        issueDto.ErrorMessage = string.Format("員編:{0} {1}", Nobr, item.ErrorMessage);
                        WSCR.workScheduleIssues.Add(issueDto); 
                    }
                }
                else
                {
                    for (DateTime dd = BDate; dd <= Edate; dd = dd.AddDays(1))
                    {
                        if (chkNoTran.Checked)
                        {//假日就跳過
                            var roteSql = (from a in db.ATTEND where a.NOBR == nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                            if (roteSql != null && holi_codeList.Contains(roteSql)) continue;
                        }

                        if (Rplist.Count > 0 && Rplist.Contains(string.Format("{0}-{1}", nobr, dd)))
                            continue;

                        instance = new JBModule.Data.Linq.ROTECHG();
                        JBModule.Data.Linq.ROTECHG instanceRp = new JBModule.Data.Linq.ROTECHG();
                        instanceRp = db.ROTECHG.Where(p => p.NOBR == nobr && p.ADATE == dd).FirstOrDefault();
                        if (instanceRp != null)
                        {
                            //var R = db.ROTE.Where(p => p.ROTE1 == instanceRp.ROTE).FirstOrDefault();
                            //instanceRp.CODE = R != null ? string.Format("前筆調班班別:{0}-{1}", R.ROTE_DISP, R.ROTENAME) : "";
                            instanceRp.ROTE = rote;
                            instanceRp.KEY_DATE = keydate;
                            instanceRp.KEY_MAN = keyman;
                        }
                        else
                        {
                            instance.NOBR = nobr;
                            instance.ROTE = rote;
                            instance.ADATE = dd;
                            instance.CODE = "";
                            instance.KEY_DATE = keydate;
                            instance.KEY_MAN = keyman;
                            db.ROTECHG.InsertOnSubmit(instance);
                        }
                    }
                    db.SubmitChanges();
                    AttendanceGenerator ag = new AttendanceGenerator(nobrs, BDate, Edate);
                    ag.Generate();
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
            }
            e.Result = WSCR;

            //if (WSCR.workScheduleIssues.Count > 0)
            //{
            //    JBControls.ShowList showList = new JBControls.ShowList(WSCR.workScheduleIssues.Select(p => new { 異常日期 = p.IssueDate, 異常敘述 = p.ErrorMessage }).CopyToDataTable());
            //    showList.Text = "異常";
            //    showList.StartPosition = FormStartPosition.CenterScreen;
            //    showList.Show();
            //}
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                WorkScheduleCheckResult WSCR = (WorkScheduleCheckResult)e.Result;
                if (WSCR.workScheduleIssues.Count > 0)
                {
                    JBControls.ShowList showList = new JBControls.ShowList(WSCR.workScheduleIssues.Select(p => new { 異常日期 = p.IssueDate, 異常敘述 = p.ErrorMessage }).CopyToDataTable());
                    showList.Text = "異常 - 違規資料將不會寫入";
                    showList.StartPosition = FormStartPosition.CenterScreen;
                    showList.Show();
                }
            }
            else
            {
                MessageBox.Show("新增調班資料完成.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            tableLayoutPanel1.Enabled = true;
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpEDate.Value = dtpBDate.Value;
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpBDate.Value = dtpEDate.Value;
        }
    }
}
