using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBTools.Extend;

namespace JBHR.Att
{
    public partial class FRM2_DiversionGroup_ADD : JBControls.JBForm
    {
        public FRM2_DiversionGroup_ADD()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.DiversionGroup instance = new JBModule.Data.Linq.DiversionGroup();
        string topic = "";
        JBModule.Data.Linq.DiversionGroup oldinstance = new JBModule.Data.Linq.DiversionGroup();
        public int Autokey = -1;//-1 = ADD , other = EDIT

        private void FRM2_DiversionGroup_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }

        private void EmpInitial()
        {
            SystemFunction.SetComboBoxItems(cbxDiversionGroupType, CodeFunction.GetMtCode("DiversionGroupType"), false, true, true, true);
            if (Autokey == -1)
            {
                SetEmpList();
                dtpBDate.Text = DateTime.Today.ToString();
                dtpEDate.Text = "9999/12/31";
                cbxDiversionGroupType.Focus();
            }
            else
            {
                instance = db.DiversionGroup.SingleOrDefault(p => p.AutoKey == Autokey);
                var emp = (from b in db.BASE
                           join bts in db.BASETTS on b.NOBR equals bts.NOBR
                           join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                           where bts.NOBR == instance.EmployeeId
                           orderby bts.ADATE descending
                           select new
                           {
                               員工編號 = b.NOBR,
                               姓名 = b.NAME_C,
                               職等 = jl.JOB_NAME,
                               編制部門 = bts.DEPT1.D_NAME
                           }).First();
                mdEmp.SelectedValues.Add(emp.員工編號);
                btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                dtpBDate.Text = instance.BeginDate.ToString();
                dtpEDate.Text = instance.EndDate.ToString();
                txtGuid.Text = instance.Guid.ToString();
                cbxDiversionGroupType.SelectedValue = instance.DiversionGroupType;
                topic = emp.編制部門 + '-' + btnEmp.Text;
                this.Text = topic;
                dtpBDate.Enabled = true;
                cbxDiversionGroupType.Enabled = true;
                oldinstance = instance.Clone();
            }
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            SetEmpList();
        }

