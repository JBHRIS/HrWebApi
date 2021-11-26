using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PAPersonalAssessment_ADD : JBControls.JBForm
    {
        public Hunya_PAPersonalAssessment_ADD()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.Hunya_PAPersonalAssessment instanceNew = new JBModule.Data.Linq.Hunya_PAPersonalAssessment();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        public string EmployeeID = string.Empty;
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_PAPersonalAssessment_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }
        private void EmpInitial()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (CodeFunction.GetHunya_PALevelCode().Count == 0)
                btnSave.Enabled = false;
            CYYMMFC.AddControl(txtPAPAYYMM, true);
            SystemFunction.SetComboBoxItems(cbxPALevelCode, CodeFunction.GetHunya_PALevelCode(), false, true, true, true);
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                txtPAPAYYMM.Text = sd.YYMM;
                //SetEmpList();
                cbxPALevelCode.Focus();
            }
            else
            {
                var emplist = from b in db.BASE
                              join bts in db.BASETTS on b.NOBR equals bts.NOBR
                              join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                              join jb in db.JOB on bts.JOB equals jb.JOB1
                              orderby bts.ADATE descending
                              select new
                              {
                                  員工編號 = b.NOBR,
                                  姓名 = b.NAME_C,
                                  性別 = b.SEX,
                                  職稱 = jb.JOB_NAME,
                                  職等 = jl.JOB_NAME,
                                  編制部門 = bts.DEPT1.D_NAME
                              };
                if (Autokey != -1)
                {
                    instanceNew = db.Hunya_PAPersonalAssessment.SingleOrDefault(p => p.AK == Autokey);
                    var emp = emplist.First(p => p.員工編號 == instanceNew.EmployeeID);
                    mdEmp.SelectedValues.Add(emp.員工編號);
                    btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                    txtPAPAYYMM.Text = instanceNew.YYMM.ToString();
                    txtGuid.Text = instanceNew.GID.ToString();
                    cbxPALevelCode.SelectedValue = instanceNew.PALevelCode;
                    topic = emp.編制部門 + '-' + btnEmp.Text;
                }
                else
                {
                    var emp = emplist.First(p => p.員工編號 == EmployeeID);
                    btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                    txtPAPAYYMM.Text = sd.YYMM;
                    cbxPALevelCode.SelectedIndex = 0;
                    topic = emp.編制部門 + '-' + btnEmp.Text;
                }
                this.Text = topic;
            }
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            //SetEmpList();
        }

        void SetEmpList()
        {
            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                string YYMM = txtPAPAYYMM.Text;
                Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(YYMM);
                DateTime bdate = sd.FirstDayOfAttend;
                DateTime edate = sd.LastDayOfAttend;
                var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
                DataTable dt = new DataTable();
                var TTSCODE = new string[] { "1", "4", "6" };
                foreach (var item in AttendByNobr.Split(1000))
                {
                    var sql = from b in db.BASE
                              join bts in db.BASETTS on b.NOBR equals bts.NOBR
                              join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                              join mt in db.MTCODE on bts.TTSCODE equals mt.CODE
                              join mt1 in db.MTCODE on b.SEX equals mt1.CODE
                              join h in (
                                    from a in db.Hunya_PAPersonalAssessment
                                    join b in db.Hunya_PALevelCode on a.PALevelCode equals b.PALevelCode
                                    where a.YYMM == YYMM
                                    select new
                                    {
                                        員工編號 = a.EmployeeID,
                                        考核年月 = a.YYMM,
                                        考核等級 =b.PALevelCode_Name
                                    }
                              ) on b.NOBR equals h.員工編號 into g
                              from result in g.DefaultIfEmpty()
                              where item.Contains(b.NOBR)
                              && edate >= bts.ADATE && edate <= bts.DDATE.Value
                              && mt.CATEGORY == "TTSCODE"
                              && mt1.CATEGORY == "SEX"
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                              select new
                              {
                                  員工編號 = b.NOBR,
                                  員工姓名 = b.NAME_C,
                                  考核年月 = result.考核年月,
                                  考核等級 = result.考核等級,
                                  異動狀態 = TTSCODE.Contains(mt.CODE) ? "在職" : mt.NAME,
                                  異動日期 = TTSCODE.Contains(mt.CODE) ? null : bts.OUDT != null ? bts.OUDT : bts.STDT != null ? bts.STDT : null,
                                  性別 = mt1.NAME,
                                  職稱 = bts.JOB1.JOB_DISP + "-" + bts.JOB1.JOB_NAME,
                                  職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                                  編制部門 = bts.DEPT1.D_NO_DISP + "-" + bts.DEPT1.D_NAME,
                              };
                    dt.Merge(sql.ToList().CopyToDataTable());
                }
                mdEmp.SetControl(btnEmp, dt, "員工編號");
                mdEmp.SelectedValues.Clear();
                btnEmp.Text = "請選擇需設定的人員";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> EmployeeList = mdEmp.SelectedValues.Distinct().ToList();
            string YYMM = txtPAPAYYMM.Text;
            string PALevelCode = cbxPALevelCode.SelectedValue.ToString();
            bool ReplaceSW = true;
            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> instanceRp = new List<JBModule.Data.Linq.Hunya_PAPersonalAssessment>();
                foreach (var item in EmployeeList.Split(1000))
                    instanceRp.AddRange(db.Hunya_PAPersonalAssessment.Where(p => item.Contains(p.EmployeeID) && p.YYMM == YYMM));
                if (instanceRp.Any())
                {
                    if (MessageBox.Show("指定年月已有考核資料，Yes = 覆蓋重複資料, No = 取消並顯示重複.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                    else
                    {
                        ReplaceSW = false;
                        ShowRepeatData(instanceRp);
                    }
                }
                if (ReplaceSW)
                {
                    object[] PARMS = new object[] { EmployeeList, YYMM, PALevelCode, instanceRp };
                    BW.RunWorkerAsync(PARMS);
                    this.tableLayoutPanel1.Enabled = false;
                }
            }
            else
            {
                string msg = "";
                try
                {
                    if (Autokey == -1)
                    {
                        instanceNew = new JBModule.Data.Linq.Hunya_PAPersonalAssessment
                        {
                            EmployeeID = EmployeeID,
                            YYMM = YYMM,
                            PALevelCode = PALevelCode,
                            GID = Guid.NewGuid(),
                            KeyMan = MainForm.USER_NAME,
                            KeyDate = DateTime.Now,
                        };
                    }
                    else
                    {
                        instanceNew.YYMM = YYMM;
                        instanceNew.PALevelCode = PALevelCode;
                        instanceNew.KeyMan = MainForm.USER_NAME;
                        instanceNew.KeyDate = DateTime.Now;
                    }
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> instanceRp = new List<JBModule.Data.Linq.Hunya_PAPersonalAssessment>();
                    instanceRp.AddRange(db.Hunya_PAPersonalAssessment.Where(p => p.EmployeeID == instanceNew.EmployeeID && p.YYMM == YYMM && p.AK != Autokey).ToList());
                    if (instanceRp.Any())
                    {
                        if (MessageBox.Show("指定年月已有考核資料，Yes = 覆蓋重複資料, No = 取消並顯示重複.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                            Repository.Hunya_PAPersonalAssessmentRepo.DataSaveRule(instanceRp, instanceNew, db);
                        }
                        else
                        {
                            ReplaceSW = false;
                            ShowRepeatData(instanceRp);
                        }
                    }
                    if (ReplaceSW)
                    {
                        instanceNew.KeyMan = MainForm.USER_NAME;
                        instanceNew.KeyDate = DateTime.Now;

                        if (Autokey == -1)
                            db.Hunya_PAPersonalAssessment.InsertOnSubmit(instanceNew);

                        db.SubmitChanges();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "存檔錯誤.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msg = ex.Message;
                    JBModule.Message.DbLog.WriteLog(msg, instanceNew, this.Name, instanceNew.AK);
                }
            }
        }

        private void ShowRepeatData(List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> instanceRp)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBHR.Sal.PreviewForm frm = new JBHR.Sal.PreviewForm();
            var sql = from ir in instanceRp
                      join hplc in db.Hunya_PALevelCode.ToList() on ir.PALevelCode equals hplc.PALevelCode
                      select new
                      {
                          員工編號 = ir.EmployeeID,
                          考核年月 = ir.YYMM,
                          考核等級 = hplc.PALevelCode_DISP + "-" + hplc.PALevelCode_Name,
                      };
            frm.DataTable = sql.CopyToDataTable();
            frm.Form_Title = "重複的資料";
            frm.Show();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> EmployeeList = parameters[0] as List<string>;
            string yymm = parameters[1] as string;
            string PALevelCode = parameters[2] as string;
            //List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> RepeatList = new List<JBModule.Data.Linq.Hunya_PAPersonalAssessment>();
            //foreach (var item in EmployeeList.Split(1000))
            //    RepeatList.AddRange(dbBW.Hunya_PAPersonalAssessment.Where(p => item.Contains(p.EmployeeID) && p.YYMM == yymm));
            List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> RepeatList = parameters[3] as List<JBModule.Data.Linq.Hunya_PAPersonalAssessment>;
            string msg = "";
            try
            {
                List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                int total = EmployeeList.Count;
                int count = 0;
                string keyman = MainForm.USER_NAME;
                foreach (var Employee in EmployeeList)
                {
                    DateTime keydate = DateTime.Now;
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生" + Employee + "個人考核資料");
                    JBModule.Data.Linq.Hunya_PAPersonalAssessment instanceBW = new JBModule.Data.Linq.Hunya_PAPersonalAssessment()
                    {
                        EmployeeID = Employee,
                        YYMM = yymm,
                        PALevelCode = PALevelCode,
                        GID = Guid.NewGuid(),
                        KeyDate = keydate,
                        KeyMan = keyman,
                    };
                    List<JBModule.Data.Linq.Hunya_PAPersonalAssessment> instanceRp = RepeatList.Where(p => p.EmployeeID == Employee).ToList();
                    if (instanceRp.Any())
                    {
                        JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                        Repository.Hunya_PAPersonalAssessmentRepo.DataSaveRule(instanceRp, instanceBW, dbBW);
                    }
                    JBModule.Message.DbLog.WriteLog("Insert", instanceBW, this.Name, instanceBW.AK);
                    dbBW.Hunya_PAPersonalAssessment.InsertOnSubmit(instanceBW);
                    dbBW.SubmitChanges();
                    count++;
                }
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = "完成.";
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, instanceNew, this.Name, instanceNew.AK);
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

        private void txtPAPAYYMM_Leave(object sender, EventArgs e)
        {
            SetEmpList();
        }
    }
}
