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
    public partial class FRM2TGN : JBControls.JBForm
    {
        public FRM2TGN()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBModule.Data.ApplicationConfigSettings acg = null;
        private void FRM2TGN_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxHCode, CodeFunction.GetHcode(true));
            dtpBDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpEDate.Value = new DateTime(DateTime.Today.Year, 12, 31);
            SetEmpData();
        }

        private void SetEmpData()
        {
            empSelection.Source = new DataTable();
            empSelection.Source = Repo.EmpRepo.GetEmpAllWithDept(dtpDDate.Value, true);
            empSelection.SelectedValues = new List<string>();
            foreach (DataRow r in empSelection.Source.Rows)
            {
                empSelection.SelectedValues.Add(r[0].ToString().Trim());
            }
            btnEmp.Text = string.Format("選取({0})", empSelection.SelectedValues.Count());
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

        private void btnEmp_Click(object sender, EventArgs e)
        {
            if (empSelection.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                btnEmp.Tag = empSelection.SelectedValues;
                btnEmp.Text = string.Format("選取({0})", empSelection.SelectedValues.Count());
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            var emplist = empSelection.SelectedValues;
            var bdate = dtpBDate.Value;
            var edate = dtpEDate.Value;
            var ddate = dtpDDate.Value;
            var hcode = cbxHCode.SelectedValue.ToString();
            object[] parameters = new object[] { emplist, bdate, edate, ddate, hcode };

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var hcoeData = from a in db.HCODE where a.H_CODE == hcode select a;
            if (!hcoeData.Any())
            {
                MessageBox.Show("找不到假別代碼的設定" + cbxHCode.SelectedValue.ToString());
                return;
            }
            JBModule.Data.Linq.HCODE hcodeRow = hcoeData.First();
            string tip = string.Format("是否要產生生效日:{0} 失效日:{1} 的 {2} {3}", bdate.ToShortDateString(), edate.ToShortDateString(), hcodeRow.H_NAME, chkOverride.Checked ? ",並覆蓋已存在的資料?" : ".");
            if (MessageBox.Show(tip, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                return;

            BW.RunWorkerAsync(parameters);
            this.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBTools.Stopwatch sw = new JBTools.Stopwatch();
                sw.Start();

                object[] parameters = e.Argument as object[];
                List<string> emplistAll = parameters[0] as List<string>;
                DateTime bdate = (parameters[1] as DateTime?).GetValueOrDefault(DateTime.Today);
                DateTime edate = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
                DateTime ddate = (parameters[3] as DateTime?).GetValueOrDefault(DateTime.Today);
                string hcode = parameters[4] as string;

                JBModule.Data.Linq.HCODE hcodeRow = (from a in db.HCODE where a.H_CODE == hcode select a).First();
                int total = emplistAll.Count();
                int count = 0;
                foreach (var emplist in emplistAll.Split(1000))//emplistAll已篩選過權限
                {
                    var absSQL = (from a in db.ABS
                                  //join b in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                                  where a.H_CODE == hcode
                                  && emplist.Contains(a.NOBR)
                                  && a.BDATE == bdate// && a.EDATE == edate
                                  //&& a.SYSCREATE//系統產生
                                  select a).ToList();

                    foreach (var emp in emplist)
                    {
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), string.Format("正在產生{0}的{1}.", emp, hcodeRow.H_NAME));
                        var absSQLofNobr = from a in absSQL where a.NOBR == emp select a;
                        if (absSQLofNobr.Any())
                        {
                            if (chkOverride.Checked)
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
                            abs.NOBR = emp;
                            abs.A_NAME = "";
                            abs.BDATE = bdate;
                            abs.EDATE = edate;
                            abs.BTIME = "0000" + DateTime.Now.ToOADate().ToString();
                            abs.ETIME = "0000" + DateTime.Now.ToOADate().ToString();
                            abs.Guid = Guid.NewGuid().ToString();
                            abs.H_CODE = hcode;
                            abs.nocalc = false;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = Guid.NewGuid().ToString();
                            abs.SYSCREATE = true;
                            abs.SYSCREATE1 = false;
                            abs.TOL_DAY = 0;
                            abs.YYMM = bdate.Year.ToString();
                            abs.TOL_HOURS = hcodeRow.MAX_NUM;
                            abs.LeaveHours = 0;
                            abs.Balance = abs.TOL_HOURS - abs.LeaveHours;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            db.ABS.InsertOnSubmit(abs);
                        }
                        count++;
                    }
                    db.SubmitChanges();
                }
                sw.Stop();
                //sw.ShowMessage();
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = string.Format( "{0}.", sw.Message);
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
            }
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Enabled = true;
            //this.DialogResult = DialogResult.OK;
        }

        private void dtpDDate_CloseUp(object sender, EventArgs e)
        {
            SetEmpData();
        }
    }
}