        void SetEmpList()
        {
            if (Autokey == -1)
            {
                string MealGroup = cbxDiversionGroupType.SelectedValue.ToString();
                //DateTime ndate = DateTime.Today;//Convert.ToDateTime(dtpADATE.Text);
                DateTime bdate = DateTime.Parse(dtpBDate.Text);
                DateTime edate = DateTime.Parse(dtpEDate.Text);
                var sql = from b in db.BASE
                          join bts in db.BASETTS on b.NOBR equals bts.NOBR
                          join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                          join mt in db.MTCODE on bts.TTSCODE equals mt.CODE
                          join ad in (db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR)) on b.NOBR equals ad.Key
                          where edate >= bts.ADATE && edate <= bts.DDATE.Value
                          && mt.CATEGORY == "TTSCODE"
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          select new
                          {
                              員工編號 = b.NOBR,
                              姓名 = b.NAME_C,
                              異動狀態 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? "在職" : mt.NAME,
                              異動日期 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? null : bts.OUDT != null ? bts.OUDT : bts.STDT != null ? bts.STDT : null,
                              職等 = jl.JOB_NAME,
                              編制部門 = bts.DEPT1.D_NAME
                          };
                mdEmp.SetControl(btnEmp, sql.CopyToDataTable(), "員工編號");
                mdEmp.SelectedValues.Clear();
                btnEmp.Text = "請選擇需設定的人員";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> EmployeeList = mdEmp.SelectedValues;
            DateTime BDate = DateTime.Parse(dtpBDate.Text);
            DateTime EDate = DateTime.Parse(dtpEDate.Text);
            string DiversionGroupType = cbxDiversionGroupType.SelectedValue.ToString();
            bool ReplaceSW = true;
            if (Autokey == -1)
            {
                List<JBModule.Data.Linq.DiversionGroup> instanceRp = new List<JBModule.Data.Linq.DiversionGroup>();
                foreach (var item in EmployeeList.Split(1000))
                    instanceRp.AddRange(db.DiversionGroup.Where(p => item.Contains(p.EmployeeId) && p.BeginDate == BDate));
                if (instanceRp.Any())
                {
                    if (MessageBox.Show("已存在同生效日資料，Yes = 覆蓋, No = 略過.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                        db.DiversionGroup.DeleteAllOnSubmit(instanceRp);
                        db.SubmitChanges();
                    }
                    else
                    {
                        ReplaceSW = false;
                    }
                }

                object[] PARMS = new object[] { Autokey, EmployeeList, BDate, EDate, DiversionGroupType, ReplaceSW };
                BW.RunWorkerAsync(PARMS);
                this.tableLayoutPanel1.Enabled = false;
            }
            else
            {
                string msg = "";
                try
                {
                    if (oldinstance.BeginDate != instance.BeginDate)
                    {
                        JBModule.Data.Linq.DiversionGroup instanceRp = new JBModule.Data.Linq.DiversionGroup();
                        instanceRp = db.DiversionGroup.Where(p => p.EmployeeId == instance.EmployeeId && p.BeginDate == instance.BeginDate).FirstOrDefault();
                        if (instanceRp != null)
                        {
                            if (MessageBox.Show("已存在同生效日資料，Yes = 覆蓋, No = 略過.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                                db.DiversionGroup.DeleteOnSubmit(instanceRp);
                                db.SubmitChanges();
                            }
                            else
                            {
                                ReplaceSW = false;
                            }
                        }
                    }
                    if (ReplaceSW)
                    {
                        string WorkLocation = db.BASETTS.Where(p => p.NOBR == instance.EmployeeId && EDate >= p.ADATE && EDate <= p.DDATE).First().WORKCD;
                        instance.DiversionGroupType = DiversionGroupType;
                        instance.WorkLocation = WorkLocation;
                        instance.BeginDate = BDate;
                        instance.EndDate = EDate;
                        instance.KeyDate = DateTime.Now;
                        instance.KeyMan = MainForm.USER_NAME;
                        JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey);
                        db.SubmitChanges();
                        CorrectionEndDate(EmployeeList);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "存檔錯誤.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msg = ex.Message;
                    JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AutoKey);
                }
            }
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            int Autokey = int.Parse(parameters[0].ToString());
            List<string> EmployeeList = parameters[1] as List<string>;
            DateTime BDate = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime Edate = (parameters[3] as DateTime?).GetValueOrDefault(DateTime.Today);
            string DiversionGroupType = parameters[4] as string;
            bool ReplaceSW = (parameters[5] as Boolean?).GetValueOrDefault(true);
            string msg = "";
            try
            {
                List<JBModule.Data.Linq.BASETTS> basetts = new List<JBModule.Data.Linq.BASETTS>();
                foreach (var nobrList in EmployeeList.Split(1000))
                {
                    var sql = dbBW.BASETTS.Where(p => nobrList.Contains(p.NOBR)).ToList();
                    basetts.AddRange(sql);
                }

                List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                int total = EmployeeList.Count;
                int count = 0;
                string keyman = MainForm.USER_NAME;
                foreach (var Employee in EmployeeList)
                {
                    DateTime keydate = DateTime.Now;
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 75), "正在產生" + Employee + "分流組別資料");
                    string WorkLocation = basetts.Where(p => p.NOBR == Employee && Edate >= p.ADATE && Edate <= p.DDATE).First().WORKCD;
                    instance = new JBModule.Data.Linq.DiversionGroup();
                    JBModule.Data.Linq.DiversionGroup instanceRp = new JBModule.Data.Linq.DiversionGroup();
                    instanceRp = dbBW.DiversionGroup.Where(p => p.EmployeeId == Employee && p.BeginDate == BDate).FirstOrDefault();
                    if (instanceRp != null)
                    {
                        if (ReplaceSW)
                        {
                            instanceRp.DiversionGroupType = DiversionGroupType;
                            instanceRp.WorkLocation = WorkLocation;
                            instanceRp.BeginDate = BDate;
                            instanceRp.EndDate = Edate;
                            instanceRp.KeyDate = keydate;
                            instanceRp.KeyMan = keyman;
                            JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey);
                        }
                    }
                    else
                    {
                        instance.EmployeeId = Employee;
                        instance.DiversionGroupType = DiversionGroupType;
                        instance.WorkLocation = WorkLocation;
                        instance.BeginDate = BDate;
                        instance.EndDate = Edate;
                        instance.Guid = Guid.NewGuid();
                        instance.KeyDate = keydate;
                        instance.KeyMan = keyman;
                        JBModule.Message.DbLog.WriteLog("Insert", instance, this.Name, instance.AutoKey);
                        dbBW.DiversionGroup.InsertOnSubmit(instance);
                    }
                    count++;
                    dbBW.SubmitChanges();
                }

                BW.ReportProgress(75, "正在校正分流組別失效日期");
                CorrectionEndDate(EmployeeList);

                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = "完成.";
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AutoKey);
            }
        }

        private void CorrectionEndDate(List<string> EmployeeList)
        {
            JBModule.Data.Linq.HrDBDataContext dbCD = new JBModule.Data.Linq.HrDBDataContext();
            foreach (var item in EmployeeList.Split(1000))
            {
                foreach (var employee in item)
                {
                    var sql = dbCD.DiversionGroup.Where(p =>  p.EmployeeId == employee).OrderByDescending(p => p.BeginDate).ToList();
                    DateTime TempDate = sql.First().EndDate;
                    foreach (var DiversionGroup in sql)
                    {
                        //if (TempDate < DiversionGroup.EndDate)
                        DiversionGroup.EndDate = TempDate;
                        TempDate = DiversionGroup.BeginDate.AddDays(-1);
                    }
                    dbCD.SubmitChanges(); 
                }
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
            this.tableLayoutPanel1.Enabled = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            //if (dtpBDate.Value > dtpEDate.Value)
            //    dtpEDate.Value = dtpBDate.Value;
            SetEmpList();
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            //if (dtpBDate.Value > dtpEDate.Value)
            //    dtpBDate.Value = dtpEDate.Value;
            SetEmpList();
        }
    }
}
