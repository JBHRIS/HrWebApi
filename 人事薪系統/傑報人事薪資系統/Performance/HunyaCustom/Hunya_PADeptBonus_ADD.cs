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
    public partial class Hunya_PADeptBonus_ADD : JBControls.JBForm
    {
        public Hunya_PADeptBonus_ADD()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdPADept = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.Hunya_PADeptBonus instanceNew = new JBModule.Data.Linq.Hunya_PADeptBonus();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        public string D_NO = string.Empty;
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_PADeptBonus_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }
        private void EmpInitial()
        {
            CYYMMFC.AddControl(txtPAYYMM_B, true);
            CYYMMFC.AddControl(txtPAYYMM_E, true);
            if (Autokey == -1)
            {
                txtPABasicBonus.Text = "0";
                Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
                txtPAYYMM_B.Text = sd.YYMM;
                txtPAYYMM_E.Text = sd.YYMM;
                SetPADeptList();
            }
            else
            {
                if (Autokey != -1)
                {
                    instanceNew = db.Hunya_PADeptBonus.SingleOrDefault(p => p.AK == Autokey);
                    var dept = db.DEPT.First(p => p.D_NO == instanceNew.PADept);
                    mdPADept.SelectedValues.Add(dept.D_NO);
                    btnPADept.Text = dept.D_NO_DISP + '-' + dept.D_NAME;
                    txtPAYYMM_B.Text = instanceNew.YYMM_B.ToString();
                    txtPAYYMM_E.Text = instanceNew.YYMM_E.ToString();
                    txtGuid.Text = instanceNew.GID.ToString();
                    txtPABasicBonus.Text = instanceNew.PABasicBonus.ToString();
                    topic = dept.D_NO_DISP + '-' + dept.D_NAME;
                }
                else
                {
                    var dept = db.DEPT.First(p => p.D_NO == D_NO);
                    btnPADept.Text = dept.D_NO_DISP + '-' + dept.D_NAME;
                    txtPABasicBonus.Text = "0";
                    Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
                    txtPAYYMM_B.Text = sd.YYMM;
                    txtPAYYMM_E.Text = "999912";
                    topic = dept.D_NO_DISP + '-' + dept.D_NAME;
                }
                this.Text = topic;
            }
        }

        void SetPADeptList()
        {
            if (Autokey == -1 && D_NO == string.Empty)
            {
                Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(txtPAYYMM_B.Text);
                DateTime BDate = sd.FirstDayOfSalary;
                sd = new JBHR.Sal.Core.SalaryDate(txtPAYYMM_E.Text);
                DateTime EDate = sd.LastDayOfSalary;
                string PAYYMM_B = txtPAYYMM_B.Text;
                string PAYYMM_E = txtPAYYMM_E.Text;
                var dept = from a in (from a in db.DEPT
                                      where a.ADATE <= EDate && a.DDATE >= BDate
                                      select new
                                      {
                                          a.D_NO,
                                          編制部門 = a.D_NO_DISP + "-" + a.D_NAME,
                                          成立日期 = a.ADATE,
                                          撤銷日期 = a.DDATE,
                                          部門群組 = a.DEPT_GROUP,
                                      }).ToList()
                           join b in (from a in db.Hunya_PADeptBonus
                                      where a.YYMM_B.CompareTo(PAYYMM_E) <= 0 && a.YYMM_E.CompareTo(PAYYMM_B) >= 0
                                      select new
                                      {
                                          a.PADept,
                                          基本獎金 = JBModule.Data.CDecryp.Number(a.PABasicBonus),
                                          發放年月起 = a.YYMM_B,
                                          發放年月迄 = a.YYMM_E,
                                      }).ToList() on a.D_NO equals b.PADept into b1
                           from b11 in b1.DefaultIfEmpty()
                           select new
                           {
                               _PADept = a.D_NO,
                               a.編制部門,
                               基本獎金 = b11 != null ? b11.基本獎金.ToString() : string.Empty,
                               發放年月起 = b11 != null ? b11.發放年月起 : string.Empty,
                               發放年月迄 = b11 != null ? b11.發放年月迄 : string.Empty,
                               //b11.基本獎金.vlaue.ToString(),
                               //b11.發放年月起,
                               //b11.發放年月迄,
                               a.成立日期,
                               a.撤銷日期,
                               a.部門群組,
                           };

                mdPADept.SetControl(btnPADept, dept.OrderBy(p => p.編制部門).CopyToDataTable(), "_PADept");
                mdPADept.SelectedValues.Clear();
                btnPADept.Text = "請選擇需計算的部門";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal PABasicBonus = JBModule.Data.CEncrypt.Number(decimal.Parse(txtPABasicBonus.Text));
            string YYMM_B = txtPAYYMM_B.Text;
            string YYMM_E = txtPAYYMM_E.Text;
            List<string> DeptList = mdPADept.SelectedValues.Distinct().ToList();
            bool ReplaceSW = true;

            if (Autokey == -1 && D_NO == string.Empty)
            {
                List<JBModule.Data.Linq.Hunya_PADeptBonus> instanceRp = new List<JBModule.Data.Linq.Hunya_PADeptBonus>();
                foreach (var item in DeptList.Split(1000))
                    instanceRp.AddRange(db.Hunya_PADeptBonus.Where(p => item.Contains(p.PADept) && p.YYMM_B.CompareTo(YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0));
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
                    object[] PARMS = new object[] { DeptList, YYMM_B, YYMM_E, PABasicBonus, instanceRp };
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
                        instanceNew = new JBModule.Data.Linq.Hunya_PADeptBonus
                        {
                            PADept = D_NO,
                            YYMM_B = YYMM_B,
                            YYMM_E = YYMM_E,
                            PABasicBonus = PABasicBonus,
                            GID = Guid.NewGuid(),
                            KeyMan = MainForm.USER_NAME,
                            KeyDate = DateTime.Now,
                        };
                    }
                    else
                    {
                        instanceNew.YYMM_B = YYMM_B;
                        instanceNew.YYMM_E = YYMM_E;
                        instanceNew.PABasicBonus = PABasicBonus;
                        instanceNew.KeyMan = MainForm.USER_NAME;
                        instanceNew.KeyDate = DateTime.Now;
                    }

                    List<JBModule.Data.Linq.Hunya_PADeptBonus> instanceRp = new List<JBModule.Data.Linq.Hunya_PADeptBonus>();
                    instanceRp.AddRange(db.Hunya_PADeptBonus.Where(p => p.PADept == instanceNew.PADept && p.YYMM_B.CompareTo(YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0 && p.AK != Autokey).ToList());
                    if (instanceRp.Any())
                    {
                        if (MessageBox.Show("指定區間已有設定資料，Yes = 覆蓋重疊區間, No = 取消並顯示區間.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                            Repository.Hunya_PADeptBonusRepo.DataSaveRule(instanceRp, instanceNew,db);
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
                            db.Hunya_PADeptBonus.InsertOnSubmit(instanceNew);

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
        private void ShowRepeatData(List<JBModule.Data.Linq.Hunya_PADeptBonus> instanceRp)
        {
            JBHR.Sal.PreviewForm frm = new JBHR.Sal.PreviewForm();
            var sql = from ir in instanceRp
                      join d in db.DEPT.ToList() on ir.PADept equals d.D_NO
                      orderby d.D_NO_DISP, ir.YYMM_B
                      select new
                      {
                          部門代碼 = d.D_NO_DISP + '-' + d.D_NAME,
                          考核年月起 = ir.YYMM_B,
                          考核年月訖 = ir.YYMM_E,
                          基本獎金 = JBModule.Data.CDecryp.Number(ir.PABasicBonus),
                      };
            frm.DataTable = sql.CopyToDataTable();
            frm.Form_Title = "影響的區間";
            frm.Show();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> DeptList = parameters[0] as List<string>;
            string YYMM_B = parameters[1] as string;
            string YYMM_E = parameters[2] as string;
            decimal PABasicBonus = decimal.Parse(parameters[3].ToString());
            //List<JBModule.Data.Linq.Hunya_PADeptBonus> RepeatList = new List<JBModule.Data.Linq.Hunya_PADeptBonus>();
            //RepeatList.AddRange(db.Hunya_PADeptBonus.Where(p => p.PADept == instanceNew.PADept && p.YYMM_B.CompareTo(YYMM_E) <= 0 && p.YYMM_E.CompareTo(YYMM_B) >= 0 && p.AK != Autokey).ToList());
            List<JBModule.Data.Linq.Hunya_PADeptBonus> RepeatList = parameters[4] as List<JBModule.Data.Linq.Hunya_PADeptBonus>;
            string msg = "";
            try
            {
                int total = DeptList.Count;
                int count = 0;
                string keyman = MainForm.USER_NAME;
                foreach (var Dept in DeptList)
                {
                    DateTime keydate = DateTime.Now;
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生" + Dept + "部門績效獎金資料");
                    JBModule.Data.Linq.Hunya_PADeptBonus instanceBW = new JBModule.Data.Linq.Hunya_PADeptBonus()
                    {
                        PADept = Dept,
                        YYMM_B = YYMM_B,
                        YYMM_E = YYMM_E,
                        PABasicBonus = PABasicBonus,
                        GID = Guid.NewGuid(),
                        KeyDate = keydate,
                        KeyMan = keyman,
                    };
                    List<JBModule.Data.Linq.Hunya_PADeptBonus> instanceRp = RepeatList.Where(p => p.PADept == Dept).ToList();
                    if (instanceRp.Any())
                    {
                        JBModule.Message.DbLog.WriteLog("OverLapUpdate", instanceRp, this.Name, -1);
                        Repository.Hunya_PADeptBonusRepo.DataSaveRule(instanceRp, instanceBW,dbBW);
                    }
                    JBModule.Message.DbLog.WriteLog("Insert", instanceBW, this.Name, instanceBW.AK);
                    dbBW.Hunya_PADeptBonus.InsertOnSubmit(instanceBW);
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
            SetPADeptList();
        }

        private void txtPAYYMM_E_Leave(object sender, EventArgs e)
        {
            SetPADeptList();
        }
    }
}
