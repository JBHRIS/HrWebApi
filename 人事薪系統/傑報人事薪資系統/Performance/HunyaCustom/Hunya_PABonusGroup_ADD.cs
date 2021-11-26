using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBTools.Extend;
using JBHR.Performance.HunyaCustom.Repository;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PABonusGroup_ADD : JBControls.JBForm
    {
        public Hunya_PABonusGroup_ADD()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.Hunya_PABonusGroup instanceNew = new JBModule.Data.Linq.Hunya_PABonusGroup();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        public string EmployeeID = string.Empty;
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_PABonusGroup_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }

        private void EmpInitial()
        {
            CYYMMFC.AddControl(txtPAYYMM_B, true);
            CYYMMFC.AddControl(txtPAYYMM_E, true);
            if (CodeFunction.GetHunya_PAGroupCode().Count == 0)
                btnSave.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxPAGroupCode, CodeFunction.GetHunya_PAGroupCode(), false, true, true, true);

            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
                txtPAYYMM_B.Text = sd.YYMM;
                txtPAYYMM_E.Text = "999912";
                SetEmpList();
                cbxPAGroupCode.Focus();
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
                    instanceNew = db.Hunya_PABonusGroup.SingleOrDefault(p => p.AK == Autokey);
                    var emp = emplist.First(p => p.員工編號 == instanceNew.EmployeeID);
                    mdEmp.SelectedValues.Add(emp.員工編號);
                    btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                    txtPAYYMM_B.Text = instanceNew.YYMM_B.ToString();
                    txtPAYYMM_E.Text = instanceNew.YYMM_E.ToString();
                    txtGuid.Text = instanceNew.GID.ToString();
                    cbxPAGroupCode.SelectedValue = instanceNew.PAGroupCode;
                    topic = emp.編制部門 + '-' + btnEmp.Text;
                }
                else
                {
                    var emp = emplist.First(p => p.員工編號 == EmployeeID);
                    btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                    Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
                    txtPAYYMM_B.Text = sd.YYMM;
                    txtPAYYMM_E.Text = "999912";
                    cbxPAGroupCode.SelectedIndex = 0;
                    topic = emp.編制部門 + '-' + btnEmp.Text;
                }
                this.Text = topic;
            }
        }

        void SetEmpList()
        {
            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(txtPAYYMM_B.Text);
                DateTime BDate = sd.FirstDayOfSalary;
                sd = new JBHR.Sal.Core.SalaryDate(txtPAYYMM_E.Text);
                DateTime EDate = sd.LastDayOfSalary;
                string YYMM_B = txtPAYYMM_B.Text;
                string YYMM_E = txtPAYYMM_E.Text;
                var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= BDate && p.ADATE <= EDate).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
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
                                   from a in db.Hunya_PABonusGroup
                                   join b in db.Hunya_PAGroupCode on a.PAGroupCode equals b.PAGroupCode
                                   where item.Contains(a.EmployeeID)
                                   && a.YYMM_B.CompareTo(YYMM_E) <= 0 && a.YYMM_E.CompareTo(YYMM_B) >= 0
                                   select new
                                   {
                                       員工編號 = a.EmployeeID,
                                       考核年月起 = a.YYMM_B,
                                       考核年月迄 = a.YYMM_E,
                                       獎金群組 = b.PAGroupCode_Disp + "-" + b.PAGroupCode_Name
                                   }
                              ) on b.NOBR equals h.員工編號 into g
                              from result in g.DefaultIfEmpty()
                              where item.Contains(b.NOBR)
                              && EDate >= bts.ADATE && EDate <= bts.DDATE.Value
                              && mt.CATEGORY == "TTSCODE"
                              && mt1.CATEGORY == "SEX"
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                              select new
                              {
                                  員工編號 = b.NOBR,
                                  員工姓名 = b.NAME_C,
                                  獎金群組 = result.獎金群組,
                                  考核年月起 = result.考核年月起,
                                  考核年月迄 = result.考核年月迄,
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
            string YYMM_B = txtPAYYMM_B.Text;
            string YYMM_E = txtPAYYMM_E.Text;
            string PAGroupCode = cbxPAGroupCode.SelectedValue.ToString();
            bool ReplaceSW = true;
            if (Autokey == -1 && EmployeeID == string.Empty)
            {
                List<JBModule.Data.Linq.Hunya_PABonusGroup> instanceRp = new List<JBModule.Data.Linq.Hunya_PABonusGroup>();
                foreach (var item in EmployeeList.Split(1000))
                    instanceRp.AddRange(db.Hunya_PABonusGroup.Where(p => item.Contains(p.EmployeeID) && p.YYMM_B.CompareTo(YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0));
                if (instanceRp.Any())
                {
                    if (MessageBox.Show("指定區間已有設定資料，Yes = 覆蓋重疊區間, No = 取消並顯示區間.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                    else
                    {
                        ReplaceSW = false;
                        ShowRepeatData(instanceRp);
                    }
                }
                if (ReplaceSW)
                {
                    object[] PARMS = new object[] { EmployeeList, YYMM_B, YYMM_E, PAGroupCode , instanceRp };
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
                        instanceNew = new JBModule.Data.Linq.Hunya_PABonusGroup
                        {
                            EmployeeID = EmployeeID,
                            YYMM_B = YYMM_B,
                            YYMM_E = YYMM_E,
                            PAGroupCode = PAGroupCode,
                            GID = Guid.NewGuid(),
                            KeyMan = MainForm.USER_NAME,
                            KeyDate = DateTime.Now,
                        };
                    }
                    else
                    {
                        instanceNew.YYMM_B = YYMM_B;
                        instanceNew.YYMM_E = YYMM_E;
                        instanceNew.PAGroupCode = PAGroupCode;
                        instanceNew.KeyMan = MainForm.USER_NAME;
                        instanceNew.KeyDate = DateTime.Now;
                    }

                    List<JBModule.Data.Linq.Hunya_PABonusGroup> instanceRp = new List<JBModule.Data.Linq.Hunya_PABonusGroup>();
                    instanceRp.AddRange(db.Hunya_PABonusGroup.Where(p => p.EmployeeID == instanceNew.EmployeeID && p.YYMM_B.CompareTo(p.YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0 && p.AK != Autokey).ToList());
                    if (instanceRp.Any())
                    {
                        if (MessageBox.Show("指定區間已有設定資料，Yes = 覆蓋重疊區間, No = 取消並顯示區間.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                            Hunya_PABonusGroupRepo.DataSaveRule(instanceRp, instanceNew, db);
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

                        if (Autokey == -1 && instanceNew.YYMM_B.CompareTo(instanceNew.YYMM_E) <= 0)
                            db.Hunya_PABonusGroup.InsertOnSubmit(instanceNew);

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

        private void ShowRepeatData(List<JBModule.Data.Linq.Hunya_PABonusGroup> instanceRp)
        {
            JBHR.Sal.PreviewForm frm = new JBHR.Sal.PreviewForm();
            var sql = from ir in instanceRp
                      join hpgc in db.Hunya_PAGroupCode.ToList() on ir.PAGroupCode equals hpgc.PAGroupCode
                      select new
                      {
                          員工編號 = ir.EmployeeID,
                          考核年月起 = ir.YYMM_B,
                          考核年月迄 = ir.YYMM_E,
                          獎金群組 = hpgc.PAGroupCode_Disp + "-" + hpgc.PAGroupCode_Name,
                      };
            frm.DataTable = sql.CopyToDataTable();
            frm.Form_Title = "影響的區間";
            frm.Show();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> EmployeeList = parameters[0] as List<string>;
            string YYMM_B = parameters[1] as string;
            string YYMM_E = parameters[2] as string;
            string PAGroupCode = parameters[3] as string;
            //List<JBModule.Data.Linq.Hunya_PABonusGroup> RepeatList = new List<JBModule.Data.Linq.Hunya_PABonusGroup>();
            //foreach (var item in EmployeeList.Split(1000))
            //    RepeatList.AddRange(db.Hunya_PABonusGroup.Where(p => item.Contains(p.EmployeeID) && p.YYMM_B.CompareTo(YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0));
            List<JBModule.Data.Linq.Hunya_PABonusGroup> RepeatList = parameters[4] as List<JBModule.Data.Linq.Hunya_PABonusGroup>;
            string msg = "";
            try
            {
                int total = EmployeeList.Count;
                int count = 0;
                string keyman = MainForm.USER_NAME;
                foreach (var Employee in EmployeeList)
                {
                    DateTime keydate = DateTime.Now;
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生" + Employee + "績效獎金群組資料");
                    JBModule.Data.Linq.Hunya_PABonusGroup instanceBW = new JBModule.Data.Linq.Hunya_PABonusGroup()
                    {
                        EmployeeID = Employee,
                        PAGroupCode = PAGroupCode,
                        YYMM_B = YYMM_B,
                        YYMM_E = YYMM_E,
                        GID = Guid.NewGuid(),
                        KeyDate = keydate,
                        KeyMan = keyman,
                    };
                    List<JBModule.Data.Linq.Hunya_PABonusGroup> instanceRp = RepeatList.Where(p => p.EmployeeID == Employee).ToList();
                    if (instanceRp.Any())
                    {
                        JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                        Hunya_PABonusGroupRepo.DataSaveRule(instanceRp, instanceBW, dbBW);
                    }
                    JBModule.Message.DbLog.WriteLog("Insert", instanceBW, this.Name, instanceBW.AK);
                    dbBW.Hunya_PABonusGroup.InsertOnSubmit(instanceBW);
                    dbBW.SubmitChanges();
                    count++;
                }
                //BW.ReportProgress(75, "正在校正績效獎金群組失效日期");
                //CorrectionEndDate(EmployeeList);

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

        private void txtPAYYMM_B_Leave(object sender, EventArgs e)
        {
            SetEmpList();
        }

        private void txtPAYYMM_E_Leave(object sender, EventArgs e)
        {
            SetEmpList();
        }
    }
}
